namespace SIS.ImgProcess.ImageZoom
{
    partial class Zoom
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new BaseControls.MyLabel();
            this.myPanel6 = new BaseControls.Panels.MyPanel();
            this.label9 = new BaseControls.MyLabel();
            this.lb_ZoomIn = new BaseControls.MyLabel();
            this.myPanel8 = new BaseControls.Panels.MyPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new BaseControls.MyLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.myPanel6);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lb_ZoomIn);
            this.panel1.Controls.Add(this.myPanel8);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(202, 110);
            this.panel1.TabIndex = 49;
            this.panel1.Click += new System.EventHandler(this.zoomItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 12);
            this.label8.TabIndex = 57;
            this.label8.Text = "适合屏幕           ";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // myPanel6
            // 
            this.myPanel6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.myPanel6.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.myPanel6.Location = new System.Drawing.Point(-40, 74);
            this.myPanel6.Name = "myPanel6";
            this.myPanel6.Size = new System.Drawing.Size(239, 1);
            this.myPanel6.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 12);
            this.label9.TabIndex = 55;
            this.label9.Text = "缩小                   ";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // lb_ZoomIn
            // 
            this.lb_ZoomIn.AutoSize = true;
            this.lb_ZoomIn.Location = new System.Drawing.Point(26, 38);
            this.lb_ZoomIn.Name = "lb_ZoomIn";
            this.lb_ZoomIn.Size = new System.Drawing.Size(155, 12);
            this.lb_ZoomIn.TabIndex = 54;
            this.lb_ZoomIn.Text = "放大                     ";
            this.lb_ZoomIn.Click += new System.EventHandler(this.lb_ZoomIn_Click);
            // 
            // myPanel8
            // 
            this.myPanel8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.myPanel8.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.myPanel8.Location = new System.Drawing.Point(2, 30);
            this.myPanel8.Name = "myPanel8";
            this.myPanel8.Size = new System.Drawing.Size(239, 1);
            this.myPanel8.TabIndex = 53;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 24);
            this.panel3.TabIndex = 48;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "缩放";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button1.Location = new System.Drawing.Point(151, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 19);
            this.button1.TabIndex = 3;
            this.button1.Text = "[关闭]";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Zoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Zoom";
            this.Size = new System.Drawing.Size(202, 112);
            this.Tag = "Zoom";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private BaseControls.MyLabel label8;
        private BaseControls.Panels.MyPanel myPanel6;
        private BaseControls.MyLabel label9;
        private BaseControls.MyLabel lb_ZoomIn;
        private BaseControls.Panels.MyPanel myPanel8;
        private System.Windows.Forms.Panel panel3;
        private BaseControls.MyLabel label2;
        public System.Windows.Forms.Button button1;

    }
}
