using ILL;
using System.Reflection;

namespace DALFactory
{
    public sealed class DAL
    {
        // Look up the DAL implementation we should be using   数据访问层工厂
        private static string path = GetConfig.DALAndModel + "_DAL";

        private DAL() { }

        public static IArchives CreateDArchives()
        {
            string className = path + ".DArchives";
            return (IArchives)Assembly.Load(path).CreateInstance(className);
        }
        public static IAreaDict CreateDAreaDict()
        {
            string className = path + ".DAreaDict";
            return (IAreaDict)Assembly.Load(path).CreateInstance(className);
        }
        public static IBespeak CreateDBespeak()
        {
            string className = path + ".DBespeak";
            return (IBespeak)Assembly.Load(path).CreateInstance(className);
        }
        public static IChargeClass CreateDChargeClass()
        {
            string className = path + ".DChargeClass";
            return (IChargeClass)Assembly.Load(path).CreateInstance(className);
        }
        public static IChargeItemDict CreateDChargeItemDict()
        {
            string className = path + ".DChargeItemDict";
            return (IChargeItemDict)Assembly.Load(path).CreateInstance(className);
        }
        public static IChargeItemClassDict CreateDChargeItemClassDict()
        {
            string className = path + ".DChargeItemClassDict";
            return (IChargeItemClassDict)Assembly.Load(path).CreateInstance(className);
        }
        public static IClinicDoctorDict CreateDClinicDoctorDict()
        {
            string className = path + ".DClinicDoctorDict";
            return (IClinicDoctorDict)Assembly.Load(path).CreateInstance(className);
        }
        public static IClinicOfficeDict CreateDClinicOfficeDict()
        {
            string className = path + ".DClinicOfficeDict";
            return (IClinicOfficeDict)Assembly.Load(path).CreateInstance(className);
        }
        public static IDeptDataDict CreateDDeptDataDict()
        {
            string className = path + ".DDeptDataDict";
            return (IDeptDataDict)Assembly.Load(path).CreateInstance(className);
        }
        public static IDeptVsQueue CreateDDeptVsQueue()
        {
            string className = path + ".DDeptVsQueue";
            return (IDeptVsQueue)Assembly.Load(path).CreateInstance(className);
        }
        public static IExamChargeList CreateDExamChargeList()
        {
            string className = path + ".DExamChargeList";
            return (IExamChargeList)Assembly.Load(path).CreateInstance(className);

        }
        public static IExamClass CreateDExamClass()
        {
            string className = path + ".DExamClass";
            return (IExamClass)Assembly.Load(path).CreateInstance(className);
        }
        public static IExamInquiry CreateDExamInquiry()
        {
            string className = path + ".DExamInquiry";
            return (IExamInquiry)Assembly.Load(path).CreateInstance(className);
        }
        public static IExamItemDict CreateDExamItemDict()
        {
            string className = path + ".DExamItemDict";
            return (IExamItemDict)Assembly.Load(path).CreateInstance(className);
        }
        public static IExamVsCharge CreateDExamVsCharge()
        {
            string className = path + ".DExamVsCharge";
            return (IExamVsCharge)Assembly.Load(path).CreateInstance(className);
        }
        public static IImage CreateDImage()
        {
            string className = path + ".DImage";
            return (IImage)Assembly.Load(path).CreateInstance(className);
        }
        public static IImgEquipment CreateDImgEquipment()
        {
            string className = path + ".DImgEquipment";
            return (IImgEquipment)Assembly.Load(path).CreateInstance(className);
        }
        public static IInstance CreateDInstance()
        {
            string className = path + ".DInstance";
            return (IInstance)Assembly.Load(path).CreateInstance(className);
        }
        public static IInterestPatient CreateDInterestPatient()
        {
            string className = path + ".DInterestPatient";
            return (IInterestPatient)Assembly.Load(path).CreateInstance(className);
        }
        public static ILocationMap CreateDLocationMap()
        {
            string className = path + ".DLocationMap";
            return (ILocationMap)Assembly.Load(path).CreateInstance(className);
        }
        public static ILocationMapInf CreateDLocationMapInf()
        {
            string className = path + ".DLocationMapInf";
            return (ILocationMapInf)Assembly.Load(path).CreateInstance(className);
        }
        public static IPatientInfLocalId CreateDPatientInfLocalId()
        {
            string className = path + ".DPatientInfLocalId";
            return (IPatientInfLocalId)Assembly.Load(path).CreateInstance(className);
        }
        public static IPatientSource CreateDPatientSource()
        {
            string className = path + ".DPatientSource";
            return (IPatientSource)Assembly.Load(path).CreateInstance(className);
        }
        public static IPrintTemplateDict CreateDPrintTemplateDict()
        {
            string className = path + ".DPrintTemplateDict";
            return (IPrintTemplateDict)Assembly.Load(path).CreateInstance(className);
        }
        public static IQcCt CreateDQcCt()
        {
            string className = path + ".DQcCt";
            return (IQcCt)Assembly.Load(path).CreateInstance(className);
        }
        public static IQcDeptManDict CreateDQcDeptManDict()
        {
            string className = path + ".DQcDeptManDict";
            return (IQcDeptManDict)Assembly.Load(path).CreateInstance(className);
        }
        public static IQcDigitalImage CreateDQcDigitalImage()
        {
            string className = path + ".DQcDigitalImage";
            return (IQcDigitalImage)Assembly.Load(path).CreateInstance(className);
        }
        public static IQcFilm CreateDQcFilm()
        {
            string className = path + ".DQcFilm";
            return (IQcFilm)Assembly.Load(path).CreateInstance(className);
        }
        public static IQcMri CreateDQcMri()
        {
            string className = path + ".DQcMri";
            return (IQcMri)Assembly.Load(path).CreateInstance(className);
        }
        public static IQcRyDiagDict CreateDQcRyDiagDict()
        {
            string className = path + ".DQcRyDiagDict";
            return (IQcRyDiagDict)Assembly.Load(path).CreateInstance(className);
        }
        public static IQueueInfo CreateDQueueInfo()
        {
            string className = path + ".DQueueInfo";
            return (IQueueInfo)Assembly.Load(path).CreateInstance(className);
        }
        public static IReport CreateDReport()
        {
            string className = path + ".DReport";
            return (IReport)Assembly.Load(path).CreateInstance(className);
        }
        public static IReportRelation CreateDReportRelation()
        {
            string className = path + ".DReportRelation";
            return (IReportRelation)Assembly.Load(path).CreateInstance(className);
        }
        public static IReportTempDict CreateDReportTempDict()
        {
            string className = path + ".DReportTempDict";
            return (IReportTempDict)Assembly.Load(path).CreateInstance(className);
        }
        public static IReportTrackInf CreateDReportTrackInf()
        {
            string className = path + ".DReportTrackInf";
            return (IReportTrackInf)Assembly.Load(path).CreateInstance(className);
        }
        public static IReqScanImage CreateDReqScanImage()
        {
            string className = path + ".DReqScanImage";
            return (IReqScanImage)Assembly.Load(path).CreateInstance(className);
        }
        public static ISystemFun CreateDSystemFun()
        {
            string className = path + ".DSystemFun";
            return (ISystemFun)Assembly.Load(path).CreateInstance(className);
        }
        public static IUser CreateDUser()
        {
            string className = path + ".DUser";
            return (IUser)Assembly.Load(path).CreateInstance(className);
        }
        public static IUsersRole CreateDUsersRole()
        {
            string className = path + ".DUsersRole";
            return (IUsersRole)Assembly.Load(path).CreateInstance(className);
        }
        public static IWorkList CreateDWorkList()
        {
            string className = path + ".DWorkList";
            return (IWorkList)Assembly.Load(path).CreateInstance(className);
        }
        public static IStudy CreateDStudy()
        {
            string className = path + ".DStudy";
            return (IStudy)Assembly.Load(path).CreateInstance(className);
        }
        public static IKnowledgeBase CreateDKnowledgeBase()
        {
            string className = path + ".DKnowledgeBase";
            return (IKnowledgeBase)Assembly.Load(path).CreateInstance(className);
        }
        public static IStat CreateDStat()
        {
            string className = path + ".DStat";
            return (IStat)Assembly.Load(path).CreateInstance(className);
        }
    }
}
