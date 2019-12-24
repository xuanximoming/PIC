namespace SIS.SysMaintenance
{
    partial class frmDeptManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeptManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_NewPatientSou = new System.Windows.Forms.Button();
            this.btnFunName = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.GvDept = new BaseControls.MyDataGridView();
            this.CLINIC_OFFICE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_OFFICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_OFFICE_PYCODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_OFFICE_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_OFFICE_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_SOURCE_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CUR_SERIAL_NUM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STUDY_UID_HEADER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvDept)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Controls.Add(this.btn_NewPatientSou, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(809, 27);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // btn_NewPatientSou
            // 
            this.btn_NewPatientSou.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_NewPatientSou.FlatAppearance.BorderSize = 0;
            this.btn_NewPatientSou.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NewPatientSou.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_NewPatientSou.Location = new System.Drawing.Point(135, 4);
            this.btn_NewPatientSou.Name = "btn_NewPatientSou";
            this.btn_NewPatientSou.Size = new System.Drawing.Size(88, 19);
            this.btn_NewPatientSou.TabIndex = 5;
            this.btn_NewPatientSou.Text = "新建病人来源";
            this.btn_NewPatientSou.UseVisualStyleBackColor = true;
            this.btn_NewPatientSou.Click += new System.EventHandler(this.btn_NewPatientSou_Click);
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
            this.btnFunName.Text = "button1";
            this.btnFunName.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSave.Location = new System.Drawing.Point(290, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(58, 19);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAdd.Location = new System.Drawing.Point(230, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(53, 19);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(305, 133);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 20;
            this.gb_PromptInfo.UseWaitCursor = true;
            this.gb_PromptInfo.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(5, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // lb_PromptInfo
            // 
            this.lb_PromptInfo.AutoSize = true;
            this.lb_PromptInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_PromptInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lb_PromptInfo.Location = new System.Drawing.Point(54, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(101, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有科室信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // GvDept
            // 
            this.GvDept.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GvDept.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GvDept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GvDept.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GvDept.BackgroundColor = System.Drawing.Color.White;
            this.GvDept.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvDept.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GvDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvDept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLINIC_OFFICE_ID,
            this.CLINIC_OFFICE,
            this.CLINIC_OFFICE_PYCODE,
            this.CLINIC_OFFICE_CODE,
            this.CLINIC_OFFICE_FLAG,
            this.PATIENT_SOURCE_ID,
            this.CUR_SERIAL_NUM,
            this.STUDY_UID_HEADER,
            this.Operate,
            this.Edit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GvDept.DefaultCellStyle = dataGridViewCellStyle3;
            this.GvDept.DefaultScaleWidth = 1280;
            this.GvDept.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.GvDept.Location = new System.Drawing.Point(10, 50);
            this.GvDept.Margin = new System.Windows.Forms.Padding(0);
            this.GvDept.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.GvDept.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("GvDept.MergeColumnNames")));
            this.GvDept.Name = "GvDept";
            this.GvDept.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvDept.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GvDept.RowTemplate.Height = 23;
            this.GvDept.Size = new System.Drawing.Size(790, 600);
            this.GvDept.TabIndex = 16;
            this.GvDept.XmlFile = null;
            this.GvDept.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GvDept_DataError);
            this.GvDept.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvDept_CellContentClick);
            // 
            // CLINIC_OFFICE_ID
            // 
            this.CLINIC_OFFICE_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLINIC_OFFICE_ID.DataPropertyName = "CLINIC_OFFICE_ID";
            this.CLINIC_OFFICE_ID.FillWeight = 15F;
            this.CLINIC_OFFICE_ID.HeaderText = "科室标识";
            this.CLINIC_OFFICE_ID.Name = "CLINIC_OFFICE_ID";
            this.CLINIC_OFFICE_ID.ReadOnly = true;
            this.CLINIC_OFFICE_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // CLINIC_OFFICE
            // 
            this.CLINIC_OFFICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLINIC_OFFICE.DataPropertyName = "CLINIC_OFFICE";
            this.CLINIC_OFFICE.FillWeight = 25F;
            this.CLINIC_OFFICE.HeaderText = "科室名称";
            this.CLINIC_OFFICE.MaxInputLength = 100;
            this.CLINIC_OFFICE.Name = "CLINIC_OFFICE";
            this.CLINIC_OFFICE.ReadOnly = true;
            // 
            // CLINIC_OFFICE_PYCODE
            // 
            this.CLINIC_OFFICE_PYCODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLINIC_OFFICE_PYCODE.DataPropertyName = "CLINIC_OFFICE_PYCODE";
            this.CLINIC_OFFICE_PYCODE.FillWeight = 10F;
            this.CLINIC_OFFICE_PYCODE.HeaderText = "科室简写";
            this.CLINIC_OFFICE_PYCODE.Name = "CLINIC_OFFICE_PYCODE";
            this.CLINIC_OFFICE_PYCODE.ReadOnly = true;
            this.CLINIC_OFFICE_PYCODE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CLINIC_OFFICE_PYCODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CLINIC_OFFICE_CODE
            // 
            this.CLINIC_OFFICE_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLINIC_OFFICE_CODE.DataPropertyName = "CLINIC_OFFICE_CODE";
            this.CLINIC_OFFICE_CODE.FillWeight = 20F;
            this.CLINIC_OFFICE_CODE.HeaderText = "科室代码";
            this.CLINIC_OFFICE_CODE.Name = "CLINIC_OFFICE_CODE";
            this.CLINIC_OFFICE_CODE.ReadOnly = true;
            this.CLINIC_OFFICE_CODE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CLINIC_OFFICE_FLAG
            // 
            this.CLINIC_OFFICE_FLAG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CLINIC_OFFICE_FLAG.DataPropertyName = "CLINIC_OFFICE_FLAG";
            this.CLINIC_OFFICE_FLAG.FillWeight = 13F;
            this.CLINIC_OFFICE_FLAG.HeaderText = "科室标志";
            this.CLINIC_OFFICE_FLAG.Name = "CLINIC_OFFICE_FLAG";
            this.CLINIC_OFFICE_FLAG.ReadOnly = true;
            this.CLINIC_OFFICE_FLAG.Width = 78;
            // 
            // PATIENT_SOURCE_ID
            // 
            this.PATIENT_SOURCE_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PATIENT_SOURCE_ID.DataPropertyName = "PATIENT_SOURCE_ID";
            this.PATIENT_SOURCE_ID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.PATIENT_SOURCE_ID.FillWeight = 20F;
            this.PATIENT_SOURCE_ID.HeaderText = "病人来源";
            this.PATIENT_SOURCE_ID.Name = "PATIENT_SOURCE_ID";
            this.PATIENT_SOURCE_ID.ReadOnly = true;
            this.PATIENT_SOURCE_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PATIENT_SOURCE_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CUR_SERIAL_NUM
            // 
            this.CUR_SERIAL_NUM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CUR_SERIAL_NUM.DataPropertyName = "CUR_SERIAL_NUM";
            this.CUR_SERIAL_NUM.FillWeight = 10F;
            this.CUR_SERIAL_NUM.HeaderText = "流水号";
            this.CUR_SERIAL_NUM.Name = "CUR_SERIAL_NUM";
            this.CUR_SERIAL_NUM.ReadOnly = true;
            // 
            // STUDY_UID_HEADER
            // 
            this.STUDY_UID_HEADER.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STUDY_UID_HEADER.DataPropertyName = "STUDY_UID_HEADER";
            this.STUDY_UID_HEADER.FillWeight = 13F;
            this.STUDY_UID_HEADER.HeaderText = "UID标头";
            this.STUDY_UID_HEADER.Name = "STUDY_UID_HEADER";
            this.STUDY_UID_HEADER.ReadOnly = true;
            // 
            // Operate
            // 
            this.Operate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Operate.FillWeight = 69.80753F;
            this.Operate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Operate.HeaderText = "操作";
            this.Operate.Name = "Operate";
            this.Operate.ReadOnly = true;
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
            this.Edit.ReadOnly = true;
            this.Edit.Text = "编辑";
            this.Edit.ToolTipText = "编辑";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 54;
            // 
            // frmDeptManage
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(809, 666);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.GvDept);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmDeptManage";
            this.Load += new System.EventHandler(this.DeptManage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvDept)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnFunName;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private BaseControls.MyLabel lb_PromptInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button btn_NewPatientSou;
        public BaseControls.MyDataGridView GvDept;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLINIC_OFFICE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLINIC_OFFICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLINIC_OFFICE_PYCODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLINIC_OFFICE_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLINIC_OFFICE_FLAG;
        private System.Windows.Forms.DataGridViewComboBoxColumn PATIENT_SOURCE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUR_SERIAL_NUM;
        private System.Windows.Forms.DataGridViewTextBoxColumn STUDY_UID_HEADER;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;

    }
}