namespace BaseControls
{
    partial class EditRTBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.richTextBox = new BaseControls.RichTextBoxEx();
            this.cms_Show = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(24, 24);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // richTextBox
            // 
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.BackColor = System.Drawing.Color.White;
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Location = new System.Drawing.Point(24, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(142, 31);
            this.richTextBox.TabIndex = 3;
            this.richTextBox.Text = "";
            this.richTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_LinkClicked);
            this.richTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.richTextBox_MouseDown);
            this.richTextBox.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.richTextBox_ContentsResized);
            // 
            // cms_Show
            // 
            this.cms_Show.Name = "cms_Show";
            this.cms_Show.ShowImageMargin = false;
            this.cms_Show.Size = new System.Drawing.Size(128, 26);
            this.cms_Show.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cms_Show_ItemClicked);
            // 
            // EditRTBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.pictureBox);
            this.Name = "EditRTBox";
            this.Size = new System.Drawing.Size(169, 34);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox;
        public RichTextBoxEx richTextBox;
        private System.Windows.Forms.ContextMenuStrip cms_Show;

    }
}
