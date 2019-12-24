using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

using System.Collections;

namespace SIS_BLL
{
    public class BQcFilm
    {
        public BQcFilm()
        {
        }
        private static IQcFilm dal = DALFactory.DAL.CreateDQcFilm();
        
        public int Add(IModel model)
        {
            return dal.Add(model);
        }

        public int AddMore(Hashtable ht)
        {
            return dal.AddMore(ht);
        }

        public int Update(IModel model, string where)
        {
            return dal.Update(model, where);
        }

        public int UpdateMore(Hashtable ht)
        {
            return dal.UpdateMore(ht);
        }

        public int Delete(string where)
        {
            return dal.Delete(where);
        }

        public int DeleteMore(Hashtable ht)
        {
            return dal.DeleteMore(ht );
        }

        public bool Exists(IModel model)
        {
            return dal.Exists(model);
        }

        public DataTable GetList(string where)
        {
            return dal.GetList(where);
        }

        public IModel GetModel(string queueID)
        {
            return dal.GetModel(queueID);
        }

    }
}
