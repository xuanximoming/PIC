using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace SIS.Function
{
    class CtlComboBox
    {
        #region 锁定COMBBOX行

        /// <summary>
        /// 根据ValueMember锁定COMBBOX行
        /// </summary>
        /// <param name="Comb_Item"></param>
        public static void SetValue(string Comb_Item, ComboBox comb)
        {
            if (comb.Items.Count == 0)
            {
                comb.SelectedIndex = -1;
                comb.Text = Comb_Item;
            }
            else
            {
                for (int i = 0; i < comb.Items.Count; ++i)
                {
                    System.Data.DataRow dr = (comb.Items[i] as System.Data.DataRowView).Row;
                    if (dr[comb.ValueMember].ToString().Trim() == Comb_Item)
                    {
                        comb.SelectedIndex = i;
                        comb.Text = dr[comb.DisplayMember].ToString().Trim();
                        break;
                    }
                    else
                    {
                        comb.SelectedIndex = -1;
                        comb.Text = Comb_Item;
                    }
                }
            }
        }

        /// <summary>
        /// 根据DisplayMember锁定COMBBOX行
        /// </summary>
        /// <param name="Comb_Item"></param>
        public static void SetDisplay(string Comb_Item, ComboBox comb)
        {
            if (comb.Items.Count == 0)
            {
                comb.SelectedIndex = -1;
                comb.Text = Comb_Item;
            }
            else
            {
                for (int i = 0; i < comb.Items.Count; ++i)
                {
                    try
                    {
                        System.Data.DataRow dr = (comb.Items[i] as System.Data.DataRowView).Row;
                        if (dr[comb.DisplayMember].ToString().Trim() == Comb_Item)
                        {
                            comb.SelectedIndex = i;
                            comb.Text = dr[comb.DisplayMember].ToString().Trim();
                            break;
                        }
                        else
                        {
                            comb.SelectedIndex = -1;
                            comb.Text = Comb_Item;
                        }
                    }
                    catch
                    {
                        comb.Text = Comb_Item;
                    }
                    comb.Text = Comb_Item;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Comb_Item"></param>
        public static bool FindMember(string where, ComboBox comb,System.Data.DataTable dt_All)
        {
            //string displayMember = comb.DisplayMember;
            //string valueMember = comb.ValueMember;
            if (dt_All == null||dt_All.Rows.Count ==0)
                return false;
            System.Data.DataRow[] drs = dt_All.Select(where);
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Merge(drs);
            if (ds.Tables.Count > 0)
            {
                
                comb.DataSource = ds.Tables[0];
                comb.SelectedIndex = -1;
                return true;
            }
            else
                return false;
            //comb.DisplayMember = displayMember;
            //comb.ValueMember = valueMember;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Comb_Item"></param>
        public static bool FindMember(string where, ComboBox comb, System.Data.DataTable dt_All,string SortName)
        {
            //string displayMember = comb.DisplayMember;
            //string valueMember = comb.ValueMember;
            if (dt_All == null || dt_All.Rows.Count == 0)
                return false;
            System.Data.DataRow[] drs = dt_All.Select(where);
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Merge(drs);
            if (ds.Tables.Count > 0)
            {
                DataView dw = ds.Tables[0].DefaultView;
                dw.Sort = SortName + " asc";
                comb.DataSource = ds.Tables[0];
                comb.SelectedIndex = -1;
                return true;
            }
            else
                return false;
            //comb.DisplayMember = displayMember;
            //comb.ValueMember = valueMember;
        }

        #endregion

    }
}