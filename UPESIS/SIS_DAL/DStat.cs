using System;
using System.Text;
using ILL;
using System.Data;
using System.Data.Odbc;
using System.Collections;
using System.Collections.Generic;

namespace SIS_DAL
{
    /// <summary>
    /// SIS的统计
    /// </summary>
    public class DStat : IStat
    {
        
        private string querySql;	//查询语句
        private System.Data.DataSet queryDs;	//查询数据集
        public DStat()
            : base(GetConfig.GetSisConnStr())
        {

        }
        
        /// <summary>
        /// 诊断医师工作量统计
        /// </summary>
        /// <param name="queryDate"></param>
        /// <param name="queryExamDoc"></param>
        /// <returns></returns>
        public override DataSet queryDiagDocWork(string queryDate, string queryExamDoc)
        {
            this.querySql = "select b.TRANSCRIBER ,decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检') as Patient_Source,count(a.EXAM_ACCESSION_NUM  ) as examcount,sum(a.costs) as chargesum from worklist a,report b where a.EXAM_ACCESSION_NUM = b.EXAM_NO and b.report_date_time " + queryDate + queryExamDoc + "group by  b.TRANSCRIBER,decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检')";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        /// <summary>
        ///检查类别工作量统计 
        /// </summary>
        /// <param name="queryDate"></param>
        /// <param name="queryExamClass"></param>
        /// <returns></returns>
        public override DataSet queryExamClassWork(string queryDate, string queryExamClass)
        {
            this.querySql = " select a.exam_class,a.exam_sub_class,a.exam_items,count(a.exam_accession_num) as examcount,sum(a.costs) as chargesum from worklist a " +
                "where a.req_date_time " + queryDate /*+ queryExamClass */+ " group by a.exam_class,a.exam_sub_class,exam_items ";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        /// <summary>
        /// 科室工作量统计
        /// </summary>
        /// <param name="queryDate"></param>
        /// <param name="queryDeptName"></param>
        /// <returns></returns>
        public override DataSet queryDiagDeptWork(string queryDate, string queryDeptName)
        {
            this.querySql = "select a.exam_class as exam_group,decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检') as Patient_Source,count(a.exam_accession_num) as examcount,sum(a.costs) as chargesum from worklist a where  a.req_date_time " + queryDate + queryDeptName + " group by a.exam_class,decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检')";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        /// <summary>
        /// 病人明细统计 
        /// </summary>
        public override DataSet queryPatientCount(string queryDate, string queryPatientSource)
        {
            this.querySql = "select a.EXAM_CLASS ,a.PATIENT_LOCAL_ID ,a.PATIENT_ID ,a.PATIENT_NAME,sum(a.COSTS) as costs from worklist a "+
                "where  a.req_date_time " + queryDate + queryPatientSource + " group by a.EXAM_CLASS ,a.PATIENT_LOCAL_ID ,a.PATIENT_ID ,a.PATIENT_NAME ";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        /// <summary>
        /// 检查技师统计 
        /// </summary>
        public override DataSet queryExamDocWork(string queryDate, string queryDoctor)
        {
            this.querySql = "select a.EXAM_DOCTOR ,decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检') as Patient_Source,count(a.EXAM_ACCESSION_NUM  ) as examcount,sum(a.COSTS  ) as costsum from worklist a " +
                "where  a.req_date_time " + queryDate + queryDoctor + " group by a.EXAM_DOCTOR,decode(a.patient_source,'1','门诊','2','病房','3','外来','4','急诊','5','体检')";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        ///<summary>
        ///阴阳性病人数统计
        ///</summary>
        public override DataSet queryAbnormal(string queryDate, string queryAbnormal)
        {
            string tempTable = " select a.EXAM_CLASS as REQ_DEPT_NAME, decode(b.IS_ABNORMAL ,'0','阴性','1','阳性',null,'不明') as IS_ABNORMAL,count(1) as PERSONSUM,sum(a.costs) as costsum from  worklist a,report b " +
                  "where a.EXAM_ACCESSION_NUM = b.EXAM_NO and a.req_date_time " + queryDate + queryAbnormal + "  group by a.EXAM_CLASS, decode(b.IS_ABNORMAL ,'0','阴性','1','阳性',null,'不明')";
            this.querySql = "select a.req_dept_name as req_dept_name,IS_ABNORMAL,PERSONSUM,costsum,TO_CHAR(trunc(b.personsum/a.total,4)*100)||'%' as Percent from (select sum(personsum) as total,req_dept_name from  (" + tempTable
                + ") group by req_dept_name) a left join (" + tempTable + ") b on a.req_dept_name=b.req_dept_name";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }

        ///<summary>
        ///各科室申请单统计
        ///</summary>
        public override DataSet queryApplyDept(string queryDate, string queryAbnormal)
        {
            this.querySql = " select a.REQ_DEPT_NAME,a.exam_class,count(1) as PERSONSUM,sum(a.COSTS) as costsum "
                + " from  worklist a ,system_users b "
                + " where  a.report_doctor = b.doctor_id "
                + " and a.req_date_time " + queryDate + queryAbnormal
                + " group by REQ_DEPT_NAME,exam_class order by REQ_DEPT_NAME ";
            this.queryDs = GetDataSet(this.querySql);
            return this.queryDs;
        }
    }
}