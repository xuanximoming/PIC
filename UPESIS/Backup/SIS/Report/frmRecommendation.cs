using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SIS
{
    public partial class frmRecommendation : BaseControls.Docking.DockContent
    {
        public Panel panel;
        public frmRecommendation()
        {
            InitializeComponent();
        }

        private void frmRecommendation_DockStateChanged(object sender, EventArgs e)
        {
            panel.BringToFront();
        }

        public void init(string Recommendation)
        {
            this.txt_Recommendation.Text = Recommendation;
        }

        public string GetRecommendation()
        {
            return this.txt_Recommendation.Text;
        }
    }
}