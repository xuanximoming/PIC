namespace SIS.SysMaintenance
{
    partial class frmChargeClass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargeClass));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.myPanel1 = new BaseControls.Panels.MyPanel();
            this.txt_CHARGE_CLASS = new BaseControls.MyTextBox();
            this.label3 = new BaseControls.MyLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.dgv_ChargeClass = new BaseControls.MyDataGridView();
            this.CHARGE_CLASS_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGE_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGE_RATIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.myPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_PromptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChargeClass)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myPanel1
            // 
            this.myPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPanel1.BorderColor = System.Drawing.Color.Silver;
            this.myPanel1.Controls.Add(this.txt_CHARGE_CLASS);
            this.myPanel1.Controls.Add(this.label3);
            this.myPanel1.Location = new System.Drawing.Point(9, 33);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(862, 42);
            this.myPanel1.TabIndex = 32;
            // 
            // txt_CHARGE_CLASS
            // 
            this.txt_CHARGE_CLASS.Location = new System.Drawing.Point(76, 10);
            this.txt_CHARGE_CLASS.Name = "txt_CHARGE_CLASS";
            this.txt_CHARGE_CLASS.Size = new System.Drawing.Size(122, 21);
            this.txt_CHARGE_CLASS.TabIndex = 3;
            this.txt_CHARGE_CLASS.TextChanged += new System.EventHandler(this.txt_CHARGE_CLASS_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "收费类别：";
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(297, 200);
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
            // lb_PromptInfo
            // 
            this.lb_PromptInfo.AutoSize = true;
            this.lb_PromptInfo.BackColor = System.Drawing.Color.Bisque;
            this.lb_PromptInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_PromptInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lb_PromptInfo.Location = new System.Drawing.Point(45, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(125, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有收费类别信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
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
            this.btn_FunName.TabIndex = 6;
            this.btn_FunName.Text = "button1";
            this.btn_FunName.UseVisualStyleBackColor = true;
            // 
            // dgv_ChargeClass
            // 
            this.dgv_ChargeClass.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_ChargeClass.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ChargeClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ChargeClass.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ChargeClass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ChargeClass.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ChargeClass.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ChargeClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ChargeClass.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHARGE_CLASS_ID,
            this.CHARGE_CLASS,
            this.CHARGE_RATIO,
            this.Operate,
            this.Edit});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ChargeClass.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ChargeClass.DefaultScaleWidth = 1280;
            this.dgv_ChargeClass.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_ChargeClass.Location = new System.Drawing.Point(9, 88);
            this.dgv_ChargeClass.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_ChargeClass.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_ChargeClass.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_ChargeClass.MergeColumnNames")));
            this.dgv_ChargeClass.Name = "dgv_ChargeClass";
            this.dgv_ChargeClass.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ChargeClass.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ChargeClass.RowTemplate.Height = 23;
            this.dgv_ChargeClass.Size = new System.Drawing.Size(865, 457);
            this.dgv_ChargeClass.TabIndex = 30;
            this.dgv_ChargeClass.XmlFile = null;
            this.dgv_ChargeClass.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_ChargceClass_DataError);
            this.dgv_ChargeClass.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ChargceClass_CellContentClick);
            // 
            // CHARGE_CLASS_ID
            // 
            this.CHARGE_CLASS_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CHARGE_CLASS_ID.DataPropertyName = "CHARGE_CLASS_ID";
            this.CHARGE_CLASS_ID.FillWeight = 50F;
            this.CHARGE_CLASS_ID.HeaderText = "类别标识";
            this.CHARGE_CLASS_ID.MinimumWidth = 70;
            this.CHARGE_CLASS_ID.Name = "CHARGE_CLASS_ID";
            this.CHARGE_CLASS_ID.ReadOnly = true;
            // 
            // CHARGE_CLASS
            // 
            this.CHARGE_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CHARGE_CLASS.DataPropertyName = "CHARGE_CLASS";
            this.CHARGE_CLASS.FillWeight = 150F;
            this.CHARGE_CLASS.HeaderText = "收费类别";
            this.CHARGE_CLASS.MinimumWidth = 80;
            this.CHARGE_CLASS.Name = "CHARGE_CLASS";
            this.CHARGE_CLASS.ReadOnly = true;
            // 
            // CHARGE_RATIO
            // 
            this.CHARGE_RATIO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CHARGE_RATIO.DataPropertyName = "CHARGE_RATIO";
            this.CHARGE_RATIO.FillWeight = 50F;
            this.CHARGE_RATIO.HeaderText = "收费百分比";
            this.CHARGE_RATIO.Name = "CHARGE_RATIO";
            this.CHARGE_RATIO.ReadOnly = true;
            // 
            // Operate
            // 
            this.Operate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Operate.FillWeight = 10F;
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
            this.Edit.Width = 50;
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 434F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Add, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 27);
            this.tableLayoutPanel1.TabIndex = 31;
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Save.Location = new System.Drawing.Point(256, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 19);
            this.btn_Save.TabIndex = 5;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Add.FlatAppearance.BorderSize = 0;
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Add.Location = new System.Drawing.Point(155, 4);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(94, 19);
            this.btn_Add.TabIndex = 4;
            this.btn_Add.Text = "增加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // frmChargeClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(883, 560);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.dgv_ChargeClass);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmChargeClass";
            this.Text = "收费类别信息";
            this.Load += new System.EventHandler(this.ChargeClass_Load);
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChargeClass)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.Panels.MyPanel myPanel1;
        private BaseControls.MyLabel label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private BaseControls.MyLabel lb_PromptInfo;
        public System.Windows.Forms.Button btn_FunName;
        private BaseControls.MyDataGridView dgv_ChargeClass;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_CLASS_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_RATIO;
        private System.Windows.Forms.DataGridViewButtonColumn Operate;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private BaseControls.MyTextBox txt_CHARGE_CLASS;
    }
}