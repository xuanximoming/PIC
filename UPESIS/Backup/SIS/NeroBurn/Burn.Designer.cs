namespace SIS.NeroBurn
{
    partial class Burn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Burn));
            this.gp_Patient = new BaseControls.GroupBox.MyGroupBox();
            this.dgv_WorkList = new BaseControls.MyDataGridView();
            this.IDL = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EXAM_ACCESSION_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STUDY_DATETIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_study = new BaseControls.MyDataGridView();
            this.ID = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.STUDY_KEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_AGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_SEX = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IS_ONLINE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STUDY_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_BIRTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmb_PATIENT_SEX = new BaseControls.ComboBoxs.MyComboBox();
            this.txt_PATIENT_AGE = new BaseControls.MyTextBox();
            this.txt_PATIENT_NAME = new BaseControls.MyTextBox();
            this.txt_PATIENT_ID = new BaseControls.MyTextBox();
            this.btn_PatientPack = new System.Windows.Forms.Button();
            this.btn_NotSelectAll = new System.Windows.Forms.Button();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.label14 = new BaseControls.MyLabel();
            this.l_patientSpaceSize = new BaseControls.MyLabel();
            this.label13 = new BaseControls.MyLabel();
            this.label10 = new BaseControls.MyLabel();
            this.label6 = new BaseControls.MyLabel();
            this.label12 = new BaseControls.MyLabel();
            this.label18 = new BaseControls.MyLabel();
            this.label17 = new BaseControls.MyLabel();
            this.label16 = new BaseControls.MyLabel();
            this.label9 = new BaseControls.MyLabel();
            this.dtpe_STUDY_DATE_TIME = new System.Windows.Forms.DateTimePicker();
            this.dtps_STUDY_DATE_TIME = new System.Windows.Forms.DateTimePicker();
            this.gp_Time = new BaseControls.GroupBox.MyGroupBox();
            this.label3 = new BaseControls.MyLabel();
            this.dtp_StudyS = new System.Windows.Forms.DateTimePicker();
            this.dtp_Studye = new System.Windows.Forms.DateTimePicker();
            this.label4 = new BaseControls.MyLabel();
            this.label5 = new BaseControls.MyLabel();
            this.l_timeSpaceSize = new BaseControls.MyLabel();
            this.btn_TimePack = new System.Windows.Forms.Button();
            this.myGroupBox1 = new BaseControls.GroupBox.MyGroupBox();
            this.rB_localDataBase = new System.Windows.Forms.RadioButton();
            this.rB_remoteDataBase = new System.Windows.Forms.RadioButton();
            this.label15 = new BaseControls.MyLabel();
            this.myGroupBox2 = new BaseControls.GroupBox.MyGroupBox();
            this.label1 = new BaseControls.MyLabel();
            this.cmb_BurnSpeed = new System.Windows.Forms.ComboBox();
            this.cmb_BurnDevices = new System.Windows.Forms.ComboBox();
            this.label2 = new BaseControls.MyLabel();
            this.label7 = new BaseControls.MyLabel();
            this.label11 = new BaseControls.MyLabel();
            this.l_DiscSize = new BaseControls.MyLabel();
            this.label8 = new BaseControls.MyLabel();
            this.lb_DiscType = new BaseControls.MyLabel();
            this.l_discVolumeKey = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.btn_Burn = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.btn_SystemSet = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsLab_Memo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsLab_pROCESS = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsPrcess = new System.Windows.Forms.ToolStripProgressBar();
            this.gp_Patient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_WorkList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_study)).BeginInit();
            this.gp_Time.SuspendLayout();
            this.myGroupBox1.SuspendLayout();
            this.myGroupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gp_Patient
            // 
            this.gp_Patient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gp_Patient.BackgroundColor = System.Drawing.Color.White;
            this.gp_Patient.BackgroundGradientColor = System.Drawing.Color.White;
            this.gp_Patient.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.gp_Patient.BorderColor = System.Drawing.Color.Black;
            this.gp_Patient.BorderThickness = 1F;
            this.gp_Patient.Controls.Add(this.dgv_WorkList);
            this.gp_Patient.Controls.Add(this.dgv_study);
            this.gp_Patient.Controls.Add(this.cmb_PATIENT_SEX);
            this.gp_Patient.Controls.Add(this.txt_PATIENT_AGE);
            this.gp_Patient.Controls.Add(this.txt_PATIENT_NAME);
            this.gp_Patient.Controls.Add(this.txt_PATIENT_ID);
            this.gp_Patient.Controls.Add(this.btn_PatientPack);
            this.gp_Patient.Controls.Add(this.btn_NotSelectAll);
            this.gp_Patient.Controls.Add(this.btn_SelectAll);
            this.gp_Patient.Controls.Add(this.label14);
            this.gp_Patient.Controls.Add(this.l_patientSpaceSize);
            this.gp_Patient.Controls.Add(this.label13);
            this.gp_Patient.Controls.Add(this.label10);
            this.gp_Patient.Controls.Add(this.label6);
            this.gp_Patient.Controls.Add(this.label12);
            this.gp_Patient.Controls.Add(this.label18);
            this.gp_Patient.Controls.Add(this.label17);
            this.gp_Patient.Controls.Add(this.label16);
            this.gp_Patient.Controls.Add(this.label9);
            this.gp_Patient.Controls.Add(this.dtpe_STUDY_DATE_TIME);
            this.gp_Patient.Controls.Add(this.dtps_STUDY_DATE_TIME);
            this.gp_Patient.CustomGroupBoxColor = System.Drawing.Color.White;
            this.gp_Patient.GroupImage = null;
            this.gp_Patient.GroupTitle = "病人打包区";
            this.gp_Patient.Location = new System.Drawing.Point(12, 30);
            this.gp_Patient.Name = "gp_Patient";
            this.gp_Patient.Padding = new System.Windows.Forms.Padding(20);
            this.gp_Patient.PaintGroupBox = false;
            this.gp_Patient.RoundCorners = 10;
            this.gp_Patient.ShadowColor = System.Drawing.Color.DarkGray;
            this.gp_Patient.ShadowControl = false;
            this.gp_Patient.ShadowThickness = 3;
            this.gp_Patient.Size = new System.Drawing.Size(527, 574);
            this.gp_Patient.TabIndex = 39;
            // 
            // dgv_WorkList
            // 
            this.dgv_WorkList.AllowUserToAddRows = false;
            this.dgv_WorkList.AllowUserToDeleteRows = false;
            this.dgv_WorkList.AllowUserToResizeRows = false;
            this.dgv_WorkList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_WorkList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_WorkList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_WorkList.ColumnHeadersHeight = 20;
            this.dgv_WorkList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDL,
            this.EXAM_ACCESSION_NUM,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.STUDY_DATETIME,
            this.dataGridViewTextBoxColumn9});
            this.dgv_WorkList.DefaultScaleWidth = 1280;
            this.dgv_WorkList.Location = new System.Drawing.Point(13, 298);
            this.dgv_WorkList.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_WorkList.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_WorkList.MergeColumnNames")));
            this.dgv_WorkList.Name = "dgv_WorkList";
            this.dgv_WorkList.RowHeadersVisible = false;
            this.dgv_WorkList.RowHeadersWidth = 30;
            this.dgv_WorkList.RowTemplate.Height = 23;
            this.dgv_WorkList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_WorkList.Size = new System.Drawing.Size(503, 168);
            this.dgv_WorkList.TabIndex = 72;
            this.dgv_WorkList.XmlFile = null;
            this.dgv_WorkList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_WorkList_DataError);
            // 
            // IDL
            // 
            this.IDL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IDL.FillWeight = 10F;
            this.IDL.HeaderText = "*";
            this.IDL.Name = "IDL";
            // 
            // EXAM_ACCESSION_NUM
            // 
            this.EXAM_ACCESSION_NUM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_ACCESSION_NUM.DataPropertyName = "EXAM_ACCESSION_NUM";
            this.EXAM_ACCESSION_NUM.FillWeight = 20F;
            this.EXAM_ACCESSION_NUM.HeaderText = "检查主键";
            this.EXAM_ACCESSION_NUM.Name = "EXAM_ACCESSION_NUM";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PATIENT_ID";
            this.dataGridViewTextBoxColumn3.FillWeight = 20F;
            this.dataGridViewTextBoxColumn3.HeaderText = "病人ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PATIENT_NAME";
            this.dataGridViewTextBoxColumn4.FillWeight = 20F;
            this.dataGridViewTextBoxColumn4.HeaderText = "姓名";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PATIENT_AGE";
            this.dataGridViewTextBoxColumn5.FillWeight = 10.98349F;
            this.dataGridViewTextBoxColumn5.HeaderText = "年龄";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PATIENT_SEX";
            this.dataGridViewTextBoxColumn6.FillWeight = 10.98349F;
            this.dataGridViewTextBoxColumn6.HeaderText = "性别";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "IS_ONLINE";
            this.dataGridViewTextBoxColumn7.FillWeight = 18F;
            this.dataGridViewTextBoxColumn7.HeaderText = "是否离线";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // STUDY_DATETIME
            // 
            this.STUDY_DATETIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STUDY_DATETIME.DataPropertyName = "STUDY_DATE_TIME";
            this.STUDY_DATETIME.FillWeight = 25F;
            this.STUDY_DATETIME.HeaderText = "检查日期";
            this.STUDY_DATETIME.Name = "STUDY_DATETIME";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PATIENT_BIRTH";
            this.dataGridViewTextBoxColumn9.FillWeight = 25F;
            this.dataGridViewTextBoxColumn9.HeaderText = "出生日期";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dgv_study
            // 
            this.dgv_study.AllowUserToAddRows = false;
            this.dgv_study.AllowUserToDeleteRows = false;
            this.dgv_study.AllowUserToResizeRows = false;
            this.dgv_study.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_study.BackgroundColor = System.Drawing.Color.White;
            this.dgv_study.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_study.ColumnHeadersHeight = 20;
            this.dgv_study.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.STUDY_KEY,
            this.PATIENT_ID,
            this.PATIENT_NAME,
            this.PATIENT_AGE,
            this.PATIENT_SEX,
            this.IS_ONLINE,
            this.STUDY_DATE_TIME,
            this.PATIENT_BIRTH});
            this.dgv_study.DefaultScaleWidth = 1280;
            this.dgv_study.Location = new System.Drawing.Point(13, 122);
            this.dgv_study.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_study.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_study.MergeColumnNames")));
            this.dgv_study.Name = "dgv_study";
            this.dgv_study.RowHeadersVisible = false;
            this.dgv_study.RowHeadersWidth = 30;
            this.dgv_study.RowTemplate.Height = 23;
            this.dgv_study.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_study.Size = new System.Drawing.Size(503, 155);
            this.dgv_study.TabIndex = 71;
            this.dgv_study.XmlFile = null;
            this.dgv_study.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_study_DataError);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.FillWeight = 10F;
            this.ID.HeaderText = "*";
            this.ID.Name = "ID";
            // 
            // STUDY_KEY
            // 
            this.STUDY_KEY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STUDY_KEY.DataPropertyName = "STUDY_KEY";
            this.STUDY_KEY.FillWeight = 20F;
            this.STUDY_KEY.HeaderText = "检查主键";
            this.STUDY_KEY.Name = "STUDY_KEY";
            this.STUDY_KEY.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.STUDY_KEY.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PATIENT_ID
            // 
            this.PATIENT_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_ID.DataPropertyName = "PATIENT_ID";
            this.PATIENT_ID.FillWeight = 20F;
            this.PATIENT_ID.HeaderText = "病人ID";
            this.PATIENT_ID.Name = "PATIENT_ID";
            this.PATIENT_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PATIENT_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PATIENT_NAME
            // 
            this.PATIENT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_NAME.DataPropertyName = "PATIENT_NAME";
            this.PATIENT_NAME.FillWeight = 20F;
            this.PATIENT_NAME.HeaderText = "姓名";
            this.PATIENT_NAME.Name = "PATIENT_NAME";
            this.PATIENT_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PATIENT_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PATIENT_AGE
            // 
            this.PATIENT_AGE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_AGE.DataPropertyName = "PATIENT_AGE";
            this.PATIENT_AGE.FillWeight = 11F;
            this.PATIENT_AGE.HeaderText = "年龄";
            this.PATIENT_AGE.Name = "PATIENT_AGE";
            this.PATIENT_AGE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PATIENT_AGE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PATIENT_SEX
            // 
            this.PATIENT_SEX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_SEX.DataPropertyName = "PATIENT_SEX";
            this.PATIENT_SEX.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.PATIENT_SEX.FillWeight = 12F;
            this.PATIENT_SEX.HeaderText = "性别";
            this.PATIENT_SEX.Name = "PATIENT_SEX";
            this.PATIENT_SEX.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PATIENT_SEX.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IS_ONLINE
            // 
            this.IS_ONLINE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IS_ONLINE.DataPropertyName = "IS_ONLINE";
            this.IS_ONLINE.FillWeight = 18F;
            this.IS_ONLINE.HeaderText = "是否离线";
            this.IS_ONLINE.Name = "IS_ONLINE";
            this.IS_ONLINE.Visible = false;
            // 
            // STUDY_DATE_TIME
            // 
            this.STUDY_DATE_TIME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STUDY_DATE_TIME.DataPropertyName = "STUDY_DATE_TIME";
            this.STUDY_DATE_TIME.FillWeight = 25F;
            this.STUDY_DATE_TIME.HeaderText = "检查日期";
            this.STUDY_DATE_TIME.Name = "STUDY_DATE_TIME";
            // 
            // PATIENT_BIRTH
            // 
            this.PATIENT_BIRTH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_BIRTH.DataPropertyName = "PATIENT_BIRTH";
            this.PATIENT_BIRTH.FillWeight = 25F;
            this.PATIENT_BIRTH.HeaderText = "出生日期";
            this.PATIENT_BIRTH.Name = "PATIENT_BIRTH";
            // 
            // cmb_PATIENT_SEX
            // 
            this.cmb_PATIENT_SEX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_PATIENT_SEX.FormattingEnabled = true;
            this.cmb_PATIENT_SEX.Location = new System.Drawing.Point(358, 35);
            this.cmb_PATIENT_SEX.Name = "cmb_PATIENT_SEX";
            this.cmb_PATIENT_SEX.Size = new System.Drawing.Size(51, 20);
            this.cmb_PATIENT_SEX.TabIndex = 70;
            // 
            // txt_PATIENT_AGE
            // 
            this.txt_PATIENT_AGE.Location = new System.Drawing.Point(456, 37);
            this.txt_PATIENT_AGE.MaxLength = 3;
            this.txt_PATIENT_AGE.Name = "txt_PATIENT_AGE";
            this.txt_PATIENT_AGE.Size = new System.Drawing.Size(40, 21);
            this.txt_PATIENT_AGE.TabIndex = 69;
            // 
            // txt_PATIENT_NAME
            // 
            this.txt_PATIENT_NAME.Location = new System.Drawing.Point(210, 34);
            this.txt_PATIENT_NAME.Name = "txt_PATIENT_NAME";
            this.txt_PATIENT_NAME.Size = new System.Drawing.Size(97, 21);
            this.txt_PATIENT_NAME.TabIndex = 69;
            // 
            // txt_PATIENT_ID
            // 
            this.txt_PATIENT_ID.Location = new System.Drawing.Point(64, 36);
            this.txt_PATIENT_ID.Name = "txt_PATIENT_ID";
            this.txt_PATIENT_ID.Size = new System.Drawing.Size(97, 21);
            this.txt_PATIENT_ID.TabIndex = 69;
            // 
            // btn_PatientPack
            // 
            this.btn_PatientPack.Location = new System.Drawing.Point(366, 530);
            this.btn_PatientPack.Name = "btn_PatientPack";
            this.btn_PatientPack.Size = new System.Drawing.Size(75, 28);
            this.btn_PatientPack.TabIndex = 68;
            this.btn_PatientPack.Text = "病人打包";
            this.btn_PatientPack.UseVisualStyleBackColor = true;
            this.btn_PatientPack.Click += new System.EventHandler(this.btn_PatientPack_Click);
            // 
            // btn_NotSelectAll
            // 
            this.btn_NotSelectAll.Location = new System.Drawing.Point(226, 530);
            this.btn_NotSelectAll.Name = "btn_NotSelectAll";
            this.btn_NotSelectAll.Size = new System.Drawing.Size(75, 28);
            this.btn_NotSelectAll.TabIndex = 68;
            this.btn_NotSelectAll.Text = "全不选";
            this.btn_NotSelectAll.UseVisualStyleBackColor = true;
            this.btn_NotSelectAll.Click += new System.EventHandler(this.btn_NotSelectAll_Click);
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.Location = new System.Drawing.Point(86, 530);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(75, 28);
            this.btn_SelectAll.TabIndex = 68;
            this.btn_SelectAll.Text = "全选";
            this.btn_SelectAll.UseVisualStyleBackColor = true;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 500);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 12);
            this.label14.TabIndex = 66;
            this.label14.Text = "总占空间大小:";
            // 
            // l_patientSpaceSize
            // 
            this.l_patientSpaceSize.BackColor = System.Drawing.Color.LightGray;
            this.l_patientSpaceSize.Location = new System.Drawing.Point(100, 496);
            this.l_patientSpaceSize.Name = "l_patientSpaceSize";
            this.l_patientSpaceSize.Size = new System.Drawing.Size(355, 20);
            this.l_patientSpaceSize.TabIndex = 67;
            this.l_patientSpaceSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 107);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 12);
            this.label13.TabIndex = 65;
            this.label13.Text = "病人检查列表:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 12);
            this.label10.TabIndex = 63;
            this.label10.Text = "检查时间:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(502, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 62;
            this.label6.Text = "岁";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(317, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 61;
            this.label12.Text = "性别:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(177, 70);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 58;
            this.label18.Text = "到";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(415, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 12);
            this.label17.TabIndex = 59;
            this.label17.Text = "年龄:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 60;
            this.label16.Text = "病人ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(169, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 57;
            this.label9.Text = "姓名:";
            // 
            // dtpe_STUDY_DATE_TIME
            // 
            this.dtpe_STUDY_DATE_TIME.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpe_STUDY_DATE_TIME.Location = new System.Drawing.Point(200, 66);
            this.dtpe_STUDY_DATE_TIME.Name = "dtpe_STUDY_DATE_TIME";
            this.dtpe_STUDY_DATE_TIME.ShowCheckBox = true;
            this.dtpe_STUDY_DATE_TIME.Size = new System.Drawing.Size(98, 21);
            this.dtpe_STUDY_DATE_TIME.TabIndex = 54;
            // 
            // dtps_STUDY_DATE_TIME
            // 
            this.dtps_STUDY_DATE_TIME.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtps_STUDY_DATE_TIME.Location = new System.Drawing.Point(73, 66);
            this.dtps_STUDY_DATE_TIME.Name = "dtps_STUDY_DATE_TIME";
            this.dtps_STUDY_DATE_TIME.ShowCheckBox = true;
            this.dtps_STUDY_DATE_TIME.Size = new System.Drawing.Size(98, 21);
            this.dtps_STUDY_DATE_TIME.TabIndex = 53;
            // 
            // gp_Time
            // 
            this.gp_Time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gp_Time.BackgroundColor = System.Drawing.Color.White;
            this.gp_Time.BackgroundGradientColor = System.Drawing.Color.White;
            this.gp_Time.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.gp_Time.BorderColor = System.Drawing.Color.Black;
            this.gp_Time.BorderThickness = 1F;
            this.gp_Time.Controls.Add(this.label3);
            this.gp_Time.Controls.Add(this.dtp_StudyS);
            this.gp_Time.Controls.Add(this.dtp_Studye);
            this.gp_Time.Controls.Add(this.label4);
            this.gp_Time.Controls.Add(this.label5);
            this.gp_Time.Controls.Add(this.l_timeSpaceSize);
            this.gp_Time.Controls.Add(this.btn_TimePack);
            this.gp_Time.CustomGroupBoxColor = System.Drawing.Color.White;
            this.gp_Time.GroupImage = null;
            this.gp_Time.GroupTitle = "时间段打包区";
            this.gp_Time.Location = new System.Drawing.Point(560, 30);
            this.gp_Time.Name = "gp_Time";
            this.gp_Time.Padding = new System.Windows.Forms.Padding(20);
            this.gp_Time.PaintGroupBox = false;
            this.gp_Time.RoundCorners = 10;
            this.gp_Time.ShadowColor = System.Drawing.Color.DarkGray;
            this.gp_Time.ShadowControl = false;
            this.gp_Time.ShadowThickness = 3;
            this.gp_Time.Size = new System.Drawing.Size(400, 149);
            this.gp_Time.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 71;
            this.label3.Text = "检查日期时间:";
            // 
            // dtp_StudyS
            // 
            this.dtp_StudyS.Location = new System.Drawing.Point(115, 35);
            this.dtp_StudyS.Name = "dtp_StudyS";
            this.dtp_StudyS.Size = new System.Drawing.Size(112, 21);
            this.dtp_StudyS.TabIndex = 69;
            // 
            // dtp_Studye
            // 
            this.dtp_Studye.Location = new System.Drawing.Point(277, 35);
            this.dtp_Studye.Name = "dtp_Studye";
            this.dtp_Studye.Size = new System.Drawing.Size(112, 21);
            this.dtp_Studye.TabIndex = 70;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(243, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 72;
            this.label4.Text = "to";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 73;
            this.label5.Text = "总占空间大小:";
            // 
            // l_timeSpaceSize
            // 
            this.l_timeSpaceSize.BackColor = System.Drawing.Color.LightGray;
            this.l_timeSpaceSize.Location = new System.Drawing.Point(115, 76);
            this.l_timeSpaceSize.Name = "l_timeSpaceSize";
            this.l_timeSpaceSize.Size = new System.Drawing.Size(274, 20);
            this.l_timeSpaceSize.TabIndex = 74;
            this.l_timeSpaceSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_TimePack
            // 
            this.btn_TimePack.Location = new System.Drawing.Point(160, 107);
            this.btn_TimePack.Name = "btn_TimePack";
            this.btn_TimePack.Size = new System.Drawing.Size(75, 28);
            this.btn_TimePack.TabIndex = 68;
            this.btn_TimePack.Text = "时间段打包";
            this.btn_TimePack.UseVisualStyleBackColor = true;
            this.btn_TimePack.Click += new System.EventHandler(this.btn_TimePack_Click);
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myGroupBox1.BackgroundColor = System.Drawing.Color.White;
            this.myGroupBox1.BackgroundGradientColor = System.Drawing.Color.White;
            this.myGroupBox1.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.myGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.myGroupBox1.BorderThickness = 1F;
            this.myGroupBox1.Controls.Add(this.rB_localDataBase);
            this.myGroupBox1.Controls.Add(this.rB_remoteDataBase);
            this.myGroupBox1.Controls.Add(this.label15);
            this.myGroupBox1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.myGroupBox1.GroupImage = null;
            this.myGroupBox1.GroupTitle = "系统设置";
            this.myGroupBox1.Location = new System.Drawing.Point(549, 386);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Padding = new System.Windows.Forms.Padding(20);
            this.myGroupBox1.PaintGroupBox = false;
            this.myGroupBox1.RoundCorners = 10;
            this.myGroupBox1.ShadowColor = System.Drawing.Color.DarkGray;
            this.myGroupBox1.ShadowControl = false;
            this.myGroupBox1.ShadowThickness = 3;
            this.myGroupBox1.Size = new System.Drawing.Size(400, 93);
            this.myGroupBox1.TabIndex = 41;
            this.myGroupBox1.Visible = false;
            // 
            // rB_localDataBase
            // 
            this.rB_localDataBase.AutoSize = true;
            this.rB_localDataBase.Location = new System.Drawing.Point(218, 46);
            this.rB_localDataBase.Name = "rB_localDataBase";
            this.rB_localDataBase.Size = new System.Drawing.Size(83, 16);
            this.rB_localDataBase.TabIndex = 45;
            this.rB_localDataBase.Text = "本地数据库";
            this.rB_localDataBase.UseVisualStyleBackColor = true;
            // 
            // rB_remoteDataBase
            // 
            this.rB_remoteDataBase.AutoSize = true;
            this.rB_remoteDataBase.Checked = true;
            this.rB_remoteDataBase.Location = new System.Drawing.Point(115, 46);
            this.rB_remoteDataBase.Name = "rB_remoteDataBase";
            this.rB_remoteDataBase.Size = new System.Drawing.Size(83, 16);
            this.rB_remoteDataBase.TabIndex = 44;
            this.rB_remoteDataBase.TabStop = true;
            this.rB_remoteDataBase.Text = "远程数据库";
            this.rB_remoteDataBase.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 12);
            this.label15.TabIndex = 46;
            this.label15.Text = "数据库:";
            // 
            // myGroupBox2
            // 
            this.myGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.myGroupBox2.BackgroundColor = System.Drawing.Color.White;
            this.myGroupBox2.BackgroundGradientColor = System.Drawing.Color.White;
            this.myGroupBox2.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.myGroupBox2.BorderColor = System.Drawing.Color.Black;
            this.myGroupBox2.BorderThickness = 1F;
            this.myGroupBox2.Controls.Add(this.label1);
            this.myGroupBox2.Controls.Add(this.cmb_BurnSpeed);
            this.myGroupBox2.Controls.Add(this.cmb_BurnDevices);
            this.myGroupBox2.Controls.Add(this.label2);
            this.myGroupBox2.Controls.Add(this.label7);
            this.myGroupBox2.Controls.Add(this.label11);
            this.myGroupBox2.Controls.Add(this.l_DiscSize);
            this.myGroupBox2.Controls.Add(this.label8);
            this.myGroupBox2.Controls.Add(this.lb_DiscType);
            this.myGroupBox2.Controls.Add(this.l_discVolumeKey);
            this.myGroupBox2.CustomGroupBoxColor = System.Drawing.Color.White;
            this.myGroupBox2.GroupImage = null;
            this.myGroupBox2.GroupTitle = "刻录信息区";
            this.myGroupBox2.Location = new System.Drawing.Point(560, 200);
            this.myGroupBox2.Name = "myGroupBox2";
            this.myGroupBox2.Padding = new System.Windows.Forms.Padding(20);
            this.myGroupBox2.PaintGroupBox = false;
            this.myGroupBox2.RoundCorners = 10;
            this.myGroupBox2.ShadowColor = System.Drawing.Color.DarkGray;
            this.myGroupBox2.ShadowControl = false;
            this.myGroupBox2.ShadowThickness = 3;
            this.myGroupBox2.Size = new System.Drawing.Size(400, 159);
            this.myGroupBox2.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "刻录设备:";
            // 
            // cmb_BurnSpeed
            // 
            this.cmb_BurnSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BurnSpeed.FormattingEnabled = true;
            this.cmb_BurnSpeed.Location = new System.Drawing.Point(291, 37);
            this.cmb_BurnSpeed.Name = "cmb_BurnSpeed";
            this.cmb_BurnSpeed.Size = new System.Drawing.Size(98, 20);
            this.cmb_BurnSpeed.TabIndex = 51;
            // 
            // cmb_BurnDevices
            // 
            this.cmb_BurnDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_BurnDevices.FormattingEnabled = true;
            this.cmb_BurnDevices.Location = new System.Drawing.Point(91, 37);
            this.cmb_BurnDevices.Name = "cmb_BurnDevices";
            this.cmb_BurnDevices.Size = new System.Drawing.Size(132, 20);
            this.cmb_BurnDevices.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "光盘类型:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 56;
            this.label7.Text = "光盘大小:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(229, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 53;
            this.label11.Text = "刻录速度:";
            // 
            // l_DiscSize
            // 
            this.l_DiscSize.BackColor = System.Drawing.Color.LightGray;
            this.l_DiscSize.Location = new System.Drawing.Point(289, 82);
            this.l_DiscSize.Name = "l_DiscSize";
            this.l_DiscSize.Size = new System.Drawing.Size(100, 20);
            this.l_DiscSize.TabIndex = 57;
            this.l_DiscSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 58;
            this.label8.Text = "光盘卷标:";
            // 
            // lb_DiscType
            // 
            this.lb_DiscType.BackColor = System.Drawing.Color.LightGray;
            this.lb_DiscType.Location = new System.Drawing.Point(91, 82);
            this.lb_DiscType.Name = "lb_DiscType";
            this.lb_DiscType.Size = new System.Drawing.Size(132, 20);
            this.lb_DiscType.TabIndex = 55;
            this.lb_DiscType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // l_discVolumeKey
            // 
            this.l_discVolumeKey.Location = new System.Drawing.Point(91, 129);
            this.l_discVolumeKey.Name = "l_discVolumeKey";
            this.l_discVolumeKey.Size = new System.Drawing.Size(132, 21);
            this.l_discVolumeKey.TabIndex = 50;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 803F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Burn, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Find, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_SystemSet, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(972, 27);
            this.tableLayoutPanel1.TabIndex = 37;
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
            // btn_Burn
            // 
            this.btn_Burn.FlatAppearance.BorderSize = 0;
            this.btn_Burn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Burn.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Burn.Location = new System.Drawing.Point(236, 4);
            this.btn_Burn.Name = "btn_Burn";
            this.btn_Burn.Size = new System.Drawing.Size(74, 19);
            this.btn_Burn.TabIndex = 0;
            this.btn_Burn.Text = "刻录";
            this.btn_Burn.UseVisualStyleBackColor = true;
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
            // btn_SystemSet
            // 
            this.btn_SystemSet.FlatAppearance.BorderSize = 0;
            this.btn_SystemSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SystemSet.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_SystemSet.Location = new System.Drawing.Point(317, 4);
            this.btn_SystemSet.Name = "btn_SystemSet";
            this.btn_SystemSet.Size = new System.Drawing.Size(74, 19);
            this.btn_SystemSet.TabIndex = 6;
            this.btn_SystemSet.Text = "系统设置";
            this.btn_SystemSet.UseVisualStyleBackColor = true;
            this.btn_SystemSet.Click += new System.EventHandler(this.btn_SystemSet_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLab_Memo,
            this.tsLab_pROCESS,
            this.tsPrcess});
            this.statusStrip1.Location = new System.Drawing.Point(0, 611);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(972, 22);
            this.statusStrip1.TabIndex = 42;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsLab_Memo
            // 
            this.tsLab_Memo.AutoSize = false;
            this.tsLab_Memo.Name = "tsLab_Memo";
            this.tsLab_Memo.Size = new System.Drawing.Size(130, 17);
            this.tsLab_Memo.Text = "正在打包";
            this.tsLab_Memo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsLab_pROCESS
            // 
            this.tsLab_pROCESS.Name = "tsLab_pROCESS";
            this.tsLab_pROCESS.Size = new System.Drawing.Size(23, 17);
            this.tsLab_pROCESS.Text = "80%";
            // 
            // tsPrcess
            // 
            this.tsPrcess.Name = "tsPrcess";
            this.tsPrcess.Size = new System.Drawing.Size(800, 16);
            // 
            // Burn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(972, 633);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.myGroupBox2);
            this.Controls.Add(this.myGroupBox1);
            this.Controls.Add(this.gp_Time);
            this.Controls.Add(this.gp_Patient);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Burn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "光盘刻录";
            this.Load += new System.EventHandler(this.Burn_Load);
            this.gp_Patient.ResumeLayout(false);
            this.gp_Patient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_WorkList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_study)).EndInit();
            this.gp_Time.ResumeLayout(false);
            this.gp_Time.PerformLayout();
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox1.PerformLayout();
            this.myGroupBox2.ResumeLayout(false);
            this.myGroupBox2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btn_Burn;
        public System.Windows.Forms.Button btn_FunName;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Find;
        private BaseControls.GroupBox.MyGroupBox gp_Patient;
        private BaseControls.MyLabel label14;
        private BaseControls.MyLabel l_patientSpaceSize;
        private BaseControls.MyLabel label13;
        private BaseControls.MyLabel label10;
        private BaseControls.MyLabel label6;
        private BaseControls.MyLabel label12;
        private BaseControls.MyLabel label18;
        private BaseControls.MyLabel label17;
        private BaseControls.MyLabel label16;
        private BaseControls.MyLabel label9;
        private System.Windows.Forms.DateTimePicker dtpe_STUDY_DATE_TIME;
        private System.Windows.Forms.DateTimePicker dtps_STUDY_DATE_TIME;
        private System.Windows.Forms.Button btn_PatientPack;
        private System.Windows.Forms.Button btn_NotSelectAll;
        private System.Windows.Forms.Button btn_SelectAll;
        private BaseControls.GroupBox.MyGroupBox gp_Time;
        private System.Windows.Forms.Button btn_TimePack;
        private BaseControls.MyLabel label3;
        private System.Windows.Forms.DateTimePicker dtp_StudyS;
        private System.Windows.Forms.DateTimePicker dtp_Studye;
        private BaseControls.MyLabel label4;
        private BaseControls.MyLabel label5;
        private BaseControls.MyLabel l_timeSpaceSize;
        private BaseControls.GroupBox.MyGroupBox myGroupBox1;
        private System.Windows.Forms.RadioButton rB_localDataBase;
        private System.Windows.Forms.RadioButton rB_remoteDataBase;
        private BaseControls.MyLabel label15;
        private BaseControls.GroupBox.MyGroupBox myGroupBox2;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.ComboBox cmb_BurnDevices;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label7;
        private BaseControls.MyLabel label11;
        private BaseControls.MyLabel l_DiscSize;
        private BaseControls.MyLabel label8;
        private BaseControls.MyLabel lb_DiscType;
        private System.Windows.Forms.TextBox l_discVolumeKey;
        private BaseControls.ComboBoxs.MyComboBox cmb_PATIENT_SEX;
        private BaseControls.MyTextBox txt_PATIENT_AGE;
        private BaseControls.MyTextBox txt_PATIENT_NAME;
        private BaseControls.MyTextBox txt_PATIENT_ID;
        private BaseControls.MyDataGridView dgv_study;
        private BaseControls.MyDataGridView dgv_WorkList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDY_KEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_AGE;
        private System.Windows.Forms.DataGridViewComboBoxColumn PATIENT_SEX;
        private System.Windows.Forms.DataGridViewTextBoxColumn IS_ONLINE;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDY_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_BIRTH;
        private System.Windows.Forms.ComboBox cmb_BurnSpeed;
        public System.Windows.Forms.Button btn_SystemSet;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsLab_Memo;
        private System.Windows.Forms.ToolStripStatusLabel tsLab_pROCESS;
        private System.Windows.Forms.ToolStripProgressBar tsPrcess;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IDL;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ACCESSION_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDY_DATETIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}