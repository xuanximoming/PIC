namespace SIS.Settings
{
    partial class frmSetFont
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("按钮", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("列表", 4);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("文本框", 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("标签", 3);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("模板树形控件", 5);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("模板显示控件", 1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("文字标注", 6);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetFont));
            this.lv_Settings = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pg_Font = new System.Windows.Forms.PropertyGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_Display = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_ForeColor = new BaseControls.ColorPicker.ColorPickerCombobox();
            this.lb_Explain = new BaseControls.MyLabel();
            this.btn_Cancel = new BaseControls.Buttons.VistaButton();
            this.btn_Ok = new BaseControls.Buttons.VistaButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_Settings
            // 
            this.lv_Settings.HideSelection = false;
            this.lv_Settings.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.lv_Settings.LargeImageList = this.imageList;
            this.lv_Settings.Location = new System.Drawing.Point(22, 12);
            this.lv_Settings.MultiSelect = false;
            this.lv_Settings.Name = "lv_Settings";
            this.lv_Settings.Size = new System.Drawing.Size(166, 380);
            this.lv_Settings.TabIndex = 0;
            this.lv_Settings.UseCompatibleStateImageBehavior = false;
            this.lv_Settings.SelectedIndexChanged += new System.EventHandler(this.lv_Settings_SelectedIndexChanged);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "button-blue.png");
            this.imageList.Images.SetKeyName(1, "cal.png");
            this.imageList.Images.SetKeyName(2, "Key.png");
            this.imageList.Images.SetKeyName(3, "label-green.png");
            this.imageList.Images.SetKeyName(4, "list.png");
            this.imageList.Images.SetKeyName(5, "Organizational Unit.png");
            this.imageList.Images.SetKeyName(6, "new window.png");
            // 
            // pg_Font
            // 
            this.pg_Font.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pg_Font.HelpVisible = false;
            this.pg_Font.Location = new System.Drawing.Point(194, 12);
            this.pg_Font.Name = "pg_Font";
            this.pg_Font.Size = new System.Drawing.Size(218, 187);
            this.pg_Font.TabIndex = 16;
            this.pg_Font.ToolbarVisible = false;
            this.pg_Font.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.pg_Font_SelectedGridItemChanged);
            this.pg_Font.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pg_Font_PropertyValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_Display);
            this.groupBox1.Location = new System.Drawing.Point(197, 317);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 75);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "效果";
            // 
            // lb_Display
            // 
            this.lb_Display.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lb_Display.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Display.Location = new System.Drawing.Point(14, 21);
            this.lb_Display.Name = "lb_Display";
            this.lb_Display.Size = new System.Drawing.Size(186, 43);
            this.lb_Display.TabIndex = 20;
            this.lb_Display.Text = "AaBbYyZz";
            this.lb_Display.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmb_ForeColor);
            this.groupBox2.Location = new System.Drawing.Point(197, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 53);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "字体颜色";
            // 
            // cmb_ForeColor
            // 
            this.cmb_ForeColor.Location = new System.Drawing.Point(31, 20);
            this.cmb_ForeColor.Name = "cmb_ForeColor";
            this.cmb_ForeColor.SelectedItem = System.Drawing.Color.Wheat;
            this.cmb_ForeColor.Size = new System.Drawing.Size(160, 23);
            this.cmb_ForeColor.TabIndex = 0;
            this.cmb_ForeColor.Text = "colorPickerCombobox1";
            this.cmb_ForeColor.SelectItemChanged += new BaseControls.ColorPicker.ColorPickerCombobox.SelectedItemChanged(this.cmb_ForeColor_SelectItemChanged);
            // 
            // lb_Explain
            // 
            this.lb_Explain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lb_Explain.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Explain.ForeColor = System.Drawing.Color.Black;
            this.lb_Explain.Location = new System.Drawing.Point(194, 202);
            this.lb_Explain.Name = "lb_Explain";
            this.lb_Explain.Size = new System.Drawing.Size(218, 44);
            this.lb_Explain.TabIndex = 19;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Cancel.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Cancel.ButtonText = "取消";
            this.btn_Cancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Cancel.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.Image")));
            this.btn_Cancel.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Cancel.Location = new System.Drawing.Point(211, 401);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(67, 32);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_Ok.BaseColor = System.Drawing.Color.Transparent;
            this.btn_Ok.ButtonColor = System.Drawing.Color.SkyBlue;
            this.btn_Ok.ButtonStyle = BaseControls.Buttons.VistaButton.Style.Flat;
            this.btn_Ok.ButtonText = "确定";
            this.btn_Ok.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Ok.ForeColor = System.Drawing.Color.Indigo;
            this.btn_Ok.Image = ((System.Drawing.Image)(resources.GetObject("btn_Ok.Image")));
            this.btn_Ok.ImageSize = new System.Drawing.Size(18, 18);
            this.btn_Ok.Location = new System.Drawing.Point(121, 401);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(67, 32);
            this.btn_Ok.TabIndex = 4;
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // frmSetFont
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(429, 456);
            this.Controls.Add(this.lb_Explain);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pg_Font);
            this.Controls.Add(this.lv_Settings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmSetFont";
            this.Text = "字体设置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lv_Settings;
        private BaseControls.Buttons.VistaButton btn_Cancel;
        private BaseControls.Buttons.VistaButton btn_Ok;
        private System.Windows.Forms.PropertyGrid pg_Font;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private BaseControls.ColorPicker.ColorPickerCombobox cmb_ForeColor;
        private System.Windows.Forms.ImageList imageList;
        private BaseControls.MyLabel lb_Explain;
        private System.Windows.Forms.Label lb_Display;

    }
}