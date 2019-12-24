namespace SIS
{
    partial class frmSimpleLocMap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSimpleLocMap));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new BaseControls.MyLabel();
            this.cmb_TagImage = new System.Windows.Forms.ComboBox();
            this.label2 = new BaseControls.MyLabel();
            this.label1 = new BaseControls.MyLabel();
            this.cmb_Explain = new System.Windows.Forms.ComboBox();
            this.cmb_Part = new System.Windows.Forms.ComboBox();
            this.drawArea = new BaseControls.ImageBox.ImageCtl();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cmb_TagImage);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmb_Explain);
            this.panel2.Controls.Add(this.cmb_Part);
            this.panel2.Controls.Add(this.drawArea);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(178, 371);
            this.panel2.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "定位图";
            // 
            // cmb_TagImage
            // 
            this.cmb_TagImage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TagImage.FormattingEnabled = true;
            this.cmb_TagImage.Items.AddRange(new object[] {
            "胃",
            "肠",
            "支气管",
            "鼻咽喉",
            "输尿管"});
            this.cmb_TagImage.Location = new System.Drawing.Point(51, 84);
            this.cmb_TagImage.Name = "cmb_TagImage";
            this.cmb_TagImage.Size = new System.Drawing.Size(114, 20);
            this.cmb_TagImage.TabIndex = 20;
            this.cmb_TagImage.SelectedIndexChanged += new System.EventHandler(this.cmb_TagImage_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "说明";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 17;
            this.label1.Text = "部位";
            // 
            // cmb_Explain
            // 
            this.cmb_Explain.FormattingEnabled = true;
            this.cmb_Explain.Location = new System.Drawing.Point(51, 52);
            this.cmb_Explain.MaxDropDownItems = 40;
            this.cmb_Explain.Name = "cmb_Explain";
            this.cmb_Explain.Size = new System.Drawing.Size(114, 20);
            this.cmb_Explain.TabIndex = 16;
            // 
            // cmb_Part
            // 
            this.cmb_Part.FormattingEnabled = true;
            this.cmb_Part.Location = new System.Drawing.Point(51, 19);
            this.cmb_Part.MaxDropDownItems = 40;
            this.cmb_Part.Name = "cmb_Part";
            this.cmb_Part.Size = new System.Drawing.Size(114, 20);
            this.cmb_Part.TabIndex = 15;
            this.cmb_Part.SelectedIndexChanged += new System.EventHandler(this.cmb_Part_SelectedIndexChanged);
            // 
            // drawArea
            // 
            this.drawArea.ActiveTool = BaseControls.ImageBox.ImageCtl.DrawToolType.Line;
            this.drawArea.BackColor = System.Drawing.Color.Black;
            this.drawArea.GraphicsList = null;
            this.drawArea.Image = ((System.Drawing.Image)(resources.GetObject("drawArea.Image")));
            this.drawArea.Location = new System.Drawing.Point(6, 117);
            this.drawArea.Name = "drawArea";
            this.drawArea.Owner = null;
            this.drawArea.Size = new System.Drawing.Size(160, 240);
            this.drawArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.drawArea.TabIndex = 14;
            this.drawArea.TabStop = false;
            // 
            // frmSimpleLocMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 371);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.panel2);
            this.DockAreas = ((BaseControls.Docking.DockAreas)(((((BaseControls.Docking.DockAreas.DockLeft | BaseControls.Docking.DockAreas.DockRight)
                        | BaseControls.Docking.DockAreas.DockTop)
                        | BaseControls.Docking.DockAreas.DockBottom)
                        | BaseControls.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmSimpleLocMap";
            this.Text = "定位图编辑";
            this.DockStateChanged += new System.EventHandler(this.frmSimpleLocMap_DockStateChanged);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private BaseControls.MyLabel label3;
        private System.Windows.Forms.ComboBox cmb_TagImage;
        private BaseControls.MyLabel label2;
        private BaseControls.MyLabel label1;
        private System.Windows.Forms.ComboBox cmb_Explain;
        private System.Windows.Forms.ComboBox cmb_Part;
        public BaseControls.ImageBox.ImageCtl drawArea;
    }
}