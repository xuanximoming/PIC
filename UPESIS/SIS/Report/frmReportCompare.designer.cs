namespace SIS
{
    partial class frmReportCompare
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.rtb_Rpt1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmb_Rpt1 = new System.Windows.Forms.ComboBox();
            this.rtb_Rpt2 = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmb_Rpt2 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(862, 515);
            this.panel1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gb_PromptInfo);
            this.splitContainer1.Panel1.Controls.Add(this.rtb_Rpt1);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtb_Rpt2);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(862, 515);
            this.splitContainer1.SplitterDistance = 254;
            this.splitContainer1.TabIndex = 12;
            // 
            // gb_PromptInfo
            // 
            this.gb_PromptInfo.BackgroundColor = System.Drawing.Color.Bisque;
            this.gb_PromptInfo.BackgroundGradientColor = System.Drawing.Color.White;
            this.gb_PromptInfo.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.gb_PromptInfo.BorderColor = System.Drawing.Color.SandyBrown;
            this.gb_PromptInfo.BorderThickness = 1F;
            this.gb_PromptInfo.Controls.Add(this.pictureBox1);
            this.gb_PromptInfo.Controls.Add(this.lb_PromptInfo);
            this.gb_PromptInfo.CustomGroupBoxColor = System.Drawing.Color.White;
            this.gb_PromptInfo.GroupImage = null;
            this.gb_PromptInfo.GroupTitle = "";
            this.gb_PromptInfo.Location = new System.Drawing.Point(246, 133);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 35;
            this.gb_PromptInfo.UseWaitCursor = true;
            this.gb_PromptInfo.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(3, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // lb_PromptInfo
            // 
            this.lb_PromptInfo.AutoSize = true;
            this.lb_PromptInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_PromptInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lb_PromptInfo.Location = new System.Drawing.Point(50, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(113, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未产生报告轨迹！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // rtb_Rpt1
            // 
            this.rtb_Rpt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Rpt1.Font = new System.Drawing.Font("宋体", 10F);
            this.rtb_Rpt1.Location = new System.Drawing.Point(0, 34);
            this.rtb_Rpt1.Name = "rtb_Rpt1";
            this.rtb_Rpt1.Size = new System.Drawing.Size(862, 220);
            this.rtb_Rpt1.TabIndex = 10;
            this.rtb_Rpt1.Text = "";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cmb_Rpt1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(862, 34);
            this.panel2.TabIndex = 7;
            // 
            // cmb_Rpt1
            // 
            this.cmb_Rpt1.FormattingEnabled = true;
            this.cmb_Rpt1.Location = new System.Drawing.Point(7, 7);
            this.cmb_Rpt1.MaxLength = 100;
            this.cmb_Rpt1.Name = "cmb_Rpt1";
            this.cmb_Rpt1.Size = new System.Drawing.Size(205, 20);
            this.cmb_Rpt1.TabIndex = 0;
            this.cmb_Rpt1.SelectedIndexChanged += new System.EventHandler(this.cmb_Rpt1_SelectedIndexChanged);
            // 
            // rtb_Rpt2
            // 
            this.rtb_Rpt2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Rpt2.Location = new System.Drawing.Point(0, 29);
            this.rtb_Rpt2.Name = "rtb_Rpt2";
            this.rtb_Rpt2.Size = new System.Drawing.Size(862, 228);
            this.rtb_Rpt2.TabIndex = 12;
            this.rtb_Rpt2.Text = "";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.cmb_Rpt2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(862, 29);
            this.panel3.TabIndex = 11;
            // 
            // cmb_Rpt2
            // 
            this.cmb_Rpt2.FormattingEnabled = true;
            this.cmb_Rpt2.Location = new System.Drawing.Point(7, 4);
            this.cmb_Rpt2.Name = "cmb_Rpt2";
            this.cmb_Rpt2.Size = new System.Drawing.Size(205, 20);
            this.cmb_Rpt2.TabIndex = 1;
            this.cmb_Rpt2.SelectedIndexChanged += new System.EventHandler(this.cmb_Rpt2_SelectedIndexChanged);
            // 
            // frmReportCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 515);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmReportCompare";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "报告轨迹";
            this.Load += new System.EventHandler(this.frmReportCompare_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReportCompare_FormClosing);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtb_Rpt1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cmb_Rpt1;
        private System.Windows.Forms.RichTextBox rtb_Rpt2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmb_Rpt2;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.MyLabel lb_PromptInfo;
    }
}