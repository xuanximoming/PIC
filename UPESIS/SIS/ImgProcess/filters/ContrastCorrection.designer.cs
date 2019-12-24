namespace SIS.ImgProcess.filters
{
    partial class Contrast
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
            this.tb_ContrastCorrectionPercent = new BaseControls.MyTextBox();
            this.tb_ContrastCorrectionValue = new BaseControls.MyTextBox();
            this.drawArea = new BaseControls.ImageFilter.ImageFilter();
            this.lb_Percentage = new BaseControls.MyLabel();
            this.lb_value = new BaseControls.MyLabel();
            this.l_track1_R = new BaseControls.MyLabel();
            this.btn_Close = new System.Windows.Forms.Button();
            this.l_track1_L = new BaseControls.MyLabel();
            this.trackBar_1 = new System.Windows.Forms.TrackBar();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label15 = new BaseControls.MyLabel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_ContrastCorrectionPercent
            // 
            this.tb_ContrastCorrectionPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ContrastCorrectionPercent.Location = new System.Drawing.Point(188, 178);
            this.tb_ContrastCorrectionPercent.MaxLength = 3;
            this.tb_ContrastCorrectionPercent.Name = "tb_ContrastCorrectionPercent";
            this.tb_ContrastCorrectionPercent.ReadOnly = true;
            this.tb_ContrastCorrectionPercent.Size = new System.Drawing.Size(32, 21);
            this.tb_ContrastCorrectionPercent.TabIndex = 101;
            this.tb_ContrastCorrectionPercent.Text = "0";
            // 
            // tb_ContrastCorrectionValue
            // 
            this.tb_ContrastCorrectionValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ContrastCorrectionValue.Location = new System.Drawing.Point(86, 178);
            this.tb_ContrastCorrectionValue.MaxLength = 4;
            this.tb_ContrastCorrectionValue.Name = "tb_ContrastCorrectionValue";
            this.tb_ContrastCorrectionValue.Size = new System.Drawing.Size(25, 21);
            this.tb_ContrastCorrectionValue.TabIndex = 100;
            this.tb_ContrastCorrectionValue.Text = "0";
            this.tb_ContrastCorrectionValue.TextChanged += new System.EventHandler(this.tb_ContrastCorrectionValue_TextChanged);
            this.tb_ContrastCorrectionValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // drawArea
            // 
            this.drawArea.Image = null;
            this.drawArea.Location = new System.Drawing.Point(24, 26);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(249, 146);
            this.drawArea.TabIndex = 99;
            this.drawArea.Text = "imageFilter1";
            // 
            // lb_Percentage
            // 
            this.lb_Percentage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_Percentage.Location = new System.Drawing.Point(130, 178);
            this.lb_Percentage.Name = "lb_Percentage";
            this.lb_Percentage.Size = new System.Drawing.Size(60, 22);
            this.lb_Percentage.TabIndex = 98;
            this.lb_Percentage.Text = "百分比：";
            this.lb_Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_value
            // 
            this.lb_value.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_value.Location = new System.Drawing.Point(54, 178);
            this.lb_value.Name = "lb_value";
            this.lb_value.Size = new System.Drawing.Size(42, 22);
            this.lb_value.TabIndex = 97;
            this.lb_value.Text = "值：";
            this.lb_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_track1_R
            // 
            this.l_track1_R.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_track1_R.Location = new System.Drawing.Point(246, 195);
            this.l_track1_R.Name = "l_track1_R";
            this.l_track1_R.Size = new System.Drawing.Size(54, 23);
            this.l_track1_R.TabIndex = 96;
            this.l_track1_R.Text = "5.000000";
            this.l_track1_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Close
            // 
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Close.Location = new System.Drawing.Point(232, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(49, 19);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "[关闭]";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // l_track1_L
            // 
            this.l_track1_L.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_track1_L.Location = new System.Drawing.Point(-1, 196);
            this.l_track1_L.Name = "l_track1_L";
            this.l_track1_L.Size = new System.Drawing.Size(53, 25);
            this.l_track1_L.TabIndex = 95;
            this.l_track1_L.Text = "0.000001";
            this.l_track1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_1
            // 
            this.trackBar_1.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.trackBar_1.Location = new System.Drawing.Point(45, 195);
            this.trackBar_1.Name = "trackBar_1";
            this.trackBar_1.Size = new System.Drawing.Size(208, 45);
            this.trackBar_1.TabIndex = 94;
            this.trackBar_1.ValueChanged += new System.EventHandler(this.trackBar_1_ValueChanged);
            // 
            // btn_Ok
            // 
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ok.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Ok.Location = new System.Drawing.Point(185, 2);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(54, 19);
            this.btn_Ok.TabIndex = 72;
            this.btn_Ok.Text = "[确认]";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel4.Controls.Add(this.btn_Ok);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.btn_Close);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(300, 24);
            this.panel4.TabIndex = 93;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(4, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "对比";
            // 
            // Contrast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tb_ContrastCorrectionPercent);
            this.Controls.Add(this.tb_ContrastCorrectionValue);
            this.Controls.Add(this.drawArea);
            this.Controls.Add(this.lb_Percentage);
            this.Controls.Add(this.lb_value);
            this.Controls.Add(this.l_track1_R);
            this.Controls.Add(this.l_track1_L);
            this.Controls.Add(this.trackBar_1);
            this.Controls.Add(this.panel4);
            this.Name = "Contrast";
            this.Size = new System.Drawing.Size(300, 241);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Light_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Light_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseControls.MyTextBox tb_ContrastCorrectionPercent;
        private BaseControls.MyTextBox tb_ContrastCorrectionValue;
        private BaseControls.ImageFilter.ImageFilter drawArea;
        private BaseControls.MyLabel lb_Percentage;
        private BaseControls.MyLabel lb_value;
        private BaseControls.MyLabel l_track1_R;
        public System.Windows.Forms.Button btn_Close;
        private BaseControls.MyLabel l_track1_L;
        private System.Windows.Forms.TrackBar trackBar_1;
        public System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Panel panel4;
        private BaseControls.MyLabel label15;
    }
}
