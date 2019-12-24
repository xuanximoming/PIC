using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;

namespace SIS_BLL
{
    /// <summary>
    /// PRINT_TEMPLATE_DICT业务类，操作SIS和PACS的打印模板字段表
    /// </summary>
    public class BPrintTemplateDict
    {
        public BPrintTemplateDict()
        {
        }
        private static IPrintTemplateDict dal = DALFactory.DAL.CreateDPrintTemplateDict();

        /// <summary>
        /// Add插入一条打印模板字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update更新指定的打印模板字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的打印模板字典记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的打印模板字典记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的打印模板字典记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定打印模板ID的打印模板字典记录
        /// </summary>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        public IModel GetModel(string Print_Template_Id)
        {
            return dal.GetModel(Print_Template_Id);
        }

        /// <summary>
        /// GetModel获取指定检查类别、检查子类的打印模板字典记录
        /// </summary>
        /// <param name="exam_class"></param>
        /// <param name="exam_sub_class"></param>
        /// <returns></returns>
        public IModel GetModel(string exam_class, string exam_sub_class)
        {
            return dal.GetModel(exam_class, exam_sub_class);
        }

        /// <summary>
        /// GetModel获取指定行的打印模板字典记录
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public IModel GetModel(DataRow dr)
        {
            return dal.GetModel(dr); ;
        }
    }
}