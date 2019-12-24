using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SIS_Function
{
    /// <summary>
    /// 线程助手
    /// </summary>
   public class ThreadHelper
    {
        public ThreadHelper()
        {

        }
        ~ThreadHelper() { }

        #region 私有变量
        /// <summary>
        /// 当前线程        
        /// </summary>
        private Thread thrWork = null;
        /// <summary>
        /// 参数集合
        /// </summary>
        private List<object> objParams = new List<object>();
        /// <summary>
        /// 方法
        /// </summary>
        private Delegate Method = null ;

        /// <summary>
        /// 线程结束标识
        /// </summary>
        private bool overFlag = false;

        private string Error = string.Empty;

        #endregion

        #region 公共方法

        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="o"></param>
        public void SetParams(object o)
        {
            objParams.Add(o); 
        }
        /// <summary>
        /// 设置方法
        /// </summary>
        /// <param name="pMethod"></param>
        public void SetMethod(Delegate pMethod)
        {
            Method = pMethod;
        }
        public bool StartThread()
        {
            try
            {
                ThreadStart myThreadStart = new ThreadStart(this.ThreadProc);
                thrWork = new Thread(myThreadStart);
                thrWork.IsBackground = true;
                thrWork.Start();
                return true;
            }
            catch (ThreadStartException e)
            {
                Error = e.ToString();
                thrWork.Abort();
                return false;
            }
        }
        public void EndStart()
        {
            if (this.overFlag)
            {
                this.thrWork.Abort();
            }
        }
        /// <summary>
        /// 错误消息
        /// </summary>
        /// <returns></returns>
        public  string outError()
        {
            return this.Error;
        }
        #endregion

        #region 私有方法

       
        private void ThreadProc()
        {
            try
            {
                System.Collections.IEnumerator m_Enum = objParams.GetEnumerator();
                while (m_Enum.MoveNext())
                {
                    Method.DynamicInvoke(m_Enum.Current);
                }
            }
            catch (ThreadStateException err)
            {
                this.Error = err.ToString();
            }
            finally
            {
                this.overFlag = true;
            }
        }
        #endregion
    }

}


