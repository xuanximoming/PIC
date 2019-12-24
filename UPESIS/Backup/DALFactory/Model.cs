using System.Reflection;
using System.Configuration;
using ILL;

namespace DALFactory
{
    public sealed class Model
    {

        // Look up the MAL implementation we should be using   模型实体
        private static readonly string path = GetConfig.DALAndModel + "_Model";

        private Model() { }

        public static IModel CreateMArchives()
        {
            string className = path + ".MArchives";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMAreaDict()
        {
            string className = path + ".MAreaDict";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMBespeak()
        {
            string className = path + ".MBespeak";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMChargeClass()
        {
            string className = path + ".MChargeClass";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMChargeItemDict()
        {
            string className = path + ".MChargeItemDict";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMChargeItemClassDict()
        {
            string className = path + ".MChargeItemClassDict";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMClinicDoctorMict()
        {
            string className = path + ".MClinicDoctorMict";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMClinicOfficeMept()
        {
            string className = path + ".MClinicOfficeMept";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMDeptVsQueue()
        {
            string className = path + ".MDeptVsQueue";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMExamChargeList()
        {
            string className = path + ".MExamChargeList";
            return (IModel)Assembly.Load(path).CreateInstance(className);

        }
        public static IModel CreateMExamClass()
        {
            string className = path + ".MExamClass";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMExamInquiry()
        {
            string className = path + ".MExamInquiry";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMExamItemMict()
        {
            string className = path + ".MExamItemMict";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMExamVsCharge()
        {
            string className = path + ".MExamVsCharge";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMGetAnyId()
        {
            string className = path + ".MGetAnyId";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMImage()
        {
            string className = path + ".MImage";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMImgEquipment()
        {
            string className = path + ".MImgEquipment";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMInterestPatient()
        {
            string className = path + ".MInterestPatient";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMInstance()
        {
            string className = path + ".MInstance";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMLocationMap()
        {
            string className = path + ".MLocationMap";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMPatientInfLocalId()
        {
            string className = path + ".MPatientInfLocalId";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMPatientSource()
        {
            string className = path + ".MPatientSource";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMPrintTemplateDict()
        {
            string className = path + ".MPrintTemplateDict";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMQueueInfo()
        {
            string className = path + ".MQueueInfo";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMReport()
        {
            string className = path + ".MReport";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMReportRelation()
        {
            string className = path + ".MReportRelation";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMReportTempMict()
        {
            string className = path + ".MReportTempMict";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMReportTrackInf()
        {
            string className = path + ".MReportTrackInf";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMReqScanImage()
        {
            string className = path + ".MReqScanImage";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMSystemFun()
        {
            string className = path + ".MSystemFun";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMUser()
        {
            string className = path + ".MUser";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMUsersRole()
        {
            string className = path + ".MUsersRole";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }
        public static IModel CreateMWorkList()
        {
            string className = path + ".MWorkList";
            return (IModel)Assembly.Load(path).CreateInstance(className);
        }

    }
}
