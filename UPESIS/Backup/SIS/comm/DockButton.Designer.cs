namespace SIS.comm
{
    partial class DockButton
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.vistaButton = new BaseControls.Buttons.VistaButton();
            this.SuspendLayout();
            // 
            // vistaButton
            // 
            this.vistaButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vistaButton.BackColor = System.Drawing.Color.Transparent;
            this.vistaButton.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(227)))), ((int)(((byte)(242)))));
            this.vistaButton.ButtonColor = System.Drawing.Color.LightSkyBlue;
            this.vistaButton.ButtonText = null;
            this.vistaButton.GlowColor = System.Drawing.Color.Orange;
            this.vistaButton.Location = new System.Drawing.Point(11, 8);
            this.vistaButton.Name = "vistaButton";
            this.vistaButton.Size = new System.Drawing.Size(130, 41);
            this.vistaButton.TabIndex = 0;
            // 
            // DockButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.vistaButton);
            this.Name = "DockButton";
            this.Size = new System.Drawing.Size(154, 58);
            this.ResumeLayout(false);

        }

        #endregion

        public BaseControls.Buttons.VistaButton vistaButton;

    }
}
