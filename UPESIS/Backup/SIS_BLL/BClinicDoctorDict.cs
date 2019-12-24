using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ILL;


namespace SIS_BLL
{
    /// <summary>
    /// CLINIC_DOCTOR_DICTҵ���࣬����SIS���ٴ�ҽ���ֵ��
    /// </summary>
    public class BClinicDoctorDict
    {
        public BClinicDoctorDict()
        {
        }
        private static IClinicDoctorDict dal = DALFactory.DAL.CreateDClinicDoctorDict();

        /// <summary>
        /// Add����ָ�����ٴ�ҽ���ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore���������ٴ�ҽ���ֵ��¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update����ָ�����ٴ�ҽ���ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore���������ٴ�ҽ���ֵ��¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Deleteɾ�������������ٴ�ҽ���ֵ��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ�����ٴ�ҽ���ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ�����������ٴ�ҽ���ֵ��¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// ��ȡ�����������ٴ�ҽ���ֵ��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetModel��ȡָ���ٴ�ҽ��ID���ٴ�ҽ���ֵ��¼
        /// </summary>
        /// <param name="CLINC_DOCTOR_ID"></param>
        /// <returns></returns>
        public IModel GetModel(string CLINC_DOCTOR_ID)
        {
            return dal.GetModel(CLINC_DOCTOR_ID);
        }
    }
}
