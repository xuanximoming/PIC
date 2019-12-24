namespace SIS
{
    partial class frmRecommendation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecommendation));
            this.gb_Recommendation = new System.Windows.Forms.GroupBox();
            this.txt_Recommendation = new BaseControls.userTextBox();
            this.gb_Recommendation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_Recommendation
            // 
            this.gb_Recommendation.Controls.Add(this.txt_Recommendation);
            this.gb_Recommendation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_Recommendation.Location = new System.Drawing.Point(0, 0);
            this.gb_Recommendation.Name = "gb_Recommendation";
            this.gb_Recommendation.Size = new System.Drawing.Size(292, 266);
            this.gb_Recommendation.TabIndex = 4;
            this.gb_Recommendation.TabStop = false;
            this.gb_Recommendation.Text = "附注";
            // 
            // txt_Recommendation
            // 
            this.txt_Recommendation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Recommendation.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Recommendation.ForeColor = System.Drawing.Color.Black;
            this.txt_Recommendation.IsChangeColor = false;
            this.txt_Recommendation.Location = new System.Drawing.Point(3, 17);
            this.txt_Recommendation.Multiline = true;
            this.txt_Recommendation.Name = "txt_Recommendation";
            this.txt_Recommendation.Size = new System.Drawing.Size(286, 246);
            this.txt_Recommendation.TabIndex = 1;
            // 
            // frmRecommendation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.gb_Recommendation);
            this.DockAreas = ((BaseControls.Docking.DockAreas)(((((BaseControls.Docking.DockAreas.DockLeft | BaseControls.Docking.DockAreas.DockRight)
                        | BaseControls.Docking.DockAreas.DockTop)
                        | BaseControls.Docking.DockAreas.DockBottom)
                        | BaseControls.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecommendation";
            this.Text = "附注编辑";
            this.DockStateChanged += new System.EventHandler(this.frmRecommendation_DockStateChanged);
            this.gb_Recommendation.ResumeLayout(false);
            this.gb_Recommendation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_Recommendation;
        private BaseControls.userTextBox txt_Recommendation;
    }
}