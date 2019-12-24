using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseControls.Docking;

namespace SIS.ImgGather
{
    public partial class frmQuickReg : DockContent
    {
        public Panel panel;
        public frmQuickReg(Panel panel)
        {
            InitializeComponent();
            this.panel = panel;
        }

        private void frmQuickReg_DockStateChanged(object sender, EventArgs e)
        {
            panel.BringToFront();
        }
    }
}