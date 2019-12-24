using System;
using System.Collections.Generic;
using System.Text;
using SIS_BLL;
using SIS_Model;
using ILL;

namespace SIS.RegisterCls
{
    /// <summary>
    /// 获取Patient_Local_ID，有则取出。无则生成新的
    /// </summary>
    public class LocalIdCreater
    {
        private string LocalIdClass = "",PatientLocalId = "";
        private int? ExamTimes;
        private string examClass,examSubClass,patientId;
        public string ExamClass
        {
            get { return this.examClass; }
            set { this.examClass = value; }
        }
        public string ExamSubClass
        {
            get { return this.examSubClass; }
            set { this.examSubClass = value; }
        }
        public string PatientId
        {
            get { return this.patientId; }
            set { this.patientId = value; }
        }
        private int LocalIdMaxIndex = -1;      //配置文件中LocalIdMax中当前检查子类对应的最大流水号的索引
        private int LocalIdMaxValue = -1;      //配置文件中LocalIdMax中当前检查子类对应的最大流水号
        private string YearHeader = "";        //年龄标头
        private string ZeroBits = "";          //检查号位数
        private BPatientInfLocalId bPatientInfLocalId = new BPatientInfLocalId();
        public IModel iPatientInfLocalId;


        public LocalIdCreater()
        {
            this.YearHeader = getYearHeader();
            this.ZeroBits = getZeroBits();
            iPatientInfLocalId = DALFactory.Model.CreateMPatientInfLocalId();
        }

        public void Init()
        {
            this.LocalIdMaxIndex = -1;
            this.LocalIdMaxValue = -1;
        }
        
        /// <summary>
        /// 获取病人检查号
        /// </summary>
        /// <param name="Mode">当前登记模式</param>
        public void GetPatientLocalID(string Mode)
        {
            string localId = "";
            bool isExit = false;//PATIENT_INF_LOCAL_ID表中是否存在该病人对该类检查类别和检查子类的记录
            localId = this.SelectPatientInfLocalId(ref isExit);
            if (GetConfig.LM_LocalIdMode != 0 && Mode != "6")//检查号模式不与病人绑定和当前登记模式不为编辑模式的初始化状态
                localId = this.NewPatietnLocalId(isExit);
            if (Mode != "10" && Mode != "11")//当前登记模式不为住院检查申请和住院登记
            {
                if (Mode == "4")//当前登记模式为绿色通道登记
                    this.SetPatientInfLocalId(true, localId);
                else
                    this.SetPatientInfLocalId(GetConfig.RM_OPDIsConfirmed, localId);//根据门诊默认是否收费来设置PATIENT_INF_LOCAL_ID表
            }
            else
            {
                this.SetPatientInfLocalId(GetConfig.RM_INPIsConfirmed, localId);//根据住院默认是否收费来设置PATIENT_INF_LOCAL_ID表
            }
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MPatientInfLocalId smPatientInfLocalId = (SIS_Model.MPatientInfLocalId)this.iPatientInfLocalId;
                    smPatientInfLocalId.PATIENT_LOCAL_ID = this.PatientLocalId;
                    smPatientInfLocalId.EXAM_TIMES = this.ExamTimes;
                    break;
                case "PACS":
                    PACS_Model.MPatientInfLocalId pmPatientInfLocalId = (PACS_Model.MPatientInfLocalId)this.iPatientInfLocalId;
                    pmPatientInfLocalId.PATIENT_LOCAL_ID = this.PatientLocalId;
                    pmPatientInfLocalId.EXAM_TIMES = this.ExamTimes;
                    break;
            }
        }

        /// <summary>
        /// 更新或插入PATIENT_INF_LOCAL_ID表
        /// </summary>
        /// <param name="Is_Confimed"></param>
        /// <param name="localId"></param>
        public void SetPatientInfLocalId(bool Is_Confimed,string localId)
        {
            if (localId != "")
            {
                PatientLocalId = localId;
                if (Is_Confimed)//默认已收费
                {
                    this.ExamTimes = this.UpdateExamTimes(this.ExamTimes);
                }
            }
            else
            {
                if (Is_Confimed)//默认已收费
                {
                    PatientLocalId = this.InsertPatientInfLocalId(true);
                }
                else
                {
                    PatientLocalId = this.InsertPatientInfLocalId(false);
                }
            }
        }

