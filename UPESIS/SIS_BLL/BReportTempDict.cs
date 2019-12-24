using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;
using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// REPORT_TEMP_DICTҵ���࣬����SIS�ı���ģ���ֵ��
    /// </summary>
    public class BReportTempDict
    {
        public BReportTempDict()
        {
        }

        private static IReportTempDict dal = DALFactory.DAL.CreateDReportTempDict();

        /// <summary>
        /// Add����һ������ģ���ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// Update����ָ���ı���ģ���ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        /// <summary>
        /// Delteɾ�����������ı���ģ���ֵ��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        /// <summary>
        /// Exists��ѯ�Ƿ������ָ���ı���ģ���ֵ��¼
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        /// <summary>
        /// GetList��ȡ���������ı���ģ���ֵ��¼�б�
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        /// <summary>
        /// GetList2��ȡ���������ı���ģ���ֵ��¼
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable GetList2(string where)
        {
            return dal.GetList2(where);
        }

        /// <summary>
        /// GetTabel��ȡָ��SQL���ı���ģ���ֵ��¼�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet GetTable(string sql)
        {
            return dal.GetTable(sql);
        }

        /// <summary>
        /// GetModel��ȡָ���ڵ�ID�ı���ģ���ֵ��¼
        /// </summary>
        /// <param name="nodeid"></param>
        /// <returns></returns>
        public IModel GetModel(string nodeid)
        {
            return dal.GetModel(nodeid);
        }

        /// <summary>
        /// DeleteMore����ɾ������ģ���ֵ��¼
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht);
        }

        /// <summary>
        /// GetModels������ȡ����ģ���ֵ��¼
        /// </summary>
        /// <param name="NODE_ID"></param>
        /// <returns></returns>
        public IModel[] GetModels(string NODE_ID)
        {
            return dal.GetModels(NODE_ID);
        }

        /// <summary>
        /// AddMore�������뱨��ģ���ֵ��¼
        /// </summary>
        /// <param name="rptTemp"></param>
        /// <returns></returns>
        public int AddMore(object rptTemp)
        {
            return dal.AddMore(rptTemp);
        }
    }
}