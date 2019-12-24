using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// QUEUE_INFOҵ���࣬����SIS��PACS�Ķ�����Ϣ��
    /// </summary>
    public class BQueueInfo
    {
        public BQueueInfo()
        {
        }
        private static IQueueInfo dal = DALFactory.DAL.CreateDQueueInfo();

        /// <summary>
        /// Add����һ��������Ϣ���˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update����ָ���Ķ�����Ϣ���˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ�����������Ķ�����Ϣ���˼�¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ���Ķ�����Ϣ���˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������Ķ�����Ϣ���˼�¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ���ļ������ŵĶ�����Ϣ���˼�¼
        /// </summary>
        /// <param name="ExamAccessionNum"></param>
        /// <returns></returns>
        public IModel GetModel(string ExamAccessionNum)
        {
            return dal.GetModel(ExamAccessionNum);
        }

        /// <summary>
        /// GetQueue��ȡ��ȡ���ظ��ķ��������Ķ�����Ϣ���˼�¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetQueue(string where)
        {
            return dal.GetQueue(where);
        }
    }
}