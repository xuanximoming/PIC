namespace SIS
{
    partial class frmSubArea
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubArea));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.cmb_Dept = new BaseControls.ComboBoxs.MyComboBox();
            this.cmb_Group = new BaseControls.ComboBoxs.MyComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFunName = new System.Windows.Forms.Button();
            this.btn_Pre = new System.Windows.Forms.Button();
            this.btn_First = new System.Windows.Forms.Button();
            this.btn_Last = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_InsertTo = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_ChangeGroup = new System.Windows.Forms.Button();
            this.label3 = new BaseControls.MyLabel();
            this.cmb_ExamStatus = new BaseControls.ComboBoxs.MyComboBox();
            this.label4 = new BaseControls.MyLabel();
            this.tx_PatientID = new BaseControls.MyTextBox();
            this.tx_PatientName = new BaseControls.MyTextBox();
            this.label5 = new BaseControls.MyLabel();
            this.Pan_Search = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_QueueInfo = new BaseControls.MyDataGridView();
            this.EXAM_ACCESSION_NUM_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_ID_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_NAME_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_SEX_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_LABLE_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOCTOR_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIAL_NO_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISIT_DATE_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIAG_FLAG_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISIT_DEPT_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_NO_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISIT_NO_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REG_DATE_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_REDIAG_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUEUE_NAME_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINT_NO_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASSED_2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_Group2 = new BaseControls.ComboBoxs.MyComboBox();
            this.label6 = new BaseControls.MyLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_RegistInfo = new BaseControls.MyDataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitter = new System.Windows.Forms.Splitter();
            this.EXAM_ACCESSION_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_SEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_LABLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIAL_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISIT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIAG_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISIT_DEPT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ORDER_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISIT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REG_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_REDIAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUEUE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINT_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PASSED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.Pan_Search.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QueueInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RegistInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "科室：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(140, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "检查组：";
            // 
            // cmb_Dept
            // 
            this.cmb_Dept.Enabled = false;
            this.cmb_Dept.FormattingEnabled = true;
            this.cmb_Dept.Location = new System.Drawing.Point(40, 12);
            this.cmb_Dept.Name = "cmb_Dept";
            this.cmb_Dept.Size = new System.Drawing.Size(96, 20);
            this.cmb_Dept.TabIndex = 22;
            this.cmb_Dept.SelectedIndexChanged += new System.EventHandler(this.cmb_Dept_SelectedIndexChanged);
            // 
            // cmb_Group
            // 
            this.cmb_Group.FormattingEnabled = true;
            this.cmb_Group.Location = new System.Drawing.Point(188, 12);
            this.cmb_Group.Name = "cmb_Group";
            this.cmb_Group.Size = new System.Drawing.Size(112, 20);
            this.cmb_Group.TabIndex = 23;
            this.cmb_Group.SelectedIndexChanged += new System.EventHandler(this.cmb_Group_SelectedIndexChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnFunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Pre, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_First, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Last, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Next, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_InsertTo, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_del, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_ChangeGroup, 7, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1016, 27);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // btnFunName
            // 
            this.btnFunName.BackgroundImage = global::SIS.Properties.Resources.bg_nav_column_light;
            this.btnFunName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFunName.Enabled = false;
            this.btnFunName.FlatAppearance.BorderSize = 0;
            this.btnFunName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFunName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFunName.Location = new System.Drawing.Point(1, 1);
            this.btnFunName.Margin = new System.Windows.Forms.Padding(0);
            this.btnFunName.Name = "btnFunName";
            this.btnFunName.Size = new System.Drawing.Size(130, 25);
            this.btnFunName.TabIndex = 3;
            this.btnFunName.Text = "排队分诊";
            this.btnFunName.UseVisualStyleBackColor = true;
            // 
            // btn_Pre
            // 
            this.btn_Pre.FlatAppearance.BorderSize = 0;
            this.btn_Pre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Pre.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Pre.Location = new System.Drawing.Point(266, 4);
            this.btn_Pre.Name = "btn_Pre";
            this.btn_Pre.Size = new System.Drawing.Size(53, 19);
            this.btn_Pre.TabIndex = 10;
            this.btn_Pre.Text = "调前";
            this.btn_Pre.UseVisualStyleBackColor = true;
            this.btn_Pre.Click += new System.EventHandler(this.btn_Pre_Click);
            // 
            // btn_First
            // 
            this.btn_First.FlatAppearance.BorderSize = 0;
            this.btn_First.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_First.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_First.Location = new System.Drawing.Point(135, 4);
            this.btn_First.Name = "btn_First";
            this.btn_First.Size = new System.Drawing.Size(63, 19);
            this.btn_First.TabIndex = 9;
            this.btn_First.Text = "最前";
            this.btn_First.UseVisualStyleBackColor = true;
            this.btn_First.Click += new System.EventHandler(this.btn_First_Click);
            // 
            // btn_Last
            // 
            this.btn_Last.FlatAppearance.BorderSize = 0;
            this.btn_Last.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Last.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Last.Location = new System.Drawing.Point(205, 4);
            this.btn_Last.Name = "btn_Last";
            this.btn_Last.Size = new System.Drawing.Size(53, 19);
            this.btn_Last.TabIndex = 11;
            this.btn_Last.Text = "最后";
            this.btn_Last.UseVisualStyleBackColor = true;
            this.btn_Last.Click += new System.EventHandler(this.btn_Last_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.FlatAppearance.BorderSize = 0;
            this.btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Next.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Next.Location = new System.Drawing.Point(327, 4);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(58, 19);
            this.btn_Next.TabIndex = 17;
            this.btn_Next.Text = "调后";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_InsertTo
            // 
            this.btn_InsertTo.FlatAppearance.BorderSize = 0;
            this.btn_InsertTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_InsertTo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_InsertTo.Location = new System.Drawing.Point(392, 4);
            this.btn_InsertTo.Name = "btn_InsertTo";
            this.btn_InsertTo.Size = new System.Drawing.Size(45, 19);
            this.btn_InsertTo.TabIndex = 0;
            this.btn_InsertTo.Text = "调至";
            this.btn_InsertTo.UseVisualStyleBackColor = true;
            this.btn_InsertTo.Click += new System.EventHandler(this.btn_InsertTo_Click);
            // 
            // btn_del
            // 
            this.btn_del.FlatAppearance.BorderSize = 0;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_del.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_del.Location = new System.Drawing.Point(455, 4);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(45, 19);
            this.btn_del.TabIndex = 12;
            this.btn_del.Text = "删除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_ChangeGroup
            // 
            this.btn_ChangeGroup.FlatAppearance.BorderSize = 0;
            this.btn_ChangeGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChangeGroup.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_ChangeGroup.Location = new System.Drawing.Point(515, 4);
            this.btn_ChangeGroup.Name = "btn_ChangeGroup";
            this.btn_ChangeGroup.Size = new System.Drawing.Size(54, 19);
            this.btn_ChangeGroup.TabIndex = 16;
            this.btn_ChangeGroup.Text = "转诊";
            this.btn_ChangeGroup.UseVisualStyleBackColor = true;
            this.btn_ChangeGroup.Click += new System.EventHandler(this.btn_ChangeGroup_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(305, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "状态：";
            // 
            // cmb_ExamStatus
            // 
            this.cmb_ExamStatus.FormattingEnabled = true;
            this.cmb_ExamStatus.Location = new System.Drawing.Point(341, 12);
            this.cmb_ExamStatus.Name = "cmb_ExamStatus";
            this.cmb_ExamStatus.Size = new System.Drawing.Size(77, 20);
            this.cmb_ExamStatus.TabIndex = 25;
            this.cmb_ExamStatus.SelectedIndexChanged += new System.EventHandler(this.cmb_ExamStatus_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(422, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "ID号：";
            // 
            // tx_PatientID
            // 
            this.tx_PatientID.Location = new System.Drawing.Point(459, 11);
            this.tx_PatientID.Name = "tx_PatientID";
            this.tx_PatientID.Size = new System.Drawing.Size(82, 21);
            this.tx_PatientID.TabIndex = 27;
            this.tx_PatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_PatientID_KeyDown);
            // 
            // tx_PatientName
            // 
            this.tx_PatientName.Location = new System.Drawing.Point(583, 11);
            this.tx_PatientName.Name = "tx_PatientName";
            this.tx_PatientName.Size = new System.Drawing.Size(69, 21);
            this.tx_PatientName.TabIndex = 29;
            this.tx_PatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tx_PatientName_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(545, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "姓名：";
            // 
            // Pan_Search
            // 
            this.Pan_Search.Controls.Add(this.tx_PatientName);
            this.Pan_Search.Controls.Add(this.cmb_ExamStatus);
            this.Pan_Search.Controls.Add(this.cmb_Group);
            this.Pan_Search.Controls.Add(this.cmb_Dept);
            this.Pan_Search.Controls.Add(this.label2);
            this.Pan_Search.Controls.Add(this.label5);
            this.Pan_Search.Controls.Add(this.label3);
            this.Pan_Search.Controls.Add(this.tx_PatientID);
            this.Pan_Search.Controls.Add(this.label1);
            this.Pan_Search.Controls.Add(this.label4);
            this.Pan_Search.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pan_Search.Location = new System.Drawing.Point(3, 17);
            this.Pan_Search.Name = "Pan_Search";
            this.Pan_Search.Size = new System.Drawing.Size(746, 39);
            this.Pan_Search.TabIndex = 30;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_QueueInfo);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(755, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 707);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检查组";
            // 
            // dgv_QueueInfo
            // 
            this.dgv_QueueInfo.AllowUserToAddRows = false;
            this.dgv_QueueInfo.AllowUserToDeleteRows = false;
            this.dgv_QueueInfo.AllowUserToResizeRows = false;
            this.dgv_QueueInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_QueueInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgv_QueueInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_QueueInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXAM_ACCESSION_NUM_2,
            this.PATIENT_ID_2,
            this.PATIENT_NAME_2,
            this.PATIENT_SEX_2,
            this.CLINIC_LABLE_2,
            this.DOCTOR_2,
            this.SERIAL_NO_2,
            this.VISIT_DATE_2,
            this.DIAG_FLAG_2,
            this.VISIT_DEPT_2,
            this.ORDER_NO_2,
            this.VISIT_NO_2,
            this.REG_DATE_2,
            this.IS_REDIAG_2,
            this.QUEUE_NAME_2,
            this.PRINT_NO_2,
            this.PASSED_2});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_QueueInfo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_QueueInfo.DefaultScaleWidth = 1280;
            this.dgv_QueueInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_QueueInfo.Location = new System.Drawing.Point(3, 56);
            this.dgv_QueueInfo.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_QueueInfo.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_QueueInfo.MergeColumnNames")));
            this.dgv_QueueInfo.MultiSelect = false;
            this.dgv_QueueInfo.Name = "dgv_QueueInfo";
            this.dgv_QueueInfo.ReadOnly = true;
            this.dgv_QueueInfo.RowHeadersVisible = false;
            this.dgv_QueueInfo.RowTemplate.Height = 23;
            this.dgv_QueueInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_QueueInfo.Size = new System.Drawing.Size(255, 648);
            this.dgv_QueueInfo.TabIndex = 35;
            this.dgv_QueueInfo.XmlFile = null;
            this.dgv_QueueInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_QueueInfo_MouseDoubleClick);
            // 
            // EXAM_ACCESSION_NUM_2
            // 
            this.EXAM_ACCESSION_NUM_2.DataPropertyName = "EXAM_ACCESSION_NUM";
            this.EXAM_ACCESSION_NUM_2.HeaderText = "检查顺序号";
            this.EXAM_ACCESSION_NUM_2.Name = "EXAM_ACCESSION_NUM_2";
            this.EXAM_ACCESSION_NUM_2.ReadOnly = true;
            this.EXAM_ACCESSION_NUM_2.Visible = false;
            this.EXAM_ACCESSION_NUM_2.Width = 71;
            // 
            // PATIENT_ID_2
            // 
            this.PATIENT_ID_2.DataPropertyName = "PATIENT_ID";
            this.PATIENT_ID_2.FillWeight = 80.18855F;
            this.PATIENT_ID_2.HeaderText = "病人ID";
            this.PATIENT_ID_2.Name = "PATIENT_ID_2";
            this.PATIENT_ID_2.ReadOnly = true;
            this.PATIENT_ID_2.Width = 66;
            // 
            // PATIENT_NAME_2
            // 
            this.PATIENT_NAME_2.DataPropertyName = "PATIENT_NAME";
            this.PATIENT_NAME_2.FillWeight = 66.82378F;
            this.PATIENT_NAME_2.HeaderText = "姓名";
            this.PATIENT_NAME_2.Name = "PATIENT_NAME_2";
            this.PATIENT_NAME_2.ReadOnly = true;
            this.PATIENT_NAME_2.Width = 54;
            // 
            // PATIENT_SEX_2
            // 
            this.PATIENT_SEX_2.DataPropertyName = "PATIENT_SEX";
            this.PATIENT_SEX_2.FillWeight = 40.09427F;
            this.PATIENT_SEX_2.HeaderText = "性别";
            this.PATIENT_SEX_2.Name = "PATIENT_SEX_2";
            this.PATIENT_SEX_2.ReadOnly = true;
            this.PATIENT_SEX_2.Width = 54;
            // 
            // CLINIC_LABLE_2
            // 
            this.CLINIC_LABLE_2.DataPropertyName = "CLINIC_LABLE";
            this.CLINIC_LABLE_2.HeaderText = "门诊号别";
            this.CLINIC_LABLE_2.Name = "CLINIC_LABLE_2";
            this.CLINIC_LABLE_2.ReadOnly = true;
            this.CLINIC_LABLE_2.Visible = false;
            this.CLINIC_LABLE_2.Width = 78;
            // 
            // DOCTOR_2
            // 
            this.DOCTOR_2.DataPropertyName = "DOCTOR";
            this.DOCTOR_2.HeaderText = "医师名称";
            this.DOCTOR_2.Name = "DOCTOR_2";
            this.DOCTOR_2.ReadOnly = true;
            this.DOCTOR_2.Visible = false;
            this.DOCTOR_2.Width = 78;
            // 
            // SERIAL_NO_2
            // 
            this.SERIAL_NO_2.DataPropertyName = "SERIAL_NO";
            this.SERIAL_NO_2.HeaderText = "流水号";
            this.SERIAL_NO_2.Name = "SERIAL_NO_2";
            this.SERIAL_NO_2.ReadOnly = true;
            this.SERIAL_NO_2.Visible = false;
            this.SERIAL_NO_2.Width = 66;
            // 
            // VISIT_DATE_2
            // 
            this.VISIT_DATE_2.DataPropertyName = "VISIT_DATE";
            this.VISIT_DATE_2.HeaderText = "挂号日期";
            this.VISIT_DATE_2.Name = "VISIT_DATE_2";
            this.VISIT_DATE_2.ReadOnly = true;
            this.VISIT_DATE_2.Visible = false;
            this.VISIT_DATE_2.Width = 78;
            // 
            // DIAG_FLAG_2
            // 
            this.DIAG_FLAG_2.DataPropertyName = "DIAG_FLAG";
            this.DIAG_FLAG_2.HeaderText = "就诊标志";
            this.DIAG_FLAG_2.Name = "DIAG_FLAG_2";
            this.DIAG_FLAG_2.ReadOnly = true;
            this.DIAG_FLAG_2.Visible = false;
            this.DIAG_FLAG_2.Width = 78;
            // 
            // VISIT_DEPT_2
            // 
            this.VISIT_DEPT_2.DataPropertyName = "VISIT_DEPT";
            this.VISIT_DEPT_2.HeaderText = "就诊科室";
            this.VISIT_DEPT_2.Name = "VISIT_DEPT_2";
            this.VISIT_DEPT_2.ReadOnly = true;
            this.VISIT_DEPT_2.Visible = false;
            this.VISIT_DEPT_2.Width = 78;
            // 
            // ORDER_NO_2
            // 
            this.ORDER_NO_2.DataPropertyName = "ORDER_NO";
            this.ORDER_NO_2.HeaderText = "排队序号";
            this.ORDER_NO_2.Name = "ORDER_NO_2";
            this.ORDER_NO_2.ReadOnly = true;
            this.ORDER_NO_2.Width = 78;
            // 
            // VISIT_NO_2
            // 
            this.VISIT_NO_2.DataPropertyName = "VISIT_NO";
            this.VISIT_NO_2.HeaderText = "就诊号";
            this.VISIT_NO_2.Name = "VISIT_NO_2";
            this.VISIT_NO_2.ReadOnly = true;
            this.VISIT_NO_2.Visible = false;
            this.VISIT_NO_2.Width = 66;
            // 
            // REG_DATE_2
            // 
            this.REG_DATE_2.DataPropertyName = "REG_DATE";
            this.REG_DATE_2.FillWeight = 192.8934F;
            this.REG_DATE_2.HeaderText = "登记日期";
            this.REG_DATE_2.Name = "REG_DATE_2";
            this.REG_DATE_2.ReadOnly = true;
            this.REG_DATE_2.Width = 78;
            // 
            // IS_REDIAG_2
            // 
            this.IS_REDIAG_2.DataPropertyName = "IS_REDIAG";
            this.IS_REDIAG_2.HeaderText = "是否复诊";
            this.IS_REDIAG_2.Name = "IS_REDIAG_2";
            this.IS_REDIAG_2.ReadOnly = true;
            this.IS_REDIAG_2.Visible = false;
            this.IS_REDIAG_2.Width = 78;
            // 
            // QUEUE_NAME_2
            // 
            this.QUEUE_NAME_2.DataPropertyName = "QUEUE_NAME";
            this.QUEUE_NAME_2.HeaderText = "诊室名";
            this.QUEUE_NAME_2.Name = "QUEUE_NAME_2";
            this.QUEUE_NAME_2.ReadOnly = true;
            this.QUEUE_NAME_2.Visible = false;
            this.QUEUE_NAME_2.Width = 66;
            // 
            // PRINT_NO_2
            // 
            this.PRINT_NO_2.DataPropertyName = "PRINT_NO";
            this.PRINT_NO_2.HeaderText = "打印号";
            this.PRINT_NO_2.Name = "PRINT_NO_2";
            this.PRINT_NO_2.ReadOnly = true;
            this.PRINT_NO_2.Visible = false;
            this.PRINT_NO_2.Width = 66;
            // 
            // PASSED_2
            // 
            this.PASSED_2.DataPropertyName = "PASSED";
            this.PASSED_2.HeaderText = "特殊标识";
            this.PASSED_2.Name = "PASSED_2";
            this.PASSED_2.ReadOnly = true;
            this.PASSED_2.Visible = false;
            this.PASSED_2.Width = 78;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmb_Group2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 39);
            this.panel1.TabIndex = 33;
            // 
            // cmb_Group2
            // 
            this.cmb_Group2.FormattingEnabled = true;
            this.cmb_Group2.Location = new System.Drawing.Point(86, 11);
            this.cmb_Group2.Name = "cmb_Group2";
            this.cmb_Group2.Size = new System.Drawing.Size(112, 20);
            this.cmb_Group2.TabIndex = 25;
            this.cmb_Group2.SelectedIndexChanged += new System.EventHandler(this.cmb_Group2_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(12, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "当前检查组：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_RegistInfo);
            this.groupBox2.Controls.Add(this.Pan_Search);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(752, 707);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "登记信息";
            // 
            // dgv_RegistInfo
            // 
            this.dgv_RegistInfo.AllowDrop = true;
            this.dgv_RegistInfo.AllowUserToAddRows = false;
            this.dgv_RegistInfo.AllowUserToDeleteRows = false;
            this.dgv_RegistInfo.AllowUserToResizeRows = false;
            this.dgv_RegistInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgv_RegistInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RegistInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXAM_ACCESSION_NUM,
            this.PATIENT_ID,
            this.PATIENT_NAME,
            this.PATIENT_SEX,
            this.CLINIC_LABLE,
            this.DOCTOR,
            this.SERIAL_NO,
            this.VISIT_DATE,
            this.DIAG_FLAG,
            this.VISIT_DEPT,
            this.ORDER_NO,
            this.VISIT_NO,
            this.REG_DATE,
            this.IS_REDIAG,
            this.QUEUE_NAME,
            this.PRINT_NO,
            this.PASSED});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_RegistInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_RegistInfo.DefaultScaleWidth = 1280;
            this.dgv_RegistInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_RegistInfo.Location = new System.Drawing.Point(3, 56);
            this.dgv_RegistInfo.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_RegistInfo.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_RegistInfo.MergeColumnNames")));
            this.dgv_RegistInfo.Name = "dgv_RegistInfo";
            this.dgv_RegistInfo.ReadOnly = true;
            this.dgv_RegistInfo.RowHeadersVisible = false;
            this.dgv_RegistInfo.RowTemplate.Height = 23;
            this.dgv_RegistInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_RegistInfo.Size = new System.Drawing.Size(746, 648);
            this.dgv_RegistInfo.TabIndex = 32;
            this.toolTip1.SetToolTip(this.dgv_RegistInfo, "该病人已就诊！");
            this.dgv_RegistInfo.XmlFile = null;
            this.dgv_RegistInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_RegistInfo_MouseDoubleClick);
            this.dgv_RegistInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_RegistInfo_CellFormatting);
            this.dgv_RegistInfo.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgv_RegistInfo_DragEnter);
            this.dgv_RegistInfo.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgv_RegistInfo_DragDrop);
            // 
            // splitter
            // 
            this.splitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter.Location = new System.Drawing.Point(752, 27);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 707);
            this.splitter.TabIndex = 36;
            this.splitter.TabStop = false;
            // 
            // EXAM_ACCESSION_NUM
            // 
            this.EXAM_ACCESSION_NUM.DataPropertyName = "EXAM_ACCESSION_NUM";
            this.EXAM_ACCESSION_NUM.HeaderText = "检查顺序号";
            this.EXAM_ACCESSION_NUM.Name = "EXAM_ACCESSION_NUM";
            this.EXAM_ACCESSION_NUM.ReadOnly = true;
            this.EXAM_ACCESSION_NUM.Width = 90;
            // 
            // PATIENT_ID
            // 
            this.PATIENT_ID.DataPropertyName = "PATIENT_ID";
            this.PATIENT_ID.FillWeight = 120F;
            this.PATIENT_ID.HeaderText = "病人ID";
            this.PATIENT_ID.Name = "PATIENT_ID";
            this.PATIENT_ID.ReadOnly = true;
            this.PATIENT_ID.Width = 80;
            // 
            // PATIENT_NAME
            // 
            this.PATIENT_NAME.DataPropertyName = "PATIENT_NAME";
            this.PATIENT_NAME.HeaderText = "姓名";
            this.PATIENT_NAME.Name = "PATIENT_NAME";
            this.PATIENT_NAME.ReadOnly = true;
            this.PATIENT_NAME.Width = 80;
            // 
            // PATIENT_SEX
            // 
            this.PATIENT_SEX.DataPropertyName = "PATIENT_SEX";
            this.PATIENT_SEX.FillWeight = 60F;
            this.PATIENT_SEX.HeaderText = "性别";
            this.PATIENT_SEX.Name = "PATIENT_SEX";
            this.PATIENT_SEX.ReadOnly = true;
            this.PATIENT_SEX.Width = 60;
            // 
            // CLINIC_LABLE
            // 
            this.CLINIC_LABLE.DataPropertyName = "CLINIC_LABLE";
            this.CLINIC_LABLE.HeaderText = "门诊号别";
            this.CLINIC_LABLE.Name = "CLINIC_LABLE";
            this.CLINIC_LABLE.ReadOnly = true;
            this.CLINIC_LABLE.Visible = false;
            // 
            // DOCTOR
            // 
            this.DOCTOR.DataPropertyName = "DOCTOR";
            this.DOCTOR.HeaderText = "医师名称";
            this.DOCTOR.Name = "DOCTOR";
            this.DOCTOR.ReadOnly = true;
            this.DOCTOR.Width = 85;
            // 
            // SERIAL_NO
            // 
            this.SERIAL_NO.DataPropertyName = "SERIAL_NO";
            this.SERIAL_NO.HeaderText = "流水号";
            this.SERIAL_NO.Name = "SERIAL_NO";
            this.SERIAL_NO.ReadOnly = true;
            this.SERIAL_NO.Visible = false;
            // 
            // VISIT_DATE
            // 
            this.VISIT_DATE.DataPropertyName = "VISIT_DATE";
            this.VISIT_DATE.HeaderText = "申请时间";
            this.VISIT_DATE.Name = "VISIT_DATE";
            this.VISIT_DATE.ReadOnly = true;
            this.VISIT_DATE.Width = 120;
            // 
            // DIAG_FLAG
            // 
            this.DIAG_FLAG.DataPropertyName = "DIAG_FLAG";
            this.DIAG_FLAG.HeaderText = "就诊标志";
            this.DIAG_FLAG.Name = "DIAG_FLAG";
            this.DIAG_FLAG.ReadOnly = true;
            this.DIAG_FLAG.Width = 85;
            // 
            // VISIT_DEPT
            // 
            this.VISIT_DEPT.DataPropertyName = "VISIT_DEPT";
            this.VISIT_DEPT.HeaderText = "就诊科室";
            this.VISIT_DEPT.Name = "VISIT_DEPT";
            this.VISIT_DEPT.ReadOnly = true;
            this.VISIT_DEPT.Visible = false;
            // 
            // ORDER_NO
            // 
            this.ORDER_NO.DataPropertyName = "ORDER_NO";
            this.ORDER_NO.HeaderText = "排队序号";
            this.ORDER_NO.Name = "ORDER_NO";
            this.ORDER_NO.ReadOnly = true;
            this.ORDER_NO.Visible = false;
            // 
            // VISIT_NO
            // 
            this.VISIT_NO.DataPropertyName = "VISIT_NO";
            this.VISIT_NO.HeaderText = "就诊号";
            this.VISIT_NO.Name = "VISIT_NO";
            this.VISIT_NO.ReadOnly = true;
            this.VISIT_NO.Visible = false;
            // 
            // REG_DATE
            // 
            this.REG_DATE.DataPropertyName = "REG_DATE";
            this.REG_DATE.HeaderText = "预约时间";
            this.REG_DATE.Name = "REG_DATE";
            this.REG_DATE.ReadOnly = true;
            this.REG_DATE.Width = 120;
            // 
            // IS_REDIAG
            // 
            this.IS_REDIAG.DataPropertyName = "IS_REDIAG";
            this.IS_REDIAG.HeaderText = "是否复诊";
            this.IS_REDIAG.Name = "IS_REDIAG";
            this.IS_REDIAG.ReadOnly = true;
            this.IS_REDIAG.Visible = false;
            // 
            // QUEUE_NAME
            // 
            this.QUEUE_NAME.DataPropertyName = "QUEUE_NAME";
            this.QUEUE_NAME.HeaderText = "诊室名";
            this.QUEUE_NAME.Name = "QUEUE_NAME";
            this.QUEUE_NAME.ReadOnly = true;
            // 
            // PRINT_NO
            // 
            this.PRINT_NO.DataPropertyName = "PRINT_NO";
            this.PRINT_NO.HeaderText = "打印号";
            this.PRINT_NO.Name = "PRINT_NO";
            this.PRINT_NO.ReadOnly = true;
            this.PRINT_NO.Visible = false;
            // 
            // PASSED
            // 
            this.PASSED.DataPropertyName = "PASSED";
            this.PASSED.HeaderText = "特殊标识";
            this.PASSED.Name = "PASSED";
            this.PASSED.ReadOnly = true;
            this.PASSED.Visible = false;
            // 
            // frmSubArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmSubArea";
            this.Text = "分诊";
            this.Load += new System.EventHandler(this.frmSubArea_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.Pan_Search.ResumeLayout(false);
            this.Pan_Search.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_QueueInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RegistInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_InsertTo;
        public System.Windows.Forms.Button btnFunName;
        private BaseControls.MyLabel label1;
        private BaseControls.MyLabel label2;
        private BaseControls.ComboBoxs.MyComboBox cmb_Dept;
        private BaseControls.ComboBoxs.MyComboBox cmb_Group;
        public System.Windows.Forms.Button btn_Last;
        public System.Windows.Forms.Button btn_Pre;
        public System.Windows.Forms.Button btn_First;
        public System.Windows.Forms.Button btn_del;
        public System.Windows.Forms.Button btn_ChangeGroup;
        public System.Windows.Forms.Button btn_Next;
        private BaseControls.MyLabel label3;
        private BaseControls.ComboBoxs.MyComboBox cmb_ExamStatus;
        private BaseControls.MyLabel label4;
        private BaseControls.MyTextBox tx_PatientID;
        private BaseControls.MyTextBox tx_PatientName;
        private BaseControls.MyLabel label5;
        private System.Windows.Forms.Panel Pan_Search;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private BaseControls.ComboBoxs.MyComboBox cmb_Group2;
        private BaseControls.MyLabel label6;
        private System.Windows.Forms.Panel panel1;
        private BaseControls.MyDataGridView dgv_RegistInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private BaseControls.MyDataGridView dgv_QueueInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ACCESSION_NUM_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_ID_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_NAME_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_SEX_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLINIC_LABLE_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCTOR_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIAL_NO_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISIT_DATE_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIAG_FLAG_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISIT_DEPT_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_NO_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISIT_NO_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn REG_DATE_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IS_REDIAG_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUEUE_NAME_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINT_NO_2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PASSED_2;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ACCESSION_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_SEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLINIC_LABLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DOCTOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIAL_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISIT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIAG_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISIT_DEPT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ORDER_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISIT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn REG_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IS_REDIAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUEUE_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINT_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn PASSED;
    }
}