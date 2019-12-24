namespace SIS.QualityControl
{
    partial class QualityControlTotal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QualityControlTotal));
            this.myComboBox1 = new BaseControls.ComboBoxs.MyComboBox();
            this.myPnl = new BaseControls.Panels.MyPanel();
            this.label14 = new BaseControls.MyLabel();
            this.dtp_STUDY_DATE_TIME_Begin = new System.Windows.Forms.DateTimePicker();
            this.cmb_EXAM_CLASS = new System.Windows.Forms.ComboBox();
            this.dtp_STUDY_DATE_TIME_End = new System.Windows.Forms.DateTimePicker();
            this.label5 = new BaseControls.MyLabel();
            this.txt_PATIENT_AGE = new System.Windows.Forms.TextBox();
            this.txt_PATIENT_NAME = new System.Windows.Forms.TextBox();
            this.label7 = new BaseControls.MyLabel();
            this.txt_STUDY_ID = new System.Windows.Forms.TextBox();
            this.txt_INP_NO = new System.Windows.Forms.TextBox();
            this.txt_PATIENT_ID = new System.Windows.Forms.TextBox();
            this.label2 = new BaseControls.MyLabel();
            this.label11 = new BaseControls.MyLabel();
            this.cmb_PATIENT_SEX = new System.Windows.Forms.ComboBox();
            this.label13 = new BaseControls.MyLabel();
            this.label15 = new BaseControls.MyLabel();
            this.label16 = new BaseControls.MyLabel();
            this.comb_RPTStatus = new System.Windows.Forms.ComboBox();
            this.cmb_PATIENT_SOURCE = new System.Windows.Forms.ComboBox();
            this.label6 = new BaseControls.MyLabel();
            this.cmb_EXAM_SUB_CLASS = new System.Windows.Forms.ComboBox();
            this.cmb_REFER_DOCTOR = new System.Windows.Forms.ComboBox();
            this.label1 = new BaseControls.MyLabel();
            this.cmb_REQ_DEPT_NAME = new System.Windows.Forms.ComboBox();
            this.label17 = new BaseControls.MyLabel();
            this.txt_MODALITY = new System.Windows.Forms.TextBox();
            this.comb_StudyStatus = new System.Windows.Forms.ComboBox();
            this.label10 = new BaseControls.MyLabel();
            this.label8 = new BaseControls.MyLabel();
            this.label12 = new BaseControls.MyLabel();
            this.label9 = new BaseControls.MyLabel();
            this.dgv_study = new BaseControls.MyDataGridView();
            this.EXAM_ACCESSION_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_SEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_AGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_BIRTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INP_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BED_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_SUB_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_ITEM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STUDY_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STUDY_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REQ_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REQ_DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REFER_DOCTOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REPORT_STATUS = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.REPORT_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRANSCRIBER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.APPROVER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODALITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGE_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STUDY_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_DEPT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_SOURCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_INDEX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VISIT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SERIES_COUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.myPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_study)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myComboBox1
            // 
            this.myComboBox1.FormattingEnabled = true;
            this.myComboBox1.Location = new System.Drawing.Point(131, 76);
            this.myComboBox1.Name = "myComboBox1";
            this.myComboBox1.Size = new System.Drawing.Size(132, 20);
            this.myComboBox1.TabIndex = 0;
            // 
            // myPnl
            // 
            this.myPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPnl.BorderColor = System.Drawing.Color.Silver;
            this.myPnl.Controls.Add(this.label14);
            this.myPnl.Controls.Add(this.dtp_STUDY_DATE_TIME_Begin);
            this.myPnl.Controls.Add(this.cmb_EXAM_CLASS);
            this.myPnl.Controls.Add(this.dtp_STUDY_DATE_TIME_End);
            this.myPnl.Controls.Add(this.label5);
            this.myPnl.Controls.Add(this.txt_PATIENT_AGE);
            this.myPnl.Controls.Add(this.txt_PATIENT_NAME);
            this.myPnl.Controls.Add(this.label7);
            this.myPnl.Controls.Add(this.txt_STUDY_ID);
            this.myPnl.Controls.Add(this.txt_INP_NO);
            this.myPnl.Controls.Add(this.txt_PATIENT_ID);
            this.myPnl.Controls.Add(this.label2);
            this.myPnl.Controls.Add(this.label11);
            this.myPnl.Controls.Add(this.cmb_PATIENT_SEX);
            this.myPnl.Controls.Add(this.label13);
            this.myPnl.Controls.Add(this.label15);
            this.myPnl.Controls.Add(this.label16);
            this.myPnl.Controls.Add(this.comb_RPTStatus);
            this.myPnl.Controls.Add(this.cmb_PATIENT_SOURCE);
            this.myPnl.Controls.Add(this.label6);
            this.myPnl.Controls.Add(this.cmb_EXAM_SUB_CLASS);
            this.myPnl.Controls.Add(this.cmb_REFER_DOCTOR);
            this.myPnl.Controls.Add(this.label1);
            this.myPnl.Controls.Add(this.cmb_REQ_DEPT_NAME);
            this.myPnl.Controls.Add(this.label17);
            this.myPnl.Controls.Add(this.txt_MODALITY);
            this.myPnl.Controls.Add(this.comb_StudyStatus);
            this.myPnl.Controls.Add(this.label10);
            this.myPnl.Controls.Add(this.label8);
            this.myPnl.Controls.Add(this.label12);
            this.myPnl.Controls.Add(this.label9);
            this.myPnl.Location = new System.Drawing.Point(12, 40);
            this.myPnl.Name = "myPnl";
            this.myPnl.Size = new System.Drawing.Size(948, 93);
            this.myPnl.TabIndex = 37;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(4, 41);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 141;
            this.label14.Text = "检查时间：";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtp_STUDY_DATE_TIME_Begin
            // 
            this.dtp_STUDY_DATE_TIME_Begin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_STUDY_DATE_TIME_Begin.Location = new System.Drawing.Point(76, 37);
            this.dtp_STUDY_DATE_TIME_Begin.Name = "dtp_STUDY_DATE_TIME_Begin";
            this.dtp_STUDY_DATE_TIME_Begin.ShowCheckBox = true;
            this.dtp_STUDY_DATE_TIME_Begin.Size = new System.Drawing.Size(126, 21);
            this.dtp_STUDY_DATE_TIME_Begin.TabIndex = 7;
            // 
            // cmb_EXAM_CLASS
            // 
            this.cmb_EXAM_CLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EXAM_CLASS.FormattingEnabled = true;
            this.cmb_EXAM_CLASS.Location = new System.Drawing.Point(420, 37);
            this.cmb_EXAM_CLASS.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_EXAM_CLASS.Name = "cmb_EXAM_CLASS";
            this.cmb_EXAM_CLASS.Size = new System.Drawing.Size(123, 20);
            this.cmb_EXAM_CLASS.TabIndex = 9;
            this.cmb_EXAM_CLASS.SelectedIndexChanged += new System.EventHandler(this.cmb_EXAM_CLASS_SelectedIndexChanged);
            // 
            // dtp_STUDY_DATE_TIME_End
            // 
            this.dtp_STUDY_DATE_TIME_End.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_STUDY_DATE_TIME_End.Location = new System.Drawing.Point(214, 37);
            this.dtp_STUDY_DATE_TIME_End.Name = "dtp_STUDY_DATE_TIME_End";
            this.dtp_STUDY_DATE_TIME_End.ShowCheckBox = true;
            this.dtp_STUDY_DATE_TIME_End.Size = new System.Drawing.Size(126, 21);
            this.dtp_STUDY_DATE_TIME_End.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(347, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 130;
            this.label5.Text = "病人姓名：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_PATIENT_AGE
            // 
            this.txt_PATIENT_AGE.Location = new System.Drawing.Point(788, 7);
            this.txt_PATIENT_AGE.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PATIENT_AGE.Name = "txt_PATIENT_AGE";
            this.txt_PATIENT_AGE.Size = new System.Drawing.Size(37, 21);
            this.txt_PATIENT_AGE.TabIndex = 5;
            // 
            // txt_PATIENT_NAME
            // 
            this.txt_PATIENT_NAME.Location = new System.Drawing.Point(420, 7);
            this.txt_PATIENT_NAME.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PATIENT_NAME.Name = "txt_PATIENT_NAME";
            this.txt_PATIENT_NAME.Size = new System.Drawing.Size(121, 21);
            this.txt_PATIENT_NAME.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(177, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 138;
            this.label7.Text = "病人ID：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_STUDY_ID
            // 
            this.txt_STUDY_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_STUDY_ID.Location = new System.Drawing.Point(60, 7);
            this.txt_STUDY_ID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_STUDY_ID.Name = "txt_STUDY_ID";
            this.txt_STUDY_ID.Size = new System.Drawing.Size(109, 21);
            this.txt_STUDY_ID.TabIndex = 1;
            // 
            // txt_INP_NO
            // 
            this.txt_INP_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_INP_NO.Location = new System.Drawing.Point(612, 7);
            this.txt_INP_NO.Margin = new System.Windows.Forms.Padding(4);
            this.txt_INP_NO.Name = "txt_INP_NO";
            this.txt_INP_NO.Size = new System.Drawing.Size(119, 21);
            this.txt_INP_NO.TabIndex = 4;
            // 
            // txt_PATIENT_ID
            // 
            this.txt_PATIENT_ID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_PATIENT_ID.Location = new System.Drawing.Point(238, 7);
            this.txt_PATIENT_ID.Margin = new System.Windows.Forms.Padding(4);
            this.txt_PATIENT_ID.Name = "txt_PATIENT_ID";
            this.txt_PATIENT_ID.Size = new System.Drawing.Size(101, 21);
            this.txt_PATIENT_ID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(4, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 143;
            this.label2.Text = "检查号：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(739, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 131;
            this.label11.Text = "年龄：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_PATIENT_SEX
            // 
            this.cmb_PATIENT_SEX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PATIENT_SEX.FormattingEnabled = true;
            this.cmb_PATIENT_SEX.Items.AddRange(new object[] {
            "",
            "男",
            "女",
            "未知"});
            this.cmb_PATIENT_SEX.Location = new System.Drawing.Point(880, 7);
            this.cmb_PATIENT_SEX.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_PATIENT_SEX.Name = "cmb_PATIENT_SEX";
            this.cmb_PATIENT_SEX.Size = new System.Drawing.Size(52, 20);
            this.cmb_PATIENT_SEX.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(551, 12);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 134;
            this.label13.Text = "住院号：";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(347, 69);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 132;
            this.label15.Text = "病人来源：";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(757, 69);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 133;
            this.label16.Text = "报告状态：";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comb_RPTStatus
            // 
            this.comb_RPTStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_RPTStatus.FormattingEnabled = true;
            this.comb_RPTStatus.Items.AddRange(new object[] {
            "",
            "未写",
            "已写",
            "正在写"});
            this.comb_RPTStatus.Location = new System.Drawing.Point(830, 65);
            this.comb_RPTStatus.Margin = new System.Windows.Forms.Padding(4);
            this.comb_RPTStatus.Name = "comb_RPTStatus";
            this.comb_RPTStatus.Size = new System.Drawing.Size(102, 20);
            this.comb_RPTStatus.TabIndex = 16;
            // 
            // cmb_PATIENT_SOURCE
            // 
            this.cmb_PATIENT_SOURCE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PATIENT_SOURCE.FormattingEnabled = true;
            this.cmb_PATIENT_SOURCE.Items.AddRange(new object[] {
            "",
            "门诊",
            "病房",
            "外来"});
            this.cmb_PATIENT_SOURCE.Location = new System.Drawing.Point(420, 65);
            this.cmb_PATIENT_SOURCE.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_PATIENT_SOURCE.Name = "cmb_PATIENT_SOURCE";
            this.cmb_PATIENT_SOURCE.Size = new System.Drawing.Size(123, 20);
            this.cmb_PATIENT_SOURCE.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(347, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 135;
            this.label6.Text = "检查类别：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_EXAM_SUB_CLASS
            // 
            this.cmb_EXAM_SUB_CLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EXAM_SUB_CLASS.DropDownWidth = 130;
            this.cmb_EXAM_SUB_CLASS.Location = new System.Drawing.Point(624, 37);
            this.cmb_EXAM_SUB_CLASS.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_EXAM_SUB_CLASS.Name = "cmb_EXAM_SUB_CLASS";
            this.cmb_EXAM_SUB_CLASS.Size = new System.Drawing.Size(125, 20);
            this.cmb_EXAM_SUB_CLASS.TabIndex = 10;
            // 
            // cmb_REFER_DOCTOR
            // 
            this.cmb_REFER_DOCTOR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_REFER_DOCTOR.FormattingEnabled = true;
            this.cmb_REFER_DOCTOR.Location = new System.Drawing.Point(245, 65);
            this.cmb_REFER_DOCTOR.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_REFER_DOCTOR.MaxDropDownItems = 15;
            this.cmb_REFER_DOCTOR.Name = "cmb_REFER_DOCTOR";
            this.cmb_REFER_DOCTOR.Size = new System.Drawing.Size(95, 20);
            this.cmb_REFER_DOCTOR.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(4, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 142;
            this.label1.Text = "申请科室：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_REQ_DEPT_NAME
            // 
            this.cmb_REQ_DEPT_NAME.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_REQ_DEPT_NAME.DropDownWidth = 130;
            this.cmb_REQ_DEPT_NAME.FormattingEnabled = true;
            this.cmb_REQ_DEPT_NAME.Location = new System.Drawing.Point(76, 65);
            this.cmb_REQ_DEPT_NAME.Margin = new System.Windows.Forms.Padding(4);
            this.cmb_REQ_DEPT_NAME.MaxDropDownItems = 20;
            this.cmb_REQ_DEPT_NAME.Name = "cmb_REQ_DEPT_NAME";
            this.cmb_REQ_DEPT_NAME.Size = new System.Drawing.Size(100, 20);
            this.cmb_REQ_DEPT_NAME.TabIndex = 12;
            this.cmb_REQ_DEPT_NAME.SelectedIndexChanged += new System.EventHandler(this.cmb_REQ_DEPT_NAME_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(757, 41);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 12);
            this.label17.TabIndex = 140;
            this.label17.Text = "检查设备：";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_MODALITY
            // 
            this.txt_MODALITY.Location = new System.Drawing.Point(830, 37);
            this.txt_MODALITY.Margin = new System.Windows.Forms.Padding(4);
            this.txt_MODALITY.Name = "txt_MODALITY";
            this.txt_MODALITY.Size = new System.Drawing.Size(100, 21);
            this.txt_MODALITY.TabIndex = 11;
            // 
            // comb_StudyStatus
            // 
            this.comb_StudyStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_StudyStatus.FormattingEnabled = true;
            this.comb_StudyStatus.Items.AddRange(new object[] {
            "",
            "未标记",
            "已标记"});
            this.comb_StudyStatus.Location = new System.Drawing.Point(624, 65);
            this.comb_StudyStatus.Margin = new System.Windows.Forms.Padding(4);
            this.comb_StudyStatus.Name = "comb_StudyStatus";
            this.comb_StudyStatus.Size = new System.Drawing.Size(125, 20);
            this.comb_StudyStatus.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(833, 12);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 144;
            this.label10.Text = "性别：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(551, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 137;
            this.label8.Text = "检查子类：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(184, 69);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 139;
            this.label12.Text = "申请医生：";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(551, 69);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 136;
            this.label9.Text = "随访标记：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_study
            // 
            this.dgv_study.AllowUserToAddRows = false;
            this.dgv_study.AllowUserToDeleteRows = false;
            this.dgv_study.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_study.BackgroundColor = System.Drawing.Color.White;
            this.dgv_study.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_study.ColumnHeadersHeight = 20;
            this.dgv_study.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXAM_ACCESSION_NUM,
            this.PATIENT_ID,
            this.PATIENT_NAME,
            this.PATIENT_SEX,
            this.PATIENT_AGE,
            this.PATIENT_BIRTH,
            this.INP_NO,
            this.BED_NUM,
            this.EXAM_CLASS,
            this.EXAM_SUB_CLASS,
            this.EXAM_ITEM,
            this.STUDY_DATE_TIME,
            this.STUDY_ID,
            this.REQ_DATE_TIME,
            this.REQ_DEPT_NAME,
            this.REFER_DOCTOR,
            this.REPORT_STATUS,
            this.REPORT_TYPE,
            this.TRANSCRIBER,
            this.APPROVER,
            this.MODALITY,
            this.CHARGE_TYPE,
            this.STUDY_STATUS,
            this.EXAM_DEPT_NAME,
            this.PATIENT_SOURCE,
            this.EXAM_INDEX,
            this.VISIT_ID,
            this.SERIES_COUNT});
            this.dgv_study.DefaultScaleWidth = 1280;
            this.dgv_study.Location = new System.Drawing.Point(12, 148);
            this.dgv_study.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_study.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_study.MergeColumnNames")));
            this.dgv_study.Name = "dgv_study";
            this.dgv_study.ReadOnly = true;
            this.dgv_study.RowHeadersWidth = 30;
            this.dgv_study.RowTemplate.Height = 23;
            this.dgv_study.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_study.Size = new System.Drawing.Size(948, 456);
            this.dgv_study.TabIndex = 38;
            this.dgv_study.XmlFile = null;
            this.dgv_study.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_study_DataError);
            // 
            // EXAM_ACCESSION_NUM
            // 
            this.EXAM_ACCESSION_NUM.DataPropertyName = "EXAM_ACCESSION_NUM";
            this.EXAM_ACCESSION_NUM.FillWeight = 20F;
            this.EXAM_ACCESSION_NUM.HeaderText = "检查申请号";
            this.EXAM_ACCESSION_NUM.Name = "EXAM_ACCESSION_NUM";
            this.EXAM_ACCESSION_NUM.ReadOnly = true;
            this.EXAM_ACCESSION_NUM.Visible = false;
            this.EXAM_ACCESSION_NUM.Width = 120;
            // 
            // PATIENT_ID
            // 
            this.PATIENT_ID.DataPropertyName = "PATIENT_ID";
            this.PATIENT_ID.FillWeight = 20F;
            this.PATIENT_ID.HeaderText = "病人ID";
            this.PATIENT_ID.Name = "PATIENT_ID";
            this.PATIENT_ID.ReadOnly = true;
            this.PATIENT_ID.Width = 80;
            // 
            // PATIENT_NAME
            // 
            this.PATIENT_NAME.DataPropertyName = "PATIENT_NAME";
            this.PATIENT_NAME.FillWeight = 20F;
            this.PATIENT_NAME.HeaderText = "姓名";
            this.PATIENT_NAME.Name = "PATIENT_NAME";
            this.PATIENT_NAME.ReadOnly = true;
            this.PATIENT_NAME.Width = 60;
            // 
            // PATIENT_SEX
            // 
            this.PATIENT_SEX.DataPropertyName = "PATIENT_SEX";
            this.PATIENT_SEX.FillWeight = 10F;
            this.PATIENT_SEX.HeaderText = "性别";
            this.PATIENT_SEX.Name = "PATIENT_SEX";
            this.PATIENT_SEX.ReadOnly = true;
            this.PATIENT_SEX.Width = 40;
            // 
            // PATIENT_AGE
            // 
            this.PATIENT_AGE.DataPropertyName = "PATIENT_AGE";
            this.PATIENT_AGE.FillWeight = 10F;
            this.PATIENT_AGE.HeaderText = "年龄";
            this.PATIENT_AGE.Name = "PATIENT_AGE";
            this.PATIENT_AGE.ReadOnly = true;
            this.PATIENT_AGE.Width = 40;
            // 
            // PATIENT_BIRTH
            // 
            this.PATIENT_BIRTH.DataPropertyName = "PATIENT_BIRTH";
            this.PATIENT_BIRTH.FillWeight = 30F;
            this.PATIENT_BIRTH.HeaderText = "出生日期";
            this.PATIENT_BIRTH.Name = "PATIENT_BIRTH";
            this.PATIENT_BIRTH.ReadOnly = true;
            this.PATIENT_BIRTH.Width = 80;
            // 
            // INP_NO
            // 
            this.INP_NO.DataPropertyName = "INP_NO";
            this.INP_NO.FillWeight = 17F;
            this.INP_NO.HeaderText = "住院号";
            this.INP_NO.Name = "INP_NO";
            this.INP_NO.ReadOnly = true;
            this.INP_NO.Width = 70;
            // 
            // BED_NUM
            // 
            this.BED_NUM.DataPropertyName = "BED_NUM";
            this.BED_NUM.FillWeight = 10F;
            this.BED_NUM.HeaderText = "床号";
            this.BED_NUM.Name = "BED_NUM";
            this.BED_NUM.ReadOnly = true;
            this.BED_NUM.Width = 60;
            // 
            // EXAM_CLASS
            // 
            this.EXAM_CLASS.DataPropertyName = "EXAM_CLASS";
            this.EXAM_CLASS.FillWeight = 30F;
            this.EXAM_CLASS.HeaderText = "检查类别";
            this.EXAM_CLASS.Name = "EXAM_CLASS";
            this.EXAM_CLASS.ReadOnly = true;
            // 
            // EXAM_SUB_CLASS
            // 
            this.EXAM_SUB_CLASS.DataPropertyName = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.FillWeight = 30F;
            this.EXAM_SUB_CLASS.HeaderText = "检查子类";
            this.EXAM_SUB_CLASS.Name = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.ReadOnly = true;
            // 
            // EXAM_ITEM
            // 
            this.EXAM_ITEM.DataPropertyName = "EXAM_ITEM";
            this.EXAM_ITEM.FillWeight = 30F;
            this.EXAM_ITEM.HeaderText = "检查项目";
            this.EXAM_ITEM.Name = "EXAM_ITEM";
            this.EXAM_ITEM.ReadOnly = true;
            // 
            // STUDY_DATE_TIME
            // 
            this.STUDY_DATE_TIME.DataPropertyName = "STUDY_DATE_TIME";
            this.STUDY_DATE_TIME.FillWeight = 30F;
            this.STUDY_DATE_TIME.HeaderText = "检查时间";
            this.STUDY_DATE_TIME.Name = "STUDY_DATE_TIME";
            this.STUDY_DATE_TIME.ReadOnly = true;
            this.STUDY_DATE_TIME.Width = 130;
            // 
            // STUDY_ID
            // 
            this.STUDY_ID.DataPropertyName = "STUDY_ID";
            this.STUDY_ID.FillWeight = 25F;
            this.STUDY_ID.HeaderText = "检查号";
            this.STUDY_ID.Name = "STUDY_ID";
            this.STUDY_ID.ReadOnly = true;
            this.STUDY_ID.Width = 70;
            // 
            // REQ_DATE_TIME
            // 
            this.REQ_DATE_TIME.DataPropertyName = "REQ_DATE_TIME";
            this.REQ_DATE_TIME.FillWeight = 25F;
            this.REQ_DATE_TIME.HeaderText = "申请时间";
            this.REQ_DATE_TIME.Name = "REQ_DATE_TIME";
            this.REQ_DATE_TIME.ReadOnly = true;
            this.REQ_DATE_TIME.Width = 130;
            // 
            // REQ_DEPT_NAME
            // 
            this.REQ_DEPT_NAME.DataPropertyName = "REQ_DEPT_NAME";
            this.REQ_DEPT_NAME.FillWeight = 30F;
            this.REQ_DEPT_NAME.HeaderText = "申请科室";
            this.REQ_DEPT_NAME.Name = "REQ_DEPT_NAME";
            this.REQ_DEPT_NAME.ReadOnly = true;
            // 
            // REFER_DOCTOR
            // 
            this.REFER_DOCTOR.DataPropertyName = "REFER_DOCTOR";
            this.REFER_DOCTOR.FillWeight = 30F;
            this.REFER_DOCTOR.HeaderText = "申请医生";
            this.REFER_DOCTOR.Name = "REFER_DOCTOR";
            this.REFER_DOCTOR.ReadOnly = true;
            // 
            // REPORT_STATUS
            // 
            this.REPORT_STATUS.DataPropertyName = "REPORT_STATUS";
            this.REPORT_STATUS.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.REPORT_STATUS.FillWeight = 30F;
            this.REPORT_STATUS.HeaderText = "报告状态";
            this.REPORT_STATUS.Name = "REPORT_STATUS";
            this.REPORT_STATUS.ReadOnly = true;
            this.REPORT_STATUS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.REPORT_STATUS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.REPORT_STATUS.Width = 80;
            // 
            // REPORT_TYPE
            // 
            this.REPORT_TYPE.DataPropertyName = "REPORT_TYPE";
            this.REPORT_TYPE.FillWeight = 30F;
            this.REPORT_TYPE.HeaderText = "报告类型";
            this.REPORT_TYPE.Name = "REPORT_TYPE";
            this.REPORT_TYPE.ReadOnly = true;
            this.REPORT_TYPE.Width = 80;
            // 
            // TRANSCRIBER
            // 
            this.TRANSCRIBER.DataPropertyName = "TRANSCRIBER";
            this.TRANSCRIBER.FillWeight = 30F;
            this.TRANSCRIBER.HeaderText = "报告医生";
            this.TRANSCRIBER.Name = "TRANSCRIBER";
            this.TRANSCRIBER.ReadOnly = true;
            this.TRANSCRIBER.Width = 80;
            // 
            // APPROVER
            // 
            this.APPROVER.DataPropertyName = "APPROVER";
            this.APPROVER.FillWeight = 30F;
            this.APPROVER.HeaderText = "审核医生";
            this.APPROVER.Name = "APPROVER";
            this.APPROVER.ReadOnly = true;
            this.APPROVER.Width = 80;
            // 
            // MODALITY
            // 
            this.MODALITY.DataPropertyName = "MODALITY";
            this.MODALITY.FillWeight = 30F;
            this.MODALITY.HeaderText = "检查设备";
            this.MODALITY.Name = "MODALITY";
            this.MODALITY.ReadOnly = true;
            // 
            // CHARGE_TYPE
            // 
            this.CHARGE_TYPE.DataPropertyName = "CHARGE_TYPE";
            this.CHARGE_TYPE.FillWeight = 25F;
            this.CHARGE_TYPE.HeaderText = "费别";
            this.CHARGE_TYPE.Name = "CHARGE_TYPE";
            this.CHARGE_TYPE.ReadOnly = true;
            this.CHARGE_TYPE.Width = 70;
            // 
            // STUDY_STATUS
            // 
            this.STUDY_STATUS.DataPropertyName = "STUDY_STATUS";
            this.STUDY_STATUS.FillWeight = 30F;
            this.STUDY_STATUS.HeaderText = "随访标记";
            this.STUDY_STATUS.Name = "STUDY_STATUS";
            this.STUDY_STATUS.ReadOnly = true;
            this.STUDY_STATUS.Width = 80;
            // 
            // EXAM_DEPT_NAME
            // 
            this.EXAM_DEPT_NAME.DataPropertyName = "EXAM_DEPT_NAME";
            this.EXAM_DEPT_NAME.FillWeight = 30F;
            this.EXAM_DEPT_NAME.HeaderText = "检查科室";
            this.EXAM_DEPT_NAME.Name = "EXAM_DEPT_NAME";
            this.EXAM_DEPT_NAME.ReadOnly = true;
            // 
            // PATIENT_SOURCE
            // 
            this.PATIENT_SOURCE.DataPropertyName = "PATIENT_SOURCE";
            this.PATIENT_SOURCE.FillWeight = 30F;
            this.PATIENT_SOURCE.HeaderText = "来源";
            this.PATIENT_SOURCE.Name = "PATIENT_SOURCE";
            this.PATIENT_SOURCE.ReadOnly = true;
            this.PATIENT_SOURCE.Width = 80;
            // 
            // EXAM_INDEX
            // 
            this.EXAM_INDEX.DataPropertyName = "EXAM_INDEX";
            this.EXAM_INDEX.FillWeight = 30F;
            this.EXAM_INDEX.HeaderText = "检查序列号";
            this.EXAM_INDEX.Name = "EXAM_INDEX";
            this.EXAM_INDEX.ReadOnly = true;
            // 
            // VISIT_ID
            // 
            this.VISIT_ID.DataPropertyName = "VISIT_ID";
            this.VISIT_ID.FillWeight = 30F;
            this.VISIT_ID.HeaderText = "本次住院标识";
            this.VISIT_ID.Name = "VISIT_ID";
            this.VISIT_ID.ReadOnly = true;
            this.VISIT_ID.Width = 130;
            // 
            // SERIES_COUNT
            // 
            this.SERIES_COUNT.DataPropertyName = "SERIES_COUNT";
            this.SERIES_COUNT.FillWeight = 25F;
            this.SERIES_COUNT.HeaderText = "序列数";
            this.SERIES_COUNT.Name = "SERIES_COUNT";
            this.SERIES_COUNT.ReadOnly = true;
            this.SERIES_COUNT.Width = 70;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Select, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Find, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Clean, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(972, 27);
            this.tableLayoutPanel1.TabIndex = 36;
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
            this.btn_FunName.TabIndex = 5;
            this.btn_FunName.Text = "button1";
            this.btn_FunName.UseVisualStyleBackColor = true;
            // 
            // btn_Select
            // 
            this.btn_Select.FlatAppearance.BorderSize = 0;
            this.btn_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Select.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Select.Location = new System.Drawing.Point(236, 4);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(74, 19);
            this.btn_Select.TabIndex = 0;
            this.btn_Select.Text = "选中记录";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_Find
            // 
            this.btn_Find.FlatAppearance.BorderSize = 0;
            this.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Find.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Find.Location = new System.Drawing.Point(155, 4);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(74, 19);
            this.btn_Find.TabIndex = 0;
            this.btn_Find.Text = "查找";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // btn_Clean
            // 
            this.btn_Clean.FlatAppearance.BorderSize = 0;
            this.btn_Clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clean.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Clean.Location = new System.Drawing.Point(317, 4);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(74, 19);
            this.btn_Clean.TabIndex = 0;
            this.btn_Clean.Text = "清空";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // QualityControlTotal
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(972, 616);
            this.Controls.Add(this.dgv_study);
            this.Controls.Add(this.myPnl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QualityControlTotal";
            this.Text = "质控统计";
            this.Load += new System.EventHandler(this.QualityControlTotal_Load);
            this.myPnl.ResumeLayout(false);
            this.myPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_study)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.ComboBoxs.MyComboBox myComboBox1;
        private BaseControls.Panels.MyPanel myPnl;
        private BaseControls.MyLabel label14;
        private System.Windows.Forms.DateTimePicker dtp_STUDY_DATE_TIME_Begin;
        private System.Windows.Forms.ComboBox cmb_EXAM_CLASS;
        private System.Windows.Forms.DateTimePicker dtp_STUDY_DATE_TIME_End;
        private BaseControls.MyLabel label8;
        private BaseControls.MyLabel label5;
        private System.Windows.Forms.TextBox txt_PATIENT_NAME;
        private BaseControls.MyLabel label7;
        private System.Windows.Forms.TextBox txt_STUDY_ID;
        private System.Windows.Forms.TextBox txt_INP_NO;
        private System.Windows.Forms.TextBox txt_PATIENT_ID;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label11;
        private System.Windows.Forms.ComboBox cmb_PATIENT_SEX;
        private BaseControls.MyLabel label13;
        private BaseControls.MyLabel label15;
        private BaseControls.MyLabel label16;
        private System.Windows.Forms.ComboBox comb_RPTStatus;
        private System.Windows.Forms.ComboBox cmb_PATIENT_SOURCE;
        private BaseControls.MyLabel label6;
        private System.Windows.Forms.ComboBox cmb_EXAM_SUB_CLASS;
        private BaseControls.MyLabel label12;
        private System.Windows.Forms.ComboBox cmb_REFER_DOCTOR;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.ComboBox cmb_REQ_DEPT_NAME;
        private BaseControls.MyLabel label17;
        private System.Windows.Forms.TextBox txt_MODALITY;
        private BaseControls.MyLabel label9;
        private System.Windows.Forms.ComboBox comb_StudyStatus;
        private BaseControls.MyLabel label10;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_FunName;
        public System.Windows.Forms.Button btn_Select;
        public System.Windows.Forms.Button btn_Find;
        public System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.TextBox txt_PATIENT_AGE;
        private BaseControls.MyDataGridView dgv_study;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ACCESSION_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_SEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_AGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_BIRTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn INP_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn BED_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_SUB_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ITEM;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDY_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDY_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn REQ_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn REQ_DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn REFER_DOCTOR;
        private System.Windows.Forms.DataGridViewComboBoxColumn REPORT_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn REPORT_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRANSCRIBER;
        private System.Windows.Forms.DataGridViewTextBoxColumn APPROVER;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODALITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDY_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_DEPT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_SOURCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_INDEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn VISIT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SERIES_COUNT;
    }
}