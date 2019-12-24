using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ILL;
using System.Data;

namespace SIS_BLL
{
    /// <summary>
    /// STAT类，负责统计工作
    /// </summary>
    public class BStat
    {
      private static IStat dal = DALFactory.DAL.CreateDStat();
      public BStat()
      {
      }

      /// <summary>
      /// 诊断医师工作量统计
      /// </summary>
      /// <param name="queryDate"></param>
      /// <param name="queryExamDoc"></param>
      /// <returns></returns>
      public DataSet queryDiagDocWork(string queryDate, string queryExamDoc)
      {
          return dal.queryDiagDocWork(queryDate, queryExamDoc);
      }

      /// <summary>
      /// 检查类别工作量统计
      /// </summary>
      /// <param name="queryDate"></param>
      /// <param name="queryExamClass"></param>
      /// <returns></returns>
      public DataSet queryExamClassWork(string queryDate, string queryExamClass)
      {
          return dal.queryExamClassWork(queryDate, queryExamClass);   
      }

      /// <summary>
      /// 科室工作量统计
      /// </summary>
      /// <param name="queryDate"></param>
      /// <param name="queryDeptName"></param>
      /// <returns></returns>
      public DataSet queryDiagDeptWork(string queryDate, string queryDeptName)
      {
          return dal.queryDiagDeptWork(queryDate, queryDeptName);
      }

      /// <summary>
      /// 检查病人明细统计 
      /// </summary>
      public DataSet queryPatientCount(string queryDate, string queryPatientSource)
      {
          return dal.queryPatientCount(queryDate, queryPatientSource);
      }
      
       /// <summary>
       /// 检查技师统计 
       /// </summary>
      public DataSet queryExamDocWork(string queryDate, string queryDoctor)
      {
          return dal.queryExamDocWork(queryDate, queryDoctor);
      }

      ///<summary>
      ///阴阳性病人数统计
      ///</summary>
      public DataSet queryAbnormal(string queryDate,string queryAbnormal)
      {
          return dal.queryAbnormal(queryDate,queryAbnormal );
      }

      ///<summary>
      ///各科室申请单统计
      ///</summary>
      public DataSet queryApplyDept(string queryDate, string queryAbnormal)
      {
          return dal.queryApplyDept(queryDate, queryAbnormal);
      }
      
    }
}