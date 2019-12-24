using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// IMAGE业务类，操作SIS的图像表
    /// </summary>
    public class BImage
    {
        public BImage()
        {
        }

        private static IImage dal = DALFactory.DAL.CreateDImage();

        /// <summary>
        /// Add插入一条图像记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Add插入一条指定ImageId的图像记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public int Add(IModel model,ref int imageId)
        {
            return dal.Add(model,ref imageId);
        }

        /// <summary>
        /// Update更新指定的图像记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delete删除符合条件的图像记录
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists查询是否存在指定的图像记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList获取符合条件的图像记录列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel获取指定ImageId的图像记录
        /// </summary>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        public IModel GetModel(string ImageID)
        {
            return dal.GetModel(ImageID);
        }

        /// <summary>
        /// GetModel获取指定行的图像记录
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public IModel GetModel(DataRow dr)
        {
            return dal.GetModel(dr); ;
        }
    }
}
