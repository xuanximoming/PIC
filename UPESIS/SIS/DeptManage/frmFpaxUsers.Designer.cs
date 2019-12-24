namespace SIS.DeptManage
{
    partial class frmFpaxUsers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFpaxUsers));
            this.label11 = new BaseControls.MyLabel();
            this.label21 = new BaseControls.MyLabel();
            this.l_Dept = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.label13 = new BaseControls.MyLabel();
            this.label9 = new BaseControls.MyLabel();
            this.label17 = new BaseControls.MyLabel();
            this.txt_DbUser = new System.Windows.Forms.TextBox();
            this.cmb_DeptName = new System.Windows.Forms.ComboBox();
            this.label12 = new BaseControls.MyLabel();
            this.txt_UserId = new System.Windows.Forms.TextBox();
            this.txt_UserCustomData = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label5 = new BaseControls.MyLabel();
            this.txt_UserPwd = new System.Windows.Forms.TextBox();
            this.label8 = new BaseControls.MyLabel();
            this.label15 = new BaseControls.MyLabel();
            this.label14 = new BaseControls.MyLabel();
            this.label4 = new BaseControls.MyLabel();
            this.txt_UserCreatDate = new System.Windows.Forms.TextBox();
            this.label6 = new BaseControls.MyLabel();
            this.label16 = new BaseControls.MyLabel();
            this.cLB_Module_Capability = new System.Windows.Forms.CheckedListBox();
            this.cLB_Application = new System.Windows.Forms.CheckedListBox();
            this.label7 = new BaseControls.MyLabel();
            this.cmb_Capability = new System.Windows.Forms.ComboBox();
            this.cmb_Chat_Capability = new System.Windows.Forms.ComboBox();
            this.cmb_ReportStyle = new System.Windows.Forms.ComboBox();
            this.cmb_ReportCapability = new System.Windows.Forms.ComboBox();
            this.cmb_Skin_Style = new System.Windows.Forms.ComboBox();
            this.cmb_Handup_Style = new System.Windows.Forms.ComboBox();
            this.pl_Top = new BaseControls.Panels.MyPanel();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.dgv_ImgEquipment = new BaseControls.MyDataGridView();
            this.DB_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAPABILITY = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_REPORT_STYLE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.USER_SKIN_STYLE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.USER_HANDUP_STYLE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CREATE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_PWD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_DEPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_CHAT_CAPABILITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APPLICATION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_CUSTOM_DATA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODULE_CAPABILITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pl_Top.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ImgEquipment)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(206, 92);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 89;
            this.label11.Text = "自定义数据：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 9F);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(419, 9);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 12);
            this.label21.TabIndex = 94;
            this.label21.Text = "用户密码：";
            // 
            // l_Dept
            // 
            this.l_Dept.AutoSize = true;
            this.l_Dept.Font = new System.Drawing.Font("宋体", 9F);
            this.l_Dept.ForeColor = System.Drawing.Color.Black;
            this.l_Dept.Location = new System.Drawing.Point(6, 37);
            this.l_Dept.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_Dept.Name = "l_Dept";
            this.l_Dept.Size = new System.Drawing.Size(65, 12);
            this.l_Dept.TabIndex = 92;
            this.l_Dept.Text = "科室名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(206, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 91;
            this.label3.Text = "用户名：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(650, 36);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 100;
            this.label13.Text = "界面风格：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(6, 64);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 86;
            this.label9.Text = "权限级别：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 9F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(206, 64);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 12);
            this.label17.TabIndex = 87;
            this.label17.Text = "即时通级别：";
            // 
            // txt_DbUser
            // 
            this.txt_DbUser.Location = new System.Drawing.Point(71, 4);
            this.txt_DbUser.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DbUser.Name = "txt_DbUser";
            this.txt_DbUser.Size = new System.Drawing.Size(132, 21);
            this.txt_DbUser.TabIndex = 0;
            // 
            // cmb_DeptName
            // 
            this.cmb_DeptName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_DeptName.FormattingEnabled = true;
            this.cmb_DeptName.Location = new System.Drawing.Point(71, 33);
            this.cmb_DeptName.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_DeptName.Name = "cmb_DeptName";
            this.cmb_DeptName.Size = new System.Drawing.Size(132, 20);
            this.cmb_DeptName.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(860, 21);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 90;
            this.label12.Text = "用户头像";
            this.label12.Visible = false;
            // 
            // txt_UserId
            // 
            this.txt_UserId.Location = new System.Drawing.Point(720, 4);
            this.txt_UserId.Margin = new System.Windows.Forms.Padding(4);
            this.txt_UserId.Name = "txt_UserId";
            this.txt_UserId.Size = new System.Drawing.Size(132, 21);
            this.txt_UserId.TabIndex = 3;
            // 
            // txt_UserCustomData
            // 
            this.txt_UserCustomData.Location = new System.Drawing.Point(280, 88);
            this.txt_UserCustomData.Margin = new System.Windows.Forms.Padding(4);
            this.txt_UserCustomData.Multiline = true;
            this.txt_UserCustomData.Name = "txt_UserCustomData";
            this.txt_UserCustomData.Size = new System.Drawing.Size(132, 87);
            this.txt_UserCustomData.TabIndex = 11;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(280, 4);
            this.txt_UserName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(131, 21);
            this.txt_UserName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(422, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 85;
            this.label5.Text = "创建日期：";
            // 
            // txt_UserPwd
            // 
            this.txt_UserPwd.Location = new System.Drawing.Point(510, 4);
            this.txt_UserPwd.Margin = new System.Windows.Forms.Padding(4);
            this.txt_UserPwd.Name = "txt_UserPwd";
            this.txt_UserPwd.PasswordChar = '*';
            this.txt_UserPwd.Size = new System.Drawing.Size(132, 21);
            this.txt_UserPwd.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(206, 35);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 103;
            this.label8.Text = "报告风格：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(647, 62);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 102;
            this.label15.Text = "报告能力：";
            this.label15.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(419, 36);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 101;
            this.label14.Text = "报告提交设置：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 84;
            this.label4.Text = "用户代码：";
            // 
            // txt_UserCreatDate
            // 
            this.txt_UserCreatDate.Location = new System.Drawing.Point(510, 58);
            this.txt_UserCreatDate.Margin = new System.Windows.Forms.Padding(4);
            this.txt_UserCreatDate.Name = "txt_UserCreatDate";
            this.txt_UserCreatDate.ReadOnly = true;
            this.txt_UserCreatDate.Size = new System.Drawing.Size(132, 21);
            this.txt_UserCreatDate.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(419, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 97;
            this.label6.Text = "功能模块：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 9F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(6, 92);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 96;
            this.label16.Text = "应用程序：";
            // 
            // cLB_Module_Capability
            // 
            this.cLB_Module_Capability.BackColor = System.Drawing.Color.White;
            this.cLB_Module_Capability.CheckOnClick = true;
            this.cLB_Module_Capability.ForeColor = System.Drawing.Color.Blue;
            this.cLB_Module_Capability.FormattingEnabled = true;
            this.cLB_Module_Capability.Items.AddRange(new object[] {
            "LOCALDB",
            "PAXDB",
            "DICOMDIR",
            "JWDB",
            "EXAM",
            "REGISTER",
            "RISDB",
            "USER"});
            this.cLB_Module_Capability.Location = new System.Drawing.Point(510, 88);
            this.cLB_Module_Capability.Margin = new System.Windows.Forms.Padding(4);
            this.cLB_Module_Capability.MultiColumn = true;
            this.cLB_Module_Capability.Name = "cLB_Module_Capability";
            this.cLB_Module_Capability.Size = new System.Drawing.Size(342, 84);
            this.cLB_Module_Capability.TabIndex = 12;
            // 
            // cLB_Application
            // 
            this.cLB_Application.BackColor = System.Drawing.Color.White;
            this.cLB_Application.CheckOnClick = true;
            this.cLB_Application.ForeColor = System.Drawing.Color.Blue;
            this.cLB_Application.FormattingEnabled = true;
            this.cLB_Application.Items.AddRange(new object[] {
            "ImageViewer",
            "CDViewer",
            "Register",
            "DeptManage"});
            this.cLB_Application.Location = new System.Drawing.Point(71, 88);
            this.cLB_Application.Margin = new System.Windows.Forms.Padding(4);
            this.cLB_Application.MultiColumn = true;
            this.cLB_Application.Name = "cLB_Application";
            this.cLB_Application.Size = new System.Drawing.Size(132, 84);
            this.cLB_Application.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(650, 9);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 88;
            this.label7.Text = "用户ID：";
            // 
            // cmb_Capability
            // 
            this.cmb_Capability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Capability.FormattingEnabled = true;
            this.cmb_Capability.Location = new System.Drawing.Point(71, 59);
            this.cmb_Capability.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Capability.Name = "cmb_Capability";
            this.cmb_Capability.Size = new System.Drawing.Size(132, 20);
            this.cmb_Capability.TabIndex = 8;
            // 
            // cmb_Chat_Capability
            // 
            this.cmb_Chat_Capability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Chat_Capability.FormattingEnabled = true;
            this.cmb_Chat_Capability.Location = new System.Drawing.Point(279, 59);
            this.cmb_Chat_Capability.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Chat_Capability.Name = "cmb_Chat_Capability";
            this.cmb_Chat_Capability.Size = new System.Drawing.Size(132, 20);
            this.cmb_Chat_Capability.TabIndex = 9;
            // 
            // cmb_ReportStyle
            // 
            this.cmb_ReportStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ReportStyle.FormattingEnabled = true;
            this.cmb_ReportStyle.Location = new System.Drawing.Point(279, 33);
            this.cmb_ReportStyle.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ReportStyle.Name = "cmb_ReportStyle";
            this.cmb_ReportStyle.Size = new System.Drawing.Size(132, 20);
            this.cmb_ReportStyle.TabIndex = 5;
            // 
            // cmb_ReportCapability
            // 
            this.cmb_ReportCapability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_ReportCapability.Enabled = false;
            this.cmb_ReportCapability.FormattingEnabled = true;
            this.cmb_ReportCapability.Location = new System.Drawing.Point(720, 61);
            this.cmb_ReportCapability.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_ReportCapability.Name = "cmb_ReportCapability";
            this.cmb_ReportCapability.Size = new System.Drawing.Size(132, 20);
            this.cmb_ReportCapability.TabIndex = 5;
            this.cmb_ReportCapability.Visible = false;
            // 
            // cmb_Skin_Style
            // 
            this.cmb_Skin_Style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Skin_Style.FormattingEnabled = true;
            this.cmb_Skin_Style.Location = new System.Drawing.Point(720, 33);
            this.cmb_Skin_Style.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Skin_Style.Name = "cmb_Skin_Style";
            this.cmb_Skin_Style.Size = new System.Drawing.Size(132, 20);
            this.cmb_Skin_Style.TabIndex = 7;
            // 
            // cmb_Handup_Style
            // 
            this.cmb_Handup_Style.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Handup_Style.FormattingEnabled = true;
            this.cmb_Handup_Style.Location = new System.Drawing.Point(510, 33);
            this.cmb_Handup_Style.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_Handup_Style.Name = "cmb_Handup_Style";
            this.cmb_Handup_Style.Size = new System.Drawing.Size(130, 20);
            this.cmb_Handup_Style.TabIndex = 6;
            // 
            // pl_Top
            // 
            this.pl_Top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pl_Top.BorderColor = System.Drawing.Color.Silver;
            this.pl_Top.Controls.Add(this.cmb_Handup_Style);
            this.pl_Top.Controls.Add(this.cmb_Skin_Style);
            this.pl_Top.Controls.Add(this.cmb_ReportCapability);
            this.pl_Top.Controls.Add(this.cmb_ReportStyle);
            this.pl_Top.Controls.Add(this.cmb_Chat_Capability);
            this.pl_Top.Controls.Add(this.cmb_Capability);
            this.pl_Top.Controls.Add(this.label7);
            this.pl_Top.Controls.Add(this.cLB_Application);
            this.pl_Top.Controls.Add(this.cLB_Module_Capability);
            this.pl_Top.Controls.Add(this.label16);
            this.pl_Top.Controls.Add(this.label6);
            this.pl_Top.Controls.Add(this.txt_UserCreatDate);
            this.pl_Top.Controls.Add(this.label4);
            this.pl_Top.Controls.Add(this.label14);
            this.pl_Top.Controls.Add(this.label15);
            this.pl_Top.Controls.Add(this.label8);
            this.pl_Top.Controls.Add(this.txt_UserPwd);
            this.pl_Top.Controls.Add(this.label5);
            this.pl_Top.Controls.Add(this.txt_UserName);
            this.pl_Top.Controls.Add(this.txt_UserCustomData);
            this.pl_Top.Controls.Add(this.txt_UserId);
            this.pl_Top.Controls.Add(this.label12);
            this.pl_Top.Controls.Add(this.cmb_DeptName);
            this.pl_Top.Controls.Add(this.txt_DbUser);
            this.pl_Top.Controls.Add(this.label17);
            this.pl_Top.Controls.Add(this.label9);
            this.pl_Top.Controls.Add(this.label13);
            this.pl_Top.Controls.Add(this.label3);
            this.pl_Top.Controls.Add(this.l_Dept);
            this.pl_Top.Controls.Add(this.label21);
            this.pl_Top.Controls.Add(this.label11);
            this.pl_Top.Location = new System.Drawing.Point(12, 33);
            this.pl_Top.Name = "pl_Top";
            this.pl_Top.Size = new System.Drawing.Size(852, 180);
            this.pl_Top.TabIndex = 32;
            // 
            // btn_Del
            // 
            this.btn_Del.FlatAppearance.BorderSize = 0;
            this.btn_Del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Del.Location = new System.Drawing.Point(458, 4);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(94, 19);
            this.btn_Del.TabIndex = 4;
            this.btn_Del.Text = "删除";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // btn_Find
            // 
            this.btn_Find.FlatAppearance.BorderSize = 0;
            this.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Find.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Find.Location = new System.Drawing.Point(155, 4);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(94, 19);
            this.btn_Find.TabIndex = 0;
            this.btn_Find.Text = "查找";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Save.Location = new System.Drawing.Point(256, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 19);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Clean
            // 
            this.btn_Clean.FlatAppearance.BorderSize = 0;
            this.btn_Clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clean.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Clean.Location = new System.Drawing.Point(357, 4);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(94, 19);
            this.btn_Clean.TabIndex = 4;
            this.btn_Clean.Text = "清空";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 452F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Clean, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Find, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Del, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(876, 27);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // btn_FunName
            // 
            this.btn_FunName.BackgroundImage = global::SIS.Properties.Resources.bg_nav_column_light;
            this.btn_FunName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_FunName.Enabled = false;
            this.btn_FunName.FlatAppearance.BorderSize = 0;
            this.btn_FunName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FunName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_FunName.Location = new System.Drawing.Point(1, 1);
            this.btn_FunName.Margin = new System.Windows.Forms.Padding(0);
            this.btn_FunName.Name = "btn_FunName";
            this.btn_FunName.Size = new System.Drawing.Size(150, 25);
            this.btn_FunName.TabIndex = 6;
            this.btn_FunName.Text = "button1";
            this.btn_FunName.UseVisualStyleBackColor = true;
            // 
            // dgv_ImgEquipment
            // 
            this.dgv_ImgEquipment.AllowUserToAddRows = false;
            this.dgv_ImgEquipment.AllowUserToDeleteRows = false;
            this.dgv_ImgEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ImgEquipment.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ImgEquipment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ImgEquipment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv_ImgEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ImgEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DB_USER,
            this.USER_ID,
            this.USER_NAME,
            this.CAPABILITY,
            this.DEPT_NAME,
            this.USER_REPORT_STYLE,
            this.USER_SKIN_STYLE,
            this.USER_HANDUP_STYLE,
            this.CREATE_DATE,
            this.USER_PWD,
            this.USER_DEPT,
            this.USER_CHAT_CAPABILITY,
            this.APPLICATION,
            this.USER_CUSTOM_DATA,
            this.MODULE_CAPABILITY});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ImgEquipment.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ImgEquipment.DefaultScaleWidth = 1280;
            this.dgv_ImgEquipment.Location = new System.Drawing.Point(12, 224);
            this.dgv_ImgEquipment.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_ImgEquipment.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_ImgEquipment.MergeColumnNames")));
            this.dgv_ImgEquipment.Name = "dgv_ImgEquipment";
            this.dgv_ImgEquipment.ReadOnly = true;
            this.dgv_ImgEquipment.RowHeadersWidth = 25;
            this.dgv_ImgEquipment.RowTemplate.Height = 23;
            this.dgv_ImgEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ImgEquipment.Size = new System.Drawing.Size(854, 325);
            this.dgv_ImgEquipment.TabIndex = 34;
            this.dgv_ImgEquipment.XmlFile = null;
            this.dgv_ImgEquipment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ImgEquipment_CellClick);
            this.dgv_ImgEquipment.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_ImgEquipment_DataError);
            // 
            // DB_USER
            // 
            this.DB_USER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DB_USER.DataPropertyName = "DB_USER";
            this.DB_USER.FillWeight = 10F;
            this.DB_USER.HeaderText = "用户代码";
            this.DB_USER.Name = "DB_USER";
            this.DB_USER.ReadOnly = true;
            // 
            // USER_ID
            // 
            this.USER_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.USER_ID.DataPropertyName = "USER_ID";
            this.USER_ID.FillWeight = 10F;
            this.USER_ID.HeaderText = "用户ID";
            this.USER_ID.Name = "USER_ID";
            this.USER_ID.ReadOnly = true;
            // 
            // USER_NAME
            // 
            this.USER_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.USER_NAME.DataPropertyName = "USER_NAME";
            this.USER_NAME.FillWeight = 10F;
            this.USER_NAME.HeaderText = "姓名";
            this.USER_NAME.Name = "USER_NAME";
            this.USER_NAME.ReadOnly = true;
            // 
            // CAPABILITY
            // 
            this.CAPABILITY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CAPABILITY.DataPropertyName = "CAPABILITY";
            this.CAPABILITY.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CAPABILITY.FillWeight = 15F;
            this.CAPABILITY.HeaderText = "权限级别";
            this.CAPABILITY.Name = "CAPABILITY";
            this.CAPABILITY.ReadOnly = true;
            this.CAPABILITY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CAPABILITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DEPT_NAME
            // 
            this.DEPT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DEPT_NAME.DataPropertyName = "DEPT_NAME";
            this.DEPT_NAME.FillWeight = 15F;
            this.DEPT_NAME.HeaderText = "科室名称";
            this.DEPT_NAME.Name = "DEPT_NAME";
            this.DEPT_NAME.ReadOnly = true;
            // 
            // USER_REPORT_STYLE
            // 
            this.USER_REPORT_STYLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.USER_REPORT_STYLE.DataPropertyName = "USER_REPORT_STYLE";
            this.USER_REPORT_STYLE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.USER_REPORT_STYLE.FillWeight = 12F;
            this.USER_REPORT_STYLE.HeaderText = "报告风格";
            this.USER_REPORT_STYLE.Name = "USER_REPORT_STYLE";
            this.USER_REPORT_STYLE.ReadOnly = true;
            this.USER_REPORT_STYLE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.USER_REPORT_STYLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // USER_SKIN_STYLE
            // 
            this.USER_SKIN_STYLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.USER_SKIN_STYLE.DataPropertyName = "USER_SKIN_STYLE";
            this.USER_SKIN_STYLE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.USER_SKIN_STYLE.FillWeight = 12F;
            this.USER_SKIN_STYLE.HeaderText = "界面风格";
            this.USER_SKIN_STYLE.Name = "USER_SKIN_STYLE";
            this.USER_SKIN_STYLE.ReadOnly = true;
            this.USER_SKIN_STYLE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.USER_SKIN_STYLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // USER_HANDUP_STYLE
            // 
            this.USER_HANDUP_STYLE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.USER_HANDUP_STYLE.DataPropertyName = "USER_HANDUP_STYLE";
            this.USER_HANDUP_STYLE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.USER_HANDUP_STYLE.FillWeight = 15F;
            this.USER_HANDUP_STYLE.HeaderText = "报告提交设置";
            this.USER_HANDUP_STYLE.Name = "USER_HANDUP_STYLE";
            this.USER_HANDUP_STYLE.ReadOnly = true;
            this.USER_HANDUP_STYLE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.USER_HANDUP_STYLE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CREATE_DATE
            // 
            this.CREATE_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CREATE_DATE.DataPropertyName = "CREATE_DATE";
            this.CREATE_DATE.FillWeight = 10F;
            this.CREATE_DATE.HeaderText = "创建日期";
            this.CREATE_DATE.Name = "CREATE_DATE";
            this.CREATE_DATE.ReadOnly = true;
            // 
            // USER_PWD
            // 
            this.USER_PWD.DataPropertyName = "USER_PWD";
            this.USER_PWD.HeaderText = "用户密码";
            this.USER_PWD.Name = "USER_PWD";
            this.USER_PWD.ReadOnly = true;
            this.USER_PWD.Visible = false;
            // 
            // USER_DEPT
            // 
            this.USER_DEPT.DataPropertyName = "USER_DEPT";
            this.USER_DEPT.HeaderText = "用户单位";
            this.USER_DEPT.Name = "USER_DEPT";
            this.USER_DEPT.ReadOnly = true;
            this.USER_DEPT.Visible = false;
            // 
            // USER_CHAT_CAPABILITY
            // 
            this.USER_CHAT_CAPABILITY.DataPropertyName = "USER_CHAT_CAPABILITY";
            this.USER_CHAT_CAPABILITY.HeaderText = "即时通用户级别";
            this.USER_CHAT_CAPABILITY.Name = "USER_CHAT_CAPABILITY";
            this.USER_CHAT_CAPABILITY.ReadOnly = true;
            this.USER_CHAT_CAPABILITY.Visible = false;
            // 
            // APPLICATION
            // 
            this.APPLICATION.DataPropertyName = "APPLICATION";
            this.APPLICATION.HeaderText = "应用程序";
            this.APPLICATION.Name = "APPLICATION";
            this.APPLICATION.ReadOnly = true;
            this.APPLICATION.Visible = false;
            // 
            // USER_CUSTOM_DATA
            // 
            this.USER_CUSTOM_DATA.DataPropertyName = "USER_CUSTOM_DATA";
            this.USER_CUSTOM_DATA.HeaderText = "自定义数据";
            this.USER_CUSTOM_DATA.Name = "USER_CUSTOM_DATA";
            this.USER_CUSTOM_DATA.ReadOnly = true;
            this.USER_CUSTOM_DATA.Visible = false;
            // 
            // MODULE_CAPABILITY
            // 
            this.MODULE_CAPABILITY.DataPropertyName = "MODULE_CAPABILITY";
            this.MODULE_CAPABILITY.HeaderText = "功能模块";
            this.MODULE_CAPABILITY.Name = "MODULE_CAPABILITY";
            this.MODULE_CAPABILITY.ReadOnly = true;
            this.MODULE_CAPABILITY.Visible = false;
            // 
            // frmFpaxUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(876, 560);
            this.Controls.Add(this.dgv_ImgEquipment);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pl_Top);
            this.Name = "frmFpaxUsers";
            this.Text = "用户管理";
            this.VisibleChanged += new System.EventHandler(this.FpaxUsers_VisibleChanged);
            this.Load += new System.EventHandler(this.FpaxUsers_Load);
            this.pl_Top.ResumeLayout(false);
            this.pl_Top.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ImgEquipment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.MyLabel label11;
        private BaseControls.MyLabel label21;
        private BaseControls.MyLabel l_Dept;
        private BaseControls.MyLabel label3;
        private BaseControls.MyLabel label13;
        private BaseControls.MyLabel label9;
        private BaseControls.MyLabel label17;
        private System.Windows.Forms.TextBox txt_DbUser;
        private System.Windows.Forms.ComboBox cmb_DeptName;
        private BaseControls.MyLabel label12;
        private System.Windows.Forms.TextBox txt_UserId;
        private System.Windows.Forms.TextBox txt_UserCustomData;
        private System.Windows.Forms.TextBox txt_UserName;
        private BaseControls.MyLabel label5;
        private System.Windows.Forms.TextBox txt_UserPwd;
        private BaseControls.MyLabel label8;
        private BaseControls.MyLabel label15;
        private BaseControls.MyLabel label14;
        private BaseControls.MyLabel label4;
        private System.Windows.Forms.TextBox txt_UserCreatDate;
        private BaseControls.MyLabel label6;
        private BaseControls.MyLabel label16;
        private System.Windows.Forms.CheckedListBox cLB_Module_Capability;
        private System.Windows.Forms.CheckedListBox cLB_Application;
        private BaseControls.MyLabel label7;
        private System.Windows.Forms.ComboBox cmb_Capability;
        private System.Windows.Forms.ComboBox cmb_Chat_Capability;
        private System.Windows.Forms.ComboBox cmb_ReportStyle;
        private System.Windows.Forms.ComboBox cmb_ReportCapability;
        private System.Windows.Forms.ComboBox cmb_Skin_Style;
        private System.Windows.Forms.ComboBox cmb_Handup_Style;
        private BaseControls.Panels.MyPanel pl_Top;
        public System.Windows.Forms.Button btn_Del;
        public System.Windows.Forms.Button btn_Find;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_Clean;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_FunName;
        private BaseControls.MyDataGridView dgv_ImgEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_NAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn CAPABILITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_NAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn USER_REPORT_STYLE;
        private System.Windows.Forms.DataGridViewComboBoxColumn USER_SKIN_STYLE;
        private System.Windows.Forms.DataGridViewComboBoxColumn USER_HANDUP_STYLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_PWD;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_DEPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_CHAT_CAPABILITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn APPLICATION;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_CUSTOM_DATA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODULE_CAPABILITY;

    }
}