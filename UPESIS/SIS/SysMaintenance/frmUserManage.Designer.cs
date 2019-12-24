namespace SIS.SysMaintenance
{
    partial class frmUserManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.myPanel1 = new BaseControls.Panels.MyPanel();
            this.txt_Doctor_Name = new BaseControls.MyTextBox();
            this.label2 = new BaseControls.MyLabel();
            this.p_role = new BaseControls.Panels.MyPanel();
            this.lv_role = new System.Windows.Forms.ListView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.label1 = new BaseControls.MyLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.dgv_UserManage = new BaseControls.MyDataGridView();
            this.DOCTOR_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_OFFICE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DOCTOR_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOCTOR_LEVEL = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.role_names = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Choose = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DOCTOR_PWD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.myPictureBox1 = new BaseControls.PictureBoxs.MyPictureBox();
            this.txt_DoctorId = new System.Windows.Forms.TextBox();
            this.lb_DoctorName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.myPanel1.SuspendLayout();
            this.p_role.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserManage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1071F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Add, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 27);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // btn_Add
            // 
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Add.Location = new System.Drawing.Point(135, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(63, 19);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "增加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Save.Location = new System.Drawing.Point(205, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(54, 19);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
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
            this.btn_FunName.Size = new System.Drawing.Size(130, 25);
            this.btn_FunName.TabIndex = 3;
            this.btn_FunName.Text = "button1";
            this.btn_FunName.UseVisualStyleBackColor = true;
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BorderColor = System.Drawing.Color.Silver;
            this.myPanel1.Controls.Add(this.lb_DoctorName);
            this.myPanel1.Controls.Add(this.txt_DoctorId);
            this.myPanel1.Controls.Add(this.txt_Doctor_Name);
            this.myPanel1.Controls.Add(this.label2);
            this.myPanel1.Location = new System.Drawing.Point(9, 33);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(790, 35);
            this.myPanel1.TabIndex = 32;
            // 
            // txt_Doctor_Name
            // 
            this.txt_Doctor_Name.Location = new System.Drawing.Point(275, 7);
            this.txt_Doctor_Name.Name = "txt_Doctor_Name";
            this.txt_Doctor_Name.Size = new System.Drawing.Size(100, 21);
            this.txt_Doctor_Name.TabIndex = 3;
            this.txt_Doctor_Name.TextChanged += new System.EventHandler(this.txt_Doctor_Name_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(204, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "医生姓名：";
            // 
            // p_role
            // 
            this.p_role.BackColor = System.Drawing.Color.WhiteSmoke;
            this.p_role.BorderColor = System.Drawing.Color.Transparent;
            this.p_role.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_role.Controls.Add(this.lv_role);
            this.p_role.Controls.Add(this.panel4);
            this.p_role.Controls.Add(this.panel3);
            this.p_role.Controls.Add(this.panel2);
            this.p_role.Controls.Add(this.panel1);
            this.p_role.Location = new System.Drawing.Point(205, 239);
            this.p_role.Name = "p_role";
            this.p_role.Size = new System.Drawing.Size(306, 238);
            this.p_role.TabIndex = 27;
            this.p_role.Visible = false;
            // 
            // lv_role
            // 
            this.lv_role.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_role.CheckBoxes = true;
            this.lv_role.GridLines = true;
            this.lv_role.Location = new System.Drawing.Point(9, 44);
            this.lv_role.Name = "lv_role";
            this.lv_role.Size = new System.Drawing.Size(287, 177);
            this.lv_role.TabIndex = 31;
            this.lv_role.UseCompatibleStateImageBehavior = false;
            this.lv_role.View = System.Windows.Forms.View.List;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(304, 1);
            this.panel4.TabIndex = 30;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 226);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(304, 10);
            this.panel3.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel2.Controls.Add(this.btn_close);
            this.panel2.Controls.Add(this.btn_Ok);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.myPictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(304, 35);
            this.panel2.TabIndex = 28;
            // 
            // btn_close
            // 
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_close.Location = new System.Drawing.Point(255, 7);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(54, 19);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "[关闭]";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ok.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Ok.Location = new System.Drawing.Point(212, 7);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(54, 19);
            this.btn_Ok.TabIndex = 2;
            this.btn_Ok.Text = "[确认]";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(40, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Tag = "";
            this.label1.Text = "选择用户角色";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 1);
            this.panel1.TabIndex = 27;
            // 
            // gb_PromptInfo
            // 
            this.gb_PromptInfo.BackgroundColor = System.Drawing.Color.Bisque;
            this.gb_PromptInfo.BackgroundGradientColor = System.Drawing.Color.White;
            this.gb_PromptInfo.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.gb_PromptInfo.BorderColor = System.Drawing.Color.SandyBrown;
            this.gb_PromptInfo.BorderThickness = 1F;
            this.gb_PromptInfo.Controls.Add(this.pictureBox1);
            this.gb_PromptInfo.Controls.Add(this.lb_PromptInfo);
            this.gb_PromptInfo.CustomGroupBoxColor = System.Drawing.Color.White;
            this.gb_PromptInfo.GroupImage = null;
            this.gb_PromptInfo.GroupTitle = "";
            this.gb_PromptInfo.Location = new System.Drawing.Point(272, 137);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 25;
            this.gb_PromptInfo.UseWaitCursor = true;
            this.gb_PromptInfo.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(3, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // lb_PromptInfo
            // 
            this.lb_PromptInfo.AutoSize = true;
            this.lb_PromptInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_PromptInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lb_PromptInfo.Location = new System.Drawing.Point(45, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(101, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有用户信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // dgv_UserManage
            // 
            this.dgv_UserManage.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_UserManage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_UserManage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_UserManage.BackgroundColor = System.Drawing.Color.White;
            this.dgv_UserManage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_UserManage.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_UserManage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_UserManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_UserManage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DOCTOR_ID,
            this.CLINIC_OFFICE,
            this.DOCTOR_NAME,
            this.DOCTOR_LEVEL,
            this.role_names,
            this.Choose,
            this.DOCTOR_PWD,
            this.Operate,
            this.Edit});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_UserManage.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_UserManage.DefaultScaleWidth = 1280;
            this.dgv_UserManage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_UserManage.Location = new System.Drawing.Point(9, 81);
            this.dgv_UserManage.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_UserManage.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_UserManage.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_UserManage.MergeColumnNames")));
            this.dgv_UserManage.Name = "dgv_UserManage";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_UserManage.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_UserManage.RowTemplate.Height = 23;
            this.dgv_UserManage.Size = new System.Drawing.Size(794, 476);
            this.dgv_UserManage.TabIndex = 31;
            this.dgv_UserManage.XmlFile = null;
            this.dgv_UserManage.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_UserManage_DataError);
            this.dgv_UserManage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_UserManage_CellContentClick);
            // 
            // DOCTOR_ID
            // 
            this.DOCTOR_ID.DataPropertyName = "DOCTOR_ID";
            this.DOCTOR_ID.HeaderText = "用户编号";
            this.DOCTOR_ID.Name = "DOCTOR_ID";
            // 
            // CLINIC_OFFICE
            // 
            this.CLINIC_OFFICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLINIC_OFFICE.DataPropertyName = "CLINIC_OFFICE_CODE";
            this.CLINIC_OFFICE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CLINIC_OFFICE.FillWeight = 15F;
            this.CLINIC_OFFICE.HeaderText = "科室名称";
            this.CLINIC_OFFICE.MinimumWidth = 2;
            this.CLINIC_OFFICE.Name = "CLINIC_OFFICE";
            this.CLINIC_OFFICE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CLINIC_OFFICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // DOCTOR_NAME
            // 
            this.DOCTOR_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DOCTOR_NAME.DataPropertyName = "DOCTOR_NAME";
            this.DOCTOR_NAME.FillWeight = 12F;
            this.DOCTOR_NAME.HeaderText = "医生姓名";
            this.DOCTOR_NAME.Name = "DOCTOR_NAME";
            this.DOCTOR_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DOCTOR_LEVEL
            // 
            this.DOCTOR_LEVEL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DOCTOR_LEVEL.DataPropertyName = "DOCTOR_LEVEL";
            this.DOCTOR_LEVEL.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DOCTOR_LEVEL.FillWeight = 20F;
            this.DOCTOR_LEVEL.HeaderText = "医生级别";
            this.DOCTOR_LEVEL.Name = "DOCTOR_LEVEL";
            this.DOCTOR_LEVEL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // role_names
            // 
            this.role_names.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.role_names.DataPropertyName = "DOCTOR_ROLE";
            this.role_names.FillWeight = 13F;
            this.role_names.HeaderText = "医生角色";
            this.role_names.Name = "role_names";
            this.role_names.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Choose
            // 
            this.Choose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Choose.HeaderText = "";
            this.Choose.Name = "Choose";
            this.Choose.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Choose.Text = "选择角色";
            this.Choose.ToolTipText = "选择角色";
            this.Choose.UseColumnTextForButtonValue = true;
            this.Choose.Width = 80;
            // 
            // DOCTOR_PWD
            // 
            this.DOCTOR_PWD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DOCTOR_PWD.DataPropertyName = "DOCTOR_PWD";
            this.DOCTOR_PWD.FillWeight = 10F;
            this.DOCTOR_PWD.HeaderText = "口令";
            this.DOCTOR_PWD.Name = "DOCTOR_PWD";
            this.DOCTOR_PWD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Operate
            // 
            this.Operate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Operate.FillWeight = 10F;
            this.Operate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Operate.HeaderText = "操作";
            this.Operate.Name = "Operate";
            this.Operate.Text = "删除";
            this.Operate.ToolTipText = "删除";
            this.Operate.UseColumnTextForButtonValue = true;
            this.Operate.Width = 50;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Edit.FillWeight = 10F;
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.Text = "编辑";
            this.Edit.ToolTipText = "编辑";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 50;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DOCTOR_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DOCTOR_LEVEL_NAME";
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // myPictureBox1
            // 
            this.myPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("myPictureBox1.Image")));
            this.myPictureBox1.Location = new System.Drawing.Point(3, 5);
            this.myPictureBox1.Name = "myPictureBox1";
            this.myPictureBox1.Size = new System.Drawing.Size(35, 24);
            this.myPictureBox1.TabIndex = 0;
            this.myPictureBox1.TabStop = false;
            // 
            // txt_DoctorId
            // 
            this.txt_DoctorId.Location = new System.Drawing.Point(84, 7);
            this.txt_DoctorId.Name = "txt_DoctorId";
            this.txt_DoctorId.Size = new System.Drawing.Size(100, 21);
            this.txt_DoctorId.TabIndex = 4;
            this.txt_DoctorId.TextChanged += new System.EventHandler(this.txt_DoctorId_TextChanged);
            // 
            // lb_DoctorName
            // 
            this.lb_DoctorName.AutoSize = true;
            this.lb_DoctorName.Location = new System.Drawing.Point(13, 11);
            this.lb_DoctorName.Name = "lb_DoctorName";
            this.lb_DoctorName.Size = new System.Drawing.Size(65, 12);
            this.lb_DoctorName.TabIndex = 5;
            this.lb_DoctorName.Text = "医生编号：";
            // 
            // frmUserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 566);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.p_role);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.dgv_UserManage);
            this.Name = "frmUserManage";
            this.Text = "UserManage";
            this.Load += new System.EventHandler(this.UserManage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            this.p_role.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserManage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.MyLabel lb_PromptInfo;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Add;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_FunName;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private BaseControls.Panels.MyPanel p_role;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private BaseControls.PictureBoxs.MyPictureBox myPictureBox1;
        public System.Windows.Forms.Button btn_close;
        public System.Windows.Forms.Button btn_Ok;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.ListView lv_role;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private BaseControls.MyDataGridView dgv_UserManage;
        private BaseControls.Panels.MyPanel myPanel1;
        private BaseControls.MyTextBox txt_Doctor_Name;
        private BaseControls.MyLabel label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCTOR_ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn CLINIC_OFFICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCTOR_NAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn DOCTOR_LEVEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn role_names;
        private System.Windows.Forms.DataGridViewButtonColumn Choose;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCTOR_PWD;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.Label lb_DoctorName;
        private System.Windows.Forms.TextBox txt_DoctorId;
    }
}