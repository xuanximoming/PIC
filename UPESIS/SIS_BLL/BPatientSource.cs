using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// PATIENT_SOURCEҵ���࣬����SIS��PACS�Ĳ�����Դ��
    /// </summary>
    public class BPatientSource
    {
        public BPatientSource()
        {
        }
        private static IPatientSource dal = DALFactory.DAL.CreateDPatientSource();

        /// <summary>
        /// Add����һ��ָ���Ĳ�����Դ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore�������벡����Դ��¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update����ָ���Ĳ�����Դ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdageMore�������²�����Դ��¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Deleteɾ�����������Ĳ�����Դ��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ���Ĳ�����Դ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������Ĳ�����Դ��¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ��������ԴID�Ĳ�����Դ��¼
        /// </summary>
        /// <param name="PatientSourceID"></param>
        /// <returns></returns>
        public IModel GetModel(string PatientSourceID)
        {
            return dal.GetModel(PatientSourceID);
        }
    }
}