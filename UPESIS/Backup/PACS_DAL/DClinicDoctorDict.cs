using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ILL;

namespace PACS_DAL
{
    /// <summary>
    /// fpax_users,��fpax�û���
    /// </summary>
    class DClinicDoctorDict : IClinicDoctorDict
    {
        private string strSql;
        private string TableName = "fpax_users";
        public DClinicDoctorDict():base(GetConfig.GetPacsConnStr())
        {
        }

        /// <summary>
        /// ��ȡ�����������û��б�
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
