using System;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;
using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// REQ_SCAN_IMAGEҵ���࣬����SIS��PACS�����뵥ͼ���
    /// </summary>
    public class BReqScanImage
    {
        public BReqScanImage()
        {
        }
        private static IReqScanImage dal = DALFactory.DAL.CreateDReqScanImage();

        /// <summary>
        /// Add����һ�����뵥ͼ���¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// AddMore�����������뵥ͼ���¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        /// <summary>
        /// Update����ָ�������뵥ͼ���¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Deleteɾ���������������뵥ͼ���¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ����ָ�������뵥ͼ���¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ�������������뵥ͼ���¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetModel��ȡָ���������ź�ͼ�����������뵥ͼ���¼
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