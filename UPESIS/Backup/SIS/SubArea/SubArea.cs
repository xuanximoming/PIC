using System;
using System.Collections.Generic;
using System.Text;
using SIS_Model;

namespace SIS
{
    public class SubArea
    {
        public void AddQueueInfo(MWorkList mWorklist)
        {
            MQueueInfo mQueueInfo = new MQueueInfo();
            mQueueInfo.EXAM_ACCESSION_NUM = mWorklist.EXAM_ACCESSION_NUM;
            mQueueInfo.PATIENT_ID = mWorklist.PATIENT_ID;
        }

    }
}
