using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;

using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// CHARGE_ITEM_DICT������SIS��PACS��
    /// </summary>
    public class BChargeItemDict
    {
        public BChargeItemDict()
        { }
        private static IChargeItemDict dal = DALFactory.DAL.CreateDChargeItemDict();

        /// <summary>
        /// Add����һ���շ���Ŀ�ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update����ָ�����շ���Ŀ�ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ�������������շ���Ŀ�ֵ��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// DeleteMore����ɾ���շ���Ŀ�ֵ��¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht );
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ�����շ���Ŀ�ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// ExistWhere��ѯ�Ƿ���ڷ���ָ��sql�����շ���Ŀ�ֵ��¼
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExistsWhere(string sql)
        {
            return dal.ExistsWhere (sql);
        }

        /// <summary>
        /// GetList��ȡ�����������շ���Ŀ�ֵ��¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetListMore������ȡ�����������շ���Ŀ�ֵ��¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetListMore(string where)
        {
            return dal.GetListMore(where);
        }

        /// <summary>
        /// ��ȡָ���շ���Ŀ�ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IModel GetModel(IModel model)
        {
            return dal.GetModel(model);
        }
    }
}
