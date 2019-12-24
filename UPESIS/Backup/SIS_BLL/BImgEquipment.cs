using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// IMG_EQUIPMENTҵ���࣬����SIS��Ӱ���豸��
    /// </summary>
   public class BImgEquipment
    {

       private  IImgEquipment dal = DALFactory.DAL.CreateDImgEquipment();

       public BImgEquipment()
       {

       }

       /// <summary>
       /// Add����һ��Ӱ���豸��¼
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public int Add(IModel model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// AddMore��������Ӱ���豸��¼
       /// </summary>
       /// <param name="ht"></param>
       /// <returns></returns>
       public int AddMore(Hashtable ht)
       {
           return dal.AddMore(ht);
       }

       /// <summary>
       /// Update����ָ����Ӱ���豸��¼
       /// </summary>
       /// <param name="model"></param>
       /// <param name="where"></param>
       /// <returns></returns>
       public int Update(IModel model, string where)
       {
           return dal.Update(model, where);
       }

       /// <summary>
       /// ��������Ӱ���豸��¼
       /// </summary>
       /// <param name="ht2"></param>
       /// <returns></returns>
       public  int UpdateMore(Hashtable ht2)
       {
           return dal.UpdateMore(ht2);
       }

       /// <summary>
       /// Deleteɾ������������Ӱ���豸��¼
       /// </summary>
       /// <param name="where"></param>
       /// <returns></returns>
       public int Delete(string where)
       {
           return dal.Delete(where);
       }

       /// <summary>
       /// Exists��ѯ�Ƿ����ָ����Ӱ���豸��¼
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public bool Exists(IModel model)
       {
           return dal.Exists(model);
       }

       /// <summary>
       /// GetList��ȡ����������Ӱ���豸��¼�б�
       /// </summary>
       /// <param name="where"></param>
       /// <returns></returns>
       public DataTable GetList(string where)
       {
           return dal.GetList(where);
       }

       /// <summary>
       /// GetListMore��ȡ����ָ��SQL����Ӱ���豸��¼�б�
       /// </summary>
       /// <param name="Sql"></param>
       /// <returns></returns>
       public  DataTable GetListMore(string Sql)
       {
           return dal.GetListMore(Sql);
       }

       /// <summary>
       /// GetModel��ȡָ����Ӱ���豸ID��Ӱ���豸��¼
       /// </summary>
       /// <param name="IMG_EQUIPMENT_ID"></param>
       /// <returns></returns>
       public IModel GetModel(string IMG_EQUIPMENT_ID)
       {
           return dal.GetModel(IMG_EQUIPMENT_ID);
       }

    }
}
