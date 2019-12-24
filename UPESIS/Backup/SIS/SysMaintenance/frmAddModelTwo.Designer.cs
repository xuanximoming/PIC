namespace SIS.SysMaintenance
{
    partial class frmAddModelTwo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddModelTwo));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFunName = new System.Windows.Forms.Button();
            this.btnGoUpModel = new System.Windows.Forms.Button();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.GvFunClassTwo = new BaseControls.MyDataGridView();
            this.MODEL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UP_MODEL_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MODEL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_PLACE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMAGE_ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SORT_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvFunClassTwo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 493F));
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnGoUpModel, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 27);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAdd.Location = new System.Drawing.Point(135, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(58, 19);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnSave.Location = new System.Drawing.Point(200, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 19);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // btnGoUpModel
            // 
            this.btnGoUpModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGoUpModel.FlatAppearance.BorderSize = 0;
            this.btnGoUpModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoUpModel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnGoUpModel.Location = new System.Drawing.Point(267, 4);
            this.btnGoUpModel.Name = "btnGoUpModel";
            this.btnGoUpModel.Size = new System.Drawing.Size(56, 19);
            this.btnGoUpModel.TabIndex = 3;
            this.btnGoUpModel.Text = "返回";
            this.btnGoUpModel.UseVisualStyleBackColor = true;
            this.btnGoUpModel.Click += new System.EventHandler(this.btnGoUpModel_Click);
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(345, 71);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 21;
            this.gb_PromptInfo.UseWaitCursor = true;
            this.gb_PromptInfo.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(4, 12);
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
            this.lb_PromptInfo.Location = new System.Drawing.Point(43, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(125, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有二级模块信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // GvFunClassTwo
            // 
            this.GvFunClassTwo.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GvFunClassTwo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GvFunClassTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GvFunClassTwo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GvFunClassTwo.BackgroundColor = System.Drawing.Color.White;
            this.GvFunClassTwo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvFunClassTwo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GvFunClassTwo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvFunClassTwo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MODEL_ID,
            this.UP_MODEL_ID,
            this.MODEL_NAME,
            this.MODEL_PLACE,
            this.IMAGE_ADDRESS,
            this.SORT_FLAG,
            this.Operate,
            this.Edit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GvFunClassTwo.DefaultCellStyle = dataGridViewCellStyle3;
            this.GvFunClassTwo.DefaultScaleWidth = 1280;
            this.GvFunClassTwo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.GvFunClassTwo.Location = new System.Drawing.Point(10, 50);
            this.GvFunClassTwo.Margin = new System.Windows.Forms.Padding(100);
            this.GvFunClassTwo.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.GvFunClassTwo.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("GvFunClassTwo.MergeColumnNames")));
            this.GvFunClassTwo.Name = "GvFunClassTwo";
            this.GvFunClassTwo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvFunClassTwo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GvFunClassTwo.RowTemplate.Height = 23;
            this.GvFunClassTwo.Size = new System.Drawing.Size(789, 517);
            this.GvFunClassTwo.TabIndex = 14;
            this.GvFunClassTwo.XmlFile = null;
            this.GvFunClassTwo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.GvFunClassTwo_DataError);
            this.GvFunClassTwo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvFunClassTwo_CellContentClick);
            // 
            // MODEL_ID
            // 
            this.MODEL_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MODEL_ID.DataPropertyName = "MODEL_ID";
            this.MODEL_ID.FillWeight = 10F;
            this.MODEL_ID.HeaderText = "编码";
            this.MODEL_ID.Name = "MODEL_ID";
            this.MODEL_ID.ReadOnly = true;
            this.MODEL_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // UP_MODEL_ID
            // 
            this.UP_MODEL_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UP_MODEL_ID.DataPropertyName = "UP_MODEL_ID";
            this.UP_MODEL_ID.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.UP_MODEL_ID.FillWeight = 20F;
            this.UP_MODEL_ID.HeaderText = "一级模块";
            this.UP_MODEL_ID.Name = "UP_MODEL_ID";
            this.UP_MODEL_ID.ReadOnly = true;
            this.UP_MODEL_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // MODEL_NAME
            // 
            this.MODEL_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MODEL_NAME.DataPropertyName = "MODEL_NAME";
            this.MODEL_NAME.FillWeight = 20F;
            this.MODEL_NAME.HeaderText = "系统名称";
            this.MODEL_NAME.MaxInputLength = 100;
            this.MODEL_NAME.Name = "MODEL_NAME";
            this.MODEL_NAME.ReadOnly = true;
            // 
            // MODEL_PLACE
            // 
            this.MODEL_PLACE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MODEL_PLACE.DataPropertyName = "MODEL_PLACE";
            this.MODEL_PLACE.FillWeight = 20F;
            this.MODEL_PLACE.HeaderText = "窗体对象名称";
            this.MODEL_PLACE.MaxInputLength = 100;
            this.MODEL_PLACE.Name = "MODEL_PLACE";
            this.MODEL_PLACE.ReadOnly = true;
            // 
            // IMAGE_ADDRESS
            // 
            this.IMAGE_ADDRESS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IMAGE_ADDRESS.DataPropertyName = "IMAGE_ADDRESS";
            this.IMAGE_ADDRESS.FillWeight = 20F;
            this.IMAGE_ADDRESS.HeaderText = "图片地址";
            this.IMAGE_ADDRESS.MaxInputLength = 100;
            this.IMAGE_ADDRESS.Name = "IMAGE_ADDRESS";
            this.IMAGE_ADDRESS.ReadOnly = true;
            // 
            // SORT_FLAG
            // 
            this.SORT_FLAG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SORT_FLAG.DataPropertyName = "SORT_FLAG";
            this.SORT_FLAG.FillWeight = 10F;
            this.SORT_FLAG.HeaderText = "序号";
            this.SORT_FLAG.MaxInputLength = 4;
            this.SORT_FLAG.Name = "SORT_FLAG";
            this.SORT_FLAG.ReadOnly = true;
            // 
            // Operate
            // 
            this.Operate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Operate.FillWeight = 238.0952F;
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
            this.Edit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Edit.HeaderText = "";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Text = "编辑";
            this.Edit.ToolTipText = "编辑";
            this.Edit.UseColumnTextForButtonValue = true;
            this.Edit.Width = 50;
            // 
            // frmAddModelTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 584);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.GvFunClassTwo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmAddModelTwo";
            this.Text = "AddModelTwo";
            this.VisibleChanged += new System.EventHandler(this.AddModelTwo_VisibleChanged);
            this.Load += new System.EventHandler(this.AddModelTwo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvFunClassTwo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btnGoUpModel;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnFunName;
        private BaseControls.MyDataGridView GvFunClassTwo;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private BaseControls.MyLabel lb_PromptInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn UP_MODEL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_PLACE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMAGE_ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT_FLAG;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
    }
}