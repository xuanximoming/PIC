using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS
{
    public partial class frmSetDataView : Form
    {
        private string xmlFile;

        public frmSetDataView()
        {
            InitializeComponent();
        }

        public frmSetDataView(System.Data.DataTable dt_View,string xmlFile)
        {
            InitializeComponent();
            this.initFrm(dt_View);
            this.xmlFile = xmlFile;
        }

        private void initFrm(System.Data.DataTable dt_View)
        {
            int columnCount = dt_View.Columns.Count;
            string[] lvitem = new string[columnCount];
            this.cLB_DataView.Columns.Add(dt_View.Columns[0].ColumnName, this.cLB_DataView.Width - 10);
            for(int i=1;i<dt_View.Columns .Count ;i++)
            {
                this.cLB_DataView.Columns.Add(dt_View.Columns[i].ColumnName,0);
            }
            for (int i = 0; i < dt_View.Rows.Count; i++)
            {
                ListViewItem.ListViewSubItem[] subitems = new ListViewItem.ListViewSubItem[columnCount];
                for(int j=0;j<columnCount ;j++)
                {
                    subitems[j] = new ListViewItem.ListViewSubItem();
                    subitems[j].Text = dt_View.Rows[i][dt_View.Columns[j].ColumnName].ToString();
                    subitems[j].Name = dt_View.Columns[j].ColumnName;
                }
                ListViewItem item = new ListViewItem(subitems,-1);
                this.cLB_DataView.Items.Add(item);
                if (dt_View.Rows[i]["Visible"].ToString() == "1")
                {
                    this.cLB_DataView.Items[i].Checked = true;
                }
                else
                {
                    this.cLB_DataView.Items[i].Checked = false;
                }
            }
            this.l_count.Text = "共 " + dt_View.Rows.Count + " 列";
            this.l_Name.Text = "";
            this.l_Notice.Text = "";
        }

        private void cLB_DataView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cLB_DataView.SelectedItems.Count > 0)
            {
                ListViewItem item = this.cLB_DataView.SelectedItems[0];
                this.txt_ColumnName.Text = item.SubItems["ColumnName"].Text;
                this.txt_DataName.Text = item.SubItems["DataName"].Text;
                this.txt_Width.Text = item.SubItems["Width"].Text;
                this.txt_Text.Text = item.SubItems["Text"].Text;
                this.cmb_Visible.SelectedIndex = Convert.ToInt32(item.SubItems["Visible"].Text);
                this.SetAutoSizeMode(this.cmb_AutoSizeMode, item.SubItems["AutoSizeMode"].Text);
                this.l_Name.Text = "";
                this.l_Notice.Text = "";
                if (this.cLB_DataView.SelectedIndices[0] == 0)
                    this.btn_Up.Enabled = false;
                else
                    this.btn_Up.Enabled = true;
                if (this.cLB_DataView.SelectedIndices[0] == (this.cLB_DataView.Items.Count - 1))
                    this.btn_Down.Enabled = false;
                else
                    this.btn_Down.Enabled = true;
            }
        }

        private void SetAutoSizeMode(ComboBox cmb, string mode)
        {
            switch (mode)
            {
                case "NotSet":
                    cmb.SelectedIndex = 0;
                    break;
                case "AllCells":
                    cmb.SelectedIndex = 1;
                    break;
                case "AllCellsExceptHeader":
                    cmb.SelectedIndex = 2;
                    break;
                case "ColumnHeader":
                    cmb.SelectedIndex = 3;
                    break;
                case "DisplayedCells":
                    cmb.SelectedIndex = 4;
                    break;
                case "DisplayedCellsExceptHeader":
                    cmb.SelectedIndex = 5;
                    break;
                case "Fill":
                    cmb.SelectedIndex = 6;
                    break;
                case "None":
                    cmb.SelectedIndex = 7;
                    break;
            }
        }

        private void cLB_DataView_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListViewItem item = this.cLB_DataView.Items[e.Index];
            if (e.NewValue == CheckState.Checked)
            {
                item.SubItems["Visible"].Text = "1";
            }
            else
            {
                item.SubItems["Visible"].Text = "0";
            }
        }

        private void txt_ColumnName_TextChanged(object sender, EventArgs e)
        {
            ListViewItem item = this.cLB_DataView.SelectedItems[0];
            item.SubItems["ColumnName"].Text = this.txt_ColumnName.Text;
        }

        private void txt_Text_TextChanged(object sender, EventArgs e)
        {
            ListViewItem item = this.cLB_DataView.SelectedItems[0];
            item.SubItems["Text"].Text = this.txt_Text.Text;
        }

        private void txt_DataName_TextChanged(object sender, EventArgs e)
        {
            ListViewItem item = this.cLB_DataView.SelectedItems[0];
            item.SubItems["DataName"].Text = this.txt_DataName.Text;
        }

        private void txt_Width_TextChanged(object sender, EventArgs e)
        {
            ListViewItem item = this.cLB_DataView.SelectedItems[0];
            item.SubItems["Width"].Text = this.txt_Width.Text;
        }


        private void cmb_Visible_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = this.cLB_DataView.SelectedItems[0];
            item.SubItems["Visible"].Text = this.cmb_Visible.SelectedIndex.ToString();
        }

        private void cmb_AutoSizeMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem item = this.cLB_DataView.SelectedItems[0];
            item.SubItems["AutoSizeMode"].Text = this.cmb_AutoSizeMode.Text;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            System.Data.DataSet ds = this.GetDataSet();
            ds.WriteXml(this.xmlFile);
            this.Close();
        }

        private System.Data.DataSet GetDataSet()
        {
            System.Data.DataTable dt = new DataTable();
            dt.Columns.Add("Text", typeof(string));
            dt.Columns.Add("ColumnName", typeof(string));
            dt.Columns.Add("DataName", typeof(string));
            dt.Columns.Add("DisplayIndex", typeof(string));
            dt.Columns.Add("Width", typeof(string));
            dt.Columns.Add("Visible", typeof(string));
            dt.Columns.Add("AutoSizeMode", typeof(string));
            for (int i = 0; i < this.cLB_DataView.Items.Count; i++)
            {
                ListViewItem item = this.cLB_DataView.Items[i];
                dt.Rows.Add(new object[] { 
                    item.SubItems["Text"].Text, 
                    item.SubItems["ColumnName"].Text, 
                    item.SubItems["DataName"].Text, 
                    i.ToString ("000"), 
                    item.SubItems["Width"].Text, 
                    item.SubItems["Visible"].Text, 
                    item.SubItems["AutoSizeMode"].Text });
            }
            dt.TableName = "ExamColumn";
            System.Data.DataSet ds = new DataSet("ExamColumns");
            ds.Tables.Add(dt);
            return ds;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            if (this.cLB_DataView.SelectedItems.Count == 0)
                return;
            int selectIndex = this.cLB_DataView.SelectedIndices[0];
            if (selectIndex == 0)
                return;
            int selectIndex_pre = selectIndex - 1; //上一个项的索引  
            ListViewItem item = this.cLB_DataView.Items[selectIndex];
            this.cLB_DataView.Items.RemoveAt(selectIndex);
            this.cLB_DataView.Items.Insert(selectIndex_pre, item);
            this.cLB_DataView.Items[selectIndex_pre].Selected = true;
            if (selectIndex_pre == 0)
                this.btn_Up.Enabled = false;
            else
                this.btn_Down.Enabled = true;
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            if (this.cLB_DataView.SelectedItems.Count  == 0)
                return;
            int selectIndex = this.cLB_DataView.SelectedIndices[0];
            if (selectIndex == (this.cLB_DataView.Items.Count-1))
                return;
            int selectIndex_next = selectIndex + 1; //下一个项的索引  
            ListViewItem item = this.cLB_DataView.Items[selectIndex];
            this.cLB_DataView.Items.RemoveAt(selectIndex);
            this.cLB_DataView.Items.Insert(selectIndex_next, item);
            this.cLB_DataView.Items[selectIndex_next].Selected = true;

            if (selectIndex_next == 0)
                this.btn_Down.Enabled = false;
            else
                this.btn_Up.Enabled = true;
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (this.cLB_DataView.SelectedItems.Count == 0)
                return;
            this.cLB_DataView.Items.RemoveAt(this.cLB_DataView.SelectedIndices[0]);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            ListViewItem item = (ListViewItem)this.cLB_DataView.Items[0].Clone();
            for (int i = 0; i < item.SubItems.Count; i++)
            {
                item.SubItems[i].Name = this.cLB_DataView.Items[0].SubItems[i].Name;
            }
            item.SubItems["Text"].Text = "Column1";
            item.SubItems["ColumnName"].Text = "Column1";
            item.SubItems["DataName"].Text = "";
            item.SubItems["DisplayIndex"].Text = "";
            item.SubItems["Width"].Text = "100";
            item.SubItems["Visible"].Text = "1";
            item.SubItems["AutoSizeMode"].Text = "NotSet";
            this.cLB_DataView.Items.Add(item);
            this.cLB_DataView.Items[this.cLB_DataView.Items.Count - 1].Selected = true;
        }

        private void txt_ColumnName_Enter(object sender, EventArgs e)
        {
            this.l_Name.Text = "（ColumnName）";
            this.l_Notice.Text = "列表中用来标识该列的名称";
        }

        private void txt_Text_Enter(object sender, EventArgs e)
        {
            this.l_Name.Text = "（Text）";
            this.l_Notice.Text = "此列的标题文本";
        }

        private void txt_DataName_Enter(object sender, EventArgs e)
        {
            this.l_Name.Text = "（DataName）";
            this.l_Notice.Text = "此列绑定到数据源属性或数据库列的名称";
        }

        private void txt_Width_Enter(object sender, EventArgs e)
        {
            this.l_Name.Text = "（Width）";
            this.l_Notice.Text = "此列的当前宽度";
        }

        private void cmb_Visible_Enter(object sender, EventArgs e)
        {
            this.l_Name.Text = "（Visible）";
            this.l_Notice.Text = "指示此列是否可见";
        }

        private void cmb_AutoSizeMode_Enter(object sender, EventArgs e)
        {
            this.l_Name.Text = "（AutoSizeMode）";
            this.l_Notice.Text = "确定此列的自动调整大小模式";
        }


    }
}