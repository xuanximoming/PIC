using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace SIS.RegisterCls
{
   
    public class ComputeCharge
    {
        #region 价表计算区

        public System.Data.DataTable DT_VS = new System.Data.DataTable();                //总检查项目与价表项目对照表
        public System.Data.DataTable Now_DT_VS;            //现在的检查项目与价表项目对照表
        public System.Data.DataTable Now_DT_VS_Old;        //修改前的检查项目与价表项目对照表
        //public System.Data.DataTable CURRENT_PRICE_LIST = new System.Data.DataTable();//总价表
        public List<System.Data.DataTable> Now_DT_VS_Group;
        public decimal costs = 0;
        public decimal charges = 0;
        public decimal chargeRatio = 1;
        public decimal ItemCharges = 0;
        public decimal ItemCosts = 0;

        public void Init()
        {
            Now_DT_VS = new System.Data.DataTable();
            Now_DT_VS_Old = new System.Data.DataTable();
            Now_DT_VS_Group = new List<System.Data.DataTable>();
            costs = 0;
            charges = 0;
            chargeRatio = 1;
            ItemCharges = 0;
            ItemCosts = 0;
        }

        public void AddExamItem(string ExamItemCode, string ExamItemName,int i)
        {
            System.Data.DataTable dt = this.GetExamItems(ExamItemCode,i);
            if (dt != null)
            {
                if (dt.Rows.Count <0)//如果为空.表示是自定义的项目名
                {
                    //DataRow dw = dt.NewRow();
                    //dw["AMOUNT"] = 1;
                    //dw["COSTS"] = 0;
                    //dw["CHARGES"] = 0;
                    //// dw["CLASS_NAME"]="G";
                    //// dw["ITEM_CLASS"]=
                    //dw["ITEM_CODE"] = ExamItemCode;
                    //dw["ITEM_SPEC"] = "/";
                    //dw["PRICE"] = 0;
                    //dw["EXAM_ITEM_CODE"] = ExamItemCode;
                    //dw["ITEM_NAME"] = ExamItemName;
                    //dw["EXAM_ITEM_NO"] = 1;
                    //dw["CHARGE_ITEM_NO"] = 1;
                    //dw["UNITS"] = "次";
                    //dt.Rows.Add(dw);
                }
                Now_DT_VS_Group.Add(dt);
                this.Now_DT_VS.Merge(Now_DT_VS_Group[Now_DT_VS_Group.Count - 1]);
                GetCostsCharges();
            }
        }

        public void RemoveExamItem(int Index)
        {
            try
            {
                if (Now_DT_VS_Group.Count == 0)
                    return;
                Now_DT_VS_Group.RemoveAt(Index);
                this.Now_DT_VS = new System.Data.DataTable();
                for (int i = 0; i < Now_DT_VS_Group.Count; i++)
                    this.Now_DT_VS.Merge(Now_DT_VS_Group[i]);
                //GetCostsCharges();
            }
            catch
            {
            }
            GetCostsCharges();
        }

        public System.Data.DataTable GetExamItems(string ExamItemCode,int i)
        {
            this.ItemCharges = 0;
            this.ItemCosts = 0;
            System.Data.DataTable dt = null;
            if (DT_VS.Rows.Count > 0)
            {
                System.Data.DataView dv = DT_VS.DefaultView;
                dv.RowFilter = " EXAM_ITEM_CODE = '" + ExamItemCode + "'";
                dt = dv.ToTable();
                dt.Columns.Add("EXAM_ITEM_NO", typeof(decimal));
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    dt.Rows[j]["EXAM_ITEM_NO"] = i;
                    string price = dt.Rows[j]["PRICE"].ToString();
                    string Amount = (dt.Rows[j]["AMOUNT"].ToString() == "") ? "0" : dt.Rows[j]["AMOUNT"].ToString();
                    this.ItemCosts += Convert.ToDecimal(price) * Convert.ToDecimal(Amount);
                }
                this.ItemCharges = this.ItemCosts * this.chargeRatio;
            }
            return dt;
        }

        /// <summary>
        /// 计算表中的价格X数量的总和
        /// </summary>
        public void GetCostsCharges()
        {
            if (this.Now_DT_VS_Group == null)
                return;
            this.costs = 0;
            for (int j = 0; j < this.Now_DT_VS_Group.Count; j++)
            {
                for (int i = 0; i < this.Now_DT_VS_Group[j].Rows.Count; i++)
                {
                    string price = this.Now_DT_VS_Group[j].Rows[i]["PRICE"].ToString();
                    string Amount = (this.Now_DT_VS_Group[j].Rows[i]["AMOUNT"].ToString() == "") ? "0" : this.Now_DT_VS_Group[j].Rows[i]["AMOUNT"].ToString();
                    this.costs += Convert.ToDecimal(price) * Convert.ToDecimal(Amount);
                }
            }
            this.charges = this.costs * chargeRatio;//根据费别计算实收费用
        }

        #endregion 价表计算区结束

    }
}
