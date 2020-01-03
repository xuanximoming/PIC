namespace SIS
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbHospitalName = new BaseControls.MyLabel();
            this.label1 = new BaseControls.MyLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new BaseControls.MyLabel();
            this.p_LoginMain = new System.Windows.Forms.Panel();
            this.cmb_ImgEquipment = new System.Windows.Forms.ComboBox();
            this.l_Notice = new BaseControls.MyLabel();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.txt_DoctorId = new System.Windows.Forms.TextBox();
            this.l_ImgEquipment = new BaseControls.MyLabel();
            this.l_Pwd = new BaseControls.MyLabel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_LoginCancel = new System.Windows.Forms.Button();
            this.p_Lock = new System.Windows.Forms.Panel();
            this.btn_Exit = new BaseControls.Buttons.VistaButton();
            this.btn_LockSetting = new BaseControls.Buttons.VistaButton();
            this.btn_UnLock = new BaseControls.Buttons.VistaButton();
            this.p_Setting = new System.Windows.Forms.Panel();
            this.txt_Minute = new BaseControls.NumberText();
            this.btn_Cancel = new BaseControls.Buttons.VistaButton();
            this.btn_Save = new BaseControls.Buttons.VistaButton();
            this.label4 = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.cb_AutoLock = new System.Windows.Forms.CheckBox();
            this.p_Validity = new System.Windows.Forms.Panel();
            this.btn_Cancel2 = new BaseControls.Buttons.VistaButton();
            this.btn_Ok = new BaseControls.Buttons.VistaButton();
            this.p_LoginButtons = new System.Windows.Forms.Panel();
            this.btn_Close = new BaseControls.Buttons.VistaButton();
            this.llb_ChangePwd = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.p_LoginMain.SuspendLayout();
            this.p_Lock.SuspendLayout();
            this.p_Setting.SuspendLayout();
            this.p_Validity.SuspendLayout();
            this.p_LoginButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lbHospitalName);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(339, 26);
            this.panel1.TabIndex = 0;
            // 
            // lbHospitalName
            // 
            this.lbHospitalName.AutoSize = true;
            this.lbHospitalName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHospitalName.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHospitalName.ForeColor = System.Drawing.Color.Indigo;
            this.lbHospitalName.Location = new System.Drawing.Point(0, 0);
            this.lbHospitalName.Name = "lbHospitalName";
            this.lbHospitalName.Size = new System.Drawing.Size(56, 16);
            this.lbHospitalName.TabIndex = 0;
            this.lbHospitalName.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("STXingkai", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(69, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "FPAX";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(101, 240);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(278, 29);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "工  号：";
            // 
            // p_LoginMain
            // 
            this.p_LoginMain.BackColor = System.Drawing.Color.Transparent;
            this.p_LoginMain.Controls.Add(this.cmb_ImgEquipment);
            this.p_LoginMain.Controls.Add(this.l_Notice);
            this.p_LoginMain.Controls.Add(this.txt_Pwd);
            this.p_LoginMain.Controls.Add(this.txt_DoctorId);
            this.p_LoginMain.Controls.Add(this.l_ImgEquipment);
            this.p_LoginMain.Controls.Add(this.l_Pwd);
            this.p_LoginMain.Controls.Add(this.label2);
            this.p_LoginMain.Location = new System.Drawing.Point(209, 72);
            this.p_LoginMain.Name = "p_LoginMain";
            this.p_LoginMain.Size = new System.Drawing.Size(269, 100);
            this.p_LoginMain.TabIndex = 5;
            // 
            // cmb_ImgEquipment
            // 
            this.cmb_ImgEquipment.FormattingEnabled = true;
            this.cmb_ImgEquipment.Location = new System.Drawing.Point(70, 76);
            this.cmb_ImgEquipment.Name = "cmb_ImgEquipment";
            this.cmb_ImgEquipment.Size = new System.Drawing.Size(127, 20);
            this.cmb_ImgEquipment.TabIndex = 7;
            this.cmb_ImgEquipment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            // 
            // l_Notice
            // 
            this.l_Notice.AutoSize = true;
            this.l_Notice.BackColor = System.Drawing.Color.Transparent;
            this.l_Notice.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Notice.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.l_Notice.Location = new System.Drawing.Point(200, 20);
            this.l_Notice.Name = "l_Notice";
            this.l_Notice.Size = new System.Drawing.Size(59, 16);
            this.l_Notice.TabIndex = 10;
            this.l_Notice.Text = "已登录";
            this.l_Notice.Visible = false;
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_Pwd.Location = new System.Drawing.Point(70, 46);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.PasswordChar = '*';
            this.txt_Pwd.Size = new System.Drawing.Size(127, 21);
            this.txt_Pwd.TabIndex = 6;
            this.txt_Pwd.Text = "1";
            this.txt_Pwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            // 
            // txt_DoctorId
            // 
            this.txt_DoctorId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_DoctorId.Location = new System.Drawing.Point(70, 16);
            this.txt_DoctorId.Name = "txt_DoctorId";
            this.txt_DoctorId.Size = new System.Drawing.Size(127, 21);
            this.txt_DoctorId.TabIndex = 5;
            this.txt_DoctorId.Text = "0068";
            this.txt_DoctorId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            // 
            // l_ImgEquipment
            // 
            this.l_ImgEquipment.AutoSize = true;
            this.l_ImgEquipment.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_ImgEquipment.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.l_ImgEquipment.Location = new System.Drawing.Point(3, 77);
            this.l_ImgEquipment.Name = "l_ImgEquipment";
            this.l_ImgEquipment.Size = new System.Drawing.Size(77, 16);
            this.l_ImgEquipment.TabIndex = 4;
            this.l_ImgEquipment.Text = "设  备：";
            // 
            // l_Pwd
            // 
            this.l_Pwd.AutoSize = true;
            this.l_Pwd.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Pwd.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.l_Pwd.Location = new System.Drawing.Point(3, 48);
            this.l_Pwd.Name = "l_Pwd";
            this.l_Pwd.Size = new System.Drawing.Size(77, 16);
            this.l_Pwd.TabIndex = 3;
            this.l_Pwd.Text = "密  码：";
            // 
            // btn_Login
            // 
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Login.Location = new System.Drawing.Point(15, 6);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(70, 28);
            this.btn_Login.TabIndex = 8;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btn_LoginCancel
            // 
            this.btn_LoginCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_LoginCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LoginCancel.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LoginCancel.Location = new System.Drawing.Point(100, 6);
            this.btn_LoginCancel.Name = "btn_LoginCancel";
            this.btn_LoginCancel.Size = new System.Drawing.Size(70, 28);
            this.btn_LoginCancel.TabIndex = 9;
            this.btn_LoginCancel.Text = "取消";
            this.btn_LoginCancel.UseVisualStyleBackColor = true;
            this.btn_LoginCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // p_Lock
            // 
            this.p_Lock.BackColor = System.Drawing.Color.Transparent;
            this.p_Lock.Controls.Add(this.btn_Exit);
            this.p_Lock.Controls.Add(this.btn_LockSetting);
            this.p_Lock.Controls.Add(this.btn_UnLock);
            this.p_Lock.Location = new System.Drawing.Point(195, 183);
            this.p_Lock.Name = "p_Lock";
            this.p_Lock.Size = new System.Drawing.Size(246, 43);
            this.p_Lock.TabIndex = 11;
            this.p_Lock.Visible = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Exit.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Exit.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Exit.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Exit.ButtonText = "退出";
            this.btn_Exit.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Exit.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.Image")));
            this.btn_Exit.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Exit.Location = new System.Drawing.Point(175, 5);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(67, 32);
            this.btn_Exit.TabIndex = 5;
            this.btn_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // btn_LockSetting
            // 
            this.btn_LockSetting.BackColor = System.Drawing.Color.Transparent;
            this.btn_LockSetting.BaseColor = System.Drawing.Color.Transparent;
            this.btn_LockSetting.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_LockSetting.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_LockSetting.ButtonText = "设置";
            this.btn_LockSetting.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LockSetting.ForeColor = System.Drawing.Color.Indigo;
            this.btn_LockSetting.Image = ((System.Drawing.Image)(resources.GetObject("btn_LockSetting.Image")));
            this.btn_LockSetting.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_LockSetting.Location = new System.Drawing.Point(89, 5);
            this.btn_LockSetting.Name = "btn_LockSetting";
            this.btn_LockSetting.Size = new System.Drawing.Size(67, 32);
            this.btn_LockSetting.TabIndex = 4;
            this.btn_LockSetting.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LockSetting.Click += new System.EventHandler(this.btn_LockSetting_Click);
            // 
            // btn_UnLock
            // 
            this.btn_UnLock.BackColor = System.Drawing.Color.Transparent;
            this.btn_UnLock.BaseColor = System.Drawing.Color.Transparent;
            this.btn_UnLock.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_UnLock.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_UnLock.ButtonText = "解锁";
            this.btn_UnLock.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_UnLock.ForeColor = System.Drawing.Color.Indigo;
            this.btn_UnLock.Image = ((System.Drawing.Image)(resources.GetObject("btn_UnLock.Image")));
            this.btn_UnLock.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_UnLock.Location = new System.Drawing.Point(3, 5);
            this.btn_UnLock.Name = "btn_UnLock";
            this.btn_UnLock.Size = new System.Drawing.Size(67, 32);
            this.btn_UnLock.TabIndex = 3;
            this.btn_UnLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_UnLock.Click += new System.EventHandler(this.btn_UnLock_Click);
            // 
            // p_Setting
            // 
            this.p_Setting.BackColor = System.Drawing.Color.Transparent;
            this.p_Setting.Controls.Add(this.txt_Minute);
            this.p_Setting.Controls.Add(this.btn_Cancel);
            this.p_Setting.Controls.Add(this.btn_Save);
            this.p_Setting.Controls.Add(this.label4);
            this.p_Setting.Controls.Add(this.label3);
            this.p_Setting.Controls.Add(this.cb_AutoLock);
            this.p_Setting.Location = new System.Drawing.Point(26, 88);
            this.p_Setting.Name = "p_Setting";
            this.p_Setting.Size = new System.Drawing.Size(428, 169);
            this.p_Setting.TabIndex = 13;
            this.p_Setting.Visible = false;
            // 
            // txt_Minute
            // 
            this.txt_Minute.Location = new System.Drawing.Point(229, 65);
            this.txt_Minute.Name = "txt_Minute";
            this.txt_Minute.NumberCount = 3;
            this.txt_Minute.Size = new System.Drawing.Size(100, 21);
            this.txt_Minute.TabIndex = 6;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Cancel.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Cancel.ButtonText = "取消";
            this.btn_Cancel.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Cancel.Location = new System.Drawing.Point(264, 114);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(77, 32);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_Save.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Save.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Save.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Save.ButtonText = "保存";
            this.btn_Save.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Save.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Save.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.Image")));
            this.btn_Save.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_Save.Location = new System.Drawing.Point(172, 113);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(74, 32);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(337, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "分钟";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(170, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "时间设置";
            // 
            // cb_AutoLock
            // 
            this.cb_AutoLock.AutoSize = true;
            this.cb_AutoLock.Location = new System.Drawing.Point(136, 30);
            this.cb_AutoLock.Name = "cb_AutoLock";
            this.cb_AutoLock.Size = new System.Drawing.Size(120, 16);
            this.cb_AutoLock.TabIndex = 0;
            this.cb_AutoLock.Text = "开启自动锁定功能";
            this.cb_AutoLock.UseVisualStyleBackColor = true;
            this.cb_AutoLock.CheckedChanged += new System.EventHandler(this.cb_AutoLock_CheckedChanged);
            // 
            // p_Validity
            // 
            this.p_Validity.BackColor = System.Drawing.Color.Transparent;
            this.p_Validity.Controls.Add(this.btn_Cancel2);
            this.p_Validity.Controls.Add(this.btn_Ok);
            this.p_Validity.Location = new System.Drawing.Point(236, 184);
            this.p_Validity.Name = "p_Validity";
            this.p_Validity.Size = new System.Drawing.Size(188, 43);
            this.p_Validity.TabIndex = 14;
            this.p_Validity.Visible = false;
            // 
            // btn_Cancel2
            // 
            this.btn_Cancel2.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel2.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Cancel2.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Cancel2.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Cancel2.ButtonText = "取消";
            this.btn_Cancel2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel2.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Cancel2.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel2.Image")));
            this.btn_Cancel2.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Cancel2.Location = new System.Drawing.Point(110, 8);
            this.btn_Cancel2.Name = "btn_Cancel2";
            this.btn_Cancel2.Size = new System.Drawing.Size(67, 32);
            this.btn_Cancel2.TabIndex = 5;
            this.btn_Cancel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel2.Click += new System.EventHandler(this.btn_Cancel2_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Ok.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Ok.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Ok.ButtonText = "确定";
            this.btn_Ok.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ok.Image")));
            this.btn_Ok.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Ok.Location = new System.Drawing.Point(22, 8);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(67, 32);
            this.btn_Ok.TabIndex = 4;
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // p_LoginButtons
            // 
            this.p_LoginButtons.BackColor = System.Drawing.Color.Transparent;
            this.p_LoginButtons.Controls.Add(this.btn_Login);
            this.p_LoginButtons.Controls.Add(this.btn_LoginCancel);
            this.p_LoginButtons.Location = new System.Drawing.Point(237, 183);
            this.p_LoginButtons.Name = "p_LoginButtons";
            this.p_LoginButtons.Size = new System.Drawing.Size(192, 42);
            this.p_LoginButtons.TabIndex = 8;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Close.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Close.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Close.ButtonText = "";
            this.btn_Close.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Close.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Close.Image = ((System.Drawing.Image)(resources.GetObject("btn_Close.Image")));
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_Close.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Close.Location = new System.Drawing.Point(456, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(32, 32);
            this.btn_Close.TabIndex = 12;
            this.btn_Close.TabStop = false;
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // llb_ChangePwd
            // 
            this.llb_ChangePwd.AutoSize = true;
            this.llb_ChangePwd.BackColor = System.Drawing.Color.Transparent;
            this.llb_ChangePwd.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llb_ChangePwd.Location = new System.Drawing.Point(410, 268);
            this.llb_ChangePwd.Name = "llb_ChangePwd";
            this.llb_ChangePwd.Size = new System.Drawing.Size(63, 14);
            this.llb_ChangePwd.TabIndex = 15;
            this.llb_ChangePwd.TabStop = true;
            this.llb_ChangePwd.Text = "修改密码";
            this.llb_ChangePwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llb_ChangePwd_LinkClicked);
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btn_Login;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.CancelButton = this.btn_LoginCancel;
            this.ClientSize = new System.Drawing.Size(490, 299);
            this.Controls.Add(this.llb_ChangePwd);
            this.Controls.Add(this.p_LoginButtons);
            this.Controls.Add(this.p_Validity);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.p_LoginMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.p_Lock);
            this.Controls.Add(this.p_Setting);
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Shown += new System.EventHandler(this.frmLogin_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.p_LoginMain.ResumeLayout(false);
            this.p_LoginMain.PerformLayout();
            this.p_Lock.ResumeLayout(false);
            this.p_Setting.ResumeLayout(false);
            this.p_Setting.PerformLayout();
            this.p_Validity.ResumeLayout(false);
            this.p_LoginButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private BaseControls.MyLabel lbHospitalName;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.Panel panel2;
        private BaseControls.MyLabel label2;
        private System.Windows.Forms.Panel p_LoginMain;
        private BaseControls.MyLabel l_Pwd;
        private BaseControls.MyLabel l_ImgEquipment;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.TextBox txt_DoctorId;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button btn_LoginCancel;
        private System.Windows.Forms.ComboBox cmb_ImgEquipment;
        private BaseControls.MyLabel l_Notice;
        private System.Windows.Forms.Panel p_Lock;
        private BaseControls.Buttons.VistaButton btn_UnLock;
        private BaseControls.Buttons.VistaButton btn_Exit;
        private BaseControls.Buttons.VistaButton btn_LockSetting;
        private BaseControls.Buttons.VistaButton btn_Close;
        private System.Windows.Forms.Panel p_Setting;
        private BaseControls.Buttons.VistaButton btn_Cancel;
        private BaseControls.Buttons.VistaButton btn_Save;
        private BaseControls.MyLabel label4;
        private BaseControls.MyLabel label3;
        private System.Windows.Forms.CheckBox cb_AutoLock;
        private BaseControls.NumberText txt_Minute;
        private System.Windows.Forms.Panel p_LoginButtons;
        private System.Windows.Forms.Panel p_Validity;
        private BaseControls.Buttons.VistaButton btn_Cancel2;
        private BaseControls.Buttons.VistaButton btn_Ok;
        private System.Windows.Forms.LinkLabel llb_ChangePwd;
    }
}