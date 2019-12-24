namespace SIS
{
    partial class frmDiagInsertTo
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
            this.components = new System.ComponentModel.Container();
            this.tx_InserNo = new BaseControls.NumberText();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new BaseControls.MyLabel();
            this.SuspendLayout();
            // 
            // tx_InserNo
            // 
            this.tx_InserNo.Location = new System.Drawing.Point(15, 21);
            this.tx_InserNo.Name = "tx_InserNo";
            this.tx_InserNo.NumberCount = 3;
            this.tx_InserNo.Size = new System.Drawing.Size(100, 21);
            this.tx_InserNo.TabIndex = 0;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(127, 20);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 1;
            this.btn_Ok.Text = "确交";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(13, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 2;
            // 
            // DiagInsertTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 62);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.tx_InserNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DiagInsertTo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "请输入第几位";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseControls.NumberText tx_InserNo;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.ToolTip toolTip1;
        private BaseControls.MyLabel label1;
    }
}