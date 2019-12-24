namespace SIS
{
    partial class frmStat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStat));
            this.btn_Stat = new BaseControls.Buttons.CrystalButton();
            this.label1 = new System.Windows.Forms.Label();
            this.list_Stat = new System.Windows.Forms.ListBox();
            this.myGroupBox1 = new BaseControls.GroupBox.MyGroupBox();
            this.date_StatB = new System.Windows.Forms.DateTimePicker();
            this.date_StatA = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.p_PatientSource = new System.Windows.Forms.Panel();
            this.cmb_PatientSource = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.p_DiagDoctor = new System.Windows.Forms.Panel();
            this.cmb_ExamDoc = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.p_Diag = new System.Windows.Forms.Panel();
            this.cmb_Diag = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.p_ExamClass = new System.Windows.Forms.Panel();
            this.cmb_ExamSubClass = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_ExamClass = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.p_DeptName = new System.Windows.Forms.Panel();
            this.cmb_DeptName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.myGroupBox2 = new BaseControls.GroupBox.MyGroupBox();
            this.p_ExamDoctor = new System.Windows.Forms.Panel();
            this.cmb_ExamDoctor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.myGroupBox1.SuspendLayout();
            this.p_PatientSource.SuspendLayout();
            this.p_DiagDoctor.SuspendLayout();
            this.p_Diag.SuspendLayout();
            this.p_ExamClass.SuspendLayout();
            this.p_DeptName.SuspendLayout();
            this.panel3.SuspendLayout();
            this.myGroupBox2.SuspendLayout();
            this.p_ExamDoctor.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Stat
            // 
            this.btn_Stat.BackColor = System.Drawing.Color.DarkTurquoise;
            this.btn_Stat.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Stat.Location = new System.Drawing.Point(60, 588);
            this.btn_Stat.Name = "btn_Stat";
            this.btn_Stat.Size = new System.Drawing.Size(87, 38);
            this.btn_Stat.TabIndex = 1;
            this.btn_Stat.Text = "统   计";
            this.btn_Stat.UseVisualStyleBackColor = true;
            this.btn_Stat.Click += new System.EventHandler(this.btn_Stat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "报表统计：";
            // 
            // list_Stat
            // 
            this.list_Stat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.list_Stat.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.list_Stat.FormattingEnabled = true;
            this.list_Stat.ItemHeight = 22;
            this.list_Stat.Items.AddRange(new object[] {
            "诊断医师工作量统计",
            "技师工作量统计",
            "检查类别工作量统计",
            "科室工作量统计",
            "检查病人明细报表",
            "阴阳性病人数统计",
            "各科室申请单统计"});
            this.list_Stat.Location = new System.Drawing.Point(3, 33);
            this.list_Stat.Name = "list_Stat";
            this.list_Stat.Size = new System.Drawing.Size(195, 180);
            this.list_Stat.TabIndex = 3;
            this.list_Stat.SelectedIndexChanged += new System.EventHandler(this.list_Stat_SelectedIndexChanged);
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.myGroupBox1.BackgroundGradientColor = System.Drawing.Color.White;
            this.myGroupBox1.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.myGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.myGroupBox1.BorderThickness = 1F;
            this.myGroupBox1.Controls.Add(this.date_StatB);
            this.myGroupBox1.Controls.Add(this.date_StatA);
            this.myGroupBox1.Controls.Add(this.label4);
            this.myGroupBox1.Controls.Add(this.label3);
            this.myGroupBox1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.myGroupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myGroupBox1.GroupImage = null;
            this.myGroupBox1.GroupTitle = "请选择日期";
            this.myGroupBox1.Location = new System.Drawing.Point(0, 231);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Padding = new System.Windows.Forms.Padding(20);
            this.myGroupBox1.PaintGroupBox = false;
            this.myGroupBox1.RoundCorners = 10;
            this.myGroupBox1.ShadowColor = System.Drawing.Color.DarkGray;
            this.myGroupBox1.ShadowControl = false;
            this.myGroupBox1.ShadowThickness = 3;
            this.myGroupBox1.Size = new System.Drawing.Size(195, 124);
            this.myGroupBox1.TabIndex = 4;
            // 
            // date_StatB
            // 
            this.date_StatB.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.date_StatB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_StatB.Location = new System.Drawing.Point(74, 84);
            this.date_StatB.Name = "date_StatB";
            this.date_StatB.Size = new System.Drawing.Size(118, 26);
            this.date_StatB.TabIndex = 4;
            // 
            // date_StatA
            // 
            this.date_StatA.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.date_StatA.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_StatA.Location = new System.Drawing.Point(74, 34);
            this.date_StatA.Name = "date_StatA";
            this.date_StatA.Size = new System.Drawing.Size(118, 26);
            this.date_StatA.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label4.Location = new System.Drawing.Point(3, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "结束日期：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Location = new System.Drawing.Point(3, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "起始日期：";
            // 
            // p_PatientSource
            // 
            this.p_PatientSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.p_PatientSource.Controls.Add(this.cmb_PatientSource);
            this.p_PatientSource.Controls.Add(this.label10);
            this.p_PatientSource.Location = new System.Drawing.Point(4, 140);
            this.p_PatientSource.Name = "p_PatientSource";
            this.p_PatientSource.Size = new System.Drawing.Size(188, 37);
            this.p_PatientSource.TabIndex = 4;
            // 
            // cmb_PatientSource
            // 
            this.cmb_PatientSource.FormattingEnabled = true;
            this.cmb_PatientSource.Location = new System.Drawing.Point(78, 3);
            this.cmb_PatientSource.Name = "cmb_PatientSource";
            this.cmb_PatientSource.Size = new System.Drawing.Size(107, 27);
            this.cmb_PatientSource.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "病人来源：";
            // 
            // p_DiagDoctor
            // 
            this.p_DiagDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.p_DiagDoctor.Controls.Add(this.cmb_ExamDoc);
            this.p_DiagDoctor.Controls.Add(this.label8);
            this.p_DiagDoctor.Location = new System.Drawing.Point(1, 67);
            this.p_DiagDoctor.Name = "p_DiagDoctor";
            this.p_DiagDoctor.Size = new System.Drawing.Size(188, 37);
            this.p_DiagDoctor.TabIndex = 2;
            // 
            // cmb_ExamDoc
            // 
            this.cmb_ExamDoc.FormattingEnabled = true;
            this.cmb_ExamDoc.Location = new System.Drawing.Point(78, 7);
            this.cmb_ExamDoc.Name = "cmb_ExamDoc";
            this.cmb_ExamDoc.Size = new System.Drawing.Size(107, 27);
            this.cmb_ExamDoc.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "诊断医生:";
            // 
            // p_Diag
            // 
            this.p_Diag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.p_Diag.Controls.Add(this.cmb_Diag);
            this.p_Diag.Controls.Add(this.label9);
            this.p_Diag.Location = new System.Drawing.Point(4, 64);
            this.p_Diag.Name = "p_Diag";
            this.p_Diag.Size = new System.Drawing.Size(188, 36);
            this.p_Diag.TabIndex = 3;
            // 
            // cmb_Diag
            // 
            this.cmb_Diag.FormattingEnabled = true;
            this.cmb_Diag.Location = new System.Drawing.Point(78, 6);
            this.cmb_Diag.Name = "cmb_Diag";
            this.cmb_Diag.Size = new System.Drawing.Size(110, 27);
            this.cmb_Diag.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "诊   室：";
            // 
            // p_ExamClass
            // 
            this.p_ExamClass.Controls.Add(this.cmb_ExamSubClass);
            this.p_ExamClass.Controls.Add(this.label6);
            this.p_ExamClass.Controls.Add(this.cmb_ExamClass);
            this.p_ExamClass.Controls.Add(this.label7);
            this.p_ExamClass.Location = new System.Drawing.Point(3, 65);
            this.p_ExamClass.Name = "p_ExamClass";
            this.p_ExamClass.Size = new System.Drawing.Size(188, 75);
            this.p_ExamClass.TabIndex = 1;
            this.p_ExamClass.Visible = false;
            // 
            // cmb_ExamSubClass
            // 
            this.cmb_ExamSubClass.FormattingEnabled = true;
            this.cmb_ExamSubClass.Location = new System.Drawing.Point(78, 35);
            this.cmb_ExamSubClass.Name = "cmb_ExamSubClass";
            this.cmb_ExamSubClass.Size = new System.Drawing.Size(107, 27);
            this.cmb_ExamSubClass.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "检查类别:";
            // 
            // cmb_ExamClass
            // 
            this.cmb_ExamClass.FormattingEnabled = true;
            this.cmb_ExamClass.Location = new System.Drawing.Point(78, 5);
            this.cmb_ExamClass.Name = "cmb_ExamClass";
            this.cmb_ExamClass.Size = new System.Drawing.Size(107, 27);
            this.cmb_ExamClass.TabIndex = 2;
            this.cmb_ExamClass.SelectedIndexChanged += new System.EventHandler(this.cmb_ExamClass_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "检查子类:";
            // 
            // p_DeptName
            // 
            this.p_DeptName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.p_DeptName.Controls.Add(this.cmb_DeptName);
            this.p_DeptName.Controls.Add(this.label5);
            this.p_DeptName.Location = new System.Drawing.Point(4, 29);
            this.p_DeptName.Name = "p_DeptName";
            this.p_DeptName.Size = new System.Drawing.Size(188, 35);
            this.p_DeptName.TabIndex = 0;
            // 
            // cmb_DeptName
            // 
            this.cmb_DeptName.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_DeptName.FormattingEnabled = true;
            this.cmb_DeptName.Location = new System.Drawing.Point(78, 3);
            this.cmb_DeptName.Name = "cmb_DeptName";
            this.cmb_DeptName.Size = new System.Drawing.Size(107, 27);
            this.cmb_DeptName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "科    室:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_Stat);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.myGroupBox2);
            this.panel3.Controls.Add(this.list_Stat);
            this.panel3.Controls.Add(this.myGroupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(827, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(201, 746);
            this.panel3.TabIndex = 1;
            // 
            // myGroupBox2
            // 
            this.myGroupBox2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.myGroupBox2.BackgroundGradientColor = System.Drawing.Color.White;
            this.myGroupBox2.BackgroundGradientMode = BaseControls.GroupBox.MyGroupBox.GroupBoxGradientMode.None;
            this.myGroupBox2.BorderColor = System.Drawing.Color.Black;
            this.myGroupBox2.BorderThickness = 1F;
            this.myGroupBox2.Controls.Add(this.p_ExamDoctor);
            this.myGroupBox2.Controls.Add(this.p_PatientSource);
            this.myGroupBox2.Controls.Add(this.p_DiagDoctor);
            this.myGroupBox2.Controls.Add(this.p_ExamClass);
            this.myGroupBox2.Controls.Add(this.p_Diag);
            this.myGroupBox2.Controls.Add(this.p_DeptName);
            this.myGroupBox2.CustomGroupBoxColor = System.Drawing.Color.White;
            this.myGroupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.myGroupBox2.GroupImage = null;
            this.myGroupBox2.GroupTitle = "请选择条件";
            this.myGroupBox2.Location = new System.Drawing.Point(3, 361);
            this.myGroupBox2.Name = "myGroupBox2";
            this.myGroupBox2.Padding = new System.Windows.Forms.Padding(20);
            this.myGroupBox2.PaintGroupBox = false;
            this.myGroupBox2.RoundCorners = 10;
            this.myGroupBox2.ShadowColor = System.Drawing.Color.DarkGray;
            this.myGroupBox2.ShadowControl = false;
            this.myGroupBox2.ShadowThickness = 3;
            this.myGroupBox2.Size = new System.Drawing.Size(195, 221);
            this.myGroupBox2.TabIndex = 5;
            // 
            // p_ExamDoctor
            // 
            this.p_ExamDoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.p_ExamDoctor.Controls.Add(this.cmb_ExamDoctor);
            this.p_ExamDoctor.Controls.Add(this.label2);
            this.p_ExamDoctor.Location = new System.Drawing.Point(4, 176);
            this.p_ExamDoctor.Name = "p_ExamDoctor";
            this.p_ExamDoctor.Size = new System.Drawing.Size(188, 37);
            this.p_ExamDoctor.TabIndex = 3;
            // 
            // cmb_ExamDoctor
            // 
            this.cmb_ExamDoctor.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_ExamDoctor.FormattingEnabled = true;
            this.cmb_ExamDoctor.Location = new System.Drawing.Point(78, 7);
            this.cmb_ExamDoctor.Name = "cmb_ExamDoctor";
            this.cmb_ExamDoctor.Size = new System.Drawing.Size(107, 27);
            this.cmb_ExamDoctor.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "检查技师:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ReportViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 746);
            this.panel1.TabIndex = 2;
            // 
            // ReportViewer
            // 
            this.ReportViewer.ActiveViewIndex = -1;
            this.ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReportViewer.DisplayGroupTree = false;
            this.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ReportViewer.Name = "ReportViewer";
            this.ReportViewer.SelectionFormula = "";
            this.ReportViewer.Size = new System.Drawing.Size(827, 746);
            this.ReportViewer.TabIndex = 0;
            this.ReportViewer.ViewTimeSelectionFormula = "";
            // 
            // frmStat
            // 
            this.AcceptButton = this.btn_Stat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStat";
            this.Text = "报表统计";
            this.myGroupBox1.ResumeLayout(false);
            this.myGroupBox1.PerformLayout();
            this.p_PatientSource.ResumeLayout(false);
            this.p_PatientSource.PerformLayout();
            this.p_DiagDoctor.ResumeLayout(false);
            this.p_DiagDoctor.PerformLayout();
            this.p_Diag.ResumeLayout(false);
            this.p_Diag.PerformLayout();
            this.p_ExamClass.ResumeLayout(false);
            this.p_ExamClass.PerformLayout();
            this.p_DeptName.ResumeLayout(false);
            this.p_DeptName.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.myGroupBox2.ResumeLayout(false);
            this.p_ExamDoctor.ResumeLayout(false);
            this.p_ExamDoctor.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.Buttons.CrystalButton btn_Stat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox list_Stat;
        private BaseControls.GroupBox.MyGroupBox myGroupBox1;
        private System.Windows.Forms.DateTimePicker date_StatB;
        private System.Windows.Forms.DateTimePicker date_StatA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel p_DeptName;
        private System.Windows.Forms.ComboBox cmb_DeptName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel p_ExamClass;
        private System.Windows.Forms.ComboBox cmb_ExamSubClass;
        private System.Windows.Forms.ComboBox cmb_ExamClass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel p_DiagDoctor;
        private System.Windows.Forms.ComboBox cmb_ExamDoc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel p_Diag;
        private System.Windows.Forms.ComboBox cmb_Diag;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel p_PatientSource;
        private System.Windows.Forms.ComboBox cmb_PatientSource;
        private System.Windows.Forms.Label label10;
        private BaseControls.GroupBox.MyGroupBox myGroupBox2;
        private System.Windows.Forms.Panel panel1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer ReportViewer;
        private System.Windows.Forms.Panel p_ExamDoctor;
        private System.Windows.Forms.ComboBox cmb_ExamDoctor;
        private System.Windows.Forms.Label label2;
    }
}