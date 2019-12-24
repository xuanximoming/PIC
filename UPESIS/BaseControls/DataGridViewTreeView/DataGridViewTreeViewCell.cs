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
    public class DataGridViewTreeViewCell:DataGridViewTextBoxCell
    {
        public DataGridViewTreeViewCell()
        {

        }
        public override void InitializeEditingControl(int rowIndex, object
       initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            DataGridViewTreeViewEditingControl ctl =
                DataGridView.EditingControl as DataGridViewTreeViewEditingControl;
            ctl.Text = (string)this.Value.ToString();
        }

        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewTreeViewEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return "";
            }
        }
    }
}
