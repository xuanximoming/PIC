using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// SYSTEM_FUNCTIONҵ���࣬����SIS��ϵͳ���ܱ�
    /// </summary>
    public class BSystemFun
    {
        public BSystemFun()
        {
        }

        private static ISystemFun dal = DALFactory.DAL.CreateDSystemFun();

        /// <summary>
        /// Add����һ��ϵͳ���ܼ�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }


        /// <summary>
        /// AddMore��������ϵͳ���ܼ�¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int  AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update����ָ����ϵͳ���ܼ�¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore��������ϵͳ���ܼ�¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Deleteɾ������������ϵͳ���ܼ�¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ����ϵͳ���ܼ�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ����������ϵͳ���ܼ�¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList��ȡָ��ID��ϵͳ���ܼ�¼
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable GetList(int id)
        {
            return dal.GetList(id);
        }

        /// <summary>
        /// GetListChild��ȡ����������ϵͳ���ܼ�¼���б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetListChild(string where)
        {
            return dal.GetListChild(where);
        }

        /// <summary>
        /// GetModel��ȡָ��MODEL_ID��ϵͳ���ܼ�¼
        /// </summary>
        /// <param name="MODEL_ID"></param>
        /// <returns></returns>
        public IModel GetModel(string MODEL_ID)
        {
            return dal.GetModel(MODEL_ID);
        }

    }
}