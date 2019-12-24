namespace SIS
{
    partial class frmTempManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTempManager));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_New = new System.Windows.Forms.Button();
            this.btn_Query = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.dgv_Print = new BaseControls.MyDataGridView();
            this.PRINT_TEMPLATE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_SUB_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINT_TEMPLATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FIELD_INF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FILE_DATE_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.tx_TempName = new BaseControls.userTextBox();
            this.cmb_ExamClass = new System.Windows.Forms.ComboBox();
            this.cmb_ExamSubClass = new System.Windows.Forms.ComboBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pan_Input = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_UnProtect = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pan_List = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.btn_SaveAs = new System.Windows.Forms.Button();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_Protect = new System.Windows.Forms.Button();
            this.winWordControl = new BaseControls.WinWordControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Print)).BeginInit();
            this.pan_Input.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.pan_List.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 479F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_New, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Query, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Delete, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(889, 27);
            this.tableLayoutPanel1.TabIndex = 25;
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
            // btn_Save
            // 
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.Color.Black;
            this.btn_Save.Location = new System.Drawing.Point(266, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(54, 19);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_New
            // 
            this.btn_New.FlatAppearance.BorderSize = 0;
            this.btn_New.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_New.ForeColor = System.Drawing.Color.Black;
            this.btn_New.Location = new System.Drawing.Point(205, 4);
            this.btn_New.Name = "btn_New";
            this.btn_New.Size = new System.Drawing.Size(54, 19);
            this.btn_New.TabIndex = 4;
            this.btn_New.Text = "增加";
            this.btn_New.UseVisualStyleBackColor = true;
            this.btn_New.Click += new System.EventHandler(this.btn_New_Click);
            // 
            // btn_Query
            // 
            this.btn_Query.FlatAppearance.BorderSize = 0;
            this.btn_Query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Query.ForeColor = System.Drawing.Color.Black;
            this.btn_Query.Location = new System.Drawing.Point(135, 4);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(63, 19);
            this.btn_Query.TabIndex = 5;
            this.btn_Query.Text = "查询";
            this.btn_Query.UseVisualStyleBackColor = true;
            this.btn_Query.Click += new System.EventHandler(this.btn_Query_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.FlatAppearance.BorderSize = 0;
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.ForeColor = System.Drawing.Color.Black;
            this.btn_Delete.Location = new System.Drawing.Point(333, 4);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(54, 19);
            this.btn_Delete.TabIndex = 6;
            this.btn_Delete.Text = "删除";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(301, 22);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 33;
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
            this.lb_PromptInfo.Size = new System.Drawing.Size(161, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "查询不到符合此条件的记录！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // dgv_Print
            // 
            this.dgv_Print.AllowUserToAddRows = false;
            this.dgv_Print.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Print.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Print.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Print.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Print.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Print.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Print.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Print.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRINT_TEMPLATE_ID,
            this.EXAM_CLASS,
            this.EXAM_SUB_CLASS,
            this.PRINT_TEMPLATE,
            this.FIELD_INF,
            this.FILE_DATE_TIME});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Print.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Print.DefaultScaleWidth = 1280;
            this.dgv_Print.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Print.Location = new System.Drawing.Point(0, 0);
            this.dgv_Print.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Print.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_Print.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_Print.MergeColumnNames")));
            this.dgv_Print.Name = "dgv_Print";
            this.dgv_Print.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Print.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Print.RowTemplate.Height = 23;
            this.dgv_Print.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Print.Size = new System.Drawing.Size(889, 150);
            this.dgv_Print.TabIndex = 32;
            this.dgv_Print.XmlFile = null;
            this.dgv_Print.DoubleClick += new System.EventHandler(this.dgv_Print_DoubleClick);
            // 
            // PRINT_TEMPLATE_ID
            // 
            this.PRINT_TEMPLATE_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PRINT_TEMPLATE_ID.DataPropertyName = "PRINT_TEMPLATE_ID";
            this.PRINT_TEMPLATE_ID.FillWeight = 12F;
            this.PRINT_TEMPLATE_ID.Frozen = true;
            this.PRINT_TEMPLATE_ID.HeaderText = "编号";
            this.PRINT_TEMPLATE_ID.MinimumWidth = 70;
            this.PRINT_TEMPLATE_ID.Name = "PRINT_TEMPLATE_ID";
            this.PRINT_TEMPLATE_ID.ReadOnly = true;
            this.PRINT_TEMPLATE_ID.Width = 81;
            // 
            // EXAM_CLASS
            // 
            this.EXAM_CLASS.DataPropertyName = "EXAM_CLASS";
            this.EXAM_CLASS.HeaderText = "检查类别";
            this.EXAM_CLASS.Name = "EXAM_CLASS";
            this.EXAM_CLASS.ReadOnly = true;
            // 
            // EXAM_SUB_CLASS
            // 
            this.EXAM_SUB_CLASS.DataPropertyName = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.HeaderText = "检查子类";
            this.EXAM_SUB_CLASS.Name = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.ReadOnly = true;
            // 
            // PRINT_TEMPLATE
            // 
            this.PRINT_TEMPLATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PRINT_TEMPLATE.DataPropertyName = "PRINT_TEMPLATE";
            this.PRINT_TEMPLATE.FillWeight = 13F;
            this.PRINT_TEMPLATE.HeaderText = "模版名称";
            this.PRINT_TEMPLATE.Name = "PRINT_TEMPLATE";
            this.PRINT_TEMPLATE.ReadOnly = true;
            this.PRINT_TEMPLATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FIELD_INF
            // 
            this.FIELD_INF.DataPropertyName = "FIELD_INF";
            this.FIELD_INF.HeaderText = "字段信息";
            this.FIELD_INF.Name = "FIELD_INF";
            this.FIELD_INF.ReadOnly = true;
            this.FIELD_INF.Visible = false;
            // 
            // FILE_DATE_TIME
            // 
            this.FILE_DATE_TIME.DataPropertyName = "FILE_DATE_TIME";
            this.FILE_DATE_TIME.HeaderText = "创建时间";
            this.FILE_DATE_TIME.Name = "FILE_DATE_TIME";
            this.FILE_DATE_TIME.ReadOnly = true;
            this.FILE_DATE_TIME.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "检查类别";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(212, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 36;
            this.label2.Text = "检查子类";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(394, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 38;
            this.label3.Text = "模版名称";
            // 
            // tx_TempName
            // 
            this.tx_TempName.Font = new System.Drawing.Font("宋体", 9F);
            this.tx_TempName.ForeColor = System.Drawing.Color.Black;
            this.tx_TempName.IsChangeColor = true;
            this.tx_TempName.Location = new System.Drawing.Point(454, 10);
            this.tx_TempName.Name = "tx_TempName";
            this.tx_TempName.Size = new System.Drawing.Size(100, 21);
            this.tx_TempName.TabIndex = 39;
            // 
            // cmb_ExamClass
            // 
            this.cmb_ExamClass.FormattingEnabled = true;
            this.cmb_ExamClass.Location = new System.Drawing.Point(85, 11);
            this.cmb_ExamClass.Name = "cmb_ExamClass";
            this.cmb_ExamClass.Size = new System.Drawing.Size(121, 20);
            this.cmb_ExamClass.TabIndex = 40;
            this.cmb_ExamClass.SelectedIndexChanged += new System.EventHandler(this.cmb_ExamClass_SelectedIndexChanged);
            // 
            // cmb_ExamSubClass
            // 
            this.cmb_ExamSubClass.FormattingEnabled = true;
            this.cmb_ExamSubClass.Location = new System.Drawing.Point(267, 10);
            this.cmb_ExamSubClass.Name = "cmb_ExamSubClass";
            this.cmb_ExamSubClass.Size = new System.Drawing.Size(121, 20);
            this.cmb_ExamSubClass.TabIndex = 41;
            this.cmb_ExamSubClass.SelectedIndexChanged += new System.EventHandler(this.cmb_ExamSubClass_SelectedIndexChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PRINT_TEMPLATE_ID";
            this.dataGridViewTextBoxColumn1.FillWeight = 12F;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "编号";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 70;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 81;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PRINT_TEMPLATE";
            this.dataGridViewTextBoxColumn2.FillWeight = 13F;
            this.dataGridViewTextBoxColumn2.HeaderText = "模版名称";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FIELD_INF";
            this.dataGridViewTextBoxColumn3.HeaderText = "字段信息";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FILE_DATE_TIME";
            this.dataGridViewTextBoxColumn4.FillWeight = 13F;
            this.dataGridViewTextBoxColumn4.HeaderText = "创建时间";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FIELD_INF";
            this.dataGridViewTextBoxColumn5.HeaderText = "字段信息";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FILE_DATE_TIME";
            this.dataGridViewTextBoxColumn6.HeaderText = "创建时间";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 200;
            // 
            // pan_Input
            // 
            this.pan_Input.Controls.Add(this.cmb_ExamClass);
            this.pan_Input.Controls.Add(this.label1);
            this.pan_Input.Controls.Add(this.cmb_ExamSubClass);
            this.pan_Input.Controls.Add(this.label2);
            this.pan_Input.Controls.Add(this.label3);
            this.pan_Input.Controls.Add(this.tx_TempName);
            this.pan_Input.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_Input.Location = new System.Drawing.Point(0, 27);
            this.pan_Input.Name = "pan_Input";
            this.pan_Input.Size = new System.Drawing.Size(889, 33);
            this.pan_Input.TabIndex = 43;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 473F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SIS.Properties.Resources.bg_nav_column_light;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 98);
            this.button1.TabIndex = 3;
            this.button1.Text = "Word编辑";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_UnProtect
            // 
            this.btn_UnProtect.FlatAppearance.BorderSize = 0;
            this.btn_UnProtect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UnProtect.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_UnProtect.Location = new System.Drawing.Point(266, 4);
            this.btn_UnProtect.Name = "btn_UnProtect";
            this.btn_UnProtect.Size = new System.Drawing.Size(54, 19);
            this.btn_UnProtect.TabIndex = 0;
            this.btn_UnProtect.Text = "解保护";
            this.btn_UnProtect.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel3.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 473F));
            this.tableLayoutPanel3.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::SIS.Properties.Resources.bg_nav_column_light;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(1, 1);
            this.button2.Margin = new System.Windows.Forms.Padding(0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 98);
            this.button2.TabIndex = 3;
            this.button2.Text = "Word编辑";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button3.Location = new System.Drawing.Point(266, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 19);
            this.button3.TabIndex = 0;
            this.button3.Text = "解保护";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel4.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel4.ColumnCount = 6;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 473F));
            this.tableLayoutPanel4.Controls.Add(this.button4, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::SIS.Properties.Resources.bg_nav_column_light;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Enabled = false;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(1, 1);
            this.button4.Margin = new System.Windows.Forms.Padding(0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(130, 98);
            this.button4.TabIndex = 3;
            this.button4.Text = "Word编辑";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.button5.Location = new System.Drawing.Point(266, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(54, 19);
            this.button5.TabIndex = 0;
            this.button5.Text = "解保护";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // pan_List
            // 
            this.pan_List.Controls.Add(this.gb_PromptInfo);
            this.pan_List.Controls.Add(this.dgv_Print);
            this.pan_List.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_List.Location = new System.Drawing.Point(0, 60);
            this.pan_List.Name = "pan_List";
            this.pan_List.Size = new System.Drawing.Size(889, 150);
            this.pan_List.TabIndex = 44;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel5.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 478F));
            this.tableLayoutPanel5.Controls.Add(this.button6, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.button7, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_SaveAs, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_Open, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_Protect, 4, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 210);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(889, 27);
            this.tableLayoutPanel5.TabIndex = 45;
            // 
            // button6
            // 
            this.button6.BackgroundImage = global::SIS.Properties.Resources.bg_nav_column_light;
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Enabled = false;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(1, 1);
            this.button6.Margin = new System.Windows.Forms.Padding(0);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(130, 25);
            this.button6.TabIndex = 3;
            this.button6.Text = "Word编辑";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(266, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(54, 19);
            this.button7.TabIndex = 0;
            this.button7.Text = "解保护";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.btn_UnProtect_Click);
            // 
            // btn_SaveAs
            // 
            this.btn_SaveAs.FlatAppearance.BorderSize = 0;
            this.btn_SaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SaveAs.ForeColor = System.Drawing.Color.Black;
            this.btn_SaveAs.Location = new System.Drawing.Point(205, 4);
            this.btn_SaveAs.Name = "btn_SaveAs";
            this.btn_SaveAs.Size = new System.Drawing.Size(54, 19);
            this.btn_SaveAs.TabIndex = 4;
            this.btn_SaveAs.Text = "另存为";
            this.btn_SaveAs.UseVisualStyleBackColor = true;
            this.btn_SaveAs.Click += new System.EventHandler(this.btn_SaveAs_Click);
            // 
            // btn_Open
            // 
            this.btn_Open.FlatAppearance.BorderSize = 0;
            this.btn_Open.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Open.ForeColor = System.Drawing.Color.Black;
            this.btn_Open.Location = new System.Drawing.Point(135, 4);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(63, 19);
            this.btn_Open.TabIndex = 5;
            this.btn_Open.Text = "打开";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_Protect
            // 
            this.btn_Protect.FlatAppearance.BorderSize = 0;
            this.btn_Protect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Protect.ForeColor = System.Drawing.Color.Black;
            this.btn_Protect.Location = new System.Drawing.Point(333, 4);
            this.btn_Protect.Name = "btn_Protect";
            this.btn_Protect.Size = new System.Drawing.Size(54, 19);
            this.btn_Protect.TabIndex = 6;
            this.btn_Protect.Text = "保护";
            this.btn_Protect.UseVisualStyleBackColor = true;
            this.btn_Protect.Click += new System.EventHandler(this.btn_Protect_Click);
            // 
            // winWordControl
            // 
            this.winWordControl.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.winWordControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winWordControl.Location = new System.Drawing.Point(0, 237);
            this.winWordControl.Name = "winWordControl";
            this.winWordControl.Size = new System.Drawing.Size(889, 477);
            this.winWordControl.TabIndex = 47;
            // 
            // frmTempManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 714);
            this.Controls.Add(this.winWordControl);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.pan_List);
            this.Controls.Add(this.pan_Input);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmTempManager";
            this.Text = "打印模板管理";
            this.Load += new System.EventHandler(this.frmTempManager_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTempManager_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Print)).EndInit();
            this.pan_Input.ResumeLayout(false);
            this.pan_Input.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.pan_List.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_New;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_FunName;
        private BaseControls.MyDataGridView dgv_Print;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.MyLabel lb_PromptInfo;
        private BaseControls.MyLabel label1;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private BaseControls.userTextBox tx_TempName;
        private System.Windows.Forms.ComboBox cmb_ExamClass;
        private System.Windows.Forms.ComboBox cmb_ExamSubClass;
        public System.Windows.Forms.Button btn_Query;
        public System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINT_TEMPLATE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_SUB_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINT_TEMPLATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FIELD_INF;
        private System.Windows.Forms.DataGridViewTextBoxColumn FILE_DATE_TIME;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Panel pan_Input;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button btn_UnProtect;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button button3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        public System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel pan_List;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        public System.Windows.Forms.Button button6;
        public System.Windows.Forms.Button button7;
        public System.Windows.Forms.Button btn_SaveAs;
        public System.Windows.Forms.Button btn_Open;
        public System.Windows.Forms.Button btn_Protect;
        private BaseControls.WinWordControl winWordControl;
    }
}