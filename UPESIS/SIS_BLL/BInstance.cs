using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// INSTANCEҵ���࣬����PACS��ͼ���
    /// </summary>
    public class BInstance
    {
        private IInstance dal = DALFactory.DAL.CreateDInstance();

        public BInstance()
        {

        }

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
        /// AddMore��������ͼ���¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
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
        /// UpdateMore��������ͼ���¼
        /// </summary>
        /// <param name="ht2"></param>
        /// <returns></returns>
        public int UpdateMore(Hashtable ht2)
        {
            return dal.UpdateMore(ht2);
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
        /// GetModel��ȡָ��ͼ��KEY��ͼ���¼
        /// </summary>
        /// <param name="IMG_EQUIPMENT_ID"></param>
        /// <returns></returns>
        public IModel GetModel(string INSTANCE_KEY)
        {
            return dal.GetModel(INSTANCE_KEY);
        }

    }
}
