using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace PACS_Model
{
    [Serializable]
    public class MQcInformation : IModel
    {
        private string examaccessionnum = "";               //检查序号
        private string localid = "";                        //检查号
        private string name = "";                           //姓名
        private string sex = "";                            //性别
        private string studydatetime = "";                  //检查时间
        private string patient_id = "";                     //病人ID
        private int? _type;                                  //图像类型

        public string EXAM_ACCESSION_NUM
        {
            get { return this.examaccessionnum; }
            set { this.examaccessionnum = value; }
        }

        public string LOCAL_ID
        {
            get { return this.localid; }
            set { this.localid = value; }
        }

        public string NAME
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public string SEX
        {
            get { return this.sex; }
            set { this.sex = value; }
        }

        public string STUDY_DATE_TIME
        {
            get { return this.studydatetime; }
            set { this.studydatetime = value; }
        }

        public string PATIENT_ID
        {
            get { return this.patient_id; }
            set { this.patient_id = value; }
        }

        public int? Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
    }
}
