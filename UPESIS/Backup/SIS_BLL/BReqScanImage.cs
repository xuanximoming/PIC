using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;
using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// REQ_SCAN_IMAGE业务类，操作SIS和PACS的申请单图像表
    /// </summary>
    public class BReqScanImage
    {
        public BReqScanImage()
        {
        }
        private static IReqScanImage dal = DALFactory.DAL.CreateDReqScanImage();

        /// <summary>
        /// Add插入一条申请单图像记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore批量插入申请单图像记录
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update更新指定的申请单图像记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的申请单图像记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的申请单图像记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的申请单图像记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定检查申请号和图像索引的申请单图像记录
        /// </summary>
        /// <param name="ExamAccessionNum"></param>
        /// <param name="ImageIndex"></param>
        /// <returns></returns>
        public IModel GetModel(string ExamAccessionNum,string ImageIndex)
        {
            return dal.GetModel(ExamAccessionNum,ImageIndex);
        }

    }
}