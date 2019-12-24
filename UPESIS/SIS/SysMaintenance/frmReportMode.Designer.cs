namespace SIS.SysMaintenance
{
    partial class frmReportMode
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportMode));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.myPnl = new BaseControls.Panels.MyPanel();
            this.txt_INPUT_CODE = new BaseControls.MyTextBox();
            this.label1 = new BaseControls.MyLabel();
            this.cmb_NODE_SIGN = new BaseControls.ComboBoxs.MyComboBox();
            this.cmb_IS_PRIVATE = new BaseControls.ComboBoxs.MyComboBox();
            this.txt_NODE_NAME = new BaseControls.MyTextBox();
            this.txt_Icdcode = new BaseControls.MyTextBox();
            this.txt_SORT_FLAG = new BaseControls.MyTextBox();
            this.txt_NODE_DEPICT = new BaseControls.MyTextBox();
            this.label9 = new BaseControls.MyLabel();
            this.label8 = new BaseControls.MyLabel();
            this.label10 = new BaseControls.MyLabel();
            this.label4 = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.dgv_ReportTempDict = new BaseControls.MyDataGridView();
            this.NODE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CLINIC_OFFICE_CODE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.INPUT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DOCTOR_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.IS_PRIVATE = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SORT_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICD10_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NODE_DEPICT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trv_ReportTempDict = new System.Windows.Forms.TreeView();
            this.cms_TEMPLATE_DICT = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cms_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Add_Equ = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Add_Next = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_li = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.myPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ReportTempDict)).BeginInit();
            this.cms_TEMPLATE_DICT.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 641F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Clean, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(988, 27);
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
            this.btn_FunName.TabIndex = 5;
            this.btn_FunName.Text = "button1";
            this.btn_FunName.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Save.Location = new System.Drawing.Point(155, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 19);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Clean
            // 
            this.btn_Clean.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Clean.FlatAppearance.BorderSize = 0;
            this.btn_Clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clean.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Clean.Location = new System.Drawing.Point(256, 4);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(94, 19);
            this.btn_Clean.TabIndex = 0;
            this.btn_Clean.Text = "清空";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // myPnl
            // 
            this.myPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPnl.BorderColor = System.Drawing.Color.Silver;
            this.myPnl.Controls.Add(this.txt_INPUT_CODE);
            this.myPnl.Controls.Add(this.label1);
            this.myPnl.Controls.Add(this.cmb_NODE_SIGN);
            this.myPnl.Controls.Add(this.cmb_IS_PRIVATE);
            this.myPnl.Controls.Add(this.txt_NODE_NAME);
            this.myPnl.Controls.Add(this.txt_Icdcode);
            this.myPnl.Controls.Add(this.txt_SORT_FLAG);
            this.myPnl.Controls.Add(this.txt_NODE_DEPICT);
            this.myPnl.Controls.Add(this.label9);
            this.myPnl.Controls.Add(this.label8);
            this.myPnl.Controls.Add(this.label10);
            this.myPnl.Controls.Add(this.label4);
            this.myPnl.Controls.Add(this.label3);
            this.myPnl.Controls.Add(this.label2);
            this.myPnl.Location = new System.Drawing.Point(228, 41);
            this.myPnl.Name = "myPnl";
            this.myPnl.Size = new System.Drawing.Size(748, 207);
            this.myPnl.TabIndex = 34;
            // 
            // txt_INPUT_CODE
            // 
            this.txt_INPUT_CODE.Location = new System.Drawing.Point(396, 6);
            this.txt_INPUT_CODE.Name = "txt_INPUT_CODE";
            this.txt_INPUT_CODE.Size = new System.Drawing.Size(82, 21);
            this.txt_INPUT_CODE.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(349, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "简写：";
            // 
            // cmb_NODE_SIGN
            // 
            this.cmb_NODE_SIGN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_NODE_SIGN.FormattingEnabled = true;
            this.cmb_NODE_SIGN.Location = new System.Drawing.Point(79, 6);
            this.cmb_NODE_SIGN.Name = "cmb_NODE_SIGN";
            this.cmb_NODE_SIGN.Size = new System.Drawing.Size(144, 20);
            this.cmb_NODE_SIGN.TabIndex = 1;
            this.cmb_NODE_SIGN.SelectedIndexChanged += new System.EventHandler(this.cmb_NODE_SIGN_SelectedIndexChanged);
            // 
            // cmb_IS_PRIVATE
            // 
            this.cmb_IS_PRIVATE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IS_PRIVATE.FormattingEnabled = true;
            this.cmb_IS_PRIVATE.Location = new System.Drawing.Point(273, 6);
            this.cmb_IS_PRIVATE.Name = "cmb_IS_PRIVATE";
            this.cmb_IS_PRIVATE.Size = new System.Drawing.Size(70, 20);
            this.cmb_IS_PRIVATE.TabIndex = 2;
            // 
            // txt_NODE_NAME
            // 
            this.txt_NODE_NAME.Location = new System.Drawing.Point(79, 34);
            this.txt_NODE_NAME.Name = "txt_NODE_NAME";
            this.txt_NODE_NAME.Size = new System.Drawing.Size(648, 21);
            this.txt_NODE_NAME.TabIndex = 6;
            // 
            // txt_Icdcode
            // 
            this.txt_Icdcode.Location = new System.Drawing.Point(567, 6);
            this.txt_Icdcode.Name = "txt_Icdcode";
            this.txt_Icdcode.Size = new System.Drawing.Size(66, 21);
            this.txt_Icdcode.TabIndex = 4;
            // 
            // txt_SORT_FLAG
            // 
            this.txt_SORT_FLAG.Location = new System.Drawing.Point(689, 6);
            this.txt_SORT_FLAG.Name = "txt_SORT_FLAG";
            this.txt_SORT_FLAG.Size = new System.Drawing.Size(38, 21);
            this.txt_SORT_FLAG.TabIndex = 5;
            // 
            // txt_NODE_DEPICT
            // 
            this.txt_NODE_DEPICT.Location = new System.Drawing.Point(79, 61);
            this.txt_NODE_DEPICT.Multiline = true;
            this.txt_NODE_DEPICT.Name = "txt_NODE_DEPICT";
            this.txt_NODE_DEPICT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_NODE_DEPICT.Size = new System.Drawing.Size(648, 135);
            this.txt_NODE_DEPICT.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(639, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "排序号：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(236, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "私有：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(484, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "疾病分类码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "结点标志：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "节点描述：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "结点名称：";
            // 
            // dgv_ReportTempDict
            // 
            this.dgv_ReportTempDict.AllowUserToAddRows = false;
            this.dgv_ReportTempDict.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_ReportTempDict.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ReportTempDict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ReportTempDict.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ReportTempDict.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ReportTempDict.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ReportTempDict.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ReportTempDict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ReportTempDict.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NODE_NAME,
            this.CLINIC_OFFICE_CODE,
            this.INPUT_CODE,
            this.DOCTOR_ID,
            this.IS_PRIVATE,
            this.SORT_FLAG,
            this.ICD10_CODE,
            this.NODE_DEPICT});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ReportTempDict.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ReportTempDict.DefaultScaleWidth = 1280;
            this.dgv_ReportTempDict.Location = new System.Drawing.Point(228, 251);
            this.dgv_ReportTempDict.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_ReportTempDict.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_ReportTempDict.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_ReportTempDict.MergeColumnNames")));
            this.dgv_ReportTempDict.Name = "dgv_ReportTempDict";
            this.dgv_ReportTempDict.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ReportTempDict.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ReportTempDict.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_ReportTempDict.RowTemplate.Height = 23;
            this.dgv_ReportTempDict.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ReportTempDict.Size = new System.Drawing.Size(748, 345);
            this.dgv_ReportTempDict.TabIndex = 32;
            this.dgv_ReportTempDict.XmlFile = null;
            this.dgv_ReportTempDict.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_ReportTempDict_DataError);
            // 
            // NODE_NAME
            // 
            this.NODE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NODE_NAME.DataPropertyName = "NODE_NAME";
            this.NODE_NAME.FillWeight = 20F;
            this.NODE_NAME.HeaderText = "结点名称";
            this.NODE_NAME.Name = "NODE_NAME";
            this.NODE_NAME.ReadOnly = true;
            // 
            // CLINIC_OFFICE_CODE
            // 
            this.CLINIC_OFFICE_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CLINIC_OFFICE_CODE.DataPropertyName = "CLINIC_OFFICE_CODE";
            this.CLINIC_OFFICE_CODE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.CLINIC_OFFICE_CODE.FillWeight = 12F;
            this.CLINIC_OFFICE_CODE.HeaderText = "科室";
            this.CLINIC_OFFICE_CODE.Name = "CLINIC_OFFICE_CODE";
            this.CLINIC_OFFICE_CODE.ReadOnly = true;
            this.CLINIC_OFFICE_CODE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CLINIC_OFFICE_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // INPUT_CODE
            // 
            this.INPUT_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.INPUT_CODE.DataPropertyName = "INPUT_CODE";
            this.INPUT_CODE.FillWeight = 8F;
            this.INPUT_CODE.HeaderText = "简写";
            this.INPUT_CODE.Name = "INPUT_CODE";
            this.INPUT_CODE.ReadOnly = true;
            this.INPUT_CODE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.INPUT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DOCTOR_ID
            // 
            this.DOCTOR_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DOCTOR_ID.DataPropertyName = "DOCTOR_ID";
            this.DOCTOR_ID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DOCTOR_ID.FillWeight = 12F;
            this.DOCTOR_ID.HeaderText = "医生姓名";
            this.DOCTOR_ID.Name = "DOCTOR_ID";
            this.DOCTOR_ID.ReadOnly = true;
            this.DOCTOR_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DOCTOR_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IS_PRIVATE
            // 
            this.IS_PRIVATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IS_PRIVATE.DataPropertyName = "IS_PRIVATE";
            this.IS_PRIVATE.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.IS_PRIVATE.FillWeight = 8F;
            this.IS_PRIVATE.HeaderText = "私有";
            this.IS_PRIVATE.Name = "IS_PRIVATE";
            this.IS_PRIVATE.ReadOnly = true;
            this.IS_PRIVATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IS_PRIVATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SORT_FLAG
            // 
            this.SORT_FLAG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SORT_FLAG.DataPropertyName = "SORT_FLAG";
            this.SORT_FLAG.FillWeight = 10F;
            this.SORT_FLAG.HeaderText = "排序号";
            this.SORT_FLAG.Name = "SORT_FLAG";
            this.SORT_FLAG.ReadOnly = true;
            this.SORT_FLAG.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ICD10_CODE
            // 
            this.ICD10_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ICD10_CODE.DataPropertyName = "ICD10_CODE";
            this.ICD10_CODE.FillWeight = 10F;
            this.ICD10_CODE.HeaderText = "疾病分类码";
            this.ICD10_CODE.Name = "ICD10_CODE";
            this.ICD10_CODE.ReadOnly = true;
            // 
            // NODE_DEPICT
            // 
            this.NODE_DEPICT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NODE_DEPICT.DataPropertyName = "NODE_DEPICT";
            this.NODE_DEPICT.FillWeight = 20F;
            this.NODE_DEPICT.HeaderText = "结点描述";
            this.NODE_DEPICT.Name = "NODE_DEPICT";
            this.NODE_DEPICT.ReadOnly = true;
            this.NODE_DEPICT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // trv_ReportTempDict
            // 
            this.trv_ReportTempDict.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.trv_ReportTempDict.ContextMenuStrip = this.cms_TEMPLATE_DICT;
            this.trv_ReportTempDict.Cursor = System.Windows.Forms.Cursors.Default;
            this.trv_ReportTempDict.FullRowSelect = true;
            this.trv_ReportTempDict.Location = new System.Drawing.Point(12, 41);
            this.trv_ReportTempDict.Name = "trv_ReportTempDict";
            this.trv_ReportTempDict.Size = new System.Drawing.Size(210, 555);
            this.trv_ReportTempDict.TabIndex = 36;
            this.trv_ReportTempDict.DoubleClick += new System.EventHandler(this.trv_ReportTempDict_DoubleClick);
            this.trv_ReportTempDict.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trv_ReportTempDict_MouseDown);
            // 
            // cms_TEMPLATE_DICT
            // 
            this.cms_TEMPLATE_DICT.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_Add,
            this.cms_Delete,
            this.tsm_li});
            this.cms_TEMPLATE_DICT.Name = "cms_TEMPLATE_DICT";
            this.cms_TEMPLATE_DICT.Size = new System.Drawing.Size(95, 70);
            // 
            // cms_Add
            // 
            this.cms_Add.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cms_Add_Equ,
            this.cms_Add_Next});
            this.cms_Add.Name = "cms_Add";
            this.cms_Add.Size = new System.Drawing.Size(94, 22);
            this.cms_Add.Text = "新增";
            this.cms_Add.Click += new System.EventHandler(this.cms_Add_Click);
            // 
            // cms_Add_Equ
            // 
            this.cms_Add_Equ.Name = "cms_Add_Equ";
            this.cms_Add_Equ.Size = new System.Drawing.Size(94, 22);
            this.cms_Add_Equ.Text = "同级";
            this.cms_Add_Equ.Click += new System.EventHandler(this.cms_Add_Equ_Click);
            // 
            // cms_Add_Next
            // 
            this.cms_Add_Next.Name = "cms_Add_Next";
            this.cms_Add_Next.Size = new System.Drawing.Size(94, 22);
            this.cms_Add_Next.Text = "下级";
            this.cms_Add_Next.Click += new System.EventHandler(this.cms_Add_Next_Click);
            // 
            // cms_Delete
            // 
            this.cms_Delete.Name = "cms_Delete";
            this.cms_Delete.Size = new System.Drawing.Size(94, 22);
            this.cms_Delete.Text = "删除";
            this.cms_Delete.Click += new System.EventHandler(this.cms_Delete_Click);
            // 
            // tsm_li
            // 
            this.tsm_li.Name = "tsm_li";
            this.tsm_li.Size = new System.Drawing.Size(94, 22);
            this.tsm_li.Text = "收缩";
            this.tsm_li.Click += new System.EventHandler(this.tsm_li_Click);
            // 
            // frmReportMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(988, 610);
            this.Controls.Add(this.trv_ReportTempDict);
            this.Controls.Add(this.myPnl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_ReportTempDict);
            this.Name = "frmReportMode";
            this.Text = " ";
            this.Load += new System.EventHandler(this.ReportMode_Load);
            this.VisibleChanged += new System.EventHandler(this.ReportMode_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.myPnl.ResumeLayout(false);
            this.myPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ReportTempDict)).EndInit();
            this.cms_TEMPLATE_DICT.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Save;
        private BaseControls.MyDataGridView dgv_ReportTempDict;
        private BaseControls.Panels.MyPanel myPnl;
        private BaseControls.MyLabel label9;
        private BaseControls.MyLabel label8;
        private BaseControls.MyLabel label4;
        private BaseControls.MyLabel label3;
        private BaseControls.MyLabel label2;
        private BaseControls.MyTextBox txt_NODE_NAME;
        private BaseControls.ComboBoxs.MyComboBox cmb_IS_PRIVATE;
        private BaseControls.MyTextBox txt_SORT_FLAG;
        private BaseControls.MyTextBox txt_NODE_DEPICT;
        public System.Windows.Forms.Button btn_FunName;
        private BaseControls.MyTextBox txt_Icdcode;
        private BaseControls.MyLabel label10;
        public System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.TreeView trv_ReportTempDict;
        private BaseControls.ComboBoxs.MyComboBox cmb_NODE_SIGN;
        private System.Windows.Forms.ContextMenuStrip cms_TEMPLATE_DICT;
        private System.Windows.Forms.ToolStripMenuItem cms_Add;
        private System.Windows.Forms.ToolStripMenuItem cms_Delete;
        private System.Windows.Forms.ToolStripMenuItem tsm_li;
        private BaseControls.MyTextBox txt_INPUT_CODE;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.ToolStripMenuItem cms_Add_Equ;
        private System.Windows.Forms.ToolStripMenuItem cms_Add_Next;
        private System.Windows.Forms.DataGridViewTextBoxColumn NODE_NAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn CLINIC_OFFICE_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_CODE;
        private System.Windows.Forms.DataGridViewComboBoxColumn DOCTOR_ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn IS_PRIVATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ICD10_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn NODE_DEPICT;
    }
}