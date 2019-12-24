using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL; 

namespace SIS_BLL
{
    /// <summary>
    /// REPORT_RELATIONҵ���࣬����SIS��һ�廯�����
    /// </summary>
    public class BReportRelation
    {
        public BReportRelation()
        {
        }

        private static IReportRelation dal = DALFactory.DAL.CreateDReportRelation();

        /// <summary>
        /// Add����һ��һ�廯�����¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Updateָ����һ�廯�����¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ������������һ�廯�����¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ����һ�廯�����¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ����������һ�廯�����¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }
    }
}