using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

using System.Collections;

namespace SIS_BLL
{
    /// <summary>
    /// IMG_EQUIPMENT业务类，操作SIS的影像设备表
    /// </summary>
   public class BImgEquipment
    {

       private  IImgEquipment dal = DALFactory.DAL.CreateDImgEquipment();

       public BImgEquipment()
       {

       }

       /// <summary>
       /// Add插入一条影像设备记录
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public int Add(IModel model)
       {
           return dal.Add(model);
       }

       /// <summary>
       /// AddMore批量插入影像设备记录
       /// </summary>
       /// <param name="ht"></param>
       /// <returns></returns>
       public int AddMore(Hashtable ht)
       {
           return dal.AddMore(ht);
       }

       /// <summary>
       /// Update更新指定的影像设备记录
       /// </summary>
       /// <param name="model"></param>
       /// <param name="where"></param>
       /// <returns></returns>
       public int Update(IModel model, string where)
       {
           return dal.Update(model, where);
       }

       /// <summary>
       /// 批量更新影像设备记录
       /// </summary>
       /// <param name="ht2"></param>
       /// <returns></returns>
       public  int UpdateMore(Hashtable ht2)
       {
           return dal.UpdateMore(ht2);
       }

       /// <summary>
       /// Delete删除符合条件的影像设备记录
       /// </summary>
       /// <param name="where"></param>
       /// <returns></returns>
       public int Delete(string where)
       {
           return dal.Delete(where);
       }

       /// <summary>
       /// Exists查询是否存在指定的影像设备记录
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public bool Exists(IModel model)
       {
           return dal.Exists(model);
       }

       /// <summary>
       /// GetList获取符合条件的影像设备记录列表
       /// </summary>
       /// <param name="where"></param>
       /// <returns></returns>
       public DataTable GetList(string where)
       {
           return dal.GetList(where);
       }

       /// <summary>
       /// GetListMore获取符合指定SQL语句的影像设备记录列表
       /// </summary>
       /// <param name="Sql"></param>
       /// <returns></returns>
       public  DataTable GetListMore(string Sql)
       {
           return dal.GetListMore(Sql);
       }

       /// <summary>
       /// GetModel获取指定的影像设备ID的影像设备记录
       /// </summary>
       /// <param name="IMG_EQUIPMENT_ID"></param>
       /// <returns></returns>
       public IModel GetModel(string IMG_EQUIPMENT_ID)
       {
           return dal.GetModel(IMG_EQUIPMENT_ID);
       }

    }
}
