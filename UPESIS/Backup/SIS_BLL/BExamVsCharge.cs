using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;
using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// EXAM_VS_CHARGEҵ���࣬����SIS��PACS�ļ���շѶ��ձ�
    /// </summary>
    public class BExamVsCharge
    {
        private static IExamVsCharge dal = DALFactory.DAL.CreateDExamVsCharge();

        /// <summary>
        /// Add����һ������շѶ��ռ�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore�����������շѶ��ռ�¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update����ָ���ļ���շѶ��ռ�¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ�����������ļ���շѶ��ռ�¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ���ڵļ���շѶ��ռ�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������ļ���շѶ��ռ�¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList2��ȡ���������ļ���շѶ��ռ�¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetModel��ȡָ���ļ����ĿCode���շ���Ŀ��ŵļ���շѶ��ռ�¼
        /// </summary>
        /// <param name="ExamItemCode"></param>
        /// <param name="ChargeItemNo"></param>
        /// <returns></returns>
        public IModel GetModel(string ExamItemCode, string ChargeItemNo)
        {
            return dal.GetModel(ExamItemCode, ChargeItemNo);
        }
    }
}
