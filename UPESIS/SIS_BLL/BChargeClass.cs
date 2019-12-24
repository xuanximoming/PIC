using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// CHARGE_CLASSҵ���࣬����SIS��PACS��CHARGE_CLASS��
    /// </summary>
    public class BChargeClass
    {
        public BChargeClass()
        {
        }
        private static IChargeClass dal = DALFactory.DAL.CreateDChargeClass();

        /// <summary>
        /// Add����һ���շ�����¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore���������շ�����¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public  int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Updage����ָ�����շ�����¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore���������շ�����¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public  int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Deleteɾ�������������շ�����¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ�����շ�����¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ�����������շ�����¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ���շ����ID������¼
        /// </summary>
        /// <param name="CHARGE_CLASS_ID"></param>
        /// <returns></returns>
        public IModel GetModel(string CHARGE_CLASS_ID)
        {
            return dal.GetModel(CHARGE_CLASS_ID);
        }
    }
}
