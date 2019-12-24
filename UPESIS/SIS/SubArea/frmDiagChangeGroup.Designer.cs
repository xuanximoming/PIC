namespace SIS
{
    partial class frmDiagChangeGroup
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
            this.cmb_Group = new BaseControls.ComboBoxs.MyComboBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb_Group
            // 
            this.cmb_Group.FormattingEnabled = true;
            this.cmb_Group.Location = new System.Drawing.Point(12, 17);
            this.cmb_Group.Name = "cmb_Group";
            this.cmb_Group.Size = new System.Drawing.Size(121, 20);
            this.cmb_Group.TabIndex = 0;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(139, 16);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 1;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // DiagChangeGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 52);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.cmb_Group);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DiagChangeGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请选择工作组";
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.ComboBoxs.MyComboBox cmb_Group;
        private System.Windows.Forms.Button btn_Ok;

    }
}