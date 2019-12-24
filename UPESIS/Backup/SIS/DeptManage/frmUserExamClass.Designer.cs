namespace SIS.DeptManage
{
    partial class frmUserExamClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserExamClass));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.btn_Mondify = new System.Windows.Forms.Button();
            this.pl_Top = new BaseControls.Panels.MyPanel();
            this.label2 = new BaseControls.MyLabel();
            this.cmb_REPORT_CAPABILITY = new BaseControls.ComboBoxs.MyComboBox();
            this.txt_USER_NAME = new BaseControls.MyTextBox();
            this.txt_DB_USER = new BaseControls.MyTextBox();
            this.label1 = new BaseControls.MyLabel();
            this.label43 = new BaseControls.MyLabel();
            this.label12 = new BaseControls.MyLabel();
            this.myPanel1 = new BaseControls.Panels.MyPanel();
            this.dgv_USER_EXAM_CLASS_User = new BaseControls.MyDataGridView();
            this.DB_USER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAPABILITY = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_DEPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new BaseControls.MyLabel();
            this.myPanel2 = new BaseControls.Panels.MyPanel();
            this.label5 = new BaseControls.MyLabel();
            this.dgv_USER_EXAM_CLASS_Exam = new BaseControls.MyDataGridView();
            this.dgv_User_Exam_Class = new BaseControls.MyDataGridView();
            this.EXAM_CLASS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPORT_CAPABILITY = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EXAM_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.pl_Top.SuspendLayout();
            this.myPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_USER_EXAM_CLASS_User)).BeginInit();
            this.myPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_USER_EXAM_CLASS_Exam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User_Exam_Class)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 457F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Del, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Clean, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Mondify, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 27);
            this.tableLayoutPanel1.TabIndex = 80;
            // 
            // btn_FunName
            // 
            this.btn_FunName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_FunName.BackgroundImage")));
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
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Save.Location = new System.Drawing.Point(155, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 19);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "保存对照";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
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
            // btn_Mondify
            // 
            this.btn_Mondify.FlatAppearance.BorderSize = 0;
            this.btn_Mondify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Mondify.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Mondify.Location = new System.Drawing.Point(256, 4);
            this.btn_Mondify.Name = "btn_Mondify";
            this.btn_Mondify.Size = new System.Drawing.Size(94, 19);
            this.btn_Mondify.TabIndex = 5;
            this.btn_Mondify.Text = "修改权限";
            this.btn_Mondify.UseVisualStyleBackColor = true;
            this.btn_Mondify.Click += new System.EventHandler(this.btn_Mondify_Click);
            // 
            // pl_Top
            // 
            this.pl_Top.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pl_Top.BorderColor = System.Drawing.Color.Silver;
            this.pl_Top.Controls.Add(this.label2);
            this.pl_Top.Controls.Add(this.cmb_REPORT_CAPABILITY);
            this.pl_Top.Controls.Add(this.txt_USER_NAME);
            this.pl_Top.Controls.Add(this.txt_DB_USER);
            this.pl_Top.Controls.Add(this.label1);
            this.pl_Top.Controls.Add(this.label43);
            this.pl_Top.Controls.Add(this.label12);
            this.pl_Top.Location = new System.Drawing.Point(12, 45);
            this.pl_Top.Name = "pl_Top";
            this.pl_Top.Size = new System.Drawing.Size(858, 35);
            this.pl_Top.TabIndex = 81;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 93;
            this.label2.Text = "报告权限：";
            // 
            // cmb_REPORT_CAPABILITY
            // 
            this.cmb_REPORT_CAPABILITY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_REPORT_CAPABILITY.FormattingEnabled = true;
            this.cmb_REPORT_CAPABILITY.Location = new System.Drawing.Point(469, 8);
            this.cmb_REPORT_CAPABILITY.Name = "cmb_REPORT_CAPABILITY";
            this.cmb_REPORT_CAPABILITY.Size = new System.Drawing.Size(135, 20);
            this.cmb_REPORT_CAPABILITY.TabIndex = 92;
            // 
            // txt_USER_NAME
            // 
            this.txt_USER_NAME.Location = new System.Drawing.Point(258, 7);
            this.txt_USER_NAME.Name = "txt_USER_NAME";
            this.txt_USER_NAME.Size = new System.Drawing.Size(124, 21);
            this.txt_USER_NAME.TabIndex = 91;
            this.txt_USER_NAME.TextChanged += new System.EventHandler(this.txt_USER_NAME_TextChanged);
            // 
            // txt_DB_USER
            // 
            this.txt_DB_USER.Location = new System.Drawing.Point(65, 7);
            this.txt_DB_USER.Name = "txt_DB_USER";
            this.txt_DB_USER.Size = new System.Drawing.Size(124, 21);
            this.txt_DB_USER.TabIndex = 91;
            this.txt_DB_USER.TextChanged += new System.EventHandler(this.txt_DB_USER_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 67;
            this.label1.Text = "用户姓名：";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(4, 10);
            this.label43.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(65, 12);
            this.label43.TabIndex = 67;
            this.label43.Text = "用户代码：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(860, 21);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 90;
            this.label12.Text = "用户头像";
            this.label12.Visible = false;
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BorderColor = System.Drawing.Color.Silver;
            this.myPanel1.Controls.Add(this.dgv_USER_EXAM_CLASS_User);
            this.myPanel1.Controls.Add(this.label4);
            this.myPanel1.Location = new System.Drawing.Point(12, 97);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(557, 457);
            this.myPanel1.TabIndex = 84;
            // 
            // dgv_USER_EXAM_CLASS_User
            // 
            this.dgv_USER_EXAM_CLASS_User.AllowUserToAddRows = false;
            this.dgv_USER_EXAM_CLASS_User.AllowUserToDeleteRows = false;
            this.dgv_USER_EXAM_CLASS_User.AllowUserToResizeRows = false;
            this.dgv_USER_EXAM_CLASS_User.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_USER_EXAM_CLASS_User.BackgroundColor = System.Drawing.Color.White;
            this.dgv_USER_EXAM_CLASS_User.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_USER_EXAM_CLASS_User.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv_USER_EXAM_CLASS_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_USER_EXAM_CLASS_User.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DB_USER,
            this.USER_ID,
            this.USER_NAME,
            this.CAPABILITY,
            this.DEPT_NAME,
            this.USER_DEPT});
            this.dgv_USER_EXAM_CLASS_User.DefaultScaleWidth = 1280;
            this.dgv_USER_EXAM_CLASS_User.Location = new System.Drawing.Point(3, 3);
            this.dgv_USER_EXAM_CLASS_User.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_USER_EXAM_CLASS_User.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_USER_EXAM_CLASS_User.MergeColumnNames")));
            this.dgv_USER_EXAM_CLASS_User.Name = "dgv_USER_EXAM_CLASS_User";
            this.dgv_USER_EXAM_CLASS_User.ReadOnly = true;
            this.dgv_USER_EXAM_CLASS_User.RowHeadersWidth = 25;
            this.dgv_USER_EXAM_CLASS_User.RowTemplate.Height = 23;
            this.dgv_USER_EXAM_CLASS_User.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_USER_EXAM_CLASS_User.Size = new System.Drawing.Size(551, 451);
            this.dgv_USER_EXAM_CLASS_User.TabIndex = 91;
            this.dgv_USER_EXAM_CLASS_User.XmlFile = null;
            this.dgv_USER_EXAM_CLASS_User.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_USER_EXAM_CLASS_User_CellDoubleClick);
            this.dgv_USER_EXAM_CLASS_User.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_USER_EXAM_CLASS_User_CellClick);
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
            this.CAPABILITY.FillWeight = 10F;
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
            this.DEPT_NAME.FillWeight = 20F;
            this.DEPT_NAME.HeaderText = "科室名称";
            this.DEPT_NAME.Name = "DEPT_NAME";
            this.DEPT_NAME.ReadOnly = true;
            this.DEPT_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // USER_DEPT
            // 
            this.USER_DEPT.DataPropertyName = "USER_DEPT";
            this.USER_DEPT.HeaderText = "科室代码";
            this.USER_DEPT.Name = "USER_DEPT";
            this.USER_DEPT.ReadOnly = true;
            this.USER_DEPT.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(860, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 90;
            this.label4.Text = "用户头像";
            this.label4.Visible = false;
            // 
            // myPanel2
            // 
            this.myPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel2.BorderColor = System.Drawing.Color.Silver;
            this.myPanel2.Controls.Add(this.label5);
            this.myPanel2.Controls.Add(this.dgv_USER_EXAM_CLASS_Exam);
            this.myPanel2.Controls.Add(this.dgv_User_Exam_Class);
            this.myPanel2.Location = new System.Drawing.Point(575, 97);
            this.myPanel2.Name = "myPanel2";
            this.myPanel2.Size = new System.Drawing.Size(299, 457);
            this.myPanel2.TabIndex = 85;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(860, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 90;
            this.label5.Text = "用户头像";
            this.label5.Visible = false;
            // 
            // dgv_USER_EXAM_CLASS_Exam
            // 
            this.dgv_USER_EXAM_CLASS_Exam.AllowUserToAddRows = false;
            this.dgv_USER_EXAM_CLASS_Exam.AllowUserToDeleteRows = false;
            this.dgv_USER_EXAM_CLASS_Exam.AllowUserToResizeRows = false;
            this.dgv_USER_EXAM_CLASS_Exam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_USER_EXAM_CLASS_Exam.BackgroundColor = System.Drawing.Color.White;
            this.dgv_USER_EXAM_CLASS_Exam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_USER_EXAM_CLASS_Exam.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv_USER_EXAM_CLASS_Exam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_USER_EXAM_CLASS_Exam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXAM_CLASS});
            this.dgv_USER_EXAM_CLASS_Exam.DefaultScaleWidth = 1280;
            this.dgv_USER_EXAM_CLASS_Exam.Location = new System.Drawing.Point(4, 3);
            this.dgv_USER_EXAM_CLASS_Exam.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_USER_EXAM_CLASS_Exam.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_USER_EXAM_CLASS_Exam.MergeColumnNames")));
            this.dgv_USER_EXAM_CLASS_Exam.Name = "dgv_USER_EXAM_CLASS_Exam";
            this.dgv_USER_EXAM_CLASS_Exam.ReadOnly = true;
            this.dgv_USER_EXAM_CLASS_Exam.RowHeadersVisible = false;
            this.dgv_USER_EXAM_CLASS_Exam.RowHeadersWidth = 25;
            this.dgv_USER_EXAM_CLASS_Exam.RowTemplate.Height = 23;
            this.dgv_USER_EXAM_CLASS_Exam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_USER_EXAM_CLASS_Exam.Size = new System.Drawing.Size(291, 451);
            this.dgv_USER_EXAM_CLASS_Exam.TabIndex = 91;
            this.dgv_USER_EXAM_CLASS_Exam.XmlFile = null;
            // 
            // dgv_User_Exam_Class
            // 
            this.dgv_User_Exam_Class.AllowUserToAddRows = false;
            this.dgv_User_Exam_Class.AllowUserToDeleteRows = false;
            this.dgv_User_Exam_Class.AllowUserToResizeRows = false;
            this.dgv_User_Exam_Class.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_User_Exam_Class.BackgroundColor = System.Drawing.Color.White;
            this.dgv_User_Exam_Class.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_User_Exam_Class.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgv_User_Exam_Class.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_User_Exam_Class.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXAM_CLASS1,
            this.REPORT_CAPABILITY});
            this.dgv_User_Exam_Class.DefaultScaleWidth = 1280;
            this.dgv_User_Exam_Class.Location = new System.Drawing.Point(5, 3);
            this.dgv_User_Exam_Class.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_User_Exam_Class.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_User_Exam_Class.MergeColumnNames")));
            this.dgv_User_Exam_Class.Name = "dgv_User_Exam_Class";
            this.dgv_User_Exam_Class.ReadOnly = true;
            this.dgv_User_Exam_Class.RowHeadersVisible = false;
            this.dgv_User_Exam_Class.RowHeadersWidth = 25;
            this.dgv_User_Exam_Class.RowTemplate.Height = 23;
            this.dgv_User_Exam_Class.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_User_Exam_Class.Size = new System.Drawing.Size(291, 451);
            this.dgv_User_Exam_Class.TabIndex = 92;
            this.dgv_User_Exam_Class.Visible = false;
            this.dgv_User_Exam_Class.XmlFile = null;
            this.dgv_User_Exam_Class.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_User_Exam_Class_DataError);
            // 
            // EXAM_CLASS1
            // 
            this.EXAM_CLASS1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_CLASS1.DataPropertyName = "EXAM_CLASS";
            this.EXAM_CLASS1.FillWeight = 10F;
            this.EXAM_CLASS1.HeaderText = "检查类别";
            this.EXAM_CLASS1.Name = "EXAM_CLASS1";
            this.EXAM_CLASS1.ReadOnly = true;
            // 
            // REPORT_CAPABILITY
            // 
            this.REPORT_CAPABILITY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.REPORT_CAPABILITY.DataPropertyName = "REPORT_CAPABILITY";
            this.REPORT_CAPABILITY.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.REPORT_CAPABILITY.FillWeight = 20F;
            this.REPORT_CAPABILITY.HeaderText = "报告权限";
            this.REPORT_CAPABILITY.Name = "REPORT_CAPABILITY";
            this.REPORT_CAPABILITY.ReadOnly = true;
            this.REPORT_CAPABILITY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.REPORT_CAPABILITY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EXAM_CLASS
            // 
            this.EXAM_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_CLASS.DataPropertyName = "EXAM_CLASS";
            this.EXAM_CLASS.FillWeight = 10F;
            this.EXAM_CLASS.HeaderText = "检查类别";
            this.EXAM_CLASS.Name = "EXAM_CLASS";
            this.EXAM_CLASS.ReadOnly = true;
            // 
            // UserExamClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 566);
            this.Controls.Add(this.pl_Top);
            this.Controls.Add(this.myPanel2);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UserExamClass";
            this.Text = "类别对照";
            this.Load += new System.EventHandler(this.UserExamClass_Load);
            this.VisibleChanged += new System.EventHandler(this.UserExamClass_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pl_Top.ResumeLayout(false);
            this.pl_Top.PerformLayout();
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_USER_EXAM_CLASS_User)).EndInit();
            this.myPanel2.ResumeLayout(false);
            this.myPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_USER_EXAM_CLASS_Exam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_User_Exam_Class)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_FunName;
        public System.Windows.Forms.Button btn_Clean;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_Del;
        private BaseControls.Panels.MyPanel pl_Top;
        private BaseControls.MyLabel label43;
        private BaseControls.MyLabel label12;
        private BaseControls.MyTextBox txt_USER_NAME;
        private BaseControls.MyTextBox txt_DB_USER;
        private BaseControls.MyLabel label1;
        private BaseControls.Panels.MyPanel myPanel1;
        private BaseControls.MyDataGridView dgv_USER_EXAM_CLASS_User;
        private BaseControls.MyLabel label4;
        private BaseControls.Panels.MyPanel myPanel2;
        private BaseControls.MyDataGridView dgv_USER_EXAM_CLASS_Exam;
        private BaseControls.MyLabel label5;
        private BaseControls.MyDataGridView dgv_User_Exam_Class;
        private BaseControls.MyLabel label2;
        private BaseControls.ComboBoxs.MyComboBox cmb_REPORT_CAPABILITY;
        public System.Windows.Forms.Button btn_Mondify;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_CLASS1;
        private System.Windows.Forms.DataGridViewComboBoxColumn REPORT_CAPABILITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_USER;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_NAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn CAPABILITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_DEPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_CLASS;
    }
}