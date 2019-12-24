namespace SIS.ImgProcess.filters
{
    partial class Pseudocolor
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
            this.tb_PseudocolorPercent = new BaseControls.MyTextBox();
            this.tb_PseudocolorValue = new BaseControls.MyTextBox();
            this.drawArea = new BaseControls.ImageFilter.ImageFilter();
            this.lb_Percentage = new BaseControls.MyLabel();
            this.lb_value = new BaseControls.MyLabel();
            this.l_track1_R = new BaseControls.MyLabel();
            this.l_track1_L = new BaseControls.MyLabel();
            this.trackBar_1 = new System.Windows.Forms.TrackBar();
            this.myTextBox1 = new BaseControls.MyTextBox();
            this.myTextBox2 = new BaseControls.MyTextBox();
            this.label1 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.label4 = new BaseControls.MyLabel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.myTextBox3 = new BaseControls.MyTextBox();
            this.myTextBox4 = new BaseControls.MyTextBox();
            this.label5 = new BaseControls.MyLabel();
            this.label6 = new BaseControls.MyLabel();
            this.label7 = new BaseControls.MyLabel();
            this.label8 = new BaseControls.MyLabel();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.l_track1_Name = new BaseControls.MyLabel();
            this.label9 = new BaseControls.MyLabel();
            this.label10 = new BaseControls.MyLabel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
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
            this.panel4.Size = new System.Drawing.Size(517, 24);
            this.panel4.TabIndex = 50;
            // 
            // btn_Ok
            // 
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ok.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Ok.Location = new System.Drawing.Point(403, 4);
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
            this.label15.Text = "伪彩";
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.Location = new System.Drawing.Point(452, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(49, 19);
            this.button3.TabIndex = 3;
            this.button3.Text = "[关闭]";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tb_PseudocolorPercent
            // 
            this.tb_PseudocolorPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_PseudocolorPercent.Location = new System.Drawing.Point(181, 38);
            this.tb_PseudocolorPercent.MaxLength = 3;
            this.tb_PseudocolorPercent.Name = "tb_PseudocolorPercent";
            this.tb_PseudocolorPercent.ReadOnly = true;
            this.tb_PseudocolorPercent.Size = new System.Drawing.Size(32, 21);
            this.tb_PseudocolorPercent.TabIndex = 100;
            this.tb_PseudocolorPercent.Text = "0";
            // 
            // tb_PseudocolorValue
            // 
            this.tb_PseudocolorValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_PseudocolorValue.Location = new System.Drawing.Point(79, 38);
            this.tb_PseudocolorValue.MaxLength = 4;
            this.tb_PseudocolorValue.Name = "tb_PseudocolorValue";
            this.tb_PseudocolorValue.Size = new System.Drawing.Size(25, 21);
            this.tb_PseudocolorValue.TabIndex = 99;
            this.tb_PseudocolorValue.Text = "0";
            this.tb_PseudocolorValue.TextChanged += new System.EventHandler(this.tb_PseudocolorValue_TextChanged);
            // 
            // drawArea
            // 
            this.drawArea.Image = null;
            this.drawArea.Location = new System.Drawing.Point(292, 30);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(209, 167);
            this.drawArea.TabIndex = 98;
            this.drawArea.Text = "imageFilter1";
            // 
            // lb_Percentage
            // 
            this.lb_Percentage.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_Percentage.Location = new System.Drawing.Point(123, 38);
            this.lb_Percentage.Name = "lb_Percentage";
            this.lb_Percentage.Size = new System.Drawing.Size(60, 22);
            this.lb_Percentage.TabIndex = 97;
            this.lb_Percentage.Text = "百分比：";
            this.lb_Percentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lb_value
            // 
            this.lb_value.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lb_value.Location = new System.Drawing.Point(56, 38);
            this.lb_value.Name = "lb_value";
            this.lb_value.Size = new System.Drawing.Size(29, 22);
            this.lb_value.TabIndex = 96;
            this.lb_value.Text = "值：";
            this.lb_value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_track1_R
            // 
            this.l_track1_R.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_track1_R.Location = new System.Drawing.Point(234, 57);
            this.l_track1_R.Name = "l_track1_R";
            this.l_track1_R.Size = new System.Drawing.Size(39, 23);
            this.l_track1_R.TabIndex = 95;
            this.l_track1_R.Text = "255";
            this.l_track1_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_track1_L
            // 
            this.l_track1_L.ForeColor = System.Drawing.SystemColors.Desktop;
            this.l_track1_L.Location = new System.Drawing.Point(6, 56);
            this.l_track1_L.Name = "l_track1_L";
            this.l_track1_L.Size = new System.Drawing.Size(32, 25);
            this.l_track1_L.TabIndex = 94;
            this.l_track1_L.Text = "0";
            this.l_track1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar_1
            // 
            this.trackBar_1.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.trackBar_1.Location = new System.Drawing.Point(31, 55);
            this.trackBar_1.Name = "trackBar_1";
            this.trackBar_1.Size = new System.Drawing.Size(208, 45);
            this.trackBar_1.TabIndex = 93;
            this.trackBar_1.ValueChanged += new System.EventHandler(this.trackBar_1_ValueChanged);
            // 
            // myTextBox1
            // 
            this.myTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTextBox1.Location = new System.Drawing.Point(180, 90);
            this.myTextBox1.MaxLength = 3;
            this.myTextBox1.Name = "myTextBox1";
            this.myTextBox1.ReadOnly = true;
            this.myTextBox1.Size = new System.Drawing.Size(32, 21);
            this.myTextBox1.TabIndex = 107;
            this.myTextBox1.Text = "0";
            // 
            // myTextBox2
            // 
            this.myTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTextBox2.Location = new System.Drawing.Point(78, 90);
            this.myTextBox2.MaxLength = 4;
            this.myTextBox2.Name = "myTextBox2";
            this.myTextBox2.Size = new System.Drawing.Size(25, 21);
            this.myTextBox2.TabIndex = 106;
            this.myTextBox2.Text = "0";
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(122, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 22);
            this.label1.TabIndex = 105;
            this.label1.Text = "百分比：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(55, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 22);
            this.label2.TabIndex = 104;
            this.label2.Text = "值：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(233, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 23);
            this.label3.TabIndex = 103;
            this.label3.Text = "255";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(5, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 25);
            this.label4.TabIndex = 102;
            this.label4.Text = "0";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar1
            // 
            this.trackBar1.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.trackBar1.Location = new System.Drawing.Point(30, 107);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(208, 45);
            this.trackBar1.TabIndex = 101;
            // 
            // myTextBox3
            // 
            this.myTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTextBox3.Location = new System.Drawing.Point(180, 142);
            this.myTextBox3.MaxLength = 3;
            this.myTextBox3.Name = "myTextBox3";
            this.myTextBox3.ReadOnly = true;
            this.myTextBox3.Size = new System.Drawing.Size(32, 21);
            this.myTextBox3.TabIndex = 114;
            this.myTextBox3.Text = "0";
            // 
            // myTextBox4
            // 
            this.myTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myTextBox4.Location = new System.Drawing.Point(78, 142);
            this.myTextBox4.MaxLength = 4;
            this.myTextBox4.Name = "myTextBox4";
            this.myTextBox4.Size = new System.Drawing.Size(25, 21);
            this.myTextBox4.TabIndex = 113;
            this.myTextBox4.Text = "0";
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label5.Location = new System.Drawing.Point(122, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 22);
            this.label5.TabIndex = 112;
            this.label5.Text = "百分比：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label6.Location = new System.Drawing.Point(55, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 22);
            this.label6.TabIndex = 111;
            this.label6.Text = "值：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(233, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 23);
            this.label7.TabIndex = 110;
            this.label7.Text = "255";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(5, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 25);
            this.label8.TabIndex = 109;
            this.label8.Text = "0";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trackBar2
            // 
            this.trackBar2.Cursor = System.Windows.Forms.Cursors.NoMoveHoriz;
            this.trackBar2.Location = new System.Drawing.Point(30, 159);
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(208, 45);
            this.trackBar2.TabIndex = 108;
            // 
            // l_track1_Name
            // 
            this.l_track1_Name.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.l_track1_Name.Location = new System.Drawing.Point(6, 38);
            this.l_track1_Name.Name = "l_track1_Name";
            this.l_track1_Name.Size = new System.Drawing.Size(35, 18);
            this.l_track1_Name.TabIndex = 115;
            this.l_track1_Name.Text = "R";
            this.l_track1_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(6, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 18);
            this.label9.TabIndex = 116;
            this.label9.Text = "B";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label10.Location = new System.Drawing.Point(6, 90);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 18);
            this.label10.TabIndex = 117;
            this.label10.Text = "G";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pseudocolor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.l_track1_Name);
            this.Controls.Add(this.myTextBox3);
            this.Controls.Add(this.myTextBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.myTextBox1);
            this.Controls.Add(this.myTextBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.tb_PseudocolorPercent);
            this.Controls.Add(this.tb_PseudocolorValue);
            this.Controls.Add(this.drawArea);
            this.Controls.Add(this.lb_Percentage);
            this.Controls.Add(this.lb_value);
            this.Controls.Add(this.l_track1_R);
            this.Controls.Add(this.l_track1_L);
            this.Controls.Add(this.trackBar_1);
            this.Controls.Add(this.panel4);
            this.Name = "Pseudocolor";
            this.Size = new System.Drawing.Size(517, 211);
            this.Load += new System.EventHandler(this.Pseudocolor_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pseudocolor_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pseudocolor_MouseDown);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Button btn_Ok;
        private BaseControls.MyLabel label15;
        public System.Windows.Forms.Button button3;
        private BaseControls.MyTextBox tb_PseudocolorPercent;
        private BaseControls.MyTextBox tb_PseudocolorValue;
        private BaseControls.ImageFilter.ImageFilter drawArea;
        private BaseControls.MyLabel lb_Percentage;
        private BaseControls.MyLabel lb_value;
        private BaseControls.MyLabel l_track1_R;
        private BaseControls.MyLabel l_track1_L;
        private System.Windows.Forms.TrackBar trackBar_1;
        private BaseControls.MyTextBox myTextBox1;
        private BaseControls.MyTextBox myTextBox2;
        private BaseControls.MyLabel label1;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label3;
        private BaseControls.MyLabel label4;
        private System.Windows.Forms.TrackBar trackBar1;
        private BaseControls.MyTextBox myTextBox3;
        private BaseControls.MyTextBox myTextBox4;
        private BaseControls.MyLabel label5;
        private BaseControls.MyLabel label6;
        private BaseControls.MyLabel label7;
        private BaseControls.MyLabel label8;
        private System.Windows.Forms.TrackBar trackBar2;
        private BaseControls.MyLabel l_track1_Name;
        private BaseControls.MyLabel label9;
        private BaseControls.MyLabel label10;
    }
}
