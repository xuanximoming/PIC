namespace SIS.ImgProcess.filters
{
    partial class Gaussian
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
            this.tb_GaussianSigemaPercent = new BaseControls.MyTextBox();
            this.tb_GaussianSigemaValue = new BaseControls.MyTextBox();
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
            this.tb_GaussianPercent = new BaseControls.MyTextBox();
            this.tb_GaussianValue = new BaseControls.MyTextBox();
            this.label1 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.l_track1_R2 = new BaseControls.MyLabel();
            this.l_track1_L2 = new BaseControls.MyLabel();
            this.trackBar_2 = new System.Windows.Forms.TrackBar();
            this.label5 = new BaseControls.MyLabel();
            this.label6 = new BaseControls.MyLabel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_2)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_GaussianSigemaPercent
            // 
            this.tb_GaussianSigemaPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_GaussianSigemaPercent.Location = new System.Drawing.Point(183, 151);
            this.tb_GaussianSigemaPercent.MaxLength = 3;
            this.tb_GaussianSigemaPercent.Name = "tb_GaussianSigemaPercent";
            this.tb_GaussianSigemaPercent.ReadOnly = true;
            this.tb_GaussianSigemaPercent.Size = new System.Drawing.Size(32, 21);
            this.tb_GaussianSigemaPercent.TabIndex = 101;
            this.tb_GaussianSigemaPercent.Text = "0";
            // 
            // tb_GaussianSigemaValue
            // 
            this.tb_GaussianSigemaValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_GaussianSigemaValue.Location = new System.Drawing.Point(81, 151);
            this.tb_GaussianSigemaValue.MaxLength = 4;
            this.tb_GaussianSigemaValue.Name = "tb_GaussianSigemaValue";
            this.tb_GaussianSigemaValue.Size = new System.Drawing.Size(25, 21);
            this.tb_GaussianSigemaValue.TabIndex = 100;
            this.tb_GaussianSigemaValue.Text = "0";
            this.tb_GaussianSigemaValue.TextChanged += new System.EventHandler(this.tb_GaussianSigemaValue_TextChanged);
            this.tb_GaussianSigemaValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // drawArea
            // 
            this.drawArea.Image = null;
            this.drawArea.Location = new System.Drawing.Point(19, 26);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(240, 116);
            this.drawArea.TabIndex = 99;
            this.drawArea.Text = "imageFilter1";
            // 
            // lb_Percentage
            // 
            this.lb_Percentage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_Percentage.Location = new System.Drawing.Point(125, 151);
            this.lb_Percentage.Name = "lb_Percentage";
            this.lb_Percentage.Size = new System.Drawing.Size(60, 22);
            this.lb_Percentage.TabIndex = 98;
            this.lb_Percentage.Text = "百分比：";
            this.lb_Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_value
            // 
            this.lb_value.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_value.Location = new System.Drawing.Point(49, 151);
            this.lb_value.Name = "lb_value";
            this.lb_value.Size = new System.Drawing.Size(42, 22);
            this.lb_value.TabIndex = 97;
            this.lb_value.Text = "值：";
            this.lb_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_track1_R
            // 
            this.l_track1_R.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_track1_R.Location = new System.Drawing.Point(236, 170);
            this.l_track1_R.Name = "l_track1_R";
            this.l_track1_R.Size = new System.Drawing.Size(39, 23);
            this.l_track1_R.TabIndex = 96;
            this.l_track1_R.Text = "180";
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
            this.l_track1_L.Location = new System.Drawing.Point(8, 169);
            this.l_track1_L.Name = "l_track1_L";
            this.l_track1_L.Size = new System.Drawing.Size(32, 25);
            this.l_track1_L.TabIndex = 95;
            this.l_track1_L.Text = "0";
            this.l_track1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_1
            // 
            this.trackBar_1.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.trackBar_1.Location = new System.Drawing.Point(33, 168);
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
            this.panel4.Size = new System.Drawing.Size(281, 24);
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
            this.label15.Text = "柔化";
            // 
            // tb_GaussianPercent
            // 
            this.tb_GaussianPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_GaussianPercent.Location = new System.Drawing.Point(181, 198);
            this.tb_GaussianPercent.MaxLength = 3;
            this.tb_GaussianPercent.Name = "tb_GaussianPercent";
            this.tb_GaussianPercent.ReadOnly = true;
            this.tb_GaussianPercent.Size = new System.Drawing.Size(32, 21);
            this.tb_GaussianPercent.TabIndex = 108;
            this.tb_GaussianPercent.Text = "0";
            // 
            // tb_GaussianValue
            // 
            this.tb_GaussianValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_GaussianValue.Location = new System.Drawing.Point(79, 198);
            this.tb_GaussianValue.MaxLength = 4;
            this.tb_GaussianValue.Name = "tb_GaussianValue";
            this.tb_GaussianValue.Size = new System.Drawing.Size(25, 21);
            this.tb_GaussianValue.TabIndex = 107;
            this.tb_GaussianValue.Text = "0";
            this.tb_GaussianValue.TextChanged += new System.EventHandler(this.tb_GaussianValue_TextChanged);
            this.tb_GaussianValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(123, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 22);
            this.label1.TabIndex = 106;
            this.label1.Text = "百分比：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(47, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 22);
            this.label2.TabIndex = 105;
            this.label2.Text = "值：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_track1_R2
            // 
            this.l_track1_R2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_track1_R2.Location = new System.Drawing.Point(234, 217);
            this.l_track1_R2.Name = "l_track1_R2";
            this.l_track1_R2.Size = new System.Drawing.Size(39, 23);
            this.l_track1_R2.TabIndex = 104;
            this.l_track1_R2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_track1_L2
            // 
            this.l_track1_L2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_track1_L2.Location = new System.Drawing.Point(6, 216);
            this.l_track1_L2.Name = "l_track1_L2";
            this.l_track1_L2.Size = new System.Drawing.Size(32, 25);
            this.l_track1_L2.TabIndex = 103;
            this.l_track1_L2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_2
            // 
            this.trackBar_2.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.trackBar_2.Location = new System.Drawing.Point(31, 215);
            this.trackBar_2.Name = "trackBar_2";
            this.trackBar_2.Size = new System.Drawing.Size(208, 45);
            this.trackBar_2.TabIndex = 102;
            this.trackBar_2.ValueChanged += new System.EventHandler(this.trackBar_2_ValueChanged);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(8, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 25);
            this.label5.TabIndex = 109;
            this.label5.Text = "∑:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(8, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 25);
            this.label6.TabIndex = 110;
            this.label6.Text = "值:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Gaussian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_GaussianPercent);
            this.Controls.Add(this.tb_GaussianValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.l_track1_R2);
            this.Controls.Add(this.l_track1_L2);
            this.Controls.Add(this.trackBar_2);
            this.Controls.Add(this.tb_GaussianSigemaPercent);
            this.Controls.Add(this.tb_GaussianSigemaValue);
            this.Controls.Add(this.drawArea);
            this.Controls.Add(this.lb_Percentage);
            this.Controls.Add(this.lb_value);
            this.Controls.Add(this.l_track1_R);
            this.Controls.Add(this.l_track1_L);
            this.Controls.Add(this.trackBar_1);
            this.Controls.Add(this.panel4);
            this.Name = "Gaussian";
            this.Size = new System.Drawing.Size(281, 254);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Light_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Light_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseControls.MyTextBox tb_GaussianSigemaPercent;
        private BaseControls.MyTextBox tb_GaussianSigemaValue;
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
        private BaseControls.MyTextBox tb_GaussianPercent;
        private BaseControls.MyTextBox tb_GaussianValue;
        private BaseControls.MyLabel label1;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel l_track1_R2;
        private BaseControls.MyLabel l_track1_L2;
        private System.Windows.Forms.TrackBar trackBar_2;
        private BaseControls.MyLabel label5;
        private BaseControls.MyLabel label6;
    }
}
