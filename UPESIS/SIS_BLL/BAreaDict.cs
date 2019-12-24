using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;

namespace SIS_BLL
{
    /// <summary>
    /// AREA_DICTҵ���࣬����SIS��PACS��Area_dict��
    /// </summary>
    public class BAreaDict
    {
        public BAreaDict()
        {
        }
        private static IAreaDict dal = DALFactory.DAL.CreateDAreaDict();

        /// <summary>
        /// Add����һ����������¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update����ָ������������¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ��������������������¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ������������¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ������������������¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡ����ָ��AREA_CODE����������¼
        /// </summary>
        /// <param name="areaCode"></param>
        /// <returns></returns>
        public IModel GetModel(string areaCode)
        {
            return dal.GetModel(areaCode);
        } 
    }
}
