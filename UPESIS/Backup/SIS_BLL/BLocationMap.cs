using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;


namespace SIS_BLL
{
    /// <summary>
    /// LOCATION_MAPҵ���࣬����SIS�Ķ�λͼ���¼��
    /// </summary>
    public class BLocationMap
    {
        public BLocationMap()
        {
        }
        private static ILocationMap dal = DALFactory.DAL.CreateDLocationMap();

        /// <summary>
        /// Add����һ����λͼ���¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update����ָ���Ķ�λͼ���¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ�����������Ķ�λͼ���¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ���Ķ�λͼ���¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������Ķ�λͼ���¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ��ͼ��ID�Ķ�λͼ���¼
        /// </summary>
        /// <param name="MapId"></param>
        /// <returns></returns>
        public IModel GetModel(string MapId)
        {
            return dal.GetModel(MapId);
        }

        /// <summary>
        /// GetModel��ȡָ���еĶ�λͼ���¼
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public IModel GetModel(DataRow dr)
        {
            return dal.GetModel(dr); ;
        }
    }
}