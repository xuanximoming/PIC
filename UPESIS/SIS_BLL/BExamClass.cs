using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;
using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// EXAM_CLASSҵ���࣬����SIS��PACS�ļ������
    /// </summary>
    public class BExamClass
    {
        public BExamClass()
        {
        }
        private static IExamClass dal = DALFactory.DAL.CreateDExamClass();

        /// <summary>
        /// Add����һ���������¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore��������������¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update����ָ���ļ������¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// UpdateMore�������¼������¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        /// <summary>
        /// Deleteɾ�����������ļ������¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// DeleteMore����ɾ���������¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ���ļ������¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������ļ������¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList2��ȡ���������ļ������¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetExamClass��ȡ���������ļ������¼�ļ�������
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetExamClass(string where)
        {
            return dal.GetExamClass(where);
        }

        /// <summary>
        /// GetModel��ȡָ�����������ơ��������ļ������¼
        /// </summary>
        /// <param name="examClass"></param>
        /// <param name="examSubClass"></param>
        /// <returns></returns>
        public IModel GetModel(string examClass, string examSubClass)
        {
            return dal.GetModel(examClass, examSubClass);
        }

        /// <summary>
        /// GetData��ȡ���м������¼
        /// </summary>
        /// <returns></returns>
        public DataSet GetData()
        {
            return dal.GetData();
        }
    }
}
