using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ILL;


namespace SIS_BLL
{
    /// <summary>
    /// CLINIC_DOCTOR_DICT业务类，操作SIS的临床医生字典表
    /// </summary>
    public class BClinicDoctorDict
    {
        public BClinicDoctorDict()
        {
        }
        private static IClinicDoctorDict dal = DALFactory.DAL.CreateDClinicDoctorDict();

        /// <summary>
        /// Add插入指定的临床医生字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入临床医生字典记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的临床医生字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore批量更新临床医生字典记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delete删除符合条件的临床医生字典记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的临床医生字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的临床医生字典记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// 获取符合条件的临床医生字典记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetModel获取指定临床医生ID的临床医生字典记录
        /// </summary>
        /// <param name="CLINC_DOCTOR_ID"></param>
        /// <returns></returns>
        public IModel GetModel(string CLINC_DOCTOR_ID)
        {
            return dal.GetModel(CLINC_DOCTOR_ID);
        }
    }
}
