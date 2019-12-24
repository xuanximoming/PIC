namespace SIS.SysMaintenance
{
    partial class frmAddModelOne
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddModelOne));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFunName = new System.Windows.Forms.Button();
            this.btnGoUpModel = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.GvFunClassOne = new BaseControls.MyDataGridView();
            this.MODEL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_PLACE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMAGE_ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SORT_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new BaseControls.XPander.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvFunClassOne)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(200, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 14);
            this.button2.TabIndex = 0;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tableLayoutPanel1.BackgroundImage")));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
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
            this.tableLayoutPanel1.TabIndex = 9;
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
            this.btnSave.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnFunName
            // 
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
            this.btnGoUpModel.TabIndex = 4;
            this.btnGoUpModel.Text = "返回";
            this.btnGoUpModel.UseVisualStyleBackColor = true;
            this.btnGoUpModel.Click += new System.EventHandler(this.btnGoUpModel_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 658F));
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
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 92);
            this.button1.TabIndex = 4;
            this.button1.Text = "增加";
            this.button1.UseVisualStyleBackColor = true;
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
            this.gb_PromptInfo.TabIndex = 22;
            this.gb_PromptInfo.UseWaitCursor = true;
            this.gb_PromptInfo.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(4, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // lb_PromptInfo
            // 
            this.lb_PromptInfo.AutoSize = true;
            this.lb_PromptInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_PromptInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lb_PromptInfo.Location = new System.Drawing.Point(44, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(125, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有一级模块信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
            // 
            // GvFunClassOne
            // 
            this.GvFunClassOne.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GvFunClassOne.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GvFunClassOne.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GvFunClassOne.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GvFunClassOne.BackgroundColor = System.Drawing.Color.White;
            this.GvFunClassOne.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvFunClassOne.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GvFunClassOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvFunClassOne.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MODEL_ID,
            this.MODEL_NAME,
            this.MODEL_PLACE,
            this.IMAGE_ADDRESS,
            this.SORT_FLAG,
            this.Operate,
            this.Edit});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GvFunClassOne.DefaultCellStyle = dataGridViewCellStyle4;
            this.GvFunClassOne.DefaultScaleWidth = 1280;
            this.GvFunClassOne.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.GvFunClassOne.Location = new System.Drawing.Point(10, 50);
            this.GvFunClassOne.Margin = new System.Windows.Forms.Padding(0);
            this.GvFunClassOne.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.GvFunClassOne.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("GvFunClassOne.MergeColumnNames")));
            this.GvFunClassOne.Name = "GvFunClassOne";
            this.GvFunClassOne.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvFunClassOne.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.GvFunClassOne.RowTemplate.Height = 23;
            this.GvFunClassOne.Size = new System.Drawing.Size(793, 531);
            this.GvFunClassOne.TabIndex = 0;
            this.GvFunClassOne.XmlFile = null;
            this.GvFunClassOne.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvFunClassOne_CellContentClick);
            // 
            // MODEL_ID
            // 
            this.MODEL_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MODEL_ID.DataPropertyName = "MODEL_ID";
            this.MODEL_ID.FillWeight = 10F;
            this.MODEL_ID.HeaderText = "编码";
            this.MODEL_ID.Name = "MODEL_ID";
            this.MODEL_ID.ReadOnly = true;
            // 
            // MODEL_NAME
            // 
            this.MODEL_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MODEL_NAME.DataPropertyName = "MODEL_NAME";
            this.MODEL_NAME.FillWeight = 25F;
            this.MODEL_NAME.HeaderText = "系统名称";
            this.MODEL_NAME.MaxInputLength = 100;
            this.MODEL_NAME.Name = "MODEL_NAME";
            this.MODEL_NAME.ReadOnly = true;
            // 
            // MODEL_PLACE
            // 
            this.MODEL_PLACE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MODEL_PLACE.DataPropertyName = "MODEL_PLACE";
            this.MODEL_PLACE.FillWeight = 25F;
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
            dataGridViewCellStyle3.NullValue = null;
            this.SORT_FLAG.DefaultCellStyle = dataGridViewCellStyle3;
            this.SORT_FLAG.FillWeight = 10F;
            this.SORT_FLAG.HeaderText = "序号";
            this.SORT_FLAG.MaxInputLength = 4;
            this.SORT_FLAG.Name = "SORT_FLAG";
            this.SORT_FLAG.ReadOnly = true;
            // 
            // Operate
            // 
            this.Operate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            this.panel1.CaptionFont = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold);
            this.panel1.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.CloseIconForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.CollapsedCaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.ColorCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(177)))), ((int)(((byte)(250)))));
            this.panel1.ColorCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(145)))));
            this.panel1.ColorCaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(127)))), ((int)(((byte)(208)))));
            this.panel1.ColorContentPanelGradientBegin = System.Drawing.Color.Empty;
            this.panel1.ColorContentPanelGradientEnd = System.Drawing.Color.Empty;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Image = null;
            this.panel1.InnerBorderColor = System.Drawing.Color.White;
            this.panel1.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel1.Location = new System.Drawing.Point(15, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(100);
            this.panel1.Name = "panel1";
            this.panel1.PanelStyle = BaseControls.XPander.PanelStyle.None;
            this.panel1.Size = new System.Drawing.Size(778, 504);
            this.panel1.TabIndex = 11;
            this.panel1.Text = "panel1";
            // 
            // frmAddModelOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(812, 590);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.GvFunClassOne);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "frmAddModelOne";
            this.Text = "AddSysFun";
            this.Load += new System.EventHandler(this.AddSysFun_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GvFunClassOne)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private DataSet1 dataSet1;
        public System.Windows.Forms.Button btnFunName;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BaseControls.XPander.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button btnGoUpModel;
        private BaseControls.MyDataGridView GvFunClassOne;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private BaseControls.MyLabel lb_PromptInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_PLACE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMAGE_ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT_FLAG;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
       // private SIS.DataSet1TableAdapters.SYSTEM_FUNCTIONTableAdapter sYSTEM_FUNCTIONTableAdapter;
    }
}