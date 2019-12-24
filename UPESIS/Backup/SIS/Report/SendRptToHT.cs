using System;
using System.Collections.Generic;
using System.Text;
using SIS_Function;

namespace SIS
{
    public class SendRptToHT
    {
        FileTransfer tranfer;
        public SendRptToHT()
        {
            tranfer = new FileTransfer(ILL.GetConfig.ServerIp, ILL.GetConfig.ServerPort);
        }
        public int SendToHT(string study_instance_uid)
        {
            return tranfer.CmtRpt(study_instance_uid);
        }
    }
}
