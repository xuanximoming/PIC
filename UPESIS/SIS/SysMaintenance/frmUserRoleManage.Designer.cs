namespace SIS.SysMaintenance
{
    partial class frmUserRoleManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserRoleManage));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.dgv_GroupManage = new BaseControls.MyDataGridView();
            this.myPanel1 = new BaseControls.Panels.MyPanel();
            this.cmb_EXAM_SUB_CLASS = new BaseControls.ComboBoxs.MyComboBox();
            this.cmb_EXAM_CLASS = new BaseControls.ComboBoxs.MyComboBox();
            this.label2 = new BaseControls.MyLabel();
            this.label1 = new BaseControls.MyLabel();
            this.ROLE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ROLE_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EXAM_CLASS = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EXAM_SUB_CLASS = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ROLE_SET = new System.Windows.Forms.DataGridViewButtonColumn();
            this.FUN_MODEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GroupManage)).BeginInit();
            this.myPanel1.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 919F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Add, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 27);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // btn_Add
            // 
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Add.Location = new System.Drawing.Point(135, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(63, 19);
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
            this.btn_Save.Location = new System.Drawing.Point(205, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(54, 19);
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(289, 114);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 22;
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
            this.lb_PromptInfo.Size = new System.Drawing.Size(101, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有角色信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // dgv_GroupManage
            // 
            this.dgv_GroupManage.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_GroupManage.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_GroupManage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_GroupManage.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_GroupManage.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_GroupManage.BackgroundColor = System.Drawing.Color.White;
            this.dgv_GroupManage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_GroupManage.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_GroupManage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_GroupManage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ROLE_ID,
            this.ROLE_NAME,
            this.EXAM_CLASS,
            this.EXAM_SUB_CLASS,
            this.ROLE_SET,
            this.FUN_MODEL,
            this.Operate,
            this.Edit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_GroupManage.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_GroupManage.DefaultScaleWidth = 1280;
            this.dgv_GroupManage.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_GroupManage.Location = new System.Drawing.Point(10, 92);
            this.dgv_GroupManage.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_GroupManage.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_GroupManage.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_GroupManage.MergeColumnNames")));
            this.dgv_GroupManage.Name = "dgv_GroupManage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_GroupManage.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_GroupManage.RowTemplate.Height = 23;
            this.dgv_GroupManage.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_GroupManage.Size = new System.Drawing.Size(790, 459);
            this.dgv_GroupManage.TabIndex = 20;
            this.dgv_GroupManage.XmlFile = null;
            this.dgv_GroupManage.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_GroupManage_CellValueChanged);
            this.dgv_GroupManage.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_GroupManage_DataError);
            this.dgv_GroupManage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_GroupManage_CellContentClick);
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BorderColor = System.Drawing.Color.Silver;
            this.myPanel1.Controls.Add(this.cmb_EXAM_SUB_CLASS);
            this.myPanel1.Controls.Add(this.cmb_EXAM_CLASS);
            this.myPanel1.Controls.Add(this.label2);
            this.myPanel1.Controls.Add(this.label1);
            this.myPanel1.Location = new System.Drawing.Point(10, 38);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(790, 35);
            this.myPanel1.TabIndex = 23;
            // 
            // cmb_EXAM_SUB_CLASS
            // 
            this.cmb_EXAM_SUB_CLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EXAM_SUB_CLASS.FormattingEnabled = true;
            this.cmb_EXAM_SUB_CLASS.Location = new System.Drawing.Point(291, 7);
            this.cmb_EXAM_SUB_CLASS.Name = "cmb_EXAM_SUB_CLASS";
            this.cmb_EXAM_SUB_CLASS.Size = new System.Drawing.Size(140, 20);
            this.cmb_EXAM_SUB_CLASS.TabIndex = 2;
            this.cmb_EXAM_SUB_CLASS.SelectedIndexChanged += new System.EventHandler(this.cmb_EXAM_SUB_CLASS_SelectedIndexChanged);
            // 
            // cmb_EXAM_CLASS
            // 
            this.cmb_EXAM_CLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_EXAM_CLASS.FormattingEnabled = true;
            this.cmb_EXAM_CLASS.Location = new System.Drawing.Point(74, 7);
            this.cmb_EXAM_CLASS.Name = "cmb_EXAM_CLASS";
            this.cmb_EXAM_CLASS.Size = new System.Drawing.Size(140, 20);
            this.cmb_EXAM_CLASS.TabIndex = 2;
            this.cmb_EXAM_CLASS.SelectedIndexChanged += new System.EventHandler(this.cmb_EXAM_CLASS_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(220, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "检查子类：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "检查类别：";
            // 
            // ROLE_ID
            // 
            this.ROLE_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ROLE_ID.DataPropertyName = "ROLE_ID";
            this.ROLE_ID.FillWeight = 20F;
            this.ROLE_ID.HeaderText = "角色标识";
            this.ROLE_ID.MaxInputLength = 4;
            this.ROLE_ID.Name = "ROLE_ID";
            // 
            // ROLE_NAME
            // 
            this.ROLE_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ROLE_NAME.DataPropertyName = "ROLE_NAME";
            this.ROLE_NAME.FillWeight = 30F;
            this.ROLE_NAME.HeaderText = "角色名称";
            this.ROLE_NAME.MaxInputLength = 16;
            this.ROLE_NAME.Name = "ROLE_NAME";
            // 
            // EXAM_CLASS
            // 
            this.EXAM_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_CLASS.DataPropertyName = "EXAM_CLASS";
            this.EXAM_CLASS.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.EXAM_CLASS.FillWeight = 20F;
            this.EXAM_CLASS.HeaderText = "检查类别";
            this.EXAM_CLASS.Name = "EXAM_CLASS";
            // 
            // EXAM_SUB_CLASS
            // 
            this.EXAM_SUB_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.EXAM_SUB_CLASS.DataPropertyName = "EXAM_SUB_CLASS";
            this.EXAM_SUB_CLASS.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.EXAM_SUB_CLASS.FillWeight = 20F;
            this.EXAM_SUB_CLASS.HeaderText = "检查子类";
            this.EXAM_SUB_CLASS.Name = "EXAM_SUB_CLASS";
            // 
            // ROLE_SET
            // 
            this.ROLE_SET.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ROLE_SET.HeaderText = "权限设置";
            this.ROLE_SET.Name = "ROLE_SET";
            this.ROLE_SET.Text = "权限设置";
            this.ROLE_SET.ToolTipText = "权限设置";
            this.ROLE_SET.UseColumnTextForButtonValue = true;
            this.ROLE_SET.Width = 59;
            // 
            // FUN_MODEL
            // 
            this.FUN_MODEL.DataPropertyName = "FUN_MODEL";
            this.FUN_MODEL.HeaderText = "功能模块";
            this.FUN_MODEL.Name = "FUN_MODEL";
            this.FUN_MODEL.Visible = false;
            this.FUN_MODEL.Width = 78;
            // 
            // Operate
            // 
            this.Operate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Operate.FillWeight = 10F;
            this.Operate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Operate.HeaderText = "操作";
            this.Operate.Name = "Operate";
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
            this.Edit.Text = "编辑";
            this.Edit.ToolTipText = "编辑";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 50;
            // 
            // frmUserRoleManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 566);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_GroupManage);
            this.Name = "frmUserRoleManage";
            this.Text = "UserRoleManage";
            this.Load += new System.EventHandler(this.UserRoleManage_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_GroupManage)).EndInit();
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.MyLabel lb_PromptInfo;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Add;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_FunName;
        private BaseControls.MyDataGridView dgv_GroupManage;
        private BaseControls.Panels.MyPanel myPanel1;
        private BaseControls.ComboBoxs.MyComboBox cmb_EXAM_SUB_CLASS;
        private BaseControls.ComboBoxs.MyComboBox cmb_EXAM_CLASS;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ROLE_NAME;
        private System.Windows.Forms.DataGridViewComboBoxColumn EXAM_CLASS;
        private System.Windows.Forms.DataGridViewComboBoxColumn EXAM_SUB_CLASS;
        private System.Windows.Forms.DataGridViewButtonColumn ROLE_SET;
        private System.Windows.Forms.DataGridViewTextBoxColumn FUN_MODEL;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}