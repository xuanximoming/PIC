using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace SIS_BLL
{
    public class BGetSeqValue
    {
        private DGetSeqValue dGetSeqValue;
        public BGetSeqValue()
        {
        }
        public BGetSeqValue(string ConnectionType,string SequenceName)
        {
            dGetSeqValue = new DGetSeqValue(ConnectionType,SequenceName);
        }
        public string GetSeqValue()
        {
            return dGetSeqValue.GetSeqValue();
        }
    }
}
