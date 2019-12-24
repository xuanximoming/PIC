namespace SIS
{
    partial class frmChangePwd
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
            this.label1 = new System.Windows.Forms.Label();
            this.tx_OldPwd = new System.Windows.Forms.TextBox();
            this.tx_NewPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tx_ConfirmPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tx_LoginName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(44, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "旧密码:";
            // 
            // tx_OldPwd
            // 
            this.tx_OldPwd.Font = new System.Drawing.Font("宋体", 10F);
            this.tx_OldPwd.Location = new System.Drawing.Point(98, 39);
            this.tx_OldPwd.Name = "tx_OldPwd";
            this.tx_OldPwd.Size = new System.Drawing.Size(113, 23);
            this.tx_OldPwd.TabIndex = 2;
            this.tx_OldPwd.UseSystemPasswordChar = true;
            // 
            // tx_NewPwd
            // 
            this.tx_NewPwd.Font = new System.Drawing.Font("宋体", 10F);
            this.tx_NewPwd.Location = new System.Drawing.Point(98, 67);
            this.tx_NewPwd.Name = "tx_NewPwd";
            this.tx_NewPwd.Size = new System.Drawing.Size(113, 23);
            this.tx_NewPwd.TabIndex = 3;
            this.tx_NewPwd.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10F);
            this.label2.Location = new System.Drawing.Point(44, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "新密码:";
            // 
            // tx_ConfirmPwd
            // 
            this.tx_ConfirmPwd.Font = new System.Drawing.Font("宋体", 10F);
            this.tx_ConfirmPwd.Location = new System.Drawing.Point(98, 95);
            this.tx_ConfirmPwd.Name = "tx_ConfirmPwd";
            this.tx_ConfirmPwd.Size = new System.Drawing.Size(113, 23);
            this.tx_ConfirmPwd.TabIndex = 4;
            this.tx_ConfirmPwd.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(30, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "确认密码:";
            // 
            // tx_LoginName
            // 
            this.tx_LoginName.Font = new System.Drawing.Font("宋体", 10F);
            this.tx_LoginName.Location = new System.Drawing.Point(98, 11);
            this.tx_LoginName.Name = "tx_LoginName";
            this.tx_LoginName.Size = new System.Drawing.Size(113, 23);
            this.tx_LoginName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(44, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "工  号:";
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(41, 131);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 5;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(136, 131);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 9;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // frmChangePwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(246, 166);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.tx_LoginName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tx_ConfirmPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tx_NewPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tx_OldPwd);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmChangePwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tx_OldPwd;
        private System.Windows.Forms.TextBox tx_NewPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tx_ConfirmPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tx_LoginName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
    }
}