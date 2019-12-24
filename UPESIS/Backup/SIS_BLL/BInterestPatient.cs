using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// INTEREST_PATIENTҵ���࣬����SIS�ĸ���Ȥ�����б�
    /// </summary>
    public class BInterestPatient
    {
        public BInterestPatient()
        {
        }

        private static IInterestPatient dal = DALFactory.DAL.CreateDInterestPatient();

        /// <summary>
        /// Add����һ������Ȥ���˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Updateָ���ĸ���Ȥ���˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ�����������ĸ���Ȥ���˼�¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѧУ�Ƿ����ָ���ĸ���Ȥ���˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������ĸ���Ȥ���˼�¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList2��ȡ���������ĸ���Ȥ���˼�¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetModel��ȡָ���ڵ�ID�ĸ���Ȥ���˼�¼
        /// </summary>
        /// <param name="nodeid"></param>
        /// <returns></returns>
        public IModel GetModel(string nodeid)
        {
            return dal.GetModel(nodeid);
        }
    }
}