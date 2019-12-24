using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;


namespace SIS_BLL
{
    public class BLocationMapInf
    {
        /// <summary>
        /// LOCATION_MAP_INFҵ���࣬����SIS�Ķ�λͼ����Ϣ��
        /// </summary>
        public BLocationMapInf()
        {
        }
        private static ILocationMapInf dal = DALFactory.DAL.CreateDLocationMapInf();

        /// <summary>
        /// Add����һ����λͼ����Ϣ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update����ָ���Ķ�λͼ����Ϣ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ�����������Ķ�λͼ����Ϣ��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ���Ķ�λͼ����Ϣ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������Ķ�λͼ����Ϣ��¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ����λͼ����ϢID�Ķ�λͼ����Ϣ��¼
        /// </summary>
        /// <param name="LOATION_MAP_INF_ID"></param>
        /// <returns></returns>
        public IModel GetModel(string LOATION_MAP_INF_ID)
        {
            return dal.GetModel(LOATION_MAP_INF_ID);
        }
    }
}