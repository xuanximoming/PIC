namespace SIS.SysMaintenance
{
    partial class frmChargeItemDict
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChargeItemDict));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label10 = new BaseControls.MyLabel();
            this.label5 = new BaseControls.MyLabel();
            this.label4 = new BaseControls.MyLabel();
            this.label3 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.label1 = new BaseControls.MyLabel();
            this.lb_PromptInfo = new BaseControls.MyLabel();
            this.gb_PromptInfo = new BaseControls.GroupBox.MyGroupBox();
            this.myPnl = new BaseControls.Panels.MyPanel();
            this.dtp_START_DATE = new System.Windows.Forms.DateTimePicker();
            this.dtp_ENTER_DATE = new System.Windows.Forms.DateTimePicker();
            this.label11 = new BaseControls.MyLabel();
            this.label7 = new BaseControls.MyLabel();
            this.cmb_CHARGE_ITEM_CLASS = new BaseControls.ComboBoxs.MyComboBox();
            this.txt_OPERATOR = new BaseControls.MyTextBox();
            this.txt_CHARGE_ITEM_SPEC = new BaseControls.MyTextBox();
            this.txt_UNITS = new BaseControls.MyTextBox();
            this.txt_STOP_DATE = new BaseControls.MyTextBox();
            this.txt_PRICE = new BaseControls.MyTextBox();
            this.txt_INPUT_CODE = new BaseControls.MyTextBox();
            this.txt_CHARGE_ITEM_CODE = new BaseControls.MyTextBox();
            this.txt_CHARGE_ITEM_NAME = new BaseControls.MyTextBox();
            this.label9 = new BaseControls.MyLabel();
            this.label8 = new BaseControls.MyLabel();
            this.label6 = new BaseControls.MyLabel();
            this.label12 = new BaseControls.MyLabel();
            this.txt_MEMO = new BaseControls.MyTextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.btn_Find = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.btn_Del = new System.Windows.Forms.Button();
            this.dgv_ChargeItemDict = new BaseControls.MyDataGridView();
            this.CHARGE_ITEM_CLASS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGE_ITEM_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGE_ITEM_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHARGE_ITEM_SPEC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNITS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INPUT_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OPERATOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.START_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STOP_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ENTER_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEMO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_PromptInfo.SuspendLayout();
            this.myPnl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChargeItemDict)).BeginInit();
            this.SuspendLayout();
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(13, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "项目名称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(433, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "简码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(266, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "项目代码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(417, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "起用日期：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(484, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "项目规格：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "所属项目：";
            // 
            // lb_PromptInfo
            // 
            this.lb_PromptInfo.AutoSize = true;
            this.lb_PromptInfo.BackColor = System.Drawing.Color.Bisque;
            this.lb_PromptInfo.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_PromptInfo.ForeColor = System.Drawing.Color.Firebrick;
            this.lb_PromptInfo.Location = new System.Drawing.Point(45, 37);
            this.lb_PromptInfo.Name = "lb_PromptInfo";
            this.lb_PromptInfo.Size = new System.Drawing.Size(101, 12);
            this.lb_PromptInfo.TabIndex = 0;
            this.lb_PromptInfo.Text = "尚未有模板信息！";
            this.lb_PromptInfo.UseWaitCursor = true;
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
            this.gb_PromptInfo.Location = new System.Drawing.Point(314, 248);
            this.gb_PromptInfo.Name = "gb_PromptInfo";
            this.gb_PromptInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gb_PromptInfo.PaintGroupBox = false;
            this.gb_PromptInfo.RoundCorners = 10;
            this.gb_PromptInfo.ShadowColor = System.Drawing.Color.DarkGray;
            this.gb_PromptInfo.ShadowControl = false;
            this.gb_PromptInfo.ShadowThickness = 3;
            this.gb_PromptInfo.Size = new System.Drawing.Size(219, 65);
            this.gb_PromptInfo.TabIndex = 39;
            this.gb_PromptInfo.UseWaitCursor = true;
            this.gb_PromptInfo.Visible = false;
            // 
            // myPnl
            // 
            this.myPnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myPnl.BorderColor = System.Drawing.Color.Silver;
            this.myPnl.Controls.Add(this.dtp_START_DATE);
            this.myPnl.Controls.Add(this.dtp_ENTER_DATE);
            this.myPnl.Controls.Add(this.label11);
            this.myPnl.Controls.Add(this.label7);
            this.myPnl.Controls.Add(this.cmb_CHARGE_ITEM_CLASS);
            this.myPnl.Controls.Add(this.txt_OPERATOR);
            this.myPnl.Controls.Add(this.txt_CHARGE_ITEM_SPEC);
            this.myPnl.Controls.Add(this.txt_UNITS);
            this.myPnl.Controls.Add(this.txt_STOP_DATE);
            this.myPnl.Controls.Add(this.txt_PRICE);
            this.myPnl.Controls.Add(this.txt_INPUT_CODE);
            this.myPnl.Controls.Add(this.txt_CHARGE_ITEM_CODE);
            this.myPnl.Controls.Add(this.txt_CHARGE_ITEM_NAME);
            this.myPnl.Controls.Add(this.label9);
            this.myPnl.Controls.Add(this.label8);
            this.myPnl.Controls.Add(this.label6);
            this.myPnl.Controls.Add(this.label10);
            this.myPnl.Controls.Add(this.label5);
            this.myPnl.Controls.Add(this.label4);
            this.myPnl.Controls.Add(this.label3);
            this.myPnl.Controls.Add(this.label2);
            this.myPnl.Controls.Add(this.label1);
            this.myPnl.Controls.Add(this.label12);
            this.myPnl.Controls.Add(this.txt_MEMO);
            this.myPnl.Location = new System.Drawing.Point(12, 41);
            this.myPnl.Name = "myPnl";
            this.myPnl.Size = new System.Drawing.Size(859, 121);
            this.myPnl.TabIndex = 38;
            // 
            // dtp_START_DATE
            // 
            this.dtp_START_DATE.CustomFormat = "yyyy-MM-dd HH:MM:ss";
            this.dtp_START_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_START_DATE.Location = new System.Drawing.Point(482, 64);
            this.dtp_START_DATE.Name = "dtp_START_DATE";
            this.dtp_START_DATE.Size = new System.Drawing.Size(140, 21);
            this.dtp_START_DATE.TabIndex = 10;
            // 
            // dtp_ENTER_DATE
            // 
            this.dtp_ENTER_DATE.CustomFormat = "yyyy-MM-dd HH:MM:ss";
            this.dtp_ENTER_DATE.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ENTER_DATE.Location = new System.Drawing.Point(271, 64);
            this.dtp_ENTER_DATE.Name = "dtp_ENTER_DATE";
            this.dtp_ENTER_DATE.Size = new System.Drawing.Size(140, 21);
            this.dtp_ENTER_DATE.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(210, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "录入日期：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(13, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "操作员：";
            // 
            // cmb_CHARGE_ITEM_CLASS
            // 
            this.cmb_CHARGE_ITEM_CLASS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_CHARGE_ITEM_CLASS.FormattingEnabled = true;
            this.cmb_CHARGE_ITEM_CLASS.Location = new System.Drawing.Point(91, 10);
            this.cmb_CHARGE_ITEM_CLASS.Name = "cmb_CHARGE_ITEM_CLASS";
            this.cmb_CHARGE_ITEM_CLASS.Size = new System.Drawing.Size(164, 20);
            this.cmb_CHARGE_ITEM_CLASS.TabIndex = 7;
            // 
            // txt_OPERATOR
            // 
            this.txt_OPERATOR.Location = new System.Drawing.Point(90, 64);
            this.txt_OPERATOR.Name = "txt_OPERATOR";
            this.txt_OPERATOR.Size = new System.Drawing.Size(114, 21);
            this.txt_OPERATOR.TabIndex = 8;
            // 
            // txt_CHARGE_ITEM_SPEC
            // 
            this.txt_CHARGE_ITEM_SPEC.Location = new System.Drawing.Point(555, 10);
            this.txt_CHARGE_ITEM_SPEC.Name = "txt_CHARGE_ITEM_SPEC";
            this.txt_CHARGE_ITEM_SPEC.Size = new System.Drawing.Size(293, 21);
            this.txt_CHARGE_ITEM_SPEC.TabIndex = 3;
            // 
            // txt_UNITS
            // 
            this.txt_UNITS.Location = new System.Drawing.Point(758, 37);
            this.txt_UNITS.Name = "txt_UNITS";
            this.txt_UNITS.Size = new System.Drawing.Size(90, 21);
            this.txt_UNITS.TabIndex = 7;
            // 
            // txt_STOP_DATE
            // 
            this.txt_STOP_DATE.Location = new System.Drawing.Point(705, 64);
            this.txt_STOP_DATE.Name = "txt_STOP_DATE";
            this.txt_STOP_DATE.Size = new System.Drawing.Size(143, 21);
            this.txt_STOP_DATE.TabIndex = 11;
            // 
            // txt_PRICE
            // 
            this.txt_PRICE.Location = new System.Drawing.Point(620, 37);
            this.txt_PRICE.Name = "txt_PRICE";
            this.txt_PRICE.Size = new System.Drawing.Size(78, 21);
            this.txt_PRICE.TabIndex = 6;
            // 
            // txt_INPUT_CODE
            // 
            this.txt_INPUT_CODE.Location = new System.Drawing.Point(477, 37);
            this.txt_INPUT_CODE.Name = "txt_INPUT_CODE";
            this.txt_INPUT_CODE.Size = new System.Drawing.Size(98, 21);
            this.txt_INPUT_CODE.TabIndex = 5;
            // 
            // txt_CHARGE_ITEM_CODE
            // 
            this.txt_CHARGE_ITEM_CODE.Location = new System.Drawing.Point(333, 10);
            this.txt_CHARGE_ITEM_CODE.Name = "txt_CHARGE_ITEM_CODE";
            this.txt_CHARGE_ITEM_CODE.Size = new System.Drawing.Size(145, 21);
            this.txt_CHARGE_ITEM_CODE.TabIndex = 2;
            // 
            // txt_CHARGE_ITEM_NAME
            // 
            this.txt_CHARGE_ITEM_NAME.Location = new System.Drawing.Point(90, 37);
            this.txt_CHARGE_ITEM_NAME.Name = "txt_CHARGE_ITEM_NAME";
            this.txt_CHARGE_ITEM_NAME.Size = new System.Drawing.Size(331, 21);
            this.txt_CHARGE_ITEM_NAME.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(633, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "停止日期：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(711, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "单位：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(581, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "价格：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 9F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(13, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 12;
            this.label12.Text = "备注";
            // 
            // txt_MEMO
            // 
            this.txt_MEMO.Location = new System.Drawing.Point(90, 91);
            this.txt_MEMO.Name = "txt_MEMO";
            this.txt_MEMO.Size = new System.Drawing.Size(758, 21);
            this.txt_MEMO.TabIndex = 12;
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
            // btn_Modify
            // 
            this.btn_Modify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Modify.FlatAppearance.BorderSize = 0;
            this.btn_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modify.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Modify.Location = new System.Drawing.Point(256, 4);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(94, 19);
            this.btn_Modify.TabIndex = 0;
            this.btn_Modify.Text = "修改";
            this.btn_Modify.UseVisualStyleBackColor = true;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 237F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Add, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Modify, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Find, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Clean, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Del, 5, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(883, 27);
            this.tableLayoutPanel1.TabIndex = 36;
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
            // btn_Find
            // 
            this.btn_Find.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Find.FlatAppearance.BorderSize = 0;
            this.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Find.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Find.Location = new System.Drawing.Point(357, 4);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(94, 19);
            this.btn_Find.TabIndex = 0;
            this.btn_Find.Text = "查找";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // btn_Clean
            // 
            this.btn_Clean.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Clean.FlatAppearance.BorderSize = 0;
            this.btn_Clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clean.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Clean.Location = new System.Drawing.Point(458, 4);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(94, 19);
            this.btn_Clean.TabIndex = 0;
            this.btn_Clean.Text = "清空";
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // btn_Del
            // 
            this.btn_Del.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Del.FlatAppearance.BorderSize = 0;
            this.btn_Del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Del.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Del.Location = new System.Drawing.Point(559, 4);
            this.btn_Del.Name = "btn_Del";
            this.btn_Del.Size = new System.Drawing.Size(94, 19);
            this.btn_Del.TabIndex = 0;
            this.btn_Del.Text = "删除";
            this.btn_Del.UseVisualStyleBackColor = true;
            this.btn_Del.Click += new System.EventHandler(this.btn_Del_Click);
            // 
            // dgv_ChargeItemDict
            // 
            this.dgv_ChargeItemDict.AllowUserToAddRows = false;
            this.dgv_ChargeItemDict.AllowUserToDeleteRows = false;
            this.dgv_ChargeItemDict.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_ChargeItemDict.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ChargeItemDict.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_ChargeItemDict.BackgroundColor = System.Drawing.Color.White;
            this.dgv_ChargeItemDict.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ChargeItemDict.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ChargeItemDict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ChargeItemDict.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CHARGE_ITEM_CLASS,
            this.CHARGE_ITEM_CODE,
            this.CHARGE_ITEM_NAME,
            this.CHARGE_ITEM_SPEC,
            this.UNITS,
            this.INPUT_CODE,
            this.PRICE,
            this.OPERATOR,
            this.START_DATE,
            this.STOP_DATE,
            this.ENTER_DATE,
            this.MEMO});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ChargeItemDict.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ChargeItemDict.DefaultScaleWidth = 1280;
            this.dgv_ChargeItemDict.Location = new System.Drawing.Point(12, 177);
            this.dgv_ChargeItemDict.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_ChargeItemDict.MergeColumnHeaderBackColor = System.Drawing.SystemColors.Control;
            this.dgv_ChargeItemDict.MergeColumnNames = ((System.Collections.Generic.List<string>)(resources.GetObject("dgv_ChargeItemDict.MergeColumnNames")));
            this.dgv_ChargeItemDict.Name = "dgv_ChargeItemDict";
            this.dgv_ChargeItemDict.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ChargeItemDict.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_ChargeItemDict.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgv_ChargeItemDict.RowTemplate.Height = 23;
            this.dgv_ChargeItemDict.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ChargeItemDict.Size = new System.Drawing.Size(859, 374);
            this.dgv_ChargeItemDict.TabIndex = 37;
            this.dgv_ChargeItemDict.XmlFile = null;
            this.dgv_ChargeItemDict.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ChargeItemDict_CellClick);
            // 
            // CHARGE_ITEM_CLASS
            // 
            this.CHARGE_ITEM_CLASS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CHARGE_ITEM_CLASS.DataPropertyName = "CHARGE_ITEM_CLASS";
            this.CHARGE_ITEM_CLASS.FillWeight = 7F;
            this.CHARGE_ITEM_CLASS.HeaderText = "项目分类";
            this.CHARGE_ITEM_CLASS.MaxInputLength = 10;
            this.CHARGE_ITEM_CLASS.MinimumWidth = 4;
            this.CHARGE_ITEM_CLASS.Name = "CHARGE_ITEM_CLASS";
            this.CHARGE_ITEM_CLASS.ReadOnly = true;
            // 
            // CHARGE_ITEM_CODE
            // 
            this.CHARGE_ITEM_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CHARGE_ITEM_CODE.DataPropertyName = "CHARGE_ITEM_CODE";
            this.CHARGE_ITEM_CODE.FillWeight = 7F;
            this.CHARGE_ITEM_CODE.HeaderText = "项目代码";
            this.CHARGE_ITEM_CODE.MaxInputLength = 48;
            this.CHARGE_ITEM_CODE.Name = "CHARGE_ITEM_CODE";
            this.CHARGE_ITEM_CODE.ReadOnly = true;
            // 
            // CHARGE_ITEM_NAME
            // 
            this.CHARGE_ITEM_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CHARGE_ITEM_NAME.DataPropertyName = "CHARGE_ITEM_NAME";
            this.CHARGE_ITEM_NAME.FillWeight = 12F;
            this.CHARGE_ITEM_NAME.HeaderText = "项目名称";
            this.CHARGE_ITEM_NAME.Name = "CHARGE_ITEM_NAME";
            this.CHARGE_ITEM_NAME.ReadOnly = true;
            this.CHARGE_ITEM_NAME.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CHARGE_ITEM_SPEC
            // 
            this.CHARGE_ITEM_SPEC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CHARGE_ITEM_SPEC.DataPropertyName = "CHARGE_ITEM_SPEC";
            this.CHARGE_ITEM_SPEC.FillWeight = 8F;
            this.CHARGE_ITEM_SPEC.HeaderText = "项目规格";
            this.CHARGE_ITEM_SPEC.MaxInputLength = 32;
            this.CHARGE_ITEM_SPEC.Name = "CHARGE_ITEM_SPEC";
            this.CHARGE_ITEM_SPEC.ReadOnly = true;
            this.CHARGE_ITEM_SPEC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // UNITS
            // 
            this.UNITS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UNITS.DataPropertyName = "UNITS";
            this.UNITS.FillWeight = 7F;
            this.UNITS.HeaderText = "单位";
            this.UNITS.Name = "UNITS";
            this.UNITS.ReadOnly = true;
            // 
            // INPUT_CODE
            // 
            this.INPUT_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.INPUT_CODE.DataPropertyName = "INPUT_CODE";
            this.INPUT_CODE.FillWeight = 8F;
            this.INPUT_CODE.HeaderText = "简码";
            this.INPUT_CODE.MaxInputLength = 3;
            this.INPUT_CODE.Name = "INPUT_CODE";
            this.INPUT_CODE.ReadOnly = true;
            // 
            // PRICE
            // 
            this.PRICE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PRICE.DataPropertyName = "PRICE";
            this.PRICE.FillWeight = 5F;
            this.PRICE.HeaderText = "价格";
            this.PRICE.Name = "PRICE";
            this.PRICE.ReadOnly = true;
            this.PRICE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // OPERATOR
            // 
            this.OPERATOR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OPERATOR.DataPropertyName = "OPERATOR";
            this.OPERATOR.FillWeight = 7F;
            this.OPERATOR.HeaderText = "操作员";
            this.OPERATOR.Name = "OPERATOR";
            this.OPERATOR.ReadOnly = true;
            // 
            // START_DATE
            // 
            this.START_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.START_DATE.DataPropertyName = "START_DATE";
            this.START_DATE.FillWeight = 10F;
            this.START_DATE.HeaderText = "起用日期";
            this.START_DATE.MinimumWidth = 10;
            this.START_DATE.Name = "START_DATE";
            this.START_DATE.ReadOnly = true;
            // 
            // STOP_DATE
            // 
            this.STOP_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.STOP_DATE.DataPropertyName = "STOP_DATE";
            this.STOP_DATE.FillWeight = 10F;
            this.STOP_DATE.HeaderText = "停止日期";
            this.STOP_DATE.Name = "STOP_DATE";
            this.STOP_DATE.ReadOnly = true;
            this.STOP_DATE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ENTER_DATE
            // 
            this.ENTER_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ENTER_DATE.DataPropertyName = "ENTER_DATE";
            this.ENTER_DATE.FillWeight = 10F;
            this.ENTER_DATE.HeaderText = "录入日期";
            this.ENTER_DATE.Name = "ENTER_DATE";
            this.ENTER_DATE.ReadOnly = true;
            this.ENTER_DATE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // MEMO
            // 
            this.MEMO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MEMO.DataPropertyName = "MEMO";
            this.MEMO.FillWeight = 15F;
            this.MEMO.HeaderText = "备注";
            this.MEMO.Name = "MEMO";
            this.MEMO.ReadOnly = true;
            // 
            // frmChargeItemDict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(883, 560);
            this.Controls.Add(this.gb_PromptInfo);
            this.Controls.Add(this.myPnl);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.dgv_ChargeItemDict);
            this.Name = "frmChargeItemDict";
            this.Text = "价表项目表";
            this.VisibleChanged += new System.EventHandler(this.ChargeItemDict_VisibleChanged);
            this.Load += new System.EventHandler(this.ChargeItemDict_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_PromptInfo.ResumeLayout(false);
            this.gb_PromptInfo.PerformLayout();
            this.myPnl.ResumeLayout(false);
            this.myPnl.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ChargeItemDict)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private BaseControls.MyLabel label10;
        private BaseControls.MyLabel label5;
        private BaseControls.MyLabel label4;
        private BaseControls.MyLabel label3;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label1;
        private BaseControls.MyLabel lb_PromptInfo;
        private BaseControls.GroupBox.MyGroupBox gb_PromptInfo;
        private BaseControls.Panels.MyPanel myPnl;
        private BaseControls.ComboBoxs.MyComboBox cmb_CHARGE_ITEM_CLASS;
        private BaseControls.MyTextBox txt_CHARGE_ITEM_SPEC;
        private BaseControls.MyTextBox txt_INPUT_CODE;
        private BaseControls.MyTextBox txt_CHARGE_ITEM_CODE;
        private BaseControls.MyTextBox txt_CHARGE_ITEM_NAME;
        private BaseControls.MyLabel label9;
        private BaseControls.MyLabel label8;
        private BaseControls.MyLabel label6;
        public System.Windows.Forms.Button btn_Add;
        public System.Windows.Forms.Button btn_Modify;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_FunName;
        public System.Windows.Forms.Button btn_Find;
        public System.Windows.Forms.Button btn_Clean;
        public System.Windows.Forms.Button btn_Del;
        private BaseControls.MyDataGridView dgv_ChargeItemDict;
        private BaseControls.MyLabel label12;
        private BaseControls.MyLabel label11;
        private BaseControls.MyLabel label7;
        private BaseControls.MyTextBox txt_MEMO;
        private System.Windows.Forms.DateTimePicker dtp_ENTER_DATE;
        private BaseControls.MyTextBox txt_OPERATOR;
        private BaseControls.MyTextBox txt_UNITS;
        private BaseControls.MyTextBox txt_PRICE;
        private BaseControls.MyTextBox txt_STOP_DATE;
        private System.Windows.Forms.DateTimePicker dtp_START_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_ITEM_CLASS;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_ITEM_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_ITEM_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHARGE_ITEM_SPEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNITS;
        private System.Windows.Forms.DataGridViewTextBoxColumn INPUT_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OPERATOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn START_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn STOP_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ENTER_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEMO;
    }
}