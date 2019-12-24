using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS
{
    public partial class frmDiagChangeGroup : Form
    {
        public frmDiagChangeGroup(DataTable dt,int Index)
        {
            InitializeComponent();
            GroupBind(dt,Index);
        }
        private int _selectValue=-1;
        public int Value
        {
            set { this._selectValue = value; }
            get { return this._selectValue; }
        }
        private void GroupBind(DataTable dt,int index)
        {
            this.cmb_Group.DataSource = dt;
            this.cmb_Group.DisplayMember = "QUEUE_NAME";
            this.cmb_Group.ValueMember = "QUEUE_ID";
            this.cmb_Group.SelectedIndex = index;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this.Value = this.cmb_Group.SelectedIndex ;
            this.DialogResult = DialogResult.OK;
        }
    }
}