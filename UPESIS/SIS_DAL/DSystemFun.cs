using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using SIS_Model;
using ILL;

namespace SIS_DAL
{
    /// <summary>
    /// 对SYSTEM_FUNCTION，系统功能表
    /// </summary>
    public class DSystemFun : ISystemFun
    {
        private string strSql;
        private string TableName = "SYSTEM_FUNCTION";
        public DSystemFun()
            : base(GetConfig.GetSisConnStr())
        {
        }

        /// <summary>
        /// 插入一条系统功能记录
        /// </summary>
        /// <param name="isystemFun"></param>
        /// <returns></returns>
        public override int Add(IModel isystemFun)
        {
            MSystemFun systemFun = (MSystemFun)isystemFun;
            Hashtable ht = new Hashtable();
            ht.Add("MODEL_ID", systemFun.MODEL_ID);
            ht.Add("UP_MODEL_ID", systemFun.UP_MODEL_ID);
            ht.Add("MODEL_CLASS", systemFun.MODEL_CLASS);
            ht.Add("DEL_FLAG", systemFun.DEL_FLAG);
            ht.Add("SORT_FLAG", systemFun.SORT_FLAG);
            ht.Add("MODEL_PLACE", systemFun.MODEL_PLACE);
            ht.Add("MODEL_NAME", systemFun.MODEL_NAME);
            ht.Add("IMAGE_ADDRESS", systemFun.IMAGE_ADDRESS);
            return (ExecuteSql(StringConstructor.InsertSql(TableName, ht).ToString()));
        }

