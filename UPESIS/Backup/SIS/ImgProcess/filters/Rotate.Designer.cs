namespace SIS.ImgProcess.filters
{
    partial class Rotate
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
            this.tb_B = new BaseControls.MyTextBox();
            this.tb_G = new BaseControls.MyTextBox();
            this.tb_R = new BaseControls.MyTextBox();
            this.label1 = new BaseControls.MyLabel();
            this.label9 = new BaseControls.MyLabel();
            this.label10 = new BaseControls.MyLabel();
            this.label11 = new BaseControls.MyLabel();
            this.cb_KeepSize = new System.Windows.Forms.CheckBox();
            this.label12 = new BaseControls.MyLabel();
            this.cb_Rotate = new BaseControls.MyTextBox();
            this.label13 = new BaseControls.MyLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.label15 = new BaseControls.MyLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.cb_methodCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new BaseControls.MyLabel();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_B
            // 
            this.tb_B.Location = new System.Drawing.Point(245, 104);
            this.tb_B.Name = "tb_B";
            this.tb_B.Size = new System.Drawing.Size(28, 21);
            this.tb_B.TabIndex = 71;
            this.tb_B.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber2);
            // 
            // tb_G
            // 
            this.tb_G.Location = new System.Drawing.Point(189, 104);
            this.tb_G.Name = "tb_G";
            this.tb_G.Size = new System.Drawing.Size(28, 21);
            this.tb_G.TabIndex = 70;
            this.tb_G.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber2);
            // 
            // tb_R
            // 
            this.tb_R.Location = new System.Drawing.Point(136, 104);
            this.tb_R.Name = "tb_R";
            this.tb_R.Size = new System.Drawing.Size(28, 21);
            this.tb_R.TabIndex = 69;
            this.tb_R.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber2);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 68;
            this.label1.Text = "B：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(165, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 12);
            this.label9.TabIndex = 67;
            this.label9.Text = "G：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(110, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 12);
            this.label10.TabIndex = 66;
            this.label10.Text = "R：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(54, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 65;
            this.label11.Text = "填充色：";
            // 
            // cb_KeepSize
            // 
            this.cb_KeepSize.AutoSize = true;
            this.cb_KeepSize.Location = new System.Drawing.Point(121, 84);
            this.cb_KeepSize.Name = "cb_KeepSize";
            this.cb_KeepSize.Size = new System.Drawing.Size(15, 14);
            this.cb_KeepSize.TabIndex = 64;
            this.cb_KeepSize.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 86);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 63;
            this.label12.Text = "保持原大小：";
            // 
            // cb_Rotate
            // 
            this.cb_Rotate.Location = new System.Drawing.Point(121, 32);
            this.cb_Rotate.Name = "cb_Rotate";
            this.cb_Rotate.Size = new System.Drawing.Size(100, 21);
            this.cb_Rotate.TabIndex = 62;
            this.cb_Rotate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnlyEnterIntNumber);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(42, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 61;
            this.label13.Text = "旋转角度：";
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
            this.panel4.Size = new System.Drawing.Size(279, 24);
            this.panel4.TabIndex = 48;
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
            this.label15.Text = "旋转";
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
            // cb_methodCombo
            // 
            this.cb_methodCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_methodCombo.Items.AddRange(new object[] {
            "Nearest neighbour",
            "Bilinear",
            "Bicubic"});
            this.cb_methodCombo.Location = new System.Drawing.Point(121, 59);
            this.cb_methodCombo.Name = "cb_methodCombo";
            this.cb_methodCombo.Size = new System.Drawing.Size(120, 20);
            this.cb_methodCombo.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 73;
            this.label2.Text = "插补类型：";
            // 
            // Rotate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_methodCombo);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.tb_B);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cb_Rotate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_G);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_R);
            this.Controls.Add(this.cb_KeepSize);
            this.Name = "Rotate";
            this.Size = new System.Drawing.Size(279, 136);
            this.Tag = "Rotate";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Rotate_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Rotate_MouseDown);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseControls.MyTextBox tb_B;
        private BaseControls.MyTextBox tb_G;
        private BaseControls.MyTextBox tb_R;
        private BaseControls.MyLabel label1;
        private BaseControls.MyLabel label9;
        private BaseControls.MyLabel label10;
        private BaseControls.MyLabel label11;
        private System.Windows.Forms.CheckBox cb_KeepSize;
        private BaseControls.MyLabel label12;
        private BaseControls.MyTextBox cb_Rotate;
        private BaseControls.MyLabel label13;
        private System.Windows.Forms.Panel panel4;
        private BaseControls.MyLabel label15;
        public System.Windows.Forms.Button button3;
        public System.Windows.Forms.Button btn_Ok;
        private BaseControls.MyLabel label2;
        private System.Windows.Forms.ComboBox cb_methodCombo;
    }
}
