using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace EditFont
{
    public partial class Main : Form
    {
        const int ROM_SIZE = 2048;
        const int CHARS = ROM_SIZE / 8;
        const int TABLE_SCALE = 4;
        const int EDIT_SCALE = 24;

        private string[] fileName;
        private byte[] fontRomData, editData;
        private Bitmap bmpOrgTable, bmpViewTable, bmpViewEdit, bmpOrgEdit;
        private int fontRomData_head = -1;
        private int lastX, lastY;

        public Main()
        {
            InitializeComponent();

            bmpOrgEdit = new Bitmap(8, 8);
            bmpViewEdit = new Bitmap(8 * EDIT_SCALE, 8 * EDIT_SCALE);
            bmpOrgTable = new Bitmap(8 * 16 * TABLE_SCALE, 8 * 16 * TABLE_SCALE);
            editData = new byte[8];
        }


        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            var info = new FileInfo(fileName[0]);
            if (info.Length != ROM_SIZE || fileName.Length != 1)
            {
                System.Media.SystemSounds.Beep.Play();
                return;
            }

            try
            {
                fontRomData = System.IO.File.ReadAllBytes(fileName[0]);
            }
            catch (Exception ex)
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show(ex.Message);
                return;
            }
            SetBmpOrgTable();
            bmpViewTable = new Bitmap(bmpOrgTable);
            this.PicFontTable.Image = bmpViewTable;

            fontRomData_head = -1;
            ClearEditData();
        }


        /// <summary>
        /// フォント一覧を表示するためのBMP作成
        /// </summary>
        private void SetBmpOrgTable()
        {
            int index = 0;

            for (int yy = 0; yy < (int)(CHARS / 16); ++yy)
            {
                for (int xx = 0; xx < 16; ++xx)
                {
                    for (int y = 0; y < 8; ++y)
                    {
                        for (int x = 0; x < 8; ++x)
                        {
                            var b = fontRomData[index];
                            int j = b >> (7 - x);
                            j &= 1;

                            Color c = j == 1 ? Color.White : Color.Black;
                            using (Graphics g = Graphics.FromImage(bmpOrgTable))
                            {
                                g.FillRectangle(
                                    new SolidBrush(c),
                                    xx * 8 * TABLE_SCALE + x * TABLE_SCALE,
                                    yy * 8 * TABLE_SCALE + y * TABLE_SCALE,
                                    TABLE_SCALE,
                                    TABLE_SCALE);
                            }

                        }
                        ++index;
                    }
                }
            }
        }





        private void PicFontTable_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = (int)(e.X / TABLE_SCALE);
                int y = (int)(e.Y / TABLE_SCALE);

                fontRomData_head = y / 8 * 8 * 16 + x / 8 * 8;

                for (int i = 0; i < 8; ++i)
                {
                    editData[i] = fontRomData[fontRomData_head + i];
                }

                DrawFontData();

                x /= 8;
                y /= 8;

                bmpViewTable = (Bitmap)bmpOrgTable.Clone();
                using (Graphics g = Graphics.FromImage(bmpViewTable))
                {
                    g.DrawRectangle(
                        new Pen(Color.Red),
                        x * 8 * TABLE_SCALE,
                        y * 8 * TABLE_SCALE,
                        8 * TABLE_SCALE,
                        8 * TABLE_SCALE);

                }
                this.PicFontTable.Image = bmpViewTable;
                this.PicFontTable.Invalidate();
            }
        }



        private void BtnWriteBack_Click(object sender, EventArgs e)
        {
            if (fontRomData_head == -1) return;
            int index = fontRomData_head;
            for (int y = 0; y < 8; ++y)
            {
                byte b = 0;
                for (int x = 0; x < 8; ++x)
                {
                    var c = bmpOrgEdit.GetPixel(x, y);
                    byte t = 0;
                    if (c.R == 0 && c.G == 0 && c.B == 0)
                    {
                        t = 0;
                    } else
                    {
                        t = 1;
                    }
                    b <<= 1;
                    b += t;
                }
                fontRomData[index] = b;
                ++index;
            }

            fontRomData_head = -1;

            SetBmpOrgTable();

            this.PicFontTable.Image = bmpOrgTable;
            this.PicFontTable.Invalidate();

            ClearEditData();
        }


        private void PicEditFont_MouseDown(object sender, MouseEventArgs e)
        {
            if (bmpViewEdit == null || bmpOrgEdit == null || fontRomData_head == -1)
                return;

            int x = (int)(e.X / EDIT_SCALE);
            int y = (int)(e.Y / EDIT_SCALE);

            Color c;
            if (e.Button == MouseButtons.Left)
                c = Color.White;
            else
                c = Color.Black;

            bmpOrgEdit.SetPixel(x, y, c);
            lastX = x;
            lastY = y;
            DrawEditVIewImage();
        }


        private void PicEditFont_MouseMove(object sender, MouseEventArgs e)
        {
            if (bmpViewEdit == null || bmpOrgEdit == null || fontRomData_head == -1)
                return;

            if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) &&
                e.X >= 0 && e.Y >= 0 && e.X < bmpViewEdit.Width && e.Y < bmpViewEdit.Height)
            {
                if (bmpViewEdit == null || bmpOrgEdit == null)
                    return;

                int x = (int)(e.X / EDIT_SCALE);
                int y = (int)(e.Y / EDIT_SCALE);

                Color c;
                if (e.Button == MouseButtons.Left)
                    c = Color.White;
                else
                    c = Color.Black;

                using (var g = Graphics.FromImage(bmpOrgEdit))
                {
                    using (var pen = new Pen(c))
                        g.DrawLine(pen, lastX, lastY, x, y);
                }
                lastX = x;
                lastY = y;

                DrawEditVIewImage();
            }
        }



        /// <summary>
        /// 編集するフォントデータをコピーして表示
        /// </summary>
        private void DrawFontData()
        {
            int index = 0;
            for (int y = 0; y < 8; ++y)
            {
                for (int x = 0; x < 8; ++x)
                {
                    var b = editData[index];
                    int j = b >> (7 - x);
                    j &= 1;

                    Color c = j == 1 ? Color.White : Color.Black;
                    bmpOrgEdit.SetPixel(x, y, c);
                }
                ++index;
            }
            DrawEditVIewImage();
        }



        /// <summary>
        /// 編集データ表示用ビットマップ描画
        /// </summary>
        void DrawEditVIewImage()
        {
            if (bmpViewEdit == null || bmpOrgEdit == null) return;

            using (var gr = Graphics.FromImage(bmpViewEdit))
            {
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                using (var brkBrush = new SolidBrush(Color.Black))
                    gr.FillRectangle(brkBrush, new Rectangle(0, 0, bmpViewEdit.Width, bmpViewEdit.Height));


                using (var whitePen = new Pen(Color.White))
                using (var blackPen = new Pen(Color.Black))
                using (var whiteBrush = new SolidBrush(Color.White))
                {
                    for (int x = 0; x < bmpOrgEdit.Width; ++x)
                    {
                        for (int y = 0; y < bmpOrgEdit.Height; ++y)
                        {
                            Color c = bmpOrgEdit.GetPixel(x, y);
                            if (c.R == 0 && c.G == 0 && c.B == 0)
                                gr.DrawRectangle(whitePen, x * EDIT_SCALE, y * EDIT_SCALE, EDIT_SCALE, EDIT_SCALE);
                            else
                                gr.FillRectangle(whiteBrush, x * EDIT_SCALE, y * EDIT_SCALE, EDIT_SCALE, EDIT_SCALE);
                        }
                    }
                }
            }
            this.PicEditFont.Image = bmpViewEdit;
        }



        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (fontRomData_head == -1) return;
            
            ClearEditData();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (fontRomData == null) return;

            if (this.RdoR0.Checked)
            {
                FileSave(fontRomData);
            }
            else if (this.RdoR90.Checked)
            {
                byte[] rotateData = new byte[ROM_SIZE];

                for (int c = 0; c < CHARS; ++c)
                {
                    for (int x = 0; x < 8; ++x)
                    {
                        for (int t = 0; t < 8; ++t)
                        {
                            var b = fontRomData[c * 8 + t];
                            int j = b >> (7 - x);
                            j &= 1;

                            rotateData[c * 8 + x] |= (byte)(j << t);
                        }
                    }
                }
                FileSave(rotateData);
            }
            else if (this.RdoR180.Checked)
            {
                byte[] rotateData = new byte[ROM_SIZE];

                for (int c = 0; c < CHARS; ++c)
                {
                    for (int x = 0; x < 8; ++x)
                    {
                        var b = fontRomData[c * 8 + 7 - x];
                        int d = 0;
                        for (int i = 0; i < 8; i++)
                        {
                            int j = b >> i;
                            j &= 1;
                            d <<= 1;
                            d += j;
                        }
                        rotateData[c * 8 + x] = (byte)d;
                    }
                }
                FileSave(rotateData);
            }
            else if (this.RdoR270.Checked)
            {
                byte[] rotateData = new byte[ROM_SIZE];

                for (int c = 0; c < CHARS; ++c)
                {
                    for (int x = 0; x < 8; ++x)
                    {
                        for (int t = 0; t < 8; ++t)
                        {
                            var b = fontRomData[c * 8 + t];
                            int j = b >> x;
                            j &= 1;

                            rotateData[c * 8 + x] |= (byte)(j << (7 - t));
                        }
                    }
                }
                FileSave(rotateData);
            }
        }


        /// <summary>
        /// BINまたはCJRで保存
        /// </summary>
        /// <param name="data"></param>
        void FileSave(byte[] data)
        {
            string fileName;

            if (this.RdoBin.Checked)
            {
                // BINで保存
                if (DlgSaveBinFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.WriteAllBytes(DlgSaveBinFile.FileName, data);
                    } catch (Exception ex)
                    {
                        System.Media.SystemSounds.Beep.Play();
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
            else
            {
                // CJRで保存
                if (DlgSaveCjrFile.ShowDialog() == DialogResult.OK)
                {
                    fileName = DlgSaveCjrFile.FileName;
                    var cjr = new CjrFormat2();
                    cjr.AddBinData(data, "FONTDATA", 0xd000, false);
                    cjr.CloseCjrData();
                    try
                    {
                        cjr.WriteCjrFile(fileName, CjrFormat2.WriteType.CJR);
                    }
                    catch (Exception ex)
                    {
                        System.Media.SystemSounds.Beep.Play();
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
        }


        /// <summary>
        /// エディット中のフォントデータをクリア
        /// </summary>
        void ClearEditData()
        {
            for (int i = 0; i < 8; ++i)
            {
                editData[i] = 0;
            }

            using (Graphics g = Graphics.FromImage(bmpOrgEdit))
            {
                g.FillRectangle(new SolidBrush(Color.Black), 0, 0, 8, 8);

            }
            DrawEditVIewImage();
        }



        /// <summary>
        /// エディット中のフォントデータを白で埋める
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFill_Click(object sender, EventArgs e)
        {
            if (fontRomData_head == -1) return;

            for (int i = 0; i < 8; ++i)
            {
                editData[i] = 0xff;
            }

            using (Graphics g = Graphics.FromImage(bmpOrgEdit))
            {
                g.FillRectangle(
                    new SolidBrush(Color.White), 0, 0, 8, 8);
            }
            DrawEditVIewImage();
        }
    }
}
