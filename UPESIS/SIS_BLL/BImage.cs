using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// IMAGEҵ���࣬����SIS��ͼ���
    /// </summary>
    public class BImage
    {
        public BImage()
        {
        }

        private static IImage dal = DALFactory.DAL.CreateDImage();

        /// <summary>
        /// Add����һ��ͼ���¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Add����һ��ָ��ImageId��ͼ���¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="imageId"></param>
        /// <returns></returns>
        public int Add(IModel model,ref int imageId)
        {
            return dal.Add(model,ref imageId);
        }

        /// <summary>
        /// Update����ָ����ͼ���¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ������������ͼ���¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ����ͼ���¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ����������ͼ���¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ��ImageId��ͼ���¼
        /// </summary>
        /// <param name="ImageID"></param>
        /// <returns></returns>
        public IModel GetModel(string ImageID)
        {
            return dal.GetModel(ImageID);
        }

        /// <summary>
        /// GetModel��ȡָ���е�ͼ���¼
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public IModel GetModel(DataRow dr)
        {
            return dal.GetModel(dr); ;
        }
    }
}
