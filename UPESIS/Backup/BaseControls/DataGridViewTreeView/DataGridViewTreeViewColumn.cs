using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;

namespace BaseControls
{
    public class DataGridViewTreeViewColumn:DataGridViewColumn
    {
        public DataGridViewTreeViewColumn():
            base(new DataGridViewTreeViewCell())
        {

        }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewTreeViewCell)))
                {
                    throw new InvalidCastException("²»ÊÇDataGridViewTreeViewCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
