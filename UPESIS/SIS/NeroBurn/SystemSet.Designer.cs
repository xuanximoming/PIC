namespace SIS.NeroBurn
{
    partial class SystemSet
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
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Default = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.myGroupBox1 = new BaseControls.GroupBox.MyGroupBox();
            this.cmb_Number = new BaseControls.ComboBoxs.MyComboBox();
            this.label4 = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.txt_VKheader = new System.Windows.Forms.TextBox();
            this.label36 = new BaseControls.MyLabel();
            this.label34 = new BaseControls.MyLabel();
            this.myGroupBox2 = new BaseControls.GroupBox.MyGroupBox();
            this.cmb_DayNum = new BaseControls.ComboBoxs.MyComboBox();
            this.label1 = new BaseControls.MyLabel();
            this.myGroupBox1.SuspendLayout();
            this.myGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(25, 227);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 28);
            this.btn_Save.TabIndex = 172;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Default
            // 
            this.btn_Default.Location = new System.Drawing.Point(140, 227);
            this.btn_Default.Name = "btn_Default";
            this.btn_Default.Size = new System.Drawing.Size(75, 28);
            this.btn_Default.TabIndex = 172;
            this.btn_Default.Text = "默认";
            this.btn_Default.UseVisualStyleBackColor = true;
            this.btn_Default.Click += new System.EventHandler(this.btn_Default_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(255, 227);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 28);
            this.btn_Exit.TabIndex = 172;
            this.btn_Exit.Text = "退出";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.myGroupBox1.BackgroundGradientColor = System.Drawing.Color.White;
            this.myGroupBox1.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.myGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.myGroupBox1.BorderThickness = 1F;
            this.myGroupBox1.Controls.Add(this.cmb_Number);
            this.myGroupBox1.Controls.Add(this.label4);
            this.myGroupBox1.Controls.Add(this.label3);
            this.myGroupBox1.Controls.Add(this.txt_VKheader);
            this.myGroupBox1.Controls.Add(this.label36);
            this.myGroupBox1.Controls.Add(this.label34);
            this.myGroupBox1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.myGroupBox1.GroupImage = null;
            this.myGroupBox1.GroupTitle = "卷标设置";
            this.myGroupBox1.Location = new System.Drawing.Point(12, 6);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Padding = new System.Windows.Forms.Padding(20);
            this.myGroupBox1.PaintGroupBox = false;
            this.myGroupBox1.RoundCorners = 10;
            this.myGroupBox1.ShadowColor = System.Drawing.Color.DarkGray;
            this.myGroupBox1.ShadowControl = false;
            this.myGroupBox1.ShadowThickness = 3;
            this.myGroupBox1.Size = new System.Drawing.Size(352, 114);
            this.myGroupBox1.TabIndex = 173;
            // 
            // cmb_Number
            // 
            this.cmb_Number.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Number.FormattingEnabled = true;
            this.cmb_Number.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "6",
            "8"});
            this.cmb_Number.Location = new System.Drawing.Point(102, 77);
            this.cmb_Number.Name = "cmb_Number";
            this.cmb_Number.Size = new System.Drawing.Size(108, 20);
            this.cmb_Number.TabIndex = 159;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(216, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 158;
            this.label4.Text = "请选择显示数字位数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(216, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 12);
            this.label3.TabIndex = 157;
            this.label3.Text = "小于4个字符";
            // 
            // txt_VKheader
            // 
            this.txt_VKheader.Location = new System.Drawing.Point(102, 37);
            this.txt_VKheader.Name = "txt_VKheader";
            this.txt_VKheader.Size = new System.Drawing.Size(108, 21);
            this.txt_VKheader.TabIndex = 156;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(23, 82);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 12);
            this.label36.TabIndex = 154;
            this.label36.Text = "数字位区：";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(23, 42);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 12);
            this.label34.TabIndex = 155;
            this.label34.Text = "卷标头：";
            // 
            // myGroupBox2
            // 
            this.myGroupBox2.BackgroundColor = System.Drawing.Color.White;
            this.myGroupBox2.BackgroundGradientColor = System.Drawing.Color.White;
            this.myGroupBox2.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.myGroupBox2.BorderColor = System.Drawing.Color.Black;
            this.myGroupBox2.BorderThickness = 1F;
            this.myGroupBox2.Controls.Add(this.cmb_DayNum);
            this.myGroupBox2.Controls.Add(this.label1);
            this.myGroupBox2.CustomGroupBoxColor = System.Drawing.Color.White;
            this.myGroupBox2.GroupImage = null;
            this.myGroupBox2.GroupTitle = "时间段设置";
            this.myGroupBox2.Location = new System.Drawing.Point(12, 137);
            this.myGroupBox2.Name = "myGroupBox2";
            this.myGroupBox2.Padding = new System.Windows.Forms.Padding(20);
            this.myGroupBox2.PaintGroupBox = false;
            this.myGroupBox2.RoundCorners = 10;
            this.myGroupBox2.ShadowColor = System.Drawing.Color.DarkGray;
            this.myGroupBox2.ShadowControl = false;
            this.myGroupBox2.ShadowThickness = 3;
            this.myGroupBox2.Size = new System.Drawing.Size(352, 72);
            this.myGroupBox2.TabIndex = 173;
            // 
            // cmb_DayNum
            // 
            this.cmb_DayNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DayNum.FormattingEnabled = true;
            this.cmb_DayNum.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "6",
            "8"});
            this.cmb_DayNum.Location = new System.Drawing.Point(102, 37);
            this.cmb_DayNum.Name = "cmb_DayNum";
            this.cmb_DayNum.Size = new System.Drawing.Size(108, 20);
            this.cmb_DayNum.TabIndex = 161;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 160;
            this.label1.Text = "默认天数：";
            // 
            // SystemSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(379, 267);
            this.Controls.Add(this.myGroupBox2);
            this.Controls.Add(this.myGroupBox1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_Default);
            this.Controls.Add(this.btn_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.VolumeKeySetting_Load);
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox1.PerformLayout();
            this.myGroupBox2.ResumeLayout(false);
            this.myGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Default;
        private System.Windows.Forms.Button btn_Exit;
        private BaseControls.GroupBox.MyGroupBox myGroupBox1;
        private BaseControls.ComboBoxs.MyComboBox cmb_Number;
        private BaseControls.MyLabel label4;
        private BaseControls.MyLabel label3;
        private System.Windows.Forms.TextBox txt_VKheader;
        private BaseControls.MyLabel label36;
        private BaseControls.MyLabel label34;
        private BaseControls.GroupBox.MyGroupBox myGroupBox2;
        private BaseControls.ComboBoxs.MyComboBox cmb_DayNum;
        private BaseControls.MyLabel label1;
    }
}