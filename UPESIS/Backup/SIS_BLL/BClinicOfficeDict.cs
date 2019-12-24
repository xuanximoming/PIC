using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// CLINIC_OFFICE_DICTҵ���࣬����SIS���ٴ������ֵ��
    /// </summary>
    public class BClinicOfficeDict
    {
        public BClinicOfficeDict()
        {
        }
        private static IClinicOfficeDict dal = DALFactory.DAL.CreateDClinicOfficeDict();

        /// <summary>
        /// Add����һ��ָ�����ٴ������ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore���������ٴ������ֵ��¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update����ָ�����ٴ������ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore���������ٴ������ֵ��¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public  int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Delectɾ�������������ٴ������ֵ��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ�����ٴ������ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ�����������ٴ������ֵ��б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ���ٴ�����Code���ٴ������ֵ��¼
        /// </summary>
        /// <param name="DeptCode"></param>
        /// <returns></returns>
        public IModel GetModel(string DeptCode)
        {
            return dal.GetModel(DeptCode);
        }

        /// <summary>
        /// GetModel2��ȡָ���ٴ�����ID���ٴ������ֵ��¼
        /// </summary>
        /// <param name="ClinicOfficeID"></param>
        /// <returns></returns>
        public IModel GetModel2(string ClinicOfficeID)
        {
            return dal.GetModel2(ClinicOfficeID);
        }

        /// <summary>
        ///GetData��ȡ�����������ٴ����Ҽ�¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetData(string where)
        {
            return dal.GetData(where);
        }
    }
}
