using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaseControls.ComboBoxs
{
    public partial class MyComboBox : System.Windows.Forms.ComboBox
    {
        public MyComboBox()
        {
            InitializeComponent();
        }

        protected override void OnEnter(EventArgs e)
        {
            this.BackColor = Color.PapayaWhip;
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = Color.White;
            base.OnLeave(e);
        }
    }
}
