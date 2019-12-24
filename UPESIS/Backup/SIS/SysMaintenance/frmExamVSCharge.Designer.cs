namespace SIS.SysMaintenance
{
    partial class frmExamVSCharge
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExamVSCharge));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnFunName = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.myPanel1 = new BaseControls.Panels.MyPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_Exam_Class = new BaseControls.ComboBoxs.MyComboBox();
            this.txt_AMOUNT = new BaseControls.MyTextBox();
            this.label3 = new BaseControls.MyLabel();
            this.dgv_Exam_Item = new BaseControls.MyDataGridView();
            this.EXAM_ITEM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_SUB_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Charge_Item_Dic = new BaseControls.MyDataGridView();
            this.CHARGE_ITEM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGE_ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGE_ITEM_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNITS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.myPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Exam_Item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Charge_Item_Dic)).BeginInit();
            this.SuspendLayout();
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 878F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Edit, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFunName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 27);
            this.tableLayoutPanel1.TabIndex = 35;
            // 
            // btn_Edit
            // 
            this.btn_Edit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Edit.FlatAppearance.BorderSize = 0;
            this.btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Edit.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Edit.Location = new System.Drawing.Point(135, 4);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(63, 19);
            this.btn_Edit.TabIndex = 4;
            this.btn_Edit.Text = "修改";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BorderColor = System.Drawing.Color.Silver;
            this.myPanel1.Controls.Add(this.label1);
            this.myPanel1.Controls.Add(this.cmb_Exam_Class);
            this.myPanel1.Controls.Add(this.txt_AMOUNT);
            this.myPanel1.Controls.Add(this.label3);
            this.myPanel1.Location = new System.Drawing.Point(10, 33);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(790, 35);
            this.myPanel1.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "检查类别：";
            // 
            // cmb_Exam_Class
            // 
            this.cmb_Exam_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Exam_Class.FormattingEnabled = true;
            this.cmb_Exam_Class.Location = new System.Drawing.Point(80, 8);
            this.cmb_Exam_Class.Name = "cmb_Exam_Class";
            this.cmb_Exam_Class.Size = new System.Drawing.Size(134, 20);
            this.cmb_Exam_Class.TabIndex = 2;
            this.cmb_Exam_Class.SelectedIndexChanged += new System.EventHandler(this.cmb_Exam_Class_SelectedIndexChanged);
            // 
            // txt_AMOUNT
            // 
            this.txt_AMOUNT.Location = new System.Drawing.Point(298, 8);
            this.txt_AMOUNT.Name = "txt_AMOUNT";
            this.txt_AMOUNT.Size = new System.Drawing.Size(114, 21);
            this.txt_AMOUNT.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(241, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "数量：";
            // 
            // dgv_Exam_Item
            // 
            this.dgv_Exam_Item.AllowUserToAddRows = false;
            this.dgv_Exam_Item.AllowUserToDeleteRows = false;
            this.dgv_Exam_Item.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Exam_Item.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_Exam_Item.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_Exam_Item.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Exam_Item.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Exam_Item.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Exam_Item.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Exam_Item.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_Exam_Item.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Exam_Item.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EXAM_ITEM_CODE,
            this.EXAM_CLASS,
            this.EXAM_SUB_CLASS,
            this.EXAM_ITEM_NAME});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Exam_Item.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_Exam_Item.DefaultScaleWidth = 1280;
            this.dgv_Exam_Item.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_Exam_Item.Location = new System.Drawing.Point(9, 84);
            this.dgv_Exam_Item.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Exam_Item.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_Exam_Item.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_Exam_Item.MergeColumnNames")));
            this.dgv_Exam_Item.Name = "dgv_Exam_Item";
            this.dgv_Exam_Item.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Exam_Item.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_Exam_Item.RowHeadersWidth = 15;
            this.dgv_Exam_Item.RowTemplate.Height = 23;
            this.dgv_Exam_Item.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Exam_Item.Size = new System.Drawing.Size(471, 473);
            this.dgv_Exam_Item.TabIndex = 34;
            this.dgv_Exam_Item.XmlFile = null;
            this.dgv_Exam_Item.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Exam_Item_CellClick);
            // 
            // EXAM_ITEM_CODE
            // 
            this.EXAM_ITEM_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_ITEM_CODE.DataPropertyName = "EXAM_ITEM_CODE";
            this.EXAM_ITEM_CODE.FillWeight = 15F;
            this.EXAM_ITEM_CODE.HeaderText = "检查代码";
            this.EXAM_ITEM_CODE.Name = "EXAM_ITEM_CODE";
            this.EXAM_ITEM_CODE.ReadOnly = true;
            // 
            // EXAM_CLASS
            // 
            this.EXAM_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_CLASS.DataPropertyName = "EXAM_CLASS";
            this.EXAM_CLASS.FillWeight = 15F;
            this.EXAM_CLASS.HeaderText = "检查类别";
            this.EXAM_CLASS.Name = "EXAM_CLASS";
            this.EXAM_CLASS.ReadOnly = true;
            // 
            // EXAM_SUB_CLASS
            // 
            this.EXAM_SUB_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_SUB_CLASS.DataPropertyName = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.FillWeight = 15F;
            this.EXAM_SUB_CLASS.HeaderText = "检查子类";
            this.EXAM_SUB_CLASS.Name = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.ReadOnly = true;
            // 
            // EXAM_ITEM_NAME
            // 
            this.EXAM_ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_ITEM_NAME.DataPropertyName = "EXAM_ITEM_NAME";
            this.EXAM_ITEM_NAME.FillWeight = 30F;
            this.EXAM_ITEM_NAME.HeaderText = "项目名称";
            this.EXAM_ITEM_NAME.Name = "EXAM_ITEM_NAME";
            this.EXAM_ITEM_NAME.ReadOnly = true;
            // 
            // dgv_Charge_Item_Dic
            // 
            this.dgv_Charge_Item_Dic.AllowUserToAddRows = false;
            this.dgv_Charge_Item_Dic.AllowUserToDeleteRows = false;
            this.dgv_Charge_Item_Dic.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Charge_Item_Dic.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_Charge_Item_Dic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Charge_Item_Dic.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_Charge_Item_Dic.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Charge_Item_Dic.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Charge_Item_Dic.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Charge_Item_Dic.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv_Charge_Item_Dic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Charge_Item_Dic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHARGE_ITEM_CODE,
            this.CHARGE_ITEM_NAME,
            this.CHARGE_ITEM_SPEC,
            this.PRICE,
            this.UNITS});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Charge_Item_Dic.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgv_Charge_Item_Dic.DefaultScaleWidth = 1280;
            this.dgv_Charge_Item_Dic.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_Charge_Item_Dic.Location = new System.Drawing.Point(495, 84);
            this.dgv_Charge_Item_Dic.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Charge_Item_Dic.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_Charge_Item_Dic.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_Charge_Item_Dic.MergeColumnNames")));
            this.dgv_Charge_Item_Dic.Name = "dgv_Charge_Item_Dic";
            this.dgv_Charge_Item_Dic.ReadOnly = true;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Charge_Item_Dic.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv_Charge_Item_Dic.RowHeadersWidth = 15;
            this.dgv_Charge_Item_Dic.RowTemplate.Height = 23;
            this.dgv_Charge_Item_Dic.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Charge_Item_Dic.Size = new System.Drawing.Size(305, 473);
            this.dgv_Charge_Item_Dic.TabIndex = 34;
            this.dgv_Charge_Item_Dic.XmlFile = null;
            // 
            // CHARGE_ITEM_CODE
            // 
            this.CHARGE_ITEM_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CHARGE_ITEM_CODE.DataPropertyName = "CHARGE_ITEM_CODE";
            this.CHARGE_ITEM_CODE.FillWeight = 15F;
            this.CHARGE_ITEM_CODE.HeaderText = "项目代码";
            this.CHARGE_ITEM_CODE.Name = "CHARGE_ITEM_CODE";
            this.CHARGE_ITEM_CODE.ReadOnly = true;
            // 
            // CHARGE_ITEM_NAME
            // 
            this.CHARGE_ITEM_NAME.DataPropertyName = "CHARGE_ITEM_NAME";
            this.CHARGE_ITEM_NAME.HeaderText = "项目名称";
            this.CHARGE_ITEM_NAME.Name = "CHARGE_ITEM_NAME";
            this.CHARGE_ITEM_NAME.ReadOnly = true;
            this.CHARGE_ITEM_NAME.Width = 78;
            // 
            // CHARGE_ITEM_SPEC
            // 
            this.CHARGE_ITEM_SPEC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CHARGE_ITEM_SPEC.DataPropertyName = "CHARGE_ITEM_SPEC";
            this.CHARGE_ITEM_SPEC.FillWeight = 20F;
            this.CHARGE_ITEM_SPEC.HeaderText = "项目规格";
            this.CHARGE_ITEM_SPEC.Name = "CHARGE_ITEM_SPEC";
            this.CHARGE_ITEM_SPEC.ReadOnly = true;
            // 
            // PRICE
            // 
            this.PRICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PRICE.DataPropertyName = "PRICE";
            this.PRICE.FillWeight = 10F;
            this.PRICE.HeaderText = "价格";
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            // 
            // UNITS
            // 
            this.UNITS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UNITS.DataPropertyName = "UNITS";
            this.UNITS.FillWeight = 10F;
            this.UNITS.HeaderText = "单位";
            this.UNITS.Name = "UNITS";
            this.UNITS.ReadOnly = true;
            // 
            // frmExamVSCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 566);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_Charge_Item_Dic);
            this.Controls.Add(this.dgv_Exam_Item);
            this.Name = "frmExamVSCharge";
            this.Text = "检查项目价格对照";
            this.Load += new System.EventHandler(this.frmExamVSCharge_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Exam_Item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Charge_Item_Dic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.MyTextBox txt_AMOUNT;
        private BaseControls.MyLabel label3;
        private BaseControls.Panels.MyPanel myPanel1;
        public System.Windows.Forms.Button btnFunName;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Edit;
        private BaseControls.MyDataGridView dgv_Exam_Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ITEM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_SUB_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn EXAM_ITEM_NAME;
        private BaseControls.MyDataGridView dgv_Charge_Item_Dic;
        private System.Windows.Forms.Label label1;
        private BaseControls.ComboBoxs.MyComboBox cmb_Exam_Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_ITEM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_ITEM_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNITS;
    }
}