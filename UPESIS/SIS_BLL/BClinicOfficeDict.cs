using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// CLINIC_OFFICE_DICT业务类，操作SIS的临床科室字典表
    /// </summary>
    public class BClinicOfficeDict
    {
        public BClinicOfficeDict()
        {
        }
        private static IClinicOfficeDict dal = DALFactory.DAL.CreateDClinicOfficeDict();

        /// <summary>
        /// Add插入一条指定的临床科室字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入临床科室字典记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的临床科室字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore批量更新临床科室字典记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public  int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delect删除符合条件的临床科室字典记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的临床科室字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的临床科室字典列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定临床科室Code的临床科室字典记录
        /// </summary>
        /// <param name="DeptCode"></param>
        /// <returns></returns>
        public IModel GetModel(string DeptCode)
        {
            return dal.GetModel(DeptCode);
        }

        /// <summary>
        /// GetModel2获取指定临床科室ID的临床科室字典记录
        /// </summary>
        /// <param name="ClinicOfficeID"></param>
        /// <returns></returns>
        public IModel GetModel2(string ClinicOfficeID)
        {
            return dal.GetModel2(ClinicOfficeID);
        }

        /// <summary>
        ///GetData获取符合条件的临床科室记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetData(string where)
        {
            return dal.GetData(where);
        }
    }
}
