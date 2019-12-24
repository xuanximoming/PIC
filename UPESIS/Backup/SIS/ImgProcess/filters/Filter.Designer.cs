namespace SIS.ImgProcess.filters
{
    partial class Filter
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
            this.l_track1_L = new BaseControls.MyLabel();
            this.l_track1_R = new BaseControls.MyLabel();
            this.lb_value = new BaseControls.MyLabel();
            this.lb_Percentage = new BaseControls.MyLabel();
            this.l_track1_Name = new BaseControls.MyLabel();
            this.label1 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.label4 = new BaseControls.MyLabel();
            this.label5 = new BaseControls.MyLabel();
            this.label6 = new BaseControls.MyLabel();
            this.label7 = new BaseControls.MyLabel();
            this.label8 = new BaseControls.MyLabel();
            this.label9 = new BaseControls.MyLabel();
            this.label10 = new BaseControls.MyLabel();
            this.label11 = new BaseControls.MyLabel();
            this.label12 = new BaseControls.MyLabel();
            this.label13 = new BaseControls.MyLabel();
            this.label14 = new BaseControls.MyLabel();
            this.label16 = new BaseControls.MyLabel();
            this.tb_Gmax = new BaseControls.MyTextBox();
            this.tb_Bmax = new BaseControls.MyTextBox();
            this.tb_Gmin = new BaseControls.MyTextBox();
            this.tb_Bmin = new BaseControls.MyTextBox();
            this.tb_Rmax = new BaseControls.MyTextBox();
            this.tb_Rmin = new BaseControls.MyTextBox();
            this.cs_Red = new BaseControls.ColorSlider.ColorSlider();
            this.cs_Blue = new BaseControls.ColorSlider.ColorSlider();
            this.cs_Green = new BaseControls.ColorSlider.ColorSlider();
            this.cb_FillType = new BaseControls.ComboBoxs.MyComboBox();
            this.tb_FillBlue = new BaseControls.MyTextBox();
            this.tb_FillGreen = new BaseControls.MyTextBox();
            this.tb_FillRed = new BaseControls.MyTextBox();
            this.drawArea = new BaseControls.ImageFilter.ImageFilter();
            this.panel4.SuspendLayout();
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
            this.panel4.Size = new System.Drawing.Size(637, 24);
            this.panel4.TabIndex = 49;
            // 
            // btn_Ok
            // 
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ok.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Ok.Location = new System.Drawing.Point(535, 4);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(52, 19);
            this.btn_Ok.TabIndex = 5;
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
            this.label15.Text = "过滤";
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.Location = new System.Drawing.Point(582, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 19);
            this.button3.TabIndex = 3;
            this.button3.Text = "[关闭]";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // l_track1_L
            // 
            this.l_track1_L.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_track1_L.Location = new System.Drawing.Point(17, 52);
            this.l_track1_L.Name = "l_track1_L";
            this.l_track1_L.Size = new System.Drawing.Size(18, 23);
            this.l_track1_L.TabIndex = 50;
            this.l_track1_L.Text = "0";
            this.l_track1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_track1_R
            // 
            this.l_track1_R.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_track1_R.Location = new System.Drawing.Point(311, 53);
            this.l_track1_R.Name = "l_track1_R";
            this.l_track1_R.Size = new System.Drawing.Size(37, 23);
            this.l_track1_R.TabIndex = 51;
            this.l_track1_R.Text = "255";
            this.l_track1_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_value
            // 
            this.lb_value.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_value.Location = new System.Drawing.Point(81, 36);
            this.lb_value.Name = "lb_value";
            this.lb_value.Size = new System.Drawing.Size(36, 18);
            this.lb_value.TabIndex = 53;
            this.lb_value.Text = "Min:";
            this.lb_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_Percentage
            // 
            this.lb_Percentage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_Percentage.Location = new System.Drawing.Point(148, 37);
            this.lb_Percentage.Name = "lb_Percentage";
            this.lb_Percentage.Size = new System.Drawing.Size(66, 17);
            this.lb_Percentage.TabIndex = 54;
            this.lb_Percentage.Text = "Max:";
            this.lb_Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_track1_Name
            // 
            this.l_track1_Name.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.l_track1_Name.Location = new System.Drawing.Point(12, 36);
            this.l_track1_Name.Name = "l_track1_Name";
            this.l_track1_Name.Size = new System.Drawing.Size(35, 18);
            this.l_track1_Name.TabIndex = 55;
            this.l_track1_Name.Text = "Red";
            this.l_track1_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 18);
            this.label1.TabIndex = 61;
            this.label1.Text = "Green";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(311, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 23);
            this.label2.TabIndex = 58;
            this.label2.Text = "255";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(63, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 59;
            this.label3.Text = "Min:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(148, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 60;
            this.label4.Text = "Max:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(9, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 23);
            this.label5.TabIndex = 57;
            this.label5.Text = "0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(12, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 18);
            this.label6.TabIndex = 67;
            this.label6.Text = "Blue";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(311, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 23);
            this.label7.TabIndex = 64;
            this.label7.Text = "255";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(63, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 17);
            this.label8.TabIndex = 65;
            this.label8.Text = "Min:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(148, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 17);
            this.label9.TabIndex = 66;
            this.label9.Text = "Max:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(9, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 23);
            this.label10.TabIndex = 63;
            this.label10.Text = "0";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label11.Location = new System.Drawing.Point(12, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 18);
            this.label11.TabIndex = 68;
            this.label11.Text = "填充色";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label12.Location = new System.Drawing.Point(51, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 18);
            this.label12.TabIndex = 69;
            this.label12.Text = "R:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label13.Location = new System.Drawing.Point(116, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 18);
            this.label13.TabIndex = 70;
            this.label13.Text = "G:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label14.Location = new System.Drawing.Point(183, 224);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 18);
            this.label14.TabIndex = 71;
            this.label14.Text = "B:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(12, 260);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 18);
            this.label16.TabIndex = 75;
            this.label16.Text = "填充类型";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Gmax
            // 
            this.tb_Gmax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Gmax.Location = new System.Drawing.Point(198, 89);
            this.tb_Gmax.MaxLength = 3;
            this.tb_Gmax.Name = "tb_Gmax";
            this.tb_Gmax.Size = new System.Drawing.Size(25, 21);
            this.tb_Gmax.TabIndex = 92;
            this.tb_Gmax.Text = "255";
            this.tb_Gmax.TextChanged += new System.EventHandler(this.tb_Gmax_TextChanged);
            this.tb_Gmax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // tb_Bmax
            // 
            this.tb_Bmax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Bmax.Location = new System.Drawing.Point(198, 147);
            this.tb_Bmax.MaxLength = 3;
            this.tb_Bmax.Name = "tb_Bmax";
            this.tb_Bmax.Size = new System.Drawing.Size(25, 21);
            this.tb_Bmax.TabIndex = 91;
            this.tb_Bmax.Text = "255";
            this.tb_Bmax.TextChanged += new System.EventHandler(this.tb_Bmax_TextChanged);
            this.tb_Bmax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // tb_Gmin
            // 
            this.tb_Gmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Gmin.Location = new System.Drawing.Point(114, 89);
            this.tb_Gmin.MaxLength = 3;
            this.tb_Gmin.Name = "tb_Gmin";
            this.tb_Gmin.Size = new System.Drawing.Size(25, 21);
            this.tb_Gmin.TabIndex = 90;
            this.tb_Gmin.Text = "0";
            this.tb_Gmin.TextChanged += new System.EventHandler(this.tb_Gmin_TextChanged);
            this.tb_Gmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // tb_Bmin
            // 
            this.tb_Bmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Bmin.Location = new System.Drawing.Point(114, 147);
            this.tb_Bmin.MaxLength = 3;
            this.tb_Bmin.Name = "tb_Bmin";
            this.tb_Bmin.Size = new System.Drawing.Size(25, 21);
            this.tb_Bmin.TabIndex = 89;
            this.tb_Bmin.Text = "0";
            this.tb_Bmin.TextChanged += new System.EventHandler(this.tb_Bmin_TextChanged);
            this.tb_Bmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // tb_Rmax
            // 
            this.tb_Rmax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Rmax.Location = new System.Drawing.Point(198, 33);
            this.tb_Rmax.MaxLength = 3;
            this.tb_Rmax.Name = "tb_Rmax";
            this.tb_Rmax.Size = new System.Drawing.Size(25, 21);
            this.tb_Rmax.TabIndex = 88;
            this.tb_Rmax.Text = "255";
            this.tb_Rmax.TextChanged += new System.EventHandler(this.tb_Rmax_TextChanged);
            this.tb_Rmax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // tb_Rmin
            // 
            this.tb_Rmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Rmin.Location = new System.Drawing.Point(114, 34);
            this.tb_Rmin.MaxLength = 3;
            this.tb_Rmin.Name = "tb_Rmin";
            this.tb_Rmin.Size = new System.Drawing.Size(25, 21);
            this.tb_Rmin.TabIndex = 87;
            this.tb_Rmin.Text = "0";
            this.tb_Rmin.TextChanged += new System.EventHandler(this.tb_Rmin_TextChanged);
            this.tb_Rmin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // cs_Red
            // 
            this.cs_Red.Color2 = System.Drawing.Color.Red;
            this.cs_Red.Location = new System.Drawing.Point(30, 56);
            this.cs_Red.Name = "cs_Red";
            this.cs_Red.Size = new System.Drawing.Size(289, 23);
            this.cs_Red.TabIndex = 86;
            this.cs_Red.Text = "colorSlider4";
            this.cs_Red.ValuesChanged += new System.EventHandler(this.cs_Red_ValuesChanged);
            // 
            // cs_Blue
            // 
            this.cs_Blue.Color2 = System.Drawing.Color.Blue;
            this.cs_Blue.Location = new System.Drawing.Point(42, 171);
            this.cs_Blue.Name = "cs_Blue";
            this.cs_Blue.Size = new System.Drawing.Size(263, 23);
            this.cs_Blue.TabIndex = 79;
            this.cs_Blue.Text = "colorSlider3";
            this.cs_Blue.ValuesChanged += new System.EventHandler(this.cs_Blue_ValuesChanged);
            // 
            // cs_Green
            // 
            this.cs_Green.Color2 = System.Drawing.Color.Green;
            this.cs_Green.Location = new System.Drawing.Point(41, 112);
            this.cs_Green.Name = "cs_Green";
            this.cs_Green.Size = new System.Drawing.Size(264, 23);
            this.cs_Green.TabIndex = 78;
            this.cs_Green.Text = "colorSlider2";
            this.cs_Green.ValuesChanged += new System.EventHandler(this.cs_Green_ValuesChanged);
            // 
            // cb_FillType
            // 
            this.cb_FillType.FormattingEnabled = true;
            this.cb_FillType.Items.AddRange(new object[] {
            "OutSide",
            "InSide"});
            this.cb_FillType.Location = new System.Drawing.Point(68, 260);
            this.cb_FillType.Name = "cb_FillType";
            this.cb_FillType.Size = new System.Drawing.Size(121, 20);
            this.cb_FillType.TabIndex = 76;
            this.cb_FillType.SelectedIndexChanged += new System.EventHandler(this.cb_FillType_SelectedIndexChanged);
            // 
            // tb_FillBlue
            // 
            this.tb_FillBlue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FillBlue.Location = new System.Drawing.Point(203, 224);
            this.tb_FillBlue.MaxLength = 3;
            this.tb_FillBlue.Name = "tb_FillBlue";
            this.tb_FillBlue.Size = new System.Drawing.Size(49, 21);
            this.tb_FillBlue.TabIndex = 74;
            this.tb_FillBlue.Text = "0";
            this.tb_FillBlue.TextChanged += new System.EventHandler(this.tb_FillBlue_TextChanged);
            this.tb_FillBlue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // tb_FillGreen
            // 
            this.tb_FillGreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FillGreen.Location = new System.Drawing.Point(135, 224);
            this.tb_FillGreen.MaxLength = 3;
            this.tb_FillGreen.Name = "tb_FillGreen";
            this.tb_FillGreen.Size = new System.Drawing.Size(49, 21);
            this.tb_FillGreen.TabIndex = 73;
            this.tb_FillGreen.Text = "0";
            this.tb_FillGreen.TextChanged += new System.EventHandler(this.tb_FillGreen_TextChanged);
            this.tb_FillGreen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // tb_FillRed
            // 
            this.tb_FillRed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FillRed.Location = new System.Drawing.Point(68, 224);
            this.tb_FillRed.MaxLength = 3;
            this.tb_FillRed.Name = "tb_FillRed";
            this.tb_FillRed.Size = new System.Drawing.Size(49, 21);
            this.tb_FillRed.TabIndex = 72;
            this.tb_FillRed.Text = "0";
            this.tb_FillRed.TextChanged += new System.EventHandler(this.tb_FillRed_TextChanged);
            this.tb_FillRed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // drawArea
            // 
            this.drawArea.Image = null;
            this.drawArea.Location = new System.Drawing.Point(370, 37);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(248, 235);
            this.drawArea.TabIndex = 93;
            this.drawArea.Text = "imageFilter1";
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.drawArea);
            this.Controls.Add(this.tb_Gmax);
            this.Controls.Add(this.tb_Bmax);
            this.Controls.Add(this.tb_Gmin);
            this.Controls.Add(this.tb_Bmin);
            this.Controls.Add(this.tb_Rmax);
            this.Controls.Add(this.tb_Rmin);
            this.Controls.Add(this.cs_Red);
            this.Controls.Add(this.cs_Blue);
            this.Controls.Add(this.cs_Green);
            this.Controls.Add(this.cb_FillType);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.tb_FillBlue);
            this.Controls.Add(this.tb_FillGreen);
            this.Controls.Add(this.tb_FillRed);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.l_track1_Name);
            this.Controls.Add(this.l_track1_R);
            this.Controls.Add(this.lb_value);
            this.Controls.Add(this.lb_Percentage);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.l_track1_L);
            this.Name = "Filter";
            this.Size = new System.Drawing.Size(637, 285);
            this.Tag = "Filter";
           // this.Load += new System.EventHandler(this.Filter_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Filter_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Filter_MouseDown);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private BaseControls.MyLabel label15;
        public System.Windows.Forms.Button button3;
        private BaseControls.MyLabel l_track1_L;
        private BaseControls.MyLabel l_track1_R;
        private BaseControls.MyLabel lb_value;
        private BaseControls.MyLabel lb_Percentage;
        private BaseControls.MyLabel l_track1_Name;
        private BaseControls.MyLabel label1;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label3;
        private BaseControls.MyLabel label4;
        private BaseControls.MyLabel label5;
        private BaseControls.MyLabel label6;
        private BaseControls.MyLabel label7;
        private BaseControls.MyLabel label8;
        private BaseControls.MyLabel label9;
        private BaseControls.MyLabel label10;
        private BaseControls.MyLabel label11;
        private BaseControls.MyLabel label12;
        private BaseControls.MyLabel label13;
        private BaseControls.MyLabel label14;
        private BaseControls.MyTextBox tb_FillRed;
        private BaseControls.MyTextBox tb_FillGreen;
        private BaseControls.MyTextBox tb_FillBlue;
        private BaseControls.MyLabel label16;
        private BaseControls.ComboBoxs.MyComboBox cb_FillType;
        private BaseControls.ColorSlider.ColorSlider cs_Green;
        private BaseControls.ColorSlider.ColorSlider cs_Blue;
        private BaseControls.ColorSlider.ColorSlider cs_Red;
        public System.Windows.Forms.Button btn_Ok;
        private BaseControls.MyTextBox tb_Rmin;
        private BaseControls.MyTextBox tb_Rmax;
        private BaseControls.MyTextBox tb_Bmin;
        private BaseControls.MyTextBox tb_Gmin;
        private BaseControls.MyTextBox tb_Bmax;
        private BaseControls.MyTextBox tb_Gmax;
        private BaseControls.ImageFilter.ImageFilter drawArea;
    }
}
