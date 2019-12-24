namespace SIS.SysMaintenance
{
    partial class frmRoleInfo
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_FunName = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label1 = new BaseControls.MyLabel();
            this.myPanel1 = new BaseControls.Panels.MyPanel();
            this.lv_To = new System.Windows.Forms.ListView();
            this.ROLE_ID = new System.Windows.Forms.ColumnHeader();
            this.FUN_NAME = new System.Windows.Forms.ColumnHeader();
            this.lv_From = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.myPanel2 = new BaseControls.Panels.MyPanel();
            this.label3 = new BaseControls.MyLabel();
            this.label2 = new BaseControls.MyLabel();
            this.myPanel5 = new BaseControls.Panels.MyPanel();
            this.myPanel3 = new BaseControls.Panels.MyPanel();
            this.label4 = new BaseControls.MyLabel();
            this.myPanel4 = new BaseControls.Panels.MyPanel();
            this.btn_SrcSendAllToLeft = new BaseControls.Buttons.GlassButton();
            this.btn_ResSendAllToRight = new BaseControls.Buttons.GlassButton();
            this.btn_ResSendToRight = new BaseControls.Buttons.GlassButton();
            this.btn_ResSendToLeft = new BaseControls.Buttons.GlassButton();
            this.CbSystemName = new BaseControls.ComboBoxs.MyComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.myPanel1.SuspendLayout();
            this.myPanel2.SuspendLayout();
            this.myPanel3.SuspendLayout();
            this.myPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImage = global::SIS.Properties.Resources.bg_btn;
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Save, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_FunName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Close, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(532, 27);
            this.tableLayoutPanel1.TabIndex = 27;
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_Save.Location = new System.Drawing.Point(135, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(58, 19);
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
            this.btn_FunName.Text = "选择用户权限";
            this.btn_FunName.UseVisualStyleBackColor = true;
            // 
            // btn_Close
            // 
            this.btn_Close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_Close.Location = new System.Drawing.Point(200, 4);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(49, 19);
            this.btn_Close.TabIndex = 28;
            this.btn_Close.Text = "关闭";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 12);
            this.label1.TabIndex = 29;
            this.label1.Text = "请选择系统名称：";
            // 
            // myPanel1
            // 
            this.myPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.myPanel1.BorderColor = System.Drawing.Color.White;
            this.myPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myPanel1.Controls.Add(this.lv_To);
            this.myPanel1.Controls.Add(this.lv_From);
            this.myPanel1.Controls.Add(this.myPanel2);
            this.myPanel1.Controls.Add(this.myPanel3);
            this.myPanel1.Controls.Add(this.myPanel4);
            this.myPanel1.Location = new System.Drawing.Point(12, 68);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.myPanel1.Size = new System.Drawing.Size(508, 428);
            this.myPanel1.TabIndex = 30;
            // 
            // lv_To
            // 
            this.lv_To.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_To.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ROLE_ID,
            this.FUN_NAME});
            this.lv_To.FullRowSelect = true;
            this.lv_To.Location = new System.Drawing.Point(289, 37);
            this.lv_To.Name = "lv_To";
            this.lv_To.Size = new System.Drawing.Size(210, 350);
            this.lv_To.TabIndex = 8;
            this.lv_To.UseCompatibleStateImageBehavior = false;
            this.lv_To.View = System.Windows.Forms.View.Details;
            // 
            // ROLE_ID
            // 
            this.ROLE_ID.Text = "编号";
            this.ROLE_ID.Width = 50;
            // 
            // FUN_NAME
            // 
            this.FUN_NAME.Text = "名称";
            this.FUN_NAME.Width = 160;
            // 
            // lv_From
            // 
            this.lv_From.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lv_From.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4});
            this.lv_From.FullRowSelect = true;
            this.lv_From.Location = new System.Drawing.Point(7, 36);
            this.lv_From.Name = "lv_From";
            this.lv_From.Size = new System.Drawing.Size(210, 350);
            this.lv_From.TabIndex = 7;
            this.lv_From.UseCompatibleStateImageBehavior = false;
            this.lv_From.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "编号";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "名称";
            this.columnHeader4.Width = 160;
            // 
            // myPanel2
            // 
            this.myPanel2.BorderColor = System.Drawing.Color.White;
            this.myPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myPanel2.Controls.Add(this.label3);
            this.myPanel2.Controls.Add(this.label2);
            this.myPanel2.Controls.Add(this.myPanel5);
            this.myPanel2.Location = new System.Drawing.Point(-1, -1);
            this.myPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.myPanel2.Name = "myPanel2";
            this.myPanel2.Size = new System.Drawing.Size(508, 33);
            this.myPanel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(348, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "已选功能";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(70, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "待选功能";
            // 
            // myPanel5
            // 
            this.myPanel5.BorderColor = System.Drawing.Color.White;
            this.myPanel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myPanel5.Location = new System.Drawing.Point(223, -1);
            this.myPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.myPanel5.Name = "myPanel5";
            this.myPanel5.Padding = new System.Windows.Forms.Padding(3);
            this.myPanel5.Size = new System.Drawing.Size(60, 33);
            this.myPanel5.TabIndex = 3;
            // 
            // myPanel3
            // 
            this.myPanel3.BorderColor = System.Drawing.Color.White;
            this.myPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myPanel3.Controls.Add(this.label4);
            this.myPanel3.Location = new System.Drawing.Point(-1, 394);
            this.myPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.myPanel3.Name = "myPanel3";
            this.myPanel3.Padding = new System.Windows.Forms.Padding(3);
            this.myPanel3.Size = new System.Drawing.Size(508, 33);
            this.myPanel3.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(100, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "点击条目时，可以组合CTRL或SHIFT键进行多选";
            // 
            // myPanel4
            // 
            this.myPanel4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.myPanel4.BorderColor = System.Drawing.Color.White;
            this.myPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myPanel4.Controls.Add(this.btn_SrcSendAllToLeft);
            this.myPanel4.Controls.Add(this.btn_ResSendAllToRight);
            this.myPanel4.Controls.Add(this.btn_ResSendToRight);
            this.myPanel4.Controls.Add(this.btn_ResSendToLeft);
            this.myPanel4.Location = new System.Drawing.Point(223, -1);
            this.myPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.myPanel4.Name = "myPanel4";
            this.myPanel4.Padding = new System.Windows.Forms.Padding(3);
            this.myPanel4.Size = new System.Drawing.Size(60, 428);
            this.myPanel4.TabIndex = 2;
            // 
            // btn_SrcSendAllToLeft
            // 
            this.btn_SrcSendAllToLeft.BackColor = System.Drawing.Color.Silver;
            this.btn_SrcSendAllToLeft.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_SrcSendAllToLeft.InnerBorderColor = System.Drawing.Color.DarkGray;
            this.btn_SrcSendAllToLeft.Location = new System.Drawing.Point(4, 220);
            this.btn_SrcSendAllToLeft.Name = "btn_SrcSendAllToLeft";
            this.btn_SrcSendAllToLeft.Size = new System.Drawing.Size(50, 23);
            this.btn_SrcSendAllToLeft.TabIndex = 3;
            this.btn_SrcSendAllToLeft.Text = "<-全部";
            this.btn_SrcSendAllToLeft.Click += new System.EventHandler(this.btn_SrcSendAllToLeft_Click);
            // 
            // btn_ResSendAllToRight
            // 
            this.btn_ResSendAllToRight.BackColor = System.Drawing.Color.Silver;
            this.btn_ResSendAllToRight.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_ResSendAllToRight.InnerBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ResSendAllToRight.Location = new System.Drawing.Point(4, 259);
            this.btn_ResSendAllToRight.Name = "btn_ResSendAllToRight";
            this.btn_ResSendAllToRight.Size = new System.Drawing.Size(50, 23);
            this.btn_ResSendAllToRight.TabIndex = 2;
            this.btn_ResSendAllToRight.Text = "全部->";
            this.btn_ResSendAllToRight.Click += new System.EventHandler(this.btn_ResSendAllToRight_Click);
            // 
            // btn_ResSendToRight
            // 
            this.btn_ResSendToRight.BackColor = System.Drawing.Color.Silver;
            this.btn_ResSendToRight.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_ResSendToRight.InnerBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ResSendToRight.Location = new System.Drawing.Point(4, 152);
            this.btn_ResSendToRight.Name = "btn_ResSendToRight";
            this.btn_ResSendToRight.Size = new System.Drawing.Size(50, 23);
            this.btn_ResSendToRight.TabIndex = 1;
            this.btn_ResSendToRight.Text = ">>>";
            this.btn_ResSendToRight.Click += new System.EventHandler(this.btn_ResSendToRight_Click);
            // 
            // btn_ResSendToLeft
            // 
            this.btn_ResSendToLeft.BackColor = System.Drawing.Color.Silver;
            this.btn_ResSendToLeft.Font = new System.Drawing.Font("宋体", 9F);
            this.btn_ResSendToLeft.InnerBorderColor = System.Drawing.Color.DarkGray;
            this.btn_ResSendToLeft.Location = new System.Drawing.Point(4, 114);
            this.btn_ResSendToLeft.Name = "btn_ResSendToLeft";
            this.btn_ResSendToLeft.Size = new System.Drawing.Size(50, 23);
            this.btn_ResSendToLeft.TabIndex = 0;
            this.btn_ResSendToLeft.Text = "<<<";
            this.btn_ResSendToLeft.Click += new System.EventHandler(this.btn_ResSendToLeft_Click);
            // 
            // CbSystemName
            // 
            this.CbSystemName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CbSystemName.FormattingEnabled = true;
            this.CbSystemName.Location = new System.Drawing.Point(119, 42);
            this.CbSystemName.Name = "CbSystemName";
            this.CbSystemName.Size = new System.Drawing.Size(121, 20);
            this.CbSystemName.TabIndex = 28;
            this.CbSystemName.SelectedValueChanged += new System.EventHandler(this.CbSystemName_SelectedValueChanged);
            // 
            // frmRoleInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(532, 508);
            this.Controls.Add(this.myPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CbSystemName);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmRoleInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "权限设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RoleInfo_FormClosing);
            this.Load += new System.EventHandler(this.RoleInfo_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.myPanel1.ResumeLayout(false);
            this.myPanel2.ResumeLayout(false);
            this.myPanel2.PerformLayout();
            this.myPanel3.ResumeLayout(false);
            this.myPanel3.PerformLayout();
            this.myPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Button btn_Save;
        public System.Windows.Forms.Button btn_FunName;
        public System.Windows.Forms.Button btn_Close;
        private BaseControls.MyLabel label1;
        private BaseControls.ComboBoxs.MyComboBox CbSystemName;
        private BaseControls.Panels.MyPanel myPanel1;
        private BaseControls.Panels.MyPanel myPanel2;
        private BaseControls.Panels.MyPanel myPanel3;
        private BaseControls.Panels.MyPanel myPanel4;
        private BaseControls.Panels.MyPanel myPanel5;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label3;
        private BaseControls.MyLabel label4;
        private BaseControls.Buttons.GlassButton btn_ResSendToLeft;
        private BaseControls.Buttons.GlassButton btn_SrcSendAllToLeft;
        private BaseControls.Buttons.GlassButton btn_ResSendAllToRight;
        private BaseControls.Buttons.GlassButton btn_ResSendToRight;
        private System.Windows.Forms.ListView lv_To;
        private System.Windows.Forms.ListView lv_From;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        public System.Windows.Forms.ColumnHeader ROLE_ID;
        public System.Windows.Forms.ColumnHeader FUN_NAME;
    }
}