        /// <summary>
        /// 获取LOCAL_ID_CLASS和PATIENT_INF_LOCAL_ID表中的PATIENT_LOCAL_ID、EXAM_TIMES
        /// </summary>
        public string SelectPatientInfLocalId(ref bool isExit)
        {
            BExamClass bExamClass = new BExamClass();
            IModel iExamClass = bExamClass.GetModel(this.examClass, this.examSubClass);
            string localId = "";
            isExit = false;
            try
            {
                switch (GetConfig.DALAndModel)
                {
                    case "SIS":
                        SIS_Model.MExamClass smExamClass = (SIS_Model.MExamClass)iExamClass;
                        this.LocalIdClass = smExamClass.LOCAL_ID_CLASS;
                        this.iPatientInfLocalId = bPatientInfLocalId.GetModel(this.patientId, this.LocalIdClass);
                        if (iPatientInfLocalId != null)
                        {
                            SIS_Model.MPatientInfLocalId smPatientInfLocalId = (SIS_Model.MPatientInfLocalId)this.iPatientInfLocalId;
                            localId = smPatientInfLocalId.PATIENT_LOCAL_ID;
                            ExamTimes = smPatientInfLocalId.EXAM_TIMES;
                            isExit = true;
                        }
                        break;
                    case "PACS":
                        PACS_Model.MExamClass pmExamClass = (PACS_Model.MExamClass)iExamClass;
                        this.LocalIdClass = pmExamClass.LOCAL_ID_CLASS;
                        this.iPatientInfLocalId = bPatientInfLocalId.GetModel(this.patientId, this.LocalIdClass);
                        if (iPatientInfLocalId != null)
                        {
                            PACS_Model.MPatientInfLocalId pmPatientInfLocalId = (PACS_Model.MPatientInfLocalId)this.iPatientInfLocalId;
                            localId = pmPatientInfLocalId.PATIENT_LOCAL_ID;
                            ExamTimes = pmPatientInfLocalId.EXAM_TIMES;
                            isExit = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "提示");
            }
            return localId;
        }

        /// <summary>
        /// 生成新的检查号（不与病人绑定）
        /// </summary>
        /// <param name="isExit"></param>
        /// <returns></returns>
        public string NewPatietnLocalId(bool isExit)
        {
            string localId = "";
            if (GetConfig.LM_IsLocalMode == 0)//若是网络版(流水号断号)
            {
                if (!isExit)//PATIENT_INF_LOCAL_ID表中不存在该病人对该类检查类别和检查子类的记录，即为病人新做的检查。
                    localId = this.InsertPatientInfLocalId(true);
                else
                {
                    string seq = "EXAM_" + LocalIdClass + "_SEQ";
                    //switch (GetConfig.DALAndModel)
                    //{
                    //    case "SIS":
                    //        seq = "SEQ_EXAM_" + LocalIdClass;
                    //        break;
                    //    case "PACS":
                    //        seq = "EXAM_" + LocalIdClass + "_SEQ";
                    //        break;
                    //}
                    BGetSeqValue bGetAnyId = new BGetSeqValue(GetConfig.DALAndModel,seq);
                    localId = bGetAnyId.GetSeqValue();//取出相应序列的值
                }
                localId = this.CreateLocalId(localId, true);
            }
            else
            {
                if (!isExit)
                {
                    this.InsertPatientInfLocalId(true);
                }
                localId = this.CreateLocalId("", false);
            }
            return localId;
        }

        /// <summary>
        /// 检查号生成
        /// </summary>
        /// <param name="localId">序列生成的检查号</param>
        /// <param name="isServer">若是网络版(流水号断号)</param>
        /// <returns></returns>
        public string CreateLocalId(string localId, bool isServer)
        {
            string[] LocalIdMax = GetConfig.LM_LocalIdMax.Split(',');
            if (System.DateTime.Now.Year.ToString() != GetConfig.LM_LocalYear)//当前系统时间年值不等于配置文件中的年值
            {
                if (!isServer)
                {
                    string Maxstr = "";
                    for (int j = 0; j < LocalIdMax.Length; j++)
                    {
                        Maxstr += "0" + ",";
                        LocalIdMax[j] = "0";
                    }
                    GetConfig.SetLM_LocalIdMax(Maxstr.TrimEnd(','));
                }
                GetConfig.SetLM_LocalYear(System.DateTime.Now.Year.ToString());//更新配置文件中的年值为当前系统时间年值
            }
            string Header = "";
            int Id = localId == "" ? 0 : Convert.ToInt32(localId);
            string[] LocalIdSubClass = GetConfig.LM_LocalIdSubClass.Split(',');//检查号对应的检查子类
            string[] LocalIdHeader = GetConfig.LM_LocalIdHeader.Split(',');//对应的检查子类的检查号标头
            if (!isServer)
            {
                for (int i = 0; i < LocalIdSubClass.Length; i++)
                {
                    if (this.examSubClass == LocalIdSubClass[i])
                    {
                        Id = LocalIdMax[i] == "" ? 1 : (Convert.ToInt32(LocalIdMax[i]) + 1);//新检查的流水号
                        Header = LocalIdHeader[i];//字符串标头
                        this.LocalIdMaxIndex = i;
                        this.LocalIdMaxValue = Id;
                        break;
                    }
                }
            }
            switch (GetConfig.LM_LocalIdMode)
            {
                case 1://流水号
                    localId = Id.ToString(this.ZeroBits);
                    break;
                case 2://xxxx（年）+流水号
                    localId = this.YearHeader + Id.ToString(this.ZeroBits);
                    break;
                case 3://str(Header)+xxxx（年）+流水号
                    localId = Header + this.YearHeader + Id.ToString(this.ZeroBits);
                    break;
                case 4://str(ExamClass)+xxxx（年）+流水号 
                    localId = this.LocalIdClass + this.YearHeader + Id.ToString(this.ZeroBits);
                    break;
            }
            return localId;
        }

        /// <summary>
        /// 获取检查号默认位数
        /// </summary>
        /// <returns></returns>
        public string getZeroBits()
        {
            string ZeroBits = "";//检查号位数
            for (int i = 0; i < GetConfig.LM_NumberBits; i++)
            {
                ZeroBits += "0";
            }
            return ZeroBits;
        }

        /// <summary>
        /// 获取年标头的格式
        /// </summary>
        /// <returns></returns>
        public string getYearHeader()
        {
            string YearHead = "";
            switch (GetConfig.LM_LocalIdYear)
            {
                case 1://xx（年）
                    YearHead = System.DateTime.Now.Year.ToString().Substring(2, 2);
                    break;
                case 2://xxxx（年）
                    YearHead = System.DateTime.Now.Year.ToString();
                    break;
            }
            return YearHead;
        }

        /// <summary>
        /// 插入PATIENT_INF_LOCAL_ID新记录
        /// </summary>
        /// <param name="exam_times"></param>
        /// <returns></returns>
        public string InsertPatientInfLocalId(bool exam_times)
        {
                string seq = "EXAM_" + LocalIdClass + "_SEQ";
            //switch (GetConfig.DALAndModel)
            //{
            //    case "SIS":
            //        seq = "SEQ_EXAM_" + LocalIdClass;
            //        break;
            //    case "PACS":
            //        seq = "EXAM_" + LocalIdClass + "_SEQ";
            //        break;
            //}
            BGetSeqValue bGetAnyId = new BGetSeqValue(GetConfig.DALAndModel, seq);
            string P_local_id = bGetAnyId.GetSeqValue();
            if (exam_times)//确认收费时,检查次数为1,否则为0
                this.ExamTimes = 1;
            else
                this.ExamTimes = 0;
            iPatientInfLocalId = DALFactory.Model.CreateMPatientInfLocalId();
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MPatientInfLocalId smPatientInfLocalId = (SIS_Model.MPatientInfLocalId)this.iPatientInfLocalId;
                    smPatientInfLocalId.PATIENT_ID = this.patientId;
                    smPatientInfLocalId.LOCAL_ID_CLASS = this.LocalIdClass;
                    smPatientInfLocalId.PATIENT_LOCAL_ID = P_local_id;
                    smPatientInfLocalId.EXAM_TIMES = this.ExamTimes;
                    break;
                case "PACS":
                    PACS_Model.MPatientInfLocalId pmPatientInfLocalId = (PACS_Model.MPatientInfLocalId)this.iPatientInfLocalId;
                    pmPatientInfLocalId.PATIENT_ID = this.patientId;
                    pmPatientInfLocalId.LOCAL_ID_CLASS = this.LocalIdClass;
                    pmPatientInfLocalId.PATIENT_LOCAL_ID = P_local_id;
                    pmPatientInfLocalId.EXAM_TIMES =this.ExamTimes;
                    break;
            }
            this.bPatientInfLocalId.Add(iPatientInfLocalId);
            return P_local_id;
        }

