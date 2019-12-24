using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS
{
    public partial class frmDiagInsertTo : Form
    {
        public frmDiagInsertTo()
        {
            InitializeComponent();
        }
        private int _insertNo;
        public int InsertNo
        {
            set { this._insertNo = value; }
            get { return this._insertNo; }
        }
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (tx_InserNo.Text != "")
            {
                this.InsertNo = int.Parse(tx_InserNo.Text);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.label1.Text = "«Î ‰»Î ˝◊÷£°";
            }
        }
    }
}