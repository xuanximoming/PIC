namespace SIS
{
    partial class frmSetDataView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetDataView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cLB_DataView = new System.Windows.Forms.ListView();
            this.panel8 = new System.Windows.Forms.Panel();
            this.l_count = new BaseControls.MyLabel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Width = new BaseControls.NumberText();
            this.l_Width = new BaseControls.MyLabel();
            this.cmb_AutoSizeMode = new System.Windows.Forms.ComboBox();
            this.cmb_Visible = new System.Windows.Forms.ComboBox();
            this.l_AutoSizeMode = new BaseControls.MyLabel();
            this.l_Visible = new BaseControls.MyLabel();
            this.l_DataName = new BaseControls.MyLabel();
            this.txt_DataName = new System.Windows.Forms.TextBox();
            this.l_Text = new BaseControls.MyLabel();
            this.txt_Text = new System.Windows.Forms.TextBox();
            this.l_ColumnName = new BaseControls.MyLabel();
            this.txt_ColumnName = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.l_Notice = new BaseControls.MyLabel();
            this.l_Name = new BaseControls.MyLabel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_Down = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 11);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cLB_DataView);
            this.panel2.Controls.Add(this.panel8);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 11);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 668);
            this.panel2.TabIndex = 2;
            // 
            // cLB_DataView
            // 
            this.cLB_DataView.CheckBoxes = true;
            this.cLB_DataView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cLB_DataView.FullRowSelect = true;
            this.cLB_DataView.HideSelection = false;
            this.cLB_DataView.Location = new System.Drawing.Point(10, 32);
            this.cLB_DataView.MultiSelect = false;
            this.cLB_DataView.Name = "cLB_DataView";
            this.cLB_DataView.Size = new System.Drawing.Size(236, 555);
            this.cLB_DataView.TabIndex = 4;
            this.cLB_DataView.UseCompatibleStateImageBehavior = false;
            this.cLB_DataView.View = System.Windows.Forms.View.Details;
            this.cLB_DataView.SelectedIndexChanged += new System.EventHandler(this.cLB_DataView_SelectedIndexChanged);
            this.cLB_DataView.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cLB_DataView_ItemCheck);
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.l_count);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(10, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(236, 32);
            this.panel8.TabIndex = 5;
            // 
            // l_count
            // 
            this.l_count.AutoSize = true;
            this.l_count.Location = new System.Drawing.Point(6, 12);
            this.l_count.Name = "l_count";
            this.l_count.Size = new System.Drawing.Size(16, 16);
            this.l_count.TabIndex = 4;
            this.l_count.Text = "1";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.btn_Delete);
            this.panel7.Controls.Add(this.btn_Add);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(10, 587);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(236, 79);
            this.panel7.TabIndex = 4;
            // 
            // btn_Delete
            // 
            this.btn_Delete.Location = new System.Drawing.Point(133, 16);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(70, 38);
            this.btn_Delete.TabIndex = 1;
            this.btn_Delete.Text = "删除";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(39, 16);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(70, 38);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(10, 666);
            this.panel6.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(313, 11);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(322, 668);
            this.panel3.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_Width);
            this.groupBox1.Controls.Add(this.l_Width);
            this.groupBox1.Controls.Add(this.cmb_AutoSizeMode);
            this.groupBox1.Controls.Add(this.cmb_Visible);
            this.groupBox1.Controls.Add(this.l_AutoSizeMode);
            this.groupBox1.Controls.Add(this.l_Visible);
            this.groupBox1.Controls.Add(this.l_DataName);
            this.groupBox1.Controls.Add(this.txt_DataName);
            this.groupBox1.Controls.Add(this.l_Text);
            this.groupBox1.Controls.Add(this.txt_Text);
            this.groupBox1.Controls.Add(this.l_ColumnName);
            this.groupBox1.Controls.Add(this.txt_ColumnName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 478);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "列头属性";
            // 
            // txt_Width
            // 
            this.txt_Width.Location = new System.Drawing.Point(136, 258);
            this.txt_Width.Name = "txt_Width";
            this.txt_Width.NumberCount = 3;
            this.txt_Width.Size = new System.Drawing.Size(154, 26);
            this.txt_Width.TabIndex = 5;
            this.txt_Width.TextChanged += new System.EventHandler(this.txt_Width_TextChanged);
            this.txt_Width.Enter += new System.EventHandler(this.txt_Width_Enter);
            // 
            // l_Width
            // 
            this.l_Width.BackColor = System.Drawing.Color.White;
            this.l_Width.Location = new System.Drawing.Point(7, 258);
            this.l_Width.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_Width.Name = "l_Width";
            this.l_Width.Size = new System.Drawing.Size(122, 26);
            this.l_Width.TabIndex = 4;
            this.l_Width.Text = "Width";
            this.l_Width.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_AutoSizeMode
            // 
            this.cmb_AutoSizeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_AutoSizeMode.FormattingEnabled = true;
            this.cmb_AutoSizeMode.Items.AddRange(new object[] {
            "NotSet",
            "AllCells",
            "AllCellsExceptHeader",
            "ColumnHeader",
            "DisplayedCells",
            "DisplayedCellsExceptHeader",
            "Fill",
            "None"});
            this.cmb_AutoSizeMode.Location = new System.Drawing.Point(136, 368);
            this.cmb_AutoSizeMode.Name = "cmb_AutoSizeMode";
            this.cmb_AutoSizeMode.Size = new System.Drawing.Size(154, 24);
            this.cmb_AutoSizeMode.TabIndex = 3;
            this.cmb_AutoSizeMode.SelectedIndexChanged += new System.EventHandler(this.cmb_AutoSizeMode_SelectedIndexChanged);
            this.cmb_AutoSizeMode.Enter += new System.EventHandler(this.cmb_AutoSizeMode_Enter);
            // 
            // cmb_Visible
            // 
            this.cmb_Visible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Visible.FormattingEnabled = true;
            this.cmb_Visible.Items.AddRange(new object[] {
            "False",
            "True"});
            this.cmb_Visible.Location = new System.Drawing.Point(136, 313);
            this.cmb_Visible.Name = "cmb_Visible";
            this.cmb_Visible.Size = new System.Drawing.Size(154, 24);
            this.cmb_Visible.TabIndex = 3;
            this.cmb_Visible.SelectedIndexChanged += new System.EventHandler(this.cmb_Visible_SelectedIndexChanged);
            this.cmb_Visible.Enter += new System.EventHandler(this.cmb_Visible_Enter);
            // 
            // l_AutoSizeMode
            // 
            this.l_AutoSizeMode.BackColor = System.Drawing.Color.White;
            this.l_AutoSizeMode.Location = new System.Drawing.Point(7, 368);
            this.l_AutoSizeMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_AutoSizeMode.Name = "l_AutoSizeMode";
            this.l_AutoSizeMode.Size = new System.Drawing.Size(122, 24);
            this.l_AutoSizeMode.TabIndex = 0;
            this.l_AutoSizeMode.Text = "AutoSizeMode";
            this.l_AutoSizeMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_Visible
            // 
            this.l_Visible.BackColor = System.Drawing.Color.White;
            this.l_Visible.Location = new System.Drawing.Point(7, 313);
            this.l_Visible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_Visible.Name = "l_Visible";
            this.l_Visible.Size = new System.Drawing.Size(122, 24);
            this.l_Visible.TabIndex = 0;
            this.l_Visible.Text = "Visible";
            this.l_Visible.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // l_DataName
            // 
            this.l_DataName.BackColor = System.Drawing.Color.White;
            this.l_DataName.Location = new System.Drawing.Point(7, 203);
            this.l_DataName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_DataName.Name = "l_DataName";
            this.l_DataName.Size = new System.Drawing.Size(122, 26);
            this.l_DataName.TabIndex = 0;
            this.l_DataName.Text = "DataName";
            this.l_DataName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_DataName
            // 
            this.txt_DataName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_DataName.Location = new System.Drawing.Point(136, 203);
            this.txt_DataName.Name = "txt_DataName";
            this.txt_DataName.Size = new System.Drawing.Size(154, 26);
            this.txt_DataName.TabIndex = 1;
            this.txt_DataName.TextChanged += new System.EventHandler(this.txt_DataName_TextChanged);
            this.txt_DataName.Enter += new System.EventHandler(this.txt_DataName_Enter);
            // 
            // l_Text
            // 
            this.l_Text.BackColor = System.Drawing.Color.White;
            this.l_Text.Location = new System.Drawing.Point(7, 148);
            this.l_Text.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_Text.Name = "l_Text";
            this.l_Text.Size = new System.Drawing.Size(122, 26);
            this.l_Text.TabIndex = 0;
            this.l_Text.Text = "Text";
            this.l_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Text
            // 
            this.txt_Text.Location = new System.Drawing.Point(136, 148);
            this.txt_Text.Name = "txt_Text";
            this.txt_Text.Size = new System.Drawing.Size(154, 26);
            this.txt_Text.TabIndex = 1;
            this.txt_Text.TextChanged += new System.EventHandler(this.txt_Text_TextChanged);
            this.txt_Text.Enter += new System.EventHandler(this.txt_Text_Enter);
            // 
            // l_ColumnName
            // 
            this.l_ColumnName.BackColor = System.Drawing.Color.White;
            this.l_ColumnName.Location = new System.Drawing.Point(7, 93);
            this.l_ColumnName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.l_ColumnName.Name = "l_ColumnName";
            this.l_ColumnName.Size = new System.Drawing.Size(122, 26);
            this.l_ColumnName.TabIndex = 0;
            this.l_ColumnName.Text = "ColumnName";
            this.l_ColumnName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_ColumnName
            // 
            this.txt_ColumnName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txt_ColumnName.Location = new System.Drawing.Point(136, 93);
            this.txt_ColumnName.Name = "txt_ColumnName";
            this.txt_ColumnName.Size = new System.Drawing.Size(154, 26);
            this.txt_ColumnName.TabIndex = 1;
            this.txt_ColumnName.TextChanged += new System.EventHandler(this.txt_ColumnName_TextChanged);
            this.txt_ColumnName.Enter += new System.EventHandler(this.txt_ColumnName_Enter);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.l_Notice);
            this.panel5.Controls.Add(this.l_Name);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 478);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(320, 94);
            this.panel5.TabIndex = 4;
            // 
            // l_Notice
            // 
            this.l_Notice.AutoSize = true;
            this.l_Notice.Location = new System.Drawing.Point(19, 40);
            this.l_Notice.Name = "l_Notice";
            this.l_Notice.Size = new System.Drawing.Size(56, 16);
            this.l_Notice.TabIndex = 4;
            this.l_Notice.Text = "label3";
            // 
            // l_Name
            // 
            this.l_Name.AutoSize = true;
            this.l_Name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.l_Name.Location = new System.Drawing.Point(19, 12);
            this.l_Name.Name = "l_Name";
            this.l_Name.Size = new System.Drawing.Size(62, 16);
            this.l_Name.TabIndex = 3;
            this.l_Name.Text = "label2";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btn_Cancel);
            this.panel9.Controls.Add(this.btn_Ok);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 572);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(320, 94);
            this.panel9.TabIndex = 5;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(187, 28);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(70, 38);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(93, 28);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(70, 38);
            this.btn_Ok.TabIndex = 1;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btn_Down);
            this.panel4.Controls.Add(this.btn_Up);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(251, 11);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(62, 668);
            this.panel4.TabIndex = 0;
            // 
            // btn_Down
            // 
            this.btn_Down.Image = ((System.Drawing.Image)(resources.GetObject("btn_Down.Image")));
            this.btn_Down.Location = new System.Drawing.Point(10, 61);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(41, 36);
            this.btn_Down.TabIndex = 0;
            this.btn_Down.UseVisualStyleBackColor = true;
            this.btn_Down.Click += new System.EventHandler(this.btn_Down_Click);
            // 
            // btn_Up
            // 
            this.btn_Up.Image = ((System.Drawing.Image)(resources.GetObject("btn_Up.Image")));
            this.btn_Up.Location = new System.Drawing.Point(10, 17);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(41, 38);
            this.btn_Up.TabIndex = 0;
            this.btn_Up.UseVisualStyleBackColor = true;
            this.btn_Up.Click += new System.EventHandler(this.btn_Up_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(248, 11);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 668);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // SetDataView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(635, 679);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SetDataView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetDataView";
            this.panel2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private BaseControls.MyLabel l_ColumnName;
        private System.Windows.Forms.TextBox txt_ColumnName;
        private System.Windows.Forms.Panel panel5;
        private BaseControls.MyLabel l_Notice;
        private BaseControls.MyLabel l_Name;
        private System.Windows.Forms.Panel panel4;
        private BaseControls.MyLabel l_AutoSizeMode;
        private BaseControls.MyLabel l_Visible;
        private BaseControls.MyLabel l_DataName;
        private System.Windows.Forms.TextBox txt_DataName;
        private BaseControls.MyLabel l_Text;
        private System.Windows.Forms.TextBox txt_Text;
        private System.Windows.Forms.ComboBox cmb_AutoSizeMode;
        private System.Windows.Forms.ComboBox cmb_Visible;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Splitter splitter1;
        private BaseControls.MyLabel l_count;
        private System.Windows.Forms.ListView cLB_DataView;
        private BaseControls.NumberText txt_Width;
        private BaseControls.MyLabel l_Width;
    }
}