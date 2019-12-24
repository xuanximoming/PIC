using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;


namespace SIS_BLL
{
    /// <summary>
    /// BESPEAKҵ���࣬����SIS��BESPEAK��
    /// </summary>
    public class BBespeak
    {
        public BBespeak()
        {
        }

        private static IBespeak dal = DALFactory.DAL.CreateDBespeak();

        /// <summary>
        /// Add����һ��ԤԼ���˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update����ָ����ԤԼ���˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ������������ԤԼ���˼�¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ����ԤԼ���˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡָ��ԤԼID��ԤԼ���˼�¼�б�
        /// </summary>
        /// <param name="BESPEAK_ID"></param>
        /// <returns></returns>
        public DataTable GetList(string BESPEAK_ID)
        {
            return dal.GetList(BESPEAK_ID);
        }

    }
}
