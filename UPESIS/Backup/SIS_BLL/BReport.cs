using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// REPORTҵ���࣬����SIS��PACS�ı����
    /// </summary>
    public class BReport
    {
        public BReport()
        {
        }

        private static IReport dal = DALFactory.DAL.CreateDReport();

        /// <summary>
        /// Add����һ��ָ���ı����¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update����ָ���ı����¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Updateָ��Adapter�ı����¼
        /// </summary>
        /// <param name="where"></param>
        /// <param name="dt_Report"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public int Update(string where, System.Data.DataTable dt_Report, System.Data.Odbc.OdbcDataAdapter sda)
        {
            return dal.UpdateTable(where, dt_Report, sda);
        }

        /// <summary>
        /// Deleteɾ�����������ı����¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ���ı����¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������ı����¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList��ȡָ��Adapter�ı����¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <param name="sda"></param>
        /// <returns></returns>
        public DataTable GetList(string where, ref  System.Data.Odbc.OdbcDataAdapter sda)
        {
            return dal.GetList(where, ref sda);
        }

        /// <summary>
        /// GetModel��ȡָ���������ŵı����¼
        /// </summary>
        /// <param name="ExamAccessionNum"></param>
        /// <returns></returns>
        public IModel GetModel(string ExamAccessionNum)
        {
            return dal.GetModel(ExamAccessionNum);
        }

    }
}