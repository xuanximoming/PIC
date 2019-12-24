namespace SIS.ImgProcess.filters
{
    partial class PerlinNoise
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
            this.drawArea = new BaseControls.ImageFilter.ImageFilter();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label15 = new BaseControls.MyLabel();
            this.cb_EffectType = new BaseControls.ComboBoxs.MyComboBox();
            this.label16 = new BaseControls.MyLabel();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawArea
            // 
            this.drawArea.Image = null;
            this.drawArea.Location = new System.Drawing.Point(22, 25);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(240, 116);
            this.drawArea.TabIndex = 108;
            this.drawArea.Text = "imageFilter1";
            // 
            // btn_Close
            // 
            this.btn_Close.FlatAppearance.BorderSize = 0;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Close.Location = new System.Drawing.Point(232, 2);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(49, 19);
            this.btn_Close.TabIndex = 3;
            this.btn_Close.Text = "[关闭]";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.FlatAppearance.BorderSize = 0;
            this.btn_Ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Ok.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_Ok.Location = new System.Drawing.Point(185, 2);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(54, 19);
            this.btn_Ok.TabIndex = 72;
            this.btn_Ok.Text = "[确认]";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel4.Controls.Add(this.btn_Ok);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.btn_Close);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(284, 24);
            this.panel4.TabIndex = 102;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.Location = new System.Drawing.Point(4, 7);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "去噪";
            // 
            // cb_EffectType
            // 
            this.cb_EffectType.FormattingEnabled = true;
            this.cb_EffectType.Items.AddRange(new object[] {
            "Marble",
            "Wood",
            "Clouds",
            "Labyrinth",
            "Textile",
            "Dirty",
            "Rusty"});
            this.cb_EffectType.Location = new System.Drawing.Point(103, 155);
            this.cb_EffectType.Name = "cb_EffectType";
            this.cb_EffectType.Size = new System.Drawing.Size(121, 20);
            this.cb_EffectType.TabIndex = 110;
            this.cb_EffectType.SelectedIndexChanged += new System.EventHandler(this.cb_EffectType_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label16.Location = new System.Drawing.Point(42, 155);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 18);
            this.label16.TabIndex = 109;
            this.label16.Text = "效果类型";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PerlinNoise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.cb_EffectType);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.drawArea);
            this.Controls.Add(this.panel4);
            this.Name = "PerlinNoise";
            this.Size = new System.Drawing.Size(284, 204);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PerlinNoise_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PerlinNoise_MouseDown);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BaseControls.ImageFilter.ImageFilter drawArea;
        public System.Windows.Forms.Button btn_Close;
        public System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Panel panel4;
        private BaseControls.MyLabel label15;
        private BaseControls.ComboBoxs.MyComboBox cb_EffectType;
        private BaseControls.MyLabel label16;
    }
}
