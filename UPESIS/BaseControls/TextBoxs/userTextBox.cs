using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaseControls
{
    public partial class userTextBox : System.Windows.Forms.TextBox
    {
        private bool isChangeColor = true;

        public bool IsChangeColor
        {
            get { return isChangeColor; }
            set { isChangeColor = value; }
        }

        public userTextBox()
        {
            InitializeComponent();
            this.Font = Properties.Settings.Default.Font_userTextBox;
            this.ForeColor = Properties.Settings.Default.ForeColor_userTextBox;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (isChangeColor)
                this.BackColor = Color.PapayaWhip;
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            if (isChangeColor)
                this.BackColor = Color.White;
        }
    }
}
