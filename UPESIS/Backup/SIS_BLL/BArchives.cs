using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace SIS_BLL
{
    /// <summary>
    /// ARCHIVESҵ���࣬�԰���SIS��Archives��PACS��Patient_inf����в���
    /// </summary>
    public class BArchives
    {
        public BArchives()
        {
        }       
        private IArchives dal = DALFactory.DAL.CreateDArchives();

        /// <summary>
        /// Add����һ�����˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update����ָ���Ĳ��˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model,where);
        }

        /// <summary>
        /// Deleteɾ�����������Ĳ��˼�¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ���Ĳ��˼�¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������Ĳ��˼�¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ������ID�ŵĲ��˼�¼
        /// </summary>
        /// <param name="patientID"></param>
        /// <returns></returns>
        public IModel GetModel(string patientID)
        {
            return dal.GetModel(patientID);
        }
    }
}
