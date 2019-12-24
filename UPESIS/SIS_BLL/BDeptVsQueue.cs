using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// DEPT_VS_QUEUEҵ���࣬����SIS��PACS�Ķ��������Ҷ��ձ�
    /// </summary>
    public class BDeptVsQueue
    {
        public BDeptVsQueue()
        {
        }
        private static IDeptVsQueue dal = DALFactory.DAL.CreateDDeptVsQueue();

        /// <summary>
        /// Add������������Ҷ��ռ�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update����ָ���Ķ��������Ҷ��ռ�¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ�����������Ķ��������Ҷ��ռ�¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ���Ķ��������Ҷ��ռ�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������Ķ��������Ҷ��ռ�¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ������ID�Ķ��������Ҷ��ռ�¼
        /// </summary>
        /// <param name="queueID"></param>
        /// <returns></returns>
        public IModel GetModel(string queueID)
        {
            return dal.GetModel(queueID);
        }

    }
}
