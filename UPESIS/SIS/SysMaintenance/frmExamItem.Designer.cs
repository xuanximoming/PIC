namespace SIS.SysMaintenance
{
    partial class frmExamItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamItem));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.dgv_ExamItem = new BaseControls.MyDataGridView();
            this.myPanel1 = new BaseControls.Panels.MyPanel();
            this.label3 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.label1 = new BaseControls.MyLabel();
            this.cmb_EXAM_SUB_CLASS = new BaseControls.ComboBoxs.MyComboBox();
            this.cmb_EXAM_CLASS = new BaseControls.ComboBoxs.MyComboBox();
            this.txt_INPUT_CODE = new BaseControls.MyTextBox();
            this.EXAM_ITEM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_CLASS = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EXAM_SUB_CLASS = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SORT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExamItem)).BeginInit();
            this.myPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Add
            // 
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Add.Location = new System.Drawing.Point(135, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(58, 19);
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
            this.btn_Save.Location = new System.Drawing.Point(200, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(60, 19);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 672F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Add, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 27);
            this.tableLayoutPanel1.TabIndex = 29;
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(341, 109);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 31;
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
            this.lb_PromptInfo.Location = new System.Drawing.Point(42, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(125, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有检查项目信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // dgv_ExamItem
            // 
            this.dgv_ExamItem.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_ExamItem.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ExamItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ExamItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_ExamItem.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ExamItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ExamItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ExamItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ExamItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXAM_ITEM_CODE,
            this.EXAM_ITEM_NAME,
            this.INPUT_CODE,
            this.EXAM_CLASS,
            this.EXAM_SUB_CLASS,
            this.SORT_ID,
            this.Operate,
            this.Edit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ExamItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ExamItem.DefaultScaleWidth = 1280;
            this.dgv_ExamItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_ExamItem.Location = new System.Drawing.Point(9, 85);
            this.dgv_ExamItem.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_ExamItem.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_ExamItem.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_ExamItem.MergeColumnNames")));
            this.dgv_ExamItem.Name = "dgv_ExamItem";
            this.dgv_ExamItem.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ExamItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ExamItem.RowTemplate.Height = 23;
            this.dgv_ExamItem.Size = new System.Drawing.Size(793, 462);
            this.dgv_ExamItem.TabIndex = 30;
            this.dgv_ExamItem.XmlFile = null;
            this.dgv_ExamItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ExamItem_CellValueChanged);
            this.dgv_ExamItem.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgv_ExamItem_CellValidating);
            this.dgv_ExamItem.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_ExamItem_DataError);
            this.dgv_ExamItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ExamItem_CellContentClick);
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BorderColor = System.Drawing.Color.Silver;
            this.myPanel1.Controls.Add(this.label3);
            this.myPanel1.Controls.Add(this.label2);
            this.myPanel1.Controls.Add(this.label1);
            this.myPanel1.Controls.Add(this.cmb_EXAM_SUB_CLASS);
            this.myPanel1.Controls.Add(this.cmb_EXAM_CLASS);
            this.myPanel1.Controls.Add(this.txt_INPUT_CODE);
            this.myPanel1.Location = new System.Drawing.Point(12, 30);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(791, 37);
            this.myPanel1.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(415, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "拼音码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(209, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "检查子类：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "检查类别：";
            // 
            // cmb_EXAM_SUB_CLASS
            // 
            this.cmb_EXAM_SUB_CLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EXAM_SUB_CLASS.FormattingEnabled = true;
            this.cmb_EXAM_SUB_CLASS.Location = new System.Drawing.Point(280, 10);
            this.cmb_EXAM_SUB_CLASS.Name = "cmb_EXAM_SUB_CLASS";
            this.cmb_EXAM_SUB_CLASS.Size = new System.Drawing.Size(119, 20);
            this.cmb_EXAM_SUB_CLASS.TabIndex = 1;
            this.cmb_EXAM_SUB_CLASS.SelectedIndexChanged += new System.EventHandler(this.cmb_EXAM_SUB_CLASS_SelectedIndexChanged);
            // 
            // cmb_EXAM_CLASS
            // 
            this.cmb_EXAM_CLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EXAM_CLASS.FormattingEnabled = true;
            this.cmb_EXAM_CLASS.Location = new System.Drawing.Point(74, 9);
            this.cmb_EXAM_CLASS.Name = "cmb_EXAM_CLASS";
            this.cmb_EXAM_CLASS.Size = new System.Drawing.Size(119, 20);
            this.cmb_EXAM_CLASS.TabIndex = 1;
            this.cmb_EXAM_CLASS.SelectedIndexChanged += new System.EventHandler(this.cmb_EXAM_CLASS_SelectedIndexChanged);
            // 
            // txt_INPUT_CODE
            // 
            this.txt_INPUT_CODE.Location = new System.Drawing.Point(474, 8);
            this.txt_INPUT_CODE.Name = "txt_INPUT_CODE";
            this.txt_INPUT_CODE.Size = new System.Drawing.Size(132, 21);
            this.txt_INPUT_CODE.TabIndex = 0;
            this.txt_INPUT_CODE.TextChanged += new System.EventHandler(this.txt_INPUT_CODE_TextChanged);
            // 
            // EXAM_ITEM_CODE
            // 
            this.EXAM_ITEM_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_ITEM_CODE.DataPropertyName = "EXAM_ITEM_CODE";
            this.EXAM_ITEM_CODE.FillWeight = 25F;
            this.EXAM_ITEM_CODE.HeaderText = "项目代码";
            this.EXAM_ITEM_CODE.MaxInputLength = 10;
            this.EXAM_ITEM_CODE.Name = "EXAM_ITEM_CODE";
            this.EXAM_ITEM_CODE.ReadOnly = true;
            this.EXAM_ITEM_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EXAM_ITEM_NAME
            // 
            this.EXAM_ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_ITEM_NAME.DataPropertyName = "EXAM_ITEM_NAME";
            this.EXAM_ITEM_NAME.FillWeight = 25F;
            this.EXAM_ITEM_NAME.HeaderText = "项目名称";
            this.EXAM_ITEM_NAME.MaxInputLength = 48;
            this.EXAM_ITEM_NAME.Name = "EXAM_ITEM_NAME";
            this.EXAM_ITEM_NAME.ReadOnly = true;
            this.EXAM_ITEM_NAME.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // INPUT_CODE
            // 
            this.INPUT_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.INPUT_CODE.DataPropertyName = "INPUT_CODE";
            this.INPUT_CODE.FillWeight = 10F;
            this.INPUT_CODE.HeaderText = "拼音码";
            this.INPUT_CODE.MaxInputLength = 32;
            this.INPUT_CODE.Name = "INPUT_CODE";
            this.INPUT_CODE.ReadOnly = true;
            this.INPUT_CODE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.INPUT_CODE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EXAM_CLASS
            // 
            this.EXAM_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_CLASS.DataPropertyName = "EXAM_CLASS";
            this.EXAM_CLASS.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.EXAM_CLASS.FillWeight = 20F;
            this.EXAM_CLASS.HeaderText = "检查类别";
            this.EXAM_CLASS.Name = "EXAM_CLASS";
            this.EXAM_CLASS.ReadOnly = true;
            this.EXAM_CLASS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // EXAM_SUB_CLASS
            // 
            this.EXAM_SUB_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_SUB_CLASS.DataPropertyName = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.EXAM_SUB_CLASS.FillWeight = 25F;
            this.EXAM_SUB_CLASS.HeaderText = "检查子类";
            this.EXAM_SUB_CLASS.Name = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.ReadOnly = true;
            this.EXAM_SUB_CLASS.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // SORT_ID
            // 
            this.SORT_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SORT_ID.DataPropertyName = "SORT_ID";
            this.SORT_ID.FillWeight = 10F;
            this.SORT_ID.HeaderText = "序号";
            this.SORT_ID.MaxInputLength = 3;
            this.SORT_ID.Name = "SORT_ID";
            this.SORT_ID.ReadOnly = true;
            this.SORT_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // frmExamItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 566);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_ExamItem);
            this.Name = "frmExamItem";
            this.Text = "ExamItem";
            this.Load += new System.EventHandler(this.ExamItem_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ExamItem)).EndInit();
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btn_Add;
        private BaseControls.MyDataGridView dgv_ExamItem;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_FunName;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.MyLabel lb_PromptInfo;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BaseControls.Panels.MyPanel myPanel1;
        private BaseControls.MyLabel label3;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label1;
        private BaseControls.ComboBoxs.MyComboBox cmb_EXAM_SUB_CLASS;
        private BaseControls.ComboBoxs.MyComboBox cmb_EXAM_CLASS;
        private BaseControls.MyTextBox txt_INPUT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ITEM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_CODE;
        private System.Windows.Forms.DataGridViewComboBoxColumn EXAM_CLASS;
        private System.Windows.Forms.DataGridViewComboBoxColumn EXAM_SUB_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT_ID;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}