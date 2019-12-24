using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS
{
    public partial class frmTest : Form
    {
        public frmTest()
        {
            InitializeComponent();
        }
        private QPInfo info = new QPInfo();
        private void button1_Click(object sender, EventArgs e)
        {
            //QPInfo info = new QPInfo();
            this.dataGridView1.DataSource = info.GetQPInfo("111", "11", "1");
        }
    }
}