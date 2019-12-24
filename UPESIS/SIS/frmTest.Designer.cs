namespace SIS
{
    partial class frmTest
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
            this.gb_Description = new System.Windows.Forms.GroupBox();
            this.txt_Description = new BaseControls.TextBoxEx();
            this.gb_Impression = new System.Windows.Forms.GroupBox();
            this.txt_Impression = new BaseControls.TextBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxEx1 = new BaseControls.TextBoxEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxEx2 = new BaseControls.TextBoxEx();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.glassButton1 = new BaseControls.Buttons.GlassButton();
            this.splitButton1 = new BaseControls.SplitButton();
            this.vistaButton1 = new BaseControls.Buttons.VistaButton();
            this.gb_Description.SuspendLayout();
            this.gb_Impression.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_Description
            // 
            this.gb_Description.Controls.Add(this.txt_Description);
            this.gb_Description.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gb_Description.Location = new System.Drawing.Point(0, 286);
            this.gb_Description.Name = "gb_Description";
            this.gb_Description.Size = new System.Drawing.Size(839, 115);
            this.gb_Description.TabIndex = 10;
            this.gb_Description.TabStop = false;
            this.gb_Description.Text = "检查所见";
            // 
            // txt_Description
            // 
            this.txt_Description.AllowDrop = true;
            this.txt_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Description.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_Description.Location = new System.Drawing.Point(3, 17);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Description.Size = new System.Drawing.Size(833, 95);
            this.txt_Description.TabIndex = 0;
            // 
            // gb_Impression
            // 
            this.gb_Impression.Controls.Add(this.txt_Impression);
            this.gb_Impression.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gb_Impression.Location = new System.Drawing.Point(0, 401);
            this.gb_Impression.Name = "gb_Impression";
            this.gb_Impression.Size = new System.Drawing.Size(839, 102);
            this.gb_Impression.TabIndex = 9;
            this.gb_Impression.TabStop = false;
            this.gb_Impression.Text = "诊断意见";
            // 
            // txt_Impression
            // 
            this.txt_Impression.AllowDrop = true;
            this.txt_Impression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Impression.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_Impression.Location = new System.Drawing.Point(3, 17);
            this.txt_Impression.Multiline = true;
            this.txt_Impression.Name = "txt_Impression";
            this.txt_Impression.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Impression.Size = new System.Drawing.Size(833, 82);
            this.txt_Impression.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxEx1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 286);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // textBoxEx1
            // 
            this.textBoxEx1.AllowDrop = true;
            this.textBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEx1.Location = new System.Drawing.Point(3, 17);
            this.textBoxEx1.Multiline = true;
            this.textBoxEx1.Name = "textBoxEx1";
            this.textBoxEx1.Size = new System.Drawing.Size(254, 266);
            this.textBoxEx1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxEx2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(260, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 286);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // textBoxEx2
            // 
            this.textBoxEx2.AllowDrop = true;
            this.textBoxEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxEx2.Location = new System.Drawing.Point(3, 17);
            this.textBoxEx2.Multiline = true;
            this.textBoxEx2.Name = "textBoxEx2";
            this.textBoxEx2.Size = new System.Drawing.Size(254, 266);
            this.textBoxEx2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(523, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(120, 150);
            this.dataGridView1.TabIndex = 13;
            // 
            // glassButton1
            // 
            this.glassButton1.Font = new System.Drawing.Font("宋体", 9F);
            this.glassButton1.Location = new System.Drawing.Point(672, 88);
            this.glassButton1.Name = "glassButton1";
            this.glassButton1.Size = new System.Drawing.Size(75, 23);
            this.glassButton1.TabIndex = 14;
            this.glassButton1.Text = "glassButton1";
            // 
            // splitButton1
            // 
            this.splitButton1.AutoSize = true;
            this.splitButton1.Font = new System.Drawing.Font("宋体", 9F);
            this.splitButton1.Location = new System.Drawing.Point(660, 130);
            this.splitButton1.Name = "splitButton1";
            this.splitButton1.Size = new System.Drawing.Size(131, 23);
            this.splitButton1.TabIndex = 15;
            this.splitButton1.Text = "splitButton1";
            this.splitButton1.UseVisualStyleBackColor = true;
            // 
            // vistaButton1
            // 
            this.vistaButton1.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton1.ButtonText = null;
            this.vistaButton1.Font = new System.Drawing.Font("宋体", 9F);
            this.vistaButton1.ForeColor = System.Drawing.Color.Black;
            this.vistaButton1.Location = new System.Drawing.Point(649, 30);
            this.vistaButton1.Name = "vistaButton1";
            this.vistaButton1.Size = new System.Drawing.Size(165, 39);
            this.vistaButton1.TabIndex = 16;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 503);
            this.Controls.Add(this.vistaButton1);
            this.Controls.Add(this.splitButton1);
            this.Controls.Add(this.glassButton1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gb_Description);
            this.Controls.Add(this.gb_Impression);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.gb_Description.ResumeLayout(false);
            this.gb_Description.PerformLayout();
            this.gb_Impression.ResumeLayout(false);
            this.gb_Impression.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseControls.TextBoxEx textBoxEx1;
        private System.Windows.Forms.GroupBox gb_Description;
        private BaseControls.TextBoxEx txt_Description;
        private System.Windows.Forms.GroupBox gb_Impression;
        private BaseControls.TextBoxEx txt_Impression;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private BaseControls.TextBoxEx textBoxEx2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private BaseControls.Buttons.GlassButton glassButton1;
        private BaseControls.SplitButton splitButton1;
        private BaseControls.Buttons.VistaButton vistaButton1;
    }
}