        /// <summary>
        /// 批量插入系统功能记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int AddMore(Hashtable ht2)
        {
            MSystemFun MsysFun = new MSystemFun();
            Hashtable ht = new Hashtable();
            Hashtable htstr = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    MsysFun = (MSystemFun)ht2[i];
                    ht.Add("MODEL_ID", MsysFun.MODEL_ID);
                    ht.Add("UP_MODEL_ID", MsysFun.UP_MODEL_ID);
                    ht.Add("MODEL_CLASS", MsysFun.MODEL_CLASS);
                    ht.Add("DEL_FLAG", MsysFun.DEL_FLAG);
                    ht.Add("SORT_FLAG", MsysFun.SORT_FLAG);
                    ht.Add("MODEL_PLACE", MsysFun.MODEL_PLACE);
                    ht.Add("MODEL_NAME", MsysFun.MODEL_NAME);
                    ht.Add("IMAGE_ADDRESS", MsysFun.IMAGE_ADDRESS);
                    htstr.Add(i, StringConstructor.InsertSql(cp.Uid+"."+TableName, ht).ToString());
                }
                return ExecuteNonSql(htstr);

            }
            else
                return 0;
        }

        /// <summary>
        /// 查询是否存在指定的系统功能记录
        /// </summary>
        /// <param name="isystemFun"></param>
        /// <returns></returns>
        public override bool Exists(IModel isystemFun)
        {
            MSystemFun systemFun = (MSystemFun)isystemFun;
            strSql = "select * from " + TableName + " where MODEL_ID = " + systemFun.MODEL_ID;
            return recordIsExist(strSql);
        }

        /// <summary>
        /// 获取符合条件的系统功能列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where DEL_FLAG=0 and " + where;
            return GetDataTable(strSql);

        }

        /// <summary>
        /// 获取指定ID的系统功能列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override DataTable GetList(int id)
        {
            strSql = " select  a.*, b.MODEL_NAME as up_model_name  from " + TableName + " a ," + TableName + " b where b.MODEL_ID= a.UP_MODEL_ID and a.model_class="+id +" ORDER BY a.MODEL_ID ";
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取符合条件的系统功能子列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetListChild(string where)
        {
            strSql = "select * from " + TableName + where ;
            return GetDataTable(strSql);
        }

        /// <summary>
        /// 获取指定ID的系统功能记录
        /// </summary>
        /// <param name="MODEL_ID"></param>
        /// <returns></returns>
        public override IModel GetModel(string MODEL_ID)
        {
            strSql = "select * from " + TableName + " where MODEL_ID = " + MODEL_ID;
            DataTable dt = GetDataTable(strSql);
            if (dt.Rows.Count == 0)
                return null;
            MSystemFun systemFun = new MSystemFun();
            systemFun.MODEL_ID = Convert.ToInt32(dt.Rows[0]["MODEL_ID"].ToString());
            systemFun.MODEL_CLASS = dt.Rows[0]["MODEL_CLASS"].ToString();
            systemFun.MODEL_NAME = dt.Rows[0]["MODEL_NAME"].ToString();
            systemFun.MODEL_PLACE = dt.Rows[0]["MODEL_PLACE"].ToString();
            systemFun.IMAGE_ADDRESS = dt.Rows[0]["IMAGE_ADDRESS"].ToString();
            if (dt.Rows[0]["UP_MODEL_ID"].ToString() == "")
                systemFun.UP_MODEL_ID = null;
            else
                systemFun.UP_MODEL_ID = Convert.ToInt32(dt.Rows[0]["UP_MODEL_ID"].ToString());

            if (dt.Rows[0]["SORT_FLAG"].ToString() == "")
                systemFun.SORT_FLAG = null;
            else
                systemFun.SORT_FLAG = Convert.ToInt32(dt.Rows[0]["SORT_FLAG"].ToString());

            return systemFun;
        }

        /// <summary>
        /// 更新指定的系统功能记录
        /// </summary>
        /// <param name="isystemFun"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Update(IModel isystemFun, string where)
        {
            MSystemFun systemFun = (MSystemFun)isystemFun;
            Hashtable ht = new Hashtable();
            ht.Add("MODEL_ID", systemFun.MODEL_ID);
            ht.Add("UP_MODEL_ID", systemFun.UP_MODEL_ID);
            ht.Add("MODEL_CLASS", systemFun.MODEL_CLASS);
            ht.Add("DEL_FLAG", systemFun.DEL_FLAG);
            ht.Add("SORT_FLAG", systemFun.SORT_FLAG);
            ht.Add("MODEL_PLACE", systemFun.MODEL_PLACE);
            ht.Add("MODEL_NAME", systemFun.MODEL_NAME);
            ht.Add("IMAGE_ADDRESS", systemFun.IMAGE_ADDRESS);
            return (ExecuteSql(StringConstructor.UpdateSql(TableName, ht,where).ToString()));
        }

        /// <summary>
        /// 批量更新系统功能记录
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public override int UpdateMore(Hashtable ht2)
        {
            MSystemFun MSysFun = new MSystemFun();
            Hashtable htStr = new Hashtable();
            Hashtable ht = new Hashtable();
            if (ht2.Count > 0)
            {
                for (int i = 0; i < ht2.Count; i++)
                {
                    ht.Clear();
                    MSysFun = (MSystemFun)ht2[i];
                    ht.Add("MODEL_NAME", MSysFun.MODEL_NAME);
                    ht.Add("MODEL_PLACE", MSysFun.MODEL_PLACE);
                    ht.Add("SORT_FLAG", MSysFun.SORT_FLAG);
                    ht.Add("IMAGE_ADDRESS", MSysFun.IMAGE_ADDRESS);
                    if(MSysFun.UP_MODEL_ID!=null)
                        ht.Add("Up_MODEL_ID", MSysFun.UP_MODEL_ID);
                    htStr.Add(i, StringConstructor.UpdateSql(TableName, ht, " where MODEL_ID=" + MSysFun.MODEL_ID));
                }

                return ExecuteNonSql(htStr);
            }
            return 0;
        }

        /// <summary>
        /// 删除符合条件的系统功能记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override int Delete(string where)
        {
            return ExecuteSql(StringConstructor.DeleteSql(TableName, where));
        }
    }
}