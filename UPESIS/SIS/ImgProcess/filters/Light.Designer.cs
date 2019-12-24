namespace SIS.ImgProcess.filters
{
    partial class Light
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.label15 = new BaseControls.MyLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.lb_Percentage = new BaseControls.MyLabel();
            this.lb_value = new BaseControls.MyLabel();
            this.l_track1_R = new BaseControls.MyLabel();
            this.l_track1_L = new BaseControls.MyLabel();
            this.trackBar_1 = new System.Windows.Forms.TrackBar();
            this.drawArea = new BaseControls.ImageFilter.ImageFilter();
            this.tb_LightValue = new BaseControls.MyTextBox();
            this.tb_LightPercent = new BaseControls.MyTextBox();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel4.Controls.Add(this.btn_Ok);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(288, 24);
            this.panel4.TabIndex = 49;
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(4, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "亮度";
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.Location = new System.Drawing.Point(232, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 19);
            this.button3.TabIndex = 3;
            this.button3.Text = "[关闭]";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lb_Percentage
            // 
            this.lb_Percentage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_Percentage.Location = new System.Drawing.Point(130, 155);
            this.lb_Percentage.Name = "lb_Percentage";
            this.lb_Percentage.Size = new System.Drawing.Size(60, 22);
            this.lb_Percentage.TabIndex = 59;
            this.lb_Percentage.Text = "百分比：";
            this.lb_Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_value
            // 
            this.lb_value.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_value.Location = new System.Drawing.Point(54, 155);
            this.lb_value.Name = "lb_value";
            this.lb_value.Size = new System.Drawing.Size(42, 22);
            this.lb_value.TabIndex = 58;
            this.lb_value.Text = "值：";
            this.lb_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_track1_R
            // 
            this.l_track1_R.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_track1_R.Location = new System.Drawing.Point(241, 174);
            this.l_track1_R.Name = "l_track1_R";
            this.l_track1_R.Size = new System.Drawing.Size(39, 23);
            this.l_track1_R.TabIndex = 56;
            this.l_track1_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_track1_L
            // 
            this.l_track1_L.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_track1_L.Location = new System.Drawing.Point(13, 173);
            this.l_track1_L.Name = "l_track1_L";
            this.l_track1_L.Size = new System.Drawing.Size(32, 25);
            this.l_track1_L.TabIndex = 55;
            this.l_track1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_1
            // 
            this.trackBar_1.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.trackBar_1.Location = new System.Drawing.Point(38, 172);
            this.trackBar_1.Name = "trackBar_1";
            this.trackBar_1.Size = new System.Drawing.Size(208, 45);
            this.trackBar_1.TabIndex = 54;
            this.trackBar_1.ValueChanged += new System.EventHandler(this.trackBar_1_ValueChanged);
            // 
            // drawArea
            // 
            this.drawArea.Image = null;
            this.drawArea.Location = new System.Drawing.Point(24, 30);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(240, 116);
            this.drawArea.TabIndex = 60;
            this.drawArea.Text = "imageFilter1";
            // 
            // tb_LightValue
            // 
            this.tb_LightValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_LightValue.Location = new System.Drawing.Point(86, 155);
            this.tb_LightValue.MaxLength = 4;
            this.tb_LightValue.Name = "tb_LightValue";
            this.tb_LightValue.Size = new System.Drawing.Size(25, 21);
            this.tb_LightValue.TabIndex = 91;
            this.tb_LightValue.Text = "0";
            this.tb_LightValue.TextChanged += new System.EventHandler(this.tb_LightValue_TextChanged);
            this.tb_LightValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // tb_LightPercent
            // 
            this.tb_LightPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_LightPercent.Location = new System.Drawing.Point(188, 155);
            this.tb_LightPercent.MaxLength = 3;
            this.tb_LightPercent.Name = "tb_LightPercent";
            this.tb_LightPercent.ReadOnly = true;
            this.tb_LightPercent.Size = new System.Drawing.Size(32, 21);
            this.tb_LightPercent.TabIndex = 92;
            this.tb_LightPercent.Text = "0";
            // 
            // Light
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tb_LightPercent);
            this.Controls.Add(this.tb_LightValue);
            this.Controls.Add(this.drawArea);
            this.Controls.Add(this.lb_Percentage);
            this.Controls.Add(this.lb_value);
            this.Controls.Add(this.l_track1_R);
            this.Controls.Add(this.l_track1_L);
            this.Controls.Add(this.trackBar_1);
            this.Controls.Add(this.panel4);
            this.Name = "Light";
            this.Size = new System.Drawing.Size(288, 208);
            this.Load += new System.EventHandler(this.Light_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Light_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Light_MouseDown);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button btn_Ok;
        private BaseControls.MyLabel label15;
        public System.Windows.Forms.Button button3;
        private BaseControls.MyLabel lb_Percentage;
        private BaseControls.MyLabel lb_value;
        private BaseControls.MyLabel l_track1_R;
        private BaseControls.MyLabel l_track1_L;
        private System.Windows.Forms.TrackBar trackBar_1;
        private BaseControls.ImageFilter.ImageFilter drawArea;
        private BaseControls.MyTextBox tb_LightValue;
        private BaseControls.MyTextBox tb_LightPercent;
    }
}
