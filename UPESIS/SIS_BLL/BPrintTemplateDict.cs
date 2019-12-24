using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;

namespace SIS_BLL
{
    /// <summary>
    /// PRINT_TEMPLATE_DICTҵ���࣬����SIS��PACS�Ĵ�ӡģ���ֶα�
    /// </summary>
    public class BPrintTemplateDict
    {
        public BPrintTemplateDict()
        {
        }
        private static IPrintTemplateDict dal = DALFactory.DAL.CreateDPrintTemplateDict();

        /// <summary>
        /// Add����һ����ӡģ���ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update����ָ���Ĵ�ӡģ���ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ�����������Ĵ�ӡģ���ֵ��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ���Ĵ�ӡģ���ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������Ĵ�ӡģ���ֵ��¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ����ӡģ��ID�Ĵ�ӡģ���ֵ��¼
        /// </summary>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        public IModel GetModel(string Print_Template_Id)
        {
            return dal.GetModel(Print_Template_Id);
        }

        /// <summary>
        /// GetModel��ȡָ�������𡢼������Ĵ�ӡģ���ֵ��¼
        /// </summary>
        /// <param name="exam_class"></param>
        /// <param name="exam_sub_class"></param>
        /// <returns></returns>
        public IModel GetModel(string exam_class, string exam_sub_class)
        {
            return dal.GetModel(exam_class, exam_sub_class);
        }

        /// <summary>
        /// GetModel��ȡָ���еĴ�ӡģ���ֵ��¼
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public IModel GetModel(DataRow dr)
        {
            return dal.GetModel(dr); ;
        }
    }
}