using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;
using System.Collections;
namespace SIS_BLL
{
    /// <summary>
    /// EXAM_ITEM_DICTҵ���࣬����SIS��PACS�ļ����Ŀ�ֵ��
    /// </summary>
    public class BExamItemDict
    {
        public BExamItemDict()
        {
        }
        private static IExamItemDict dal = DALFactory.DAL.CreateDExamItemDict();

        /// <summary>
        /// Add����һ�������Ŀ�ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore������������Ŀ�ֵ��¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update����ָ���ļ����Ŀ�ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore�������¼����Ŀ�ֵ��¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Deleteɾ�����������ļ����Ŀ�ֵ��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ���ļ����Ŀ�ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������ļ����Ŀ�ֵ��¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ�������ĿCODE�ͼ������ļ����Ŀ�ֵ��¼
        /// </summary>
        /// <param name="ExamItemCode"></param>
        /// <param name="ExamSubClass"></param>
        /// <returns></returns>
        public IModel GetModel(string ExamItemCode, string ExamSubClass)
        {
            return dal.GetModel(ExamItemCode, ExamSubClass);
        }

    }
}
