using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace PACS_DAL
{
    /// <summary>
    /// fpax_users,即fpax用户表
    /// </summary>
    class DClinicDoctorDict : IClinicDoctorDict
    {
        private string strSql;
        private string TableName = "fpax_users";
        public DClinicDoctorDict():base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// 获取符合条件的用户列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public override DataTable GetList(string where)
        {
            strSql = "select * from " + TableName + " where " + where;
            return GetDataTable(strSql);
        }
    }
}
