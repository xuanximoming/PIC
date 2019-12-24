using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;
using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// USERҵ���࣬����SIS��SYSTEM_USERS���PACS��FPAX_USERS��
    /// </summary>
    public class BUser
    {

        public BUser()
        {
        }
        private static IUser dal = DALFactory.DAL.CreateDUser();

        /// <summary>
        /// Add����һ���û���¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore���������û���¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update����ָ�����û���¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore���������û���¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Deleteɾ�������������û���¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// DeleteMore����ɾ���û���¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ�����û���¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ�����������û���¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetListMultiRole��ȡ���������Ķ��ɫ�û���¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetListMultiRole(string where)
        {
            return dal.GetListMultiRole(where);
        }

        /// <summary>
        /// GetModel��ȡָ��ҽ��ID���û���¼
        /// </summary>
        /// <param name="DoctorID"></param>
        /// <returns></returns>
        public IModel GetModel(string DoctorID)
        {
            return dal.GetModel(DoctorID);
        }

        /// <summary>
        /// GetData��ȡ�������������ظ��û���¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataSet GetData(string where)
        {
            return dal.GetData(where);
        }
    }
}
