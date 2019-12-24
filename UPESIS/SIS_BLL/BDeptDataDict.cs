using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;


namespace SIS_BLL
{
    /// <summary>
    /// DEPT_DATA_DICTҵ���࣬����PACS�Ŀ��������ֵ��
    /// </summary>
    public class BDeptDataDict
    {
        public BDeptDataDict()
        {
        }
        private static IDeptDataDict dal = DALFactory.DAL.CreateDDeptDataDict();

        /// <summary>
        /// Add����һ��ָ���Ŀ��������ֵ�
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
         
            return dal.Add(model);
        }

        /// <summary>
        /// Add1����ָ����Adapter�Ŀ��������ֵ�
        /// </summary>
        /// <param name="iDeptDataDict"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public int Add1(IModel iDeptDataDict, ref System.Data.OracleClient.OracleDataAdapter sda)
        {
            return dal.Add1(iDeptDataDict, ref  sda);
        }

        /// <summary>
        /// Update����ָ���Ŀ��������ֵ�
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Update1����ָ��Adapter�Ŀ��������ֵ�
        /// </summary>
        /// <param name="model"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public int Update1(IModel model, ref System.Data.OracleClient.OracleDataAdapter sda)
        {
            return dal.Update1(model, ref sda);
        }

        /// <summary>
        /// Deleteɾ�����������Ŀ��������ֵ�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ���Ŀ��������ֵ�
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������Ŀ��������ֵ��¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }
        
        /// <summary>
        /// GetList1��ȡ����������Adapter�Ŀ��������ֵ��б�
        /// </summary>
        /// <param name="where"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public DataSet GetList1(string where, ref System.Data.OracleClient.OracleDataAdapter sda)
        {
            return dal.GetList1(where, ref sda);
        }

        /// <summary>
        /// GetModel��ȡָ���Ŀ��Ҵ��룬�������ơ��������ͺ��޸�ʱ��Ŀ��������ֵ��¼
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
