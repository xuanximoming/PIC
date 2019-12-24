using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Windows.Forms;

namespace SIS.RegisterCls
{
    class SelInpPat
    {
        private RegCls_JW regJW;
        private RegCls_HT regHT;
        private IModel iWorkList;

        public SelInpPat()
        {

        }

        /// <summary>
        /// 查询HIS系统在院病人资料库
        /// </summary>
        public bool SearchPatsInHospital(string where, IModel iWorkList)
        {
            this.iWorkList = iWorkList;
            bool isExit = false;
            System.Data.DataTable dt = new System.Data.DataTable();
            switch (GetConfig.hisVender)
            {
                case "JW":
                    dt = regJW.SelectPatsInHospital(where);
                    break;
                case "HT":
                    break;
            }
            if (dt.Rows.Count > 0)
            {
                if (SelectPatsInHospital(dt))
                    return true;
            }
            return isExit;
        }

        /// <summary>
        /// 提取HIS在院病人资料库记录数据
        /// </summary>
        private bool SelectPatsInHospital(System.Data.DataTable dt)
        {
            string settled_indicator = dt.Rows[0]["SETTLED_INDICATOR"].ToString();
            if (settled_indicator == "1")
            {
                MessageBox.Show("该病人已出院！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        SIS_Model.MWorkList smWorkList = (SIS_Model.MWorkList)this.iWorkList;
                        smWorkList.VISIT_ID = Convert.ToInt32(dt.Rows[0]["VISIT_ID"].ToString());
                        smWorkList.BED_NUM = dt.Rows[0]["BED_NO"].ToString();
                        break;
                    case "PACS":
                        PACS_Model.MWorkList pmWorkList = (PACS_Model.MWorkList)this.iWorkList;
                        pmWorkList.VISIT_ID = Convert.ToInt32(dt.Rows[0]["VISIT_ID"].ToString());
                        pmWorkList.BED_NUM = dt.Rows[0]["BED_NO"].ToString();
                        break;
                }
                return true;
            }
        }
    }
}
