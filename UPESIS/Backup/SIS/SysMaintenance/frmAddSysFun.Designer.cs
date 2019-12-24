namespace SIS.SysMaintenance
{
    partial class frmAddSysFun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddSysFun));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panTool = new System.Windows.Forms.Panel();
            this.btnFunName = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel1 = new BaseControls.XPander.Panel();
            this.GvFunClassOne = new BaseControls.MyDataGridView();
            this.choose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MODEL_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_PLACE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SORT_FLAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MODEL_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GvFunClassOne)).BeginInit();
            this.SuspendLayout();
            // 
            // panTool
            // 
            this.panTool.BackgroundImage = global::SIS.Properties.Resources.timebar;
            this.panTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTool.Location = new System.Drawing.Point(0, 0);
            this.panTool.Name = "panTool";
            this.panTool.Size = new System.Drawing.Size(1064, 24);
            this.panTool.TabIndex = 10;
            // 
            // btnFunName
            // 
            this.btnFunName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFunName.Enabled = false;
            this.btnFunName.FlatAppearance.BorderSize = 0;
            this.btnFunName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFunName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnFunName.Location = new System.Drawing.Point(135, 4);
            this.btnFunName.Name = "btnFunName";
            this.btnFunName.Size = new System.Drawing.Size(58, 22);
            this.btnFunName.TabIndex = 3;
            this.btnFunName.Text = "button1";
            this.btnFunName.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(200, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(60, 22);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(124, 22);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 674F));
            this.tableLayoutPanel1.Controls.Add(this.btnDel, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpdate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFunName, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1064, 30);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // btnDel
            // 
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDel.Location = new System.Drawing.Point(330, 4);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(57, 22);
            this.btnDel.TabIndex = 2;
            this.btnDel.Text = "批删除";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpdate.Location = new System.Drawing.Point(267, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(56, 22);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
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
            this.panel1.Controls.Add(this.GvFunClassOne);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Image = null;
            this.panel1.InnerBorderColor = System.Drawing.Color.White;
            this.panel1.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.panel1.Location = new System.Drawing.Point(15, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(100);
            this.panel1.Name = "panel1";
            this.panel1.PanelStyle = BaseControls.XPander.PanelStyle.None;
            this.panel1.Size = new System.Drawing.Size(1030, 510);
            this.panel1.TabIndex = 11;
            this.panel1.Text = "panel1";
            // 
            // GvFunClassOne
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.GvFunClassOne.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GvFunClassOne.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GvFunClassOne.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GvFunClassOne.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GvFunClassOne.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.choose,
            this.MODEL_ID,
            this.MODEL_PLACE,
            this.SORT_FLAG,
            this.MODEL_NAME,
            this.Operate});
            this.GvFunClassOne.DefaultScaleWidth = 1280;
            this.GvFunClassOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GvFunClassOne.Location = new System.Drawing.Point(0, 0);
            this.GvFunClassOne.Margin = new System.Windows.Forms.Padding(100);
            this.GvFunClassOne.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.GvFunClassOne.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("GvFunClassOne.MergeColumnNames")));
            this.GvFunClassOne.Name = "GvFunClassOne";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GvFunClassOne.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GvFunClassOne.RowTemplate.Height = 23;
            this.GvFunClassOne.Size = new System.Drawing.Size(1030, 510);
            this.GvFunClassOne.TabIndex = 0;
            this.GvFunClassOne.XmlFile = null;
            this.GvFunClassOne.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvFunClassOne_CellDoubleClick);
            this.GvFunClassOne.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.GvFunClassOne_DefaultValuesNeeded);
            this.GvFunClassOne.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvFunClassOne_CellContentClick);
            // 
            // choose
            // 
            this.choose.HeaderText = "选择";
            this.choose.Name = "choose";
            this.choose.Width = 35;
            // 
            // MODEL_ID
            // 
            this.MODEL_ID.DataPropertyName = "MODEL_ID";
            this.MODEL_ID.HeaderText = "编码";
            this.MODEL_ID.Name = "MODEL_ID";
            // 
            // MODEL_PLACE
            // 
            this.MODEL_PLACE.DataPropertyName = "MODEL_PLACE";
            this.MODEL_PLACE.HeaderText = "窗体对象名称";
            this.MODEL_PLACE.Name = "MODEL_PLACE";
            this.MODEL_PLACE.Width = 400;
            // 
            // SORT_FLAG
            // 
            this.SORT_FLAG.DataPropertyName = "SORT_FLAG";
            this.SORT_FLAG.HeaderText = "排序";
            this.SORT_FLAG.Name = "SORT_FLAG";
            // 
            // MODEL_NAME
            // 
            this.MODEL_NAME.DataPropertyName = "MODEL_NAME";
            this.MODEL_NAME.HeaderText = "系统名称";
            this.MODEL_NAME.Name = "MODEL_NAME";
            this.MODEL_NAME.Width = 300;
            // 
            // Operate
            // 
            this.Operate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Operate.HeaderText = "操作";
            this.Operate.Name = "Operate";
            this.Operate.Text = "删除";
            this.Operate.ToolTipText = "删除";
            this.Operate.UseColumnTextForButtonValue = true;
            this.Operate.Width = 35;
            // 
            // AddSysFun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1064, 596);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panTool);
            this.Controls.Add(this.panel1);
            this.Name = "AddSysFun";
            this.Text = "AddSysFun";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSysFun_KeyDown);
            this.Load += new System.EventHandler(this.AddSysFun_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GvFunClassOne)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private DataSet1 dataSet1;
        public System.Windows.Forms.Panel panTool;
        public System.Windows.Forms.Button btnFunName;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private BaseControls.XPander.Panel panel1;
        private BaseControls.MyDataGridView GvFunClassOne;
        public System.Windows.Forms.Button btnUpdate;
        public System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn choose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_PLACE;
        private System.Windows.Forms.DataGridViewTextBoxColumn SORT_FLAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MODEL_NAME;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
       // private SIS.DataSet1TableAdapters.SYSTEM_FUNCTIONTableAdapter sYSTEM_FUNCTIONTableAdapter;
    }
}