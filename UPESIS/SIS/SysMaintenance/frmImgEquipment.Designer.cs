namespace SIS.SysMaintenance
{
    partial class frmImgEquipment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImgEquipment));
            this.btn_Find = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.myPanel1 = new BaseControls.Panels.MyPanel();
            this.label1 = new BaseControls.MyLabel();
            this.cmb_EQUIPMENT_STATE = new BaseControls.ComboBoxs.MyComboBox();
            this.txt_OFFICE = new BaseControls.MyTextBox();
            this.cmb_CLINIC_OFFICE = new BaseControls.ComboBoxs.MyComboBox();
            this.txt_IMG_EQUIPMENT_NAME = new BaseControls.MyTextBox();
            this.label5 = new BaseControls.MyLabel();
            this.label4 = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.dgv_ImgEquipment = new BaseControls.MyDataGridView();
            this.IMG_EQUIPMENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMG_EQUIPMENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_OFFICE_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OFFICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIAL_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EQUIPMENT_STATE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.OPERATOR_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LAST_CALL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EQU_GUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.myPanel1.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ImgEquipment)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Find
            // 
            this.btn_Find.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Find.FlatAppearance.BorderSize = 0;
            this.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Find.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Find.Location = new System.Drawing.Point(357, 4);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(94, 19);
            this.btn_Find.TabIndex = 0;
            this.btn_Find.Text = "查找";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 444F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Find, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Add, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 27);
            this.tableLayoutPanel1.TabIndex = 27;
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
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
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
            // btn_Add
            // 
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Add.Location = new System.Drawing.Point(155, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(94, 19);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "增加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BorderColor = System.Drawing.Color.Silver;
            this.myPanel1.Controls.Add(this.label1);
            this.myPanel1.Controls.Add(this.cmb_EQUIPMENT_STATE);
            this.myPanel1.Controls.Add(this.txt_OFFICE);
            this.myPanel1.Controls.Add(this.cmb_CLINIC_OFFICE);
            this.myPanel1.Controls.Add(this.txt_IMG_EQUIPMENT_NAME);
            this.myPanel1.Controls.Add(this.label5);
            this.myPanel1.Controls.Add(this.label4);
            this.myPanel1.Controls.Add(this.label3);
            this.myPanel1.Controls.Add(this.label2);
            this.myPanel1.Location = new System.Drawing.Point(9, 43);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(862, 42);
            this.myPanel1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(210, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "--";
            this.label1.Visible = false;
            // 
            // cmb_EQUIPMENT_STATE
            // 
            this.cmb_EQUIPMENT_STATE.FormattingEnabled = true;
            this.cmb_EQUIPMENT_STATE.Location = new System.Drawing.Point(540, 10);
            this.cmb_EQUIPMENT_STATE.Name = "cmb_EQUIPMENT_STATE";
            this.cmb_EQUIPMENT_STATE.Size = new System.Drawing.Size(92, 20);
            this.cmb_EQUIPMENT_STATE.TabIndex = 4;
            // 
            // txt_OFFICE
            // 
            this.txt_OFFICE.Location = new System.Drawing.Point(348, 10);
            this.txt_OFFICE.Name = "txt_OFFICE";
            this.txt_OFFICE.Size = new System.Drawing.Size(126, 21);
            this.txt_OFFICE.TabIndex = 3;
            // 
            // cmb_CLINIC_OFFICE
            // 
            this.cmb_CLINIC_OFFICE.FormattingEnabled = true;
            this.cmb_CLINIC_OFFICE.Location = new System.Drawing.Point(719, 10);
            this.cmb_CLINIC_OFFICE.Name = "cmb_CLINIC_OFFICE";
            this.cmb_CLINIC_OFFICE.Size = new System.Drawing.Size(140, 20);
            this.cmb_CLINIC_OFFICE.TabIndex = 2;
            this.cmb_CLINIC_OFFICE.Visible = false;
            // 
            // txt_IMG_EQUIPMENT_NAME
            // 
            this.txt_IMG_EQUIPMENT_NAME.Location = new System.Drawing.Point(74, 10);
            this.txt_IMG_EQUIPMENT_NAME.Name = "txt_IMG_EQUIPMENT_NAME";
            this.txt_IMG_EQUIPMENT_NAME.Size = new System.Drawing.Size(189, 21);
            this.txt_IMG_EQUIPMENT_NAME.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(478, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "设备状态：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(277, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "所属诊室：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(648, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "所属科室：";
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "设备名称：";
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(306, 202);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 29;
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
            this.lb_PromptInfo.BackColor = System.Drawing.Color.Bisque;
            this.lb_PromptInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_PromptInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lb_PromptInfo.Location = new System.Drawing.Point(45, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(125, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有影像设备信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // dgv_ImgEquipment
            // 
            this.dgv_ImgEquipment.AllowUserToAddRows = false;
            this.dgv_ImgEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ImgEquipment.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ImgEquipment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ImgEquipment.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv_ImgEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IMG_EQUIPMENT_ID,
            this.IMG_EQUIPMENT_NAME,
            this.CLINIC_OFFICE_ID,
            this.OFFICE,
            this.SERIAL_CLASS,
            this.EQUIPMENT_STATE,
            this.OPERATOR_DOCTOR,
            this.IP,
            this.LAST_CALL,
            this.EQU_GUID,
            this.Operate,
            this.Edit});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ImgEquipment.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ImgEquipment.DefaultScaleWidth = 1280;
            this.dgv_ImgEquipment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_ImgEquipment.Location = new System.Drawing.Point(9, 99);
            this.dgv_ImgEquipment.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_ImgEquipment.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_ImgEquipment.MergeColumnNames")));
            this.dgv_ImgEquipment.Name = "dgv_ImgEquipment";
            this.dgv_ImgEquipment.ReadOnly = true;
            this.dgv_ImgEquipment.RowHeadersWidth = 20;
            this.dgv_ImgEquipment.RowTemplate.Height = 23;
            this.dgv_ImgEquipment.Size = new System.Drawing.Size(862, 449);
            this.dgv_ImgEquipment.TabIndex = 30;
            this.dgv_ImgEquipment.XmlFile = null;
            this.dgv_ImgEquipment.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_ImgEquipment_DataError);
            this.dgv_ImgEquipment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ImgEquipment_CellContentClick);
            // 
            // IMG_EQUIPMENT_ID
            // 
            this.IMG_EQUIPMENT_ID.DataPropertyName = "IMG_EQUIPMENT_ID";
            this.IMG_EQUIPMENT_ID.FillWeight = 15F;
            this.IMG_EQUIPMENT_ID.HeaderText = "IMG_EQUIPMENT_ID";
            this.IMG_EQUIPMENT_ID.Name = "IMG_EQUIPMENT_ID";
            this.IMG_EQUIPMENT_ID.ReadOnly = true;
            this.IMG_EQUIPMENT_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IMG_EQUIPMENT_ID.Visible = false;
            // 
            // IMG_EQUIPMENT_NAME
            // 
            this.IMG_EQUIPMENT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IMG_EQUIPMENT_NAME.DataPropertyName = "IMG_EQUIPMENT_NAME";
            this.IMG_EQUIPMENT_NAME.FillWeight = 14F;
            this.IMG_EQUIPMENT_NAME.HeaderText = "设备名称";
            this.IMG_EQUIPMENT_NAME.Name = "IMG_EQUIPMENT_NAME";
            this.IMG_EQUIPMENT_NAME.ReadOnly = true;
            this.IMG_EQUIPMENT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CLINIC_OFFICE_ID
            // 
            this.CLINIC_OFFICE_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLINIC_OFFICE_ID.DataPropertyName = "CLINIC_OFFICE_CODE";
            this.CLINIC_OFFICE_ID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CLINIC_OFFICE_ID.FillWeight = 13F;
            this.CLINIC_OFFICE_ID.HeaderText = "所属科室";
            this.CLINIC_OFFICE_ID.Name = "CLINIC_OFFICE_ID";
            this.CLINIC_OFFICE_ID.ReadOnly = true;
            this.CLINIC_OFFICE_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OFFICE
            // 
            this.OFFICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OFFICE.DataPropertyName = "OFFICE";
            this.OFFICE.FillWeight = 13F;
            this.OFFICE.HeaderText = "所属诊室";
            this.OFFICE.Name = "OFFICE";
            this.OFFICE.ReadOnly = true;
            this.OFFICE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SERIAL_CLASS
            // 
            this.SERIAL_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SERIAL_CLASS.DataPropertyName = "SERIAL_CLASS";
            this.SERIAL_CLASS.FillWeight = 14F;
            this.SERIAL_CLASS.HeaderText = "流水号类型";
            this.SERIAL_CLASS.Name = "SERIAL_CLASS";
            this.SERIAL_CLASS.ReadOnly = true;
            this.SERIAL_CLASS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EQUIPMENT_STATE
            // 
            this.EQUIPMENT_STATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EQUIPMENT_STATE.DataPropertyName = "EQUIPMENT_STATE";
            this.EQUIPMENT_STATE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.EQUIPMENT_STATE.FillWeight = 12F;
            this.EQUIPMENT_STATE.HeaderText = "设备状态";
            this.EQUIPMENT_STATE.Name = "EQUIPMENT_STATE";
            this.EQUIPMENT_STATE.ReadOnly = true;
            this.EQUIPMENT_STATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OPERATOR_DOCTOR
            // 
            this.OPERATOR_DOCTOR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OPERATOR_DOCTOR.DataPropertyName = "OPERATOR_DOCTOR";
            this.OPERATOR_DOCTOR.FillWeight = 12F;
            this.OPERATOR_DOCTOR.HeaderText = "医生";
            this.OPERATOR_DOCTOR.Name = "OPERATOR_DOCTOR";
            this.OPERATOR_DOCTOR.ReadOnly = true;
            this.OPERATOR_DOCTOR.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IP.DataPropertyName = "IP";
            this.IP.FillWeight = 13F;
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LAST_CALL
            // 
            this.LAST_CALL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LAST_CALL.DataPropertyName = "LAST_CALL";
            this.LAST_CALL.FillWeight = 15F;
            this.LAST_CALL.HeaderText = "最后叫号时间";
            this.LAST_CALL.Name = "LAST_CALL";
            this.LAST_CALL.ReadOnly = true;
            this.LAST_CALL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EQU_GUID
            // 
            this.EQU_GUID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EQU_GUID.DataPropertyName = "EQU_GUID";
            this.EQU_GUID.FillWeight = 10F;
            this.EQU_GUID.HeaderText = "GUID";
            this.EQU_GUID.Name = "EQU_GUID";
            this.EQU_GUID.ReadOnly = true;
            this.EQU_GUID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Operate
            // 
            this.Operate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Operate.FillWeight = 8F;
            this.Operate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Operate.HeaderText = "操作";
            this.Operate.Name = "Operate";
            this.Operate.ReadOnly = true;
            this.Operate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Operate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Operate.Text = "删除";
            this.Operate.ToolTipText = "删除";
            this.Operate.UseColumnTextForButtonValue = true;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Edit.FillWeight = 8F;
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.Text = "编辑";
            this.Edit.ToolTipText = "编辑";
            this.Edit.UseColumnTextForButtonValue = true;
            // 
            // frmImgEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(883, 560);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_ImgEquipment);
            this.Name = "frmImgEquipment";
            this.Text = "影像设备表";
            this.Load += new System.EventHandler(this.ImgEquipment_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ImgEquipment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btn_Find;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Add;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_FunName;
        private BaseControls.Panels.MyPanel myPanel1;
        private BaseControls.MyLabel label5;
        private BaseControls.MyLabel label4;
        private BaseControls.MyLabel label3;
        private BaseControls.MyLabel label2;
        private BaseControls.ComboBoxs.MyComboBox cmb_EQUIPMENT_STATE;
        private BaseControls.MyTextBox txt_OFFICE;
        private BaseControls.ComboBoxs.MyComboBox cmb_CLINIC_OFFICE;
        private BaseControls.MyTextBox txt_IMG_EQUIPMENT_NAME;
        private BaseControls.MyLabel label1;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.MyLabel lb_PromptInfo;
        private BaseControls.MyDataGridView dgv_ImgEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMG_EQUIPMENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMG_EQUIPMENT_NAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn CLINIC_OFFICE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn OFFICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIAL_CLASS;
        private System.Windows.Forms.DataGridViewComboBoxColumn EQUIPMENT_STATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPERATOR_DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn LAST_CALL;
        private System.Windows.Forms.DataGridViewTextBoxColumn EQU_GUID;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}