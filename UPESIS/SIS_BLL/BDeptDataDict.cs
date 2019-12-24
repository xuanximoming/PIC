using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;


namespace SIS_BLL
{
    /// <summary>
    /// DEPT_DATA_DICT业务类，操作PACS的科室数据字典表
    /// </summary>
    public class BDeptDataDict
    {
        public BDeptDataDict()
        {
        }
        private static IDeptDataDict dal = DALFactory.DAL.CreateDDeptDataDict();

        /// <summary>
        /// Add插入一条指定的科室数据字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
         
            return dal.Add(model);
        }

        /// <summary>
        /// Add1插入指定的Adapter的科室数据字典
        /// </summary>
        /// <param name="iDeptDataDict"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public int Add1(IModel iDeptDataDict, ref System.Data.OracleClient.OracleDataAdapter sda)
        {
            return dal.Add1(iDeptDataDict, ref  sda);
        }

        /// <summary>
        /// Update更新指定的科室数据字典
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Update1更新指定Adapter的科室数据字典
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public int Update1(IModel model, ref System.Data.OracleClient.OracleDataAdapter sda)
        {
            return dal.Update1(model, ref sda);
        }

        /// <summary>
        /// Delete删除符合条件的科室数据字典
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的科室数据字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的科室数据字典记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }
        
        /// <summary>
        /// GetList1获取符合条件和Adapter的科室数据字典列表
        /// </summary>
        /// <param name="where"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public DataSet GetList1(string where, ref System.Data.OracleClient.OracleDataAdapter sda)
        {
            return dal.GetList1(where, ref sda);
        }

        /// <summary>
        /// GetModel获取指定的科室代码，科室名称、数据类型和修改时间的科室数据字典记录
        /// </summary>
        /// <param name="DeptCode"></param>
        /// <param name="DataName"></param>
        /// <param name="DataType"></param>
        /// <param name="ModifyDateTime"></param>
        /// <returns></returns>
        public IModel GetModel(string DeptCode, string DataName, string DataType, DateTime ModifyDateTime)
        {
            return dal.GetModel(DeptCode, DataName, DataType, ModifyDateTime);
        }

    }
}
