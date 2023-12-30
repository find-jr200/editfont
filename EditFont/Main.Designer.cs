namespace EditFont
{
    partial class Main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.PicFontTable = new System.Windows.Forms.PictureBox();
            this.PicEditFont = new System.Windows.Forms.PictureBox();
            this.GrpRotation = new System.Windows.Forms.GroupBox();
            this.RdoR270 = new System.Windows.Forms.RadioButton();
            this.RdoR180 = new System.Windows.Forms.RadioButton();
            this.RdoR90 = new System.Windows.Forms.RadioButton();
            this.RdoR0 = new System.Windows.Forms.RadioButton();
            this.BtnWriteBack = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.GrpFormat = new System.Windows.Forms.GroupBox();
            this.RdoCjr = new System.Windows.Forms.RadioButton();
            this.RdoBin = new System.Windows.Forms.RadioButton();
            this.DlgSaveCjrFile = new System.Windows.Forms.SaveFileDialog();
            this.DlgSaveBinFile = new System.Windows.Forms.SaveFileDialog();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnFill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicFontTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicEditFont)).BeginInit();
            this.GrpRotation.SuspendLayout();
            this.GrpFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // PicFontTable
            // 
            this.PicFontTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicFontTable.Location = new System.Drawing.Point(13, 13);
            this.PicFontTable.Name = "PicFontTable";
            this.PicFontTable.Size = new System.Drawing.Size(514, 514);
            this.PicFontTable.TabIndex = 0;
            this.PicFontTable.TabStop = false;
            this.PicFontTable.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PicFontTable_MouseDoubleClick);
            // 
            // PicEditFont
            // 
            this.PicEditFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicEditFont.Location = new System.Drawing.Point(549, 13);
            this.PicEditFont.Name = "PicEditFont";
            this.PicEditFont.Size = new System.Drawing.Size(194, 194);
            this.PicEditFont.TabIndex = 1;
            this.PicEditFont.TabStop = false;
            this.PicEditFont.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicEditFont_MouseDown);
            this.PicEditFont.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicEditFont_MouseMove);
            // 
            // GrpRotation
            // 
            this.GrpRotation.Controls.Add(this.RdoR270);
            this.GrpRotation.Controls.Add(this.RdoR180);
            this.GrpRotation.Controls.Add(this.RdoR90);
            this.GrpRotation.Controls.Add(this.RdoR0);
            this.GrpRotation.Location = new System.Drawing.Point(549, 387);
            this.GrpRotation.Name = "GrpRotation";
            this.GrpRotation.Size = new System.Drawing.Size(94, 128);
            this.GrpRotation.TabIndex = 4;
            this.GrpRotation.TabStop = false;
            this.GrpRotation.Text = "回転";
            // 
            // RdoR270
            // 
            this.RdoR270.AutoSize = true;
            this.RdoR270.Location = new System.Drawing.Point(7, 97);
            this.RdoR270.Name = "RdoR270";
            this.RdoR270.Size = new System.Drawing.Size(53, 16);
            this.RdoR270.TabIndex = 3;
            this.RdoR270.TabStop = true;
            this.RdoR270.Text = "270度";
            this.RdoR270.UseVisualStyleBackColor = true;
            // 
            // RdoR180
            // 
            this.RdoR180.AutoSize = true;
            this.RdoR180.Location = new System.Drawing.Point(7, 74);
            this.RdoR180.Name = "RdoR180";
            this.RdoR180.Size = new System.Drawing.Size(53, 16);
            this.RdoR180.TabIndex = 2;
            this.RdoR180.TabStop = true;
            this.RdoR180.Text = "180度";
            this.RdoR180.UseVisualStyleBackColor = true;
            // 
            // RdoR90
            // 
            this.RdoR90.AutoSize = true;
            this.RdoR90.Location = new System.Drawing.Point(7, 51);
            this.RdoR90.Name = "RdoR90";
            this.RdoR90.Size = new System.Drawing.Size(47, 16);
            this.RdoR90.TabIndex = 1;
            this.RdoR90.TabStop = true;
            this.RdoR90.Text = "90度";
            this.RdoR90.UseVisualStyleBackColor = true;
            // 
            // RdoR0
            // 
            this.RdoR0.AutoSize = true;
            this.RdoR0.Checked = true;
            this.RdoR0.Location = new System.Drawing.Point(7, 28);
            this.RdoR0.Name = "RdoR0";
            this.RdoR0.Size = new System.Drawing.Size(41, 16);
            this.RdoR0.TabIndex = 0;
            this.RdoR0.TabStop = true;
            this.RdoR0.Text = "0度";
            this.RdoR0.UseVisualStyleBackColor = true;
            // 
            // BtnWriteBack
            // 
            this.BtnWriteBack.Location = new System.Drawing.Point(549, 220);
            this.BtnWriteBack.Name = "BtnWriteBack";
            this.BtnWriteBack.Size = new System.Drawing.Size(75, 23);
            this.BtnWriteBack.TabIndex = 0;
            this.BtnWriteBack.Text = "←書戻し";
            this.BtnWriteBack.UseVisualStyleBackColor = true;
            this.BtnWriteBack.Click += new System.EventHandler(this.BtnWriteBack_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(666, 492);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 5;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // GrpFormat
            // 
            this.GrpFormat.Controls.Add(this.RdoCjr);
            this.GrpFormat.Controls.Add(this.RdoBin);
            this.GrpFormat.Location = new System.Drawing.Point(556, 315);
            this.GrpFormat.Name = "GrpFormat";
            this.GrpFormat.Size = new System.Drawing.Size(185, 49);
            this.GrpFormat.TabIndex = 3;
            this.GrpFormat.TabStop = false;
            this.GrpFormat.Text = "フォーマット";
            // 
            // RdoCjr
            // 
            this.RdoCjr.AutoSize = true;
            this.RdoCjr.Location = new System.Drawing.Point(91, 19);
            this.RdoCjr.Name = "RdoCjr";
            this.RdoCjr.Size = new System.Drawing.Size(46, 16);
            this.RdoCjr.TabIndex = 1;
            this.RdoCjr.TabStop = true;
            this.RdoCjr.Text = "CJR";
            this.RdoCjr.UseVisualStyleBackColor = true;
            // 
            // RdoBin
            // 
            this.RdoBin.AutoSize = true;
            this.RdoBin.Checked = true;
            this.RdoBin.Location = new System.Drawing.Point(7, 19);
            this.RdoBin.Name = "RdoBin";
            this.RdoBin.Size = new System.Drawing.Size(42, 16);
            this.RdoBin.TabIndex = 0;
            this.RdoBin.TabStop = true;
            this.RdoBin.Text = "BIN";
            this.RdoBin.UseVisualStyleBackColor = true;
            // 
            // DlgSaveCjrFile
            // 
            this.DlgSaveCjrFile.Filter = "CJRファイル|*.cjr|すべてのファイル|*.*";
            // 
            // DlgSaveBinFile
            // 
            this.DlgSaveBinFile.Filter = "BINファイル|*.bin|すべてのファイル|*.*";
            // 
            // BtnClear
            // 
            this.BtnClear.Location = new System.Drawing.Point(667, 220);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(75, 23);
            this.BtnClear.TabIndex = 1;
            this.BtnClear.Text = "全黒";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnFill
            // 
            this.BtnFill.Location = new System.Drawing.Point(667, 259);
            this.BtnFill.Name = "BtnFill";
            this.BtnFill.Size = new System.Drawing.Size(75, 23);
            this.BtnFill.TabIndex = 2;
            this.BtnFill.Text = "全白";
            this.BtnFill.UseVisualStyleBackColor = true;
            this.BtnFill.Click += new System.EventHandler(this.BtnFill_Click);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 536);
            this.Controls.Add(this.BtnFill);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.GrpFormat);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnWriteBack);
            this.Controls.Add(this.GrpRotation);
            this.Controls.Add(this.PicEditFont);
            this.Controls.Add(this.PicFontTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "フォントエディタ";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.PicFontTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicEditFont)).EndInit();
            this.GrpRotation.ResumeLayout(false);
            this.GrpRotation.PerformLayout();
            this.GrpFormat.ResumeLayout(false);
            this.GrpFormat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicFontTable;
        private System.Windows.Forms.PictureBox PicEditFont;
        private System.Windows.Forms.GroupBox GrpRotation;
        private System.Windows.Forms.RadioButton RdoR270;
        private System.Windows.Forms.RadioButton RdoR180;
        private System.Windows.Forms.RadioButton RdoR90;
        private System.Windows.Forms.RadioButton RdoR0;
        private System.Windows.Forms.Button BtnWriteBack;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox GrpFormat;
        private System.Windows.Forms.RadioButton RdoCjr;
        private System.Windows.Forms.RadioButton RdoBin;
        private System.Windows.Forms.SaveFileDialog DlgSaveCjrFile;
        private System.Windows.Forms.SaveFileDialog DlgSaveBinFile;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnFill;
    }
}

