using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace ILL
{
    /// <summary>
    /// 继承DBControl的抽象类IStat,用于操作SIS的统计
    /// </summary>
  public abstract class IStat:DBControl 
    {
      public IStat(ConParam cps)
        :base(cps)
      {
      }
      /// <summary>
      /// 诊断医师工作量统计
      /// </summary>
      public virtual DataSet queryDiagDocWork(string queryDate, string queryExamDoc)
      {
          return null;

      }
      /// <summary>
      /// 检查类别工作量统计
      /// </summary>
      public virtual DataSet queryExamClassWork(string queryDate, string queryExamClass)
      {
          return null;
      }

      /// <summary>
      /// 科室工作量统计
      /// </summary>
      public virtual DataSet queryDiagDeptWork(string queryDate, string queryDiag)
      {
          return null;
      }
      
      /// <summary>
      /// 病人数统计 
      /// </summary>
      public virtual DataSet queryPatientCount(string queryDate, string queryPatientSource)
      {
          return null;
      }
      /// <summary>
      ///  检查技师统计
      /// </summary>
      /// <param name="queryDate"></param>
      /// <param name="queryDoctor"></param>
      /// <returns></returns>
      public virtual DataSet queryExamDocWork(string queryDate, string queryDoctor)
      {
          return null;
      }
      public virtual DataSet queryAbnormal(string queryDate, string queryAbnormal)
      {
          return null;
      }
      public virtual DataSet queryApplyDept(string queryDate, string queryAbnormal)
      {
          return null;
      }
      
    }
}