        /// <summary>
        /// 更新EXAM_TIMES
        /// </summary>
        /// <param name="ExamTimes"></param>
        /// <returns></returns>
        public int? UpdateExamTimes(int? ExamTimes)
        {
            if (ExamTimes == null)
                ExamTimes = 1;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MPatientInfLocalId smPatientInfLocalId = (SIS_Model.MPatientInfLocalId)this.iPatientInfLocalId;
                    smPatientInfLocalId.EXAM_TIMES = ExamTimes;
                    break;
                case "PACS":
                    PACS_Model.MPatientInfLocalId pmPatientInfLocalId = (PACS_Model.MPatientInfLocalId)this.iPatientInfLocalId;
                    pmPatientInfLocalId.EXAM_TIMES = ExamTimes;
                    break;
            }
            this.bPatientInfLocalId.Update(iPatientInfLocalId, " where PATIENT_ID = '" + this.patientId + "' and LOCAL_ID_CLASS = '" + this.LocalIdClass + "'");
            return ExamTimes;
        }

        /// <summary>
        /// 重置配置文件中对应的检查子类的检查号最大值
        /// </summary>
        public void ReSetLocalIdMax()
        {
            if (this.LocalIdMaxValue != -1 && this.LocalIdMaxIndex != -1)
            {
                string[] LocalIdMax = GetConfig.LM_LocalIdMax.Split(',');
                LocalIdMax[this.LocalIdMaxIndex] = this.LocalIdMaxValue.ToString();
                string str = "";
                for (int i = 0; i < LocalIdMax.Length; i++)
                {
                    str += LocalIdMax[i] + ",";
                }
                GetConfig.SetLM_LocalIdMax(str.TrimEnd(','));
                GetConfig.LM_LocalIdMax = GetConfig.ReSetLM_LocalIdMax();
            }
        }

        /// <summary>
        /// 更新PATIENT_LOCAL_ID
        /// </summary>
        /// <returns></returns>
        public bool UpdatePatientInfLocalId(IModel iPatientInfLocalId)
        {
            int i = 0;
            switch (GetConfig.DALAndModel)
            {
                case "SIS":
                    SIS_Model.MPatientInfLocalId smPatientInfLocalId = (SIS_Model.MPatientInfLocalId)iPatientInfLocalId;
                    i = this.bPatientInfLocalId.Update(this.iPatientInfLocalId, "where PATIENT_ID ='" + smPatientInfLocalId.PATIENT_ID + "' and LOCAL_ID_CLASS ='" + smPatientInfLocalId.LOCAL_ID_CLASS + "'");
                    break;
                case "PACS":
                    PACS_Model.MPatientInfLocalId pmPatientInfLocalId = (PACS_Model.MPatientInfLocalId)iPatientInfLocalId;
                    i = this.bPatientInfLocalId.Update(this.iPatientInfLocalId, "where PATIENT_ID ='" + pmPatientInfLocalId.PATIENT_ID + "' and LOCAL_ID_CLASS ='" + pmPatientInfLocalId.LOCAL_ID_CLASS + "'");
                    break;
            }
            bool issuccess = i > 0 ? true : false;
           // return issuccess;
            return true;

        }

        public string UpPatientLocalId()
        {
            if (this.LocalIdMaxValue != -1)
            {
                this.ReSetLocalIdMax();
                return this.NewPatietnLocalId(true);
            }
            return "";
        }

        public string DownPatientLocalId()
        {
            if (this.LocalIdMaxValue != -1)
            {
                this.LocalIdMaxValue = this.LocalIdMaxValue - 2 < 0 ? 0 : this.LocalIdMaxValue - 2;
                this.ReSetLocalIdMax();
                return this.NewPatietnLocalId(true);
            }
            return "";
        }
    }
}
