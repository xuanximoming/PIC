namespace SIS.Settings
{
    partial class frmSetColor
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("标注", 6);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetColor));
            this.lv_Settings = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ImageCtlPenWidth = new BaseControls.NumberText();
            this.btn_Cancel = new BaseControls.Buttons.VistaButton();
            this.btn_Ok = new BaseControls.Buttons.VistaButton();
            this.colorPickerCtrl1 = new BaseControls.ColorPicker.ColorPickerCtrl();
            this.SuspendLayout();
            // 
            // lv_Settings
            // 
            this.lv_Settings.HideSelection = false;
            this.lv_Settings.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lv_Settings.LargeImageList = this.imageList;
            this.lv_Settings.Location = new System.Drawing.Point(44, 29);
            this.lv_Settings.MultiSelect = false;
            this.lv_Settings.Name = "lv_Settings";
            this.lv_Settings.Size = new System.Drawing.Size(507, 73);
            this.lv_Settings.TabIndex = 1;
            this.lv_Settings.UseCompatibleStateImageBehavior = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 354);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "标注线条宽度：";
            // 
            // txt_ImageCtlPenWidth
            // 
            this.txt_ImageCtlPenWidth.Location = new System.Drawing.Point(137, 351);
            this.txt_ImageCtlPenWidth.Name = "txt_ImageCtlPenWidth";
            this.txt_ImageCtlPenWidth.NumberCount = 3;
            this.txt_ImageCtlPenWidth.Size = new System.Drawing.Size(100, 21);
            this.txt_ImageCtlPenWidth.TabIndex = 9;
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
            this.btn_Cancel.Location = new System.Drawing.Point(307, 380);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(67, 32);
            this.btn_Cancel.TabIndex = 7;
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
            this.btn_Ok.Location = new System.Drawing.Point(217, 380);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(67, 32);
            this.btn_Ok.TabIndex = 6;
            this.btn_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // colorPickerCtrl1
            // 
            this.colorPickerCtrl1.BackColor = System.Drawing.Color.Transparent;
            this.colorPickerCtrl1.Location = new System.Drawing.Point(44, 108);
            this.colorPickerCtrl1.Name = "colorPickerCtrl1";
            this.colorPickerCtrl1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.colorPickerCtrl1.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(235)))), ((int)(((byte)(215)))));
            this.colorPickerCtrl1.Size = new System.Drawing.Size(507, 233);
            this.colorPickerCtrl1.TabIndex = 0;
            // 
            // frmSetColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 446);
            this.Controls.Add(this.txt_ImageCtlPenWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.lv_Settings);
            this.Controls.Add(this.colorPickerCtrl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmSetColor";
            this.Text = "颜色设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BaseControls.ColorPicker.ColorPickerCtrl colorPickerCtrl1;
        private System.Windows.Forms.ListView lv_Settings;
        private System.Windows.Forms.ImageList imageList;
        private BaseControls.Buttons.VistaButton btn_Cancel;
        private BaseControls.Buttons.VistaButton btn_Ok;
        private System.Windows.Forms.Label label1;
        private BaseControls.NumberText txt_ImageCtlPenWidth;
    }
}