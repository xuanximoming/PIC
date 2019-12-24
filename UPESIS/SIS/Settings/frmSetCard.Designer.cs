namespace SIS
{
    partial class frmSetCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetCard));
            this.myGroupBox1 = new BaseControls.GroupBox.MyGroupBox();
            this.cmb_CardProduct = new BaseControls.ComboBoxs.MyComboBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.myLabel4 = new BaseControls.MyLabel();
            this.myLabel3 = new BaseControls.MyLabel();
            this.myLabel2 = new BaseControls.MyLabel();
            this.myLabel1 = new BaseControls.MyLabel();
            this.txt_CardExe = new BaseControls.MyTextBox();
            this.txt_Quality = new BaseControls.MyTextBox();
            this.txt_CardType = new BaseControls.MyTextBox();
            this.myGroupBox2 = new BaseControls.GroupBox.MyGroupBox();
            this.cmb_PressD = new BaseControls.ComboBoxs.MyComboBox();
            this.cmb_PressC = new BaseControls.ComboBoxs.MyComboBox();
            this.cmb_PressB = new BaseControls.ComboBoxs.MyComboBox();
            this.cmb_PressA = new BaseControls.ComboBoxs.MyComboBox();
            this.cb_CommMode = new BaseControls.ComboBoxs.MyComboBox();
            this.cb_Port = new BaseControls.ComboBoxs.MyComboBox();
            this.myLabel11 = new BaseControls.MyLabel();
            this.myLabel10 = new BaseControls.MyLabel();
            this.myLabel9 = new BaseControls.MyLabel();
            this.myLabel15 = new BaseControls.MyLabel();
            this.myLabel14 = new BaseControls.MyLabel();
            this.myLabel13 = new BaseControls.MyLabel();
            this.myLabel12 = new BaseControls.MyLabel();
            this.myLabel8 = new BaseControls.MyLabel();
            this.myLabel7 = new BaseControls.MyLabel();
            this.myLabel6 = new BaseControls.MyLabel();
            this.myLabel5 = new BaseControls.MyLabel();
            this.txt_DataBits = new BaseControls.MyTextBox();
            this.txt_BaudRate = new BaseControls.MyTextBox();
            this.btn_Cancel = new BaseControls.Buttons.VistaButton();
            this.btn_Ok = new BaseControls.Buttons.VistaButton();
            this.opFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.cb_PerlinNoise_Yes = new System.Windows.Forms.CheckBox();
            this.cb_PerlinNoise_No = new System.Windows.Forms.CheckBox();
            this.cb_IsUse_Yes = new System.Windows.Forms.CheckBox();
            this.cb_IsUse_No = new System.Windows.Forms.CheckBox();
            this.myGroupBox1.SuspendLayout();
            this.myGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.myGroupBox1.BackgroundGradientColor = System.Drawing.Color.White;
            this.myGroupBox1.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.myGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.myGroupBox1.BorderThickness = 1F;
            this.myGroupBox1.Controls.Add(this.cmb_CardProduct);
            this.myGroupBox1.Controls.Add(this.btn_Open);
            this.myGroupBox1.Controls.Add(this.myLabel4);
            this.myGroupBox1.Controls.Add(this.myLabel3);
            this.myGroupBox1.Controls.Add(this.myLabel2);
            this.myGroupBox1.Controls.Add(this.myLabel1);
            this.myGroupBox1.Controls.Add(this.txt_CardExe);
            this.myGroupBox1.Controls.Add(this.txt_Quality);
            this.myGroupBox1.Controls.Add(this.txt_CardType);
            this.myGroupBox1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.myGroupBox1.GroupImage = null;
            this.myGroupBox1.GroupTitle = "采集卡配置";
            this.myGroupBox1.Location = new System.Drawing.Point(23, 21);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Padding = new System.Windows.Forms.Padding(20);
            this.myGroupBox1.PaintGroupBox = false;
            this.myGroupBox1.RoundCorners = 10;
            this.myGroupBox1.ShadowColor = System.Drawing.Color.DarkGray;
            this.myGroupBox1.ShadowControl = false;
            this.myGroupBox1.ShadowThickness = 3;
            this.myGroupBox1.Size = new System.Drawing.Size(534, 103);
            this.myGroupBox1.TabIndex = 0;
            // 
            // cmb_CardProduct
            // 
            this.cmb_CardProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CardProduct.FormattingEnabled = true;
            this.cmb_CardProduct.Location = new System.Drawing.Point(94, 28);
            this.cmb_CardProduct.Name = "cmb_CardProduct";
            this.cmb_CardProduct.Size = new System.Drawing.Size(94, 20);
            this.cmb_CardProduct.TabIndex = 4;
            // 
            // btn_Open
            // 
            this.btn_Open.Location = new System.Drawing.Point(473, 62);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(38, 20);
            this.btn_Open.TabIndex = 3;
            this.btn_Open.Text = "打开";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // myLabel4
            // 
            this.myLabel4.AutoSize = true;
            this.myLabel4.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel4.ForeColor = System.Drawing.Color.Black;
            this.myLabel4.Location = new System.Drawing.Point(361, 35);
            this.myLabel4.Name = "myLabel4";
            this.myLabel4.Size = new System.Drawing.Size(65, 12);
            this.myLabel4.TabIndex = 2;
            this.myLabel4.Text = "图像质量：";
            // 
            // myLabel3
            // 
            this.myLabel3.AutoSize = true;
            this.myLabel3.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel3.ForeColor = System.Drawing.Color.Black;
            this.myLabel3.Location = new System.Drawing.Point(23, 70);
            this.myLabel3.Name = "myLabel3";
            this.myLabel3.Size = new System.Drawing.Size(65, 12);
            this.myLabel3.TabIndex = 2;
            this.myLabel3.Text = "配置程序：";
            // 
            // myLabel2
            // 
            this.myLabel2.AutoSize = true;
            this.myLabel2.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel2.ForeColor = System.Drawing.Color.Black;
            this.myLabel2.Location = new System.Drawing.Point(193, 35);
            this.myLabel2.Name = "myLabel2";
            this.myLabel2.Size = new System.Drawing.Size(41, 12);
            this.myLabel2.TabIndex = 2;
            this.myLabel2.Text = "型号：";
            // 
            // myLabel1
            // 
            this.myLabel1.AutoSize = true;
            this.myLabel1.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel1.ForeColor = System.Drawing.Color.Black;
            this.myLabel1.Location = new System.Drawing.Point(23, 35);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.Size = new System.Drawing.Size(41, 12);
            this.myLabel1.TabIndex = 2;
            this.myLabel1.Text = "厂家：";
            // 
            // txt_CardExe
            // 
            this.txt_CardExe.Enabled = false;
            this.txt_CardExe.Location = new System.Drawing.Point(94, 61);
            this.txt_CardExe.Name = "txt_CardExe";
            this.txt_CardExe.Size = new System.Drawing.Size(373, 21);
            this.txt_CardExe.TabIndex = 1;
            // 
            // txt_Quality
            // 
            this.txt_Quality.Location = new System.Drawing.Point(432, 28);
            this.txt_Quality.Name = "txt_Quality";
            this.txt_Quality.Size = new System.Drawing.Size(79, 21);
            this.txt_Quality.TabIndex = 1;
            // 
            // txt_CardType
            // 
            this.txt_CardType.Location = new System.Drawing.Point(240, 28);
            this.txt_CardType.Name = "txt_CardType";
            this.txt_CardType.Size = new System.Drawing.Size(108, 21);
            this.txt_CardType.TabIndex = 1;
            // 
            // myGroupBox2
            // 
            this.myGroupBox2.BackgroundColor = System.Drawing.Color.White;
            this.myGroupBox2.BackgroundGradientColor = System.Drawing.Color.White;
            this.myGroupBox2.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.myGroupBox2.BorderColor = System.Drawing.Color.Black;
            this.myGroupBox2.BorderThickness = 1F;
            this.myGroupBox2.Controls.Add(this.cb_IsUse_No);
            this.myGroupBox2.Controls.Add(this.cb_PerlinNoise_No);
            this.myGroupBox2.Controls.Add(this.cb_IsUse_Yes);
            this.myGroupBox2.Controls.Add(this.cb_PerlinNoise_Yes);
            this.myGroupBox2.Controls.Add(this.cmb_PressD);
            this.myGroupBox2.Controls.Add(this.cmb_PressC);
            this.myGroupBox2.Controls.Add(this.cmb_PressB);
            this.myGroupBox2.Controls.Add(this.cmb_PressA);
            this.myGroupBox2.Controls.Add(this.cb_CommMode);
            this.myGroupBox2.Controls.Add(this.cb_Port);
            this.myGroupBox2.Controls.Add(this.myLabel11);
            this.myGroupBox2.Controls.Add(this.myLabel10);
            this.myGroupBox2.Controls.Add(this.myLabel9);
            this.myGroupBox2.Controls.Add(this.myLabel15);
            this.myGroupBox2.Controls.Add(this.myLabel14);
            this.myGroupBox2.Controls.Add(this.myLabel13);
            this.myGroupBox2.Controls.Add(this.myLabel12);
            this.myGroupBox2.Controls.Add(this.myLabel8);
            this.myGroupBox2.Controls.Add(this.myLabel7);
            this.myGroupBox2.Controls.Add(this.myLabel6);
            this.myGroupBox2.Controls.Add(this.myLabel5);
            this.myGroupBox2.Controls.Add(this.txt_DataBits);
            this.myGroupBox2.Controls.Add(this.txt_BaudRate);
            this.myGroupBox2.CustomGroupBoxColor = System.Drawing.Color.White;
            this.myGroupBox2.GroupImage = null;
            this.myGroupBox2.GroupTitle = "串口配置";
            this.myGroupBox2.Location = new System.Drawing.Point(23, 143);
            this.myGroupBox2.Name = "myGroupBox2";
            this.myGroupBox2.Padding = new System.Windows.Forms.Padding(20);
            this.myGroupBox2.PaintGroupBox = false;
            this.myGroupBox2.RoundCorners = 10;
            this.myGroupBox2.ShadowColor = System.Drawing.Color.DarkGray;
            this.myGroupBox2.ShadowControl = false;
            this.myGroupBox2.ShadowThickness = 3;
            this.myGroupBox2.Size = new System.Drawing.Size(534, 210);
            this.myGroupBox2.TabIndex = 0;
            // 
            // cmb_PressD
            // 
            this.cmb_PressD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PressD.FormattingEnabled = true;
            this.cmb_PressD.Location = new System.Drawing.Point(308, 176);
            this.cmb_PressD.Name = "cmb_PressD";
            this.cmb_PressD.Size = new System.Drawing.Size(118, 20);
            this.cmb_PressD.TabIndex = 4;
            // 
            // cmb_PressC
            // 
            this.cmb_PressC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PressC.FormattingEnabled = true;
            this.cmb_PressC.Location = new System.Drawing.Point(94, 173);
            this.cmb_PressC.Name = "cmb_PressC";
            this.cmb_PressC.Size = new System.Drawing.Size(120, 20);
            this.cmb_PressC.TabIndex = 4;
            // 
            // cmb_PressB
            // 
            this.cmb_PressB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PressB.FormattingEnabled = true;
            this.cmb_PressB.Location = new System.Drawing.Point(308, 147);
            this.cmb_PressB.Name = "cmb_PressB";
            this.cmb_PressB.Size = new System.Drawing.Size(118, 20);
            this.cmb_PressB.TabIndex = 4;
            // 
            // cmb_PressA
            // 
            this.cmb_PressA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PressA.FormattingEnabled = true;
            this.cmb_PressA.Location = new System.Drawing.Point(94, 142);
            this.cmb_PressA.Name = "cmb_PressA";
            this.cmb_PressA.Size = new System.Drawing.Size(120, 20);
            this.cmb_PressA.TabIndex = 4;
            // 
            // cb_CommMode
            // 
            this.cb_CommMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CommMode.FormattingEnabled = true;
            this.cb_CommMode.Location = new System.Drawing.Point(94, 66);
            this.cb_CommMode.Name = "cb_CommMode";
            this.cb_CommMode.Size = new System.Drawing.Size(94, 20);
            this.cb_CommMode.TabIndex = 4;
            // 
            // cb_Port
            // 
            this.cb_Port.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Port.FormattingEnabled = true;
            this.cb_Port.Location = new System.Drawing.Point(332, 35);
            this.cb_Port.Name = "cb_Port";
            this.cb_Port.Size = new System.Drawing.Size(94, 20);
            this.cb_Port.TabIndex = 4;
            // 
            // myLabel11
            // 
            this.myLabel11.AutoSize = true;
            this.myLabel11.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel11.ForeColor = System.Drawing.Color.Black;
            this.myLabel11.Location = new System.Drawing.Point(23, 124);
            this.myLabel11.Name = "myLabel11";
            this.myLabel11.Size = new System.Drawing.Size(53, 12);
            this.myLabel11.TabIndex = 2;
            this.myLabel11.Text = "键位图：";
            // 
            // myLabel10
            // 
            this.myLabel10.AutoSize = true;
            this.myLabel10.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel10.ForeColor = System.Drawing.Color.Black;
            this.myLabel10.Location = new System.Drawing.Point(273, 70);
            this.myLabel10.Name = "myLabel10";
            this.myLabel10.Size = new System.Drawing.Size(41, 12);
            this.myLabel10.TabIndex = 2;
            this.myLabel10.Text = "去噪：";
            // 
            // myLabel9
            // 
            this.myLabel9.AutoSize = true;
            this.myLabel9.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel9.ForeColor = System.Drawing.Color.Black;
            this.myLabel9.Location = new System.Drawing.Point(273, 104);
            this.myLabel9.Name = "myLabel9";
            this.myLabel9.Size = new System.Drawing.Size(53, 12);
            this.myLabel9.TabIndex = 2;
            this.myLabel9.Text = "数据位：";
            // 
            // myLabel15
            // 
            this.myLabel15.AutoSize = true;
            this.myLabel15.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel15.ForeColor = System.Drawing.Color.Black;
            this.myLabel15.Location = new System.Drawing.Point(238, 176);
            this.myLabel15.Name = "myLabel15";
            this.myLabel15.Size = new System.Drawing.Size(47, 12);
            this.myLabel15.TabIndex = 2;
            this.myLabel15.Text = "按键4：";
            // 
            // myLabel14
            // 
            this.myLabel14.AutoSize = true;
            this.myLabel14.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel14.ForeColor = System.Drawing.Color.Black;
            this.myLabel14.Location = new System.Drawing.Point(238, 150);
            this.myLabel14.Name = "myLabel14";
            this.myLabel14.Size = new System.Drawing.Size(47, 12);
            this.myLabel14.TabIndex = 2;
            this.myLabel14.Text = "按键3：";
            // 
            // myLabel13
            // 
            this.myLabel13.AutoSize = true;
            this.myLabel13.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel13.ForeColor = System.Drawing.Color.Black;
            this.myLabel13.Location = new System.Drawing.Point(35, 176);
            this.myLabel13.Name = "myLabel13";
            this.myLabel13.Size = new System.Drawing.Size(47, 12);
            this.myLabel13.TabIndex = 2;
            this.myLabel13.Text = "按键3：";
            // 
            // myLabel12
            // 
            this.myLabel12.AutoSize = true;
            this.myLabel12.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel12.ForeColor = System.Drawing.Color.Black;
            this.myLabel12.Location = new System.Drawing.Point(35, 150);
            this.myLabel12.Name = "myLabel12";
            this.myLabel12.Size = new System.Drawing.Size(47, 12);
            this.myLabel12.TabIndex = 2;
            this.myLabel12.Text = "按键1：";
            // 
            // myLabel8
            // 
            this.myLabel8.AutoSize = true;
            this.myLabel8.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel8.ForeColor = System.Drawing.Color.Black;
            this.myLabel8.Location = new System.Drawing.Point(23, 103);
            this.myLabel8.Name = "myLabel8";
            this.myLabel8.Size = new System.Drawing.Size(53, 12);
            this.myLabel8.TabIndex = 2;
            this.myLabel8.Text = "比特率：";
            // 
            // myLabel7
            // 
            this.myLabel7.AutoSize = true;
            this.myLabel7.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel7.ForeColor = System.Drawing.Color.Black;
            this.myLabel7.Location = new System.Drawing.Point(273, 39);
            this.myLabel7.Name = "myLabel7";
            this.myLabel7.Size = new System.Drawing.Size(53, 12);
            this.myLabel7.TabIndex = 2;
            this.myLabel7.Text = "串口号：";
            // 
            // myLabel6
            // 
            this.myLabel6.AutoSize = true;
            this.myLabel6.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel6.ForeColor = System.Drawing.Color.Black;
            this.myLabel6.Location = new System.Drawing.Point(23, 70);
            this.myLabel6.Name = "myLabel6";
            this.myLabel6.Size = new System.Drawing.Size(65, 12);
            this.myLabel6.TabIndex = 2;
            this.myLabel6.Text = "采集方式：";
            // 
            // myLabel5
            // 
            this.myLabel5.AutoSize = true;
            this.myLabel5.Font = new System.Drawing.Font("宋体", 9F);
            this.myLabel5.ForeColor = System.Drawing.Color.Black;
            this.myLabel5.Location = new System.Drawing.Point(23, 39);
            this.myLabel5.Name = "myLabel5";
            this.myLabel5.Size = new System.Drawing.Size(65, 12);
            this.myLabel5.TabIndex = 2;
            this.myLabel5.Text = "启用串口：";
            // 
            // txt_DataBits
            // 
            this.txt_DataBits.Location = new System.Drawing.Point(332, 98);
            this.txt_DataBits.Name = "txt_DataBits";
            this.txt_DataBits.Size = new System.Drawing.Size(94, 21);
            this.txt_DataBits.TabIndex = 1;
            // 
            // txt_BaudRate
            // 
            this.txt_BaudRate.Location = new System.Drawing.Point(94, 98);
            this.txt_BaudRate.Name = "txt_BaudRate";
            this.txt_BaudRate.Size = new System.Drawing.Size(94, 21);
            this.txt_BaudRate.TabIndex = 1;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Cancel.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Cancel.ButtonText = "取消";
            this.btn_Cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Cancel.Location = new System.Drawing.Point(358, 374);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(67, 32);
            this.btn_Cancel.TabIndex = 7;
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Ok.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Ok.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Ok.ButtonText = "确定";
            this.btn_Ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ok.Image")));
            this.btn_Ok.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Ok.Location = new System.Drawing.Point(144, 374);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(67, 32);
            this.btn_Ok.TabIndex = 6;
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // cb_PerlinNoise_Yes
            // 
            this.cb_PerlinNoise_Yes.AutoSize = true;
            this.cb_PerlinNoise_Yes.Location = new System.Drawing.Point(335, 70);
            this.cb_PerlinNoise_Yes.Name = "cb_PerlinNoise_Yes";
            this.cb_PerlinNoise_Yes.Size = new System.Drawing.Size(36, 16);
            this.cb_PerlinNoise_Yes.TabIndex = 5;
            this.cb_PerlinNoise_Yes.Text = "是";
            this.cb_PerlinNoise_Yes.UseVisualStyleBackColor = true;
            this.cb_PerlinNoise_Yes.CheckedChanged += new System.EventHandler(this.cb_PerlinNoise_Yes_CheckedChanged);
            // 
            // cb_PerlinNoise_No
            // 
            this.cb_PerlinNoise_No.AutoSize = true;
            this.cb_PerlinNoise_No.Location = new System.Drawing.Point(390, 69);
            this.cb_PerlinNoise_No.Name = "cb_PerlinNoise_No";
            this.cb_PerlinNoise_No.Size = new System.Drawing.Size(36, 16);
            this.cb_PerlinNoise_No.TabIndex = 5;
            this.cb_PerlinNoise_No.Text = "否";
            this.cb_PerlinNoise_No.UseVisualStyleBackColor = true;
            this.cb_PerlinNoise_No.CheckedChanged += new System.EventHandler(this.cb_PerlinNoise_No_CheckedChanged);
            // 
            // cb_IsUse_Yes
            // 
            this.cb_IsUse_Yes.AutoSize = true;
            this.cb_IsUse_Yes.Location = new System.Drawing.Point(97, 36);
            this.cb_IsUse_Yes.Name = "cb_IsUse_Yes";
            this.cb_IsUse_Yes.Size = new System.Drawing.Size(36, 16);
            this.cb_IsUse_Yes.TabIndex = 5;
            this.cb_IsUse_Yes.Text = "是";
            this.cb_IsUse_Yes.UseVisualStyleBackColor = true;
            this.cb_IsUse_Yes.CheckedChanged += new System.EventHandler(this.cb_IsUse_Yes_CheckedChanged);
            // 
            // cb_IsUse_No
            // 
            this.cb_IsUse_No.AutoSize = true;
            this.cb_IsUse_No.Location = new System.Drawing.Point(152, 35);
            this.cb_IsUse_No.Name = "cb_IsUse_No";
            this.cb_IsUse_No.Size = new System.Drawing.Size(36, 16);
            this.cb_IsUse_No.TabIndex = 5;
            this.cb_IsUse_No.Text = "否";
            this.cb_IsUse_No.UseVisualStyleBackColor = true;
            this.cb_IsUse_No.CheckedChanged += new System.EventHandler(this.cb_IsUse_No_CheckedChanged);
            // 
            // frmSetCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 438);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.myGroupBox2);
            this.Controls.Add(this.myGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "采集卡设置";
            this.Load += new System.EventHandler(this.frmSetCard_Load);
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox1.PerformLayout();
            this.myGroupBox2.ResumeLayout(false);
            this.myGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.GroupBox.MyGroupBox myGroupBox1;
        private BaseControls.GroupBox.MyGroupBox myGroupBox2;
        private BaseControls.Buttons.VistaButton btn_Cancel;
        private BaseControls.Buttons.VistaButton btn_Ok;
        private BaseControls.MyLabel myLabel1;
        private BaseControls.MyTextBox txt_CardType;
        private BaseControls.MyLabel myLabel2;
        private BaseControls.MyLabel myLabel3;
        private BaseControls.MyLabel myLabel4;
        private System.Windows.Forms.Button btn_Open;
        private BaseControls.MyTextBox txt_CardExe;
        private BaseControls.MyTextBox txt_Quality;
        private BaseControls.MyLabel myLabel5;
        private System.Windows.Forms.OpenFileDialog opFileDlg;
        private BaseControls.MyLabel myLabel6;
        private BaseControls.MyLabel myLabel8;
        private BaseControls.MyLabel myLabel7;
        private BaseControls.MyLabel myLabel9;
        private BaseControls.MyLabel myLabel10;
        private BaseControls.MyLabel myLabel11;
        private BaseControls.MyTextBox txt_BaudRate;
        private BaseControls.ComboBoxs.MyComboBox cmb_CardProduct;
        private BaseControls.ComboBoxs.MyComboBox cmb_PressD;
        private BaseControls.ComboBoxs.MyComboBox cmb_PressC;
        private BaseControls.ComboBoxs.MyComboBox cmb_PressB;
        private BaseControls.ComboBoxs.MyComboBox cmb_PressA;
        private BaseControls.ComboBoxs.MyComboBox cb_CommMode;
        private BaseControls.ComboBoxs.MyComboBox cb_Port;
        private BaseControls.MyLabel myLabel15;
        private BaseControls.MyLabel myLabel14;
        private BaseControls.MyLabel myLabel13;
        private BaseControls.MyLabel myLabel12;
        private BaseControls.MyTextBox txt_DataBits;
        private System.Windows.Forms.CheckBox cb_PerlinNoise_Yes;
        private System.Windows.Forms.CheckBox cb_PerlinNoise_No;
        private System.Windows.Forms.CheckBox cb_IsUse_No;
        private System.Windows.Forms.CheckBox cb_IsUse_Yes;
    }
}