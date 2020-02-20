using System;
using System.Text;

namespace ComSocket
{
    // [Serializable]
    public class TcpPackage
    {
        public string Version;//发送的时候设置 R1M R11 等，接收到包不修改，保持原值
        public string Type;
        public string Isend;
        public string ServerType;
        public string SourceIP;
        public int Sequence;
        public string CmdHead;
        public int Tag;
        public int MsgLength;
        public string Reserve;

        //public byte[] MsgBody;
        public byte[] MsgBuffer;

        public TcpPackage()
        {

        }
        /// <summary>
        /// 初始化数据包
        /// </summary>
        /// <param name="type"></param>
        /// <param name="issend"></param>
        /// <param name="servertype"></param>
        /// <param name="sourceip"></param>
        /// <param name="sequence"></param>
        /// <param name="cmdhead"></param>
        /// <param name="tag"></param>
        /// <param name="msglength"></param>
        /// <param name="msgbuffer"></param>
        /// <param name="stopflag"></param>
        /// <param name="msgbody"></param>
        public TcpPackage(string version, string type, string isend, string servertype, string sourceip, int sequence, string cmdhead, int tag, int msglength, string reserve, byte[] msgBuffer)
        {
            this.Version = version;
            this.Type = type;
            this.Isend = isend;
            this.ServerType = servertype;
            this.SourceIP = sourceip;
            this.Sequence = sequence;
            this.CmdHead = cmdhead;
            this.Tag = tag;
            this.MsgLength = msglength;
            this.Reserve = reserve;
            //this.MsgBody = msgbody;
            this.MsgBuffer = msgBuffer;
        }
        public byte[] CreateBuffer()
        {
            string head = Version + Type + Isend + ServerType;
            byte[] MsgHead = System.Text.Encoding.Default.GetBytes(head);
            byte[] ip = clsDataConvert.IpToByte(SourceIP);
            //byte[] buff = clsDataConvert.ConvertStringToByte(MsgBuffer);
            byte[] buff = MsgBuffer;
            MsgHead = clsDataConvert.Concat(MsgHead, ip);
            MsgHead = clsDataConvert.Concat(MsgHead, clsDataConvert.ConvertIntToByte(Sequence));
            MsgHead = clsDataConvert.Concat(MsgHead, clsDataConvert.ConvertStringToByte(CmdHead));//6个字符串
            MsgHead = clsDataConvert.Concat(MsgHead, clsDataConvert.ConvertIntToByte(Tag));
            MsgHead = clsDataConvert.Concat(MsgHead, clsDataConvert.ConvertIntToByte(buff.Length));
            MsgHead = clsDataConvert.Concat(MsgHead, clsDataConvert.ConvertStringToByte("00000000000000000000000000000000000000000000000000"));
            MsgHead = clsDataConvert.Concat(MsgHead, buff);

            string Meg = System.Text.Encoding.Default.GetString(MsgHead);
            return MsgHead;

        }
        public void DeTcpPackage(byte[] Rdata)
        {
            try
            {
                string Msg = Encoding.Default.GetString(Rdata);
                this.Version = clsDataConvert.ByteToSting(Rdata, 0, 8);
                this.Type = clsDataConvert.ByteToSting(Rdata, 8, 3);
                this.Isend = clsDataConvert.ByteToSting(Rdata, 11, 1);
                this.ServerType = clsDataConvert.ByteToSting(Rdata, 12, 2);
                this.SourceIP = clsDataConvert.ByteToIp(Rdata, 14, 4);
                this.Sequence = clsDataConvert.ByteToInt(Rdata, 18, 4);
                this.CmdHead = clsDataConvert.ByteToSting(Rdata, 22, 6);
                this.Tag = clsDataConvert.ByteToInt(Rdata, 28, 4);
                this.MsgLength = clsDataConvert.ByteToInt(Rdata, 32, 4);
                this.Reserve = clsDataConvert.ByteToSting(Rdata, 36, 50);
                this.MsgBuffer = new byte[this.MsgLength];
                //Array.Copy(Rdata, 86, this.MsgBuffer, 0, this.MsgLength);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
