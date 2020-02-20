using System;
using System.Net;

namespace ComSocket
{
    public class clsDataConvert
    {

        #region Binary Serializers
        /// <summary>
        /// 将类实例转成MemoryStream
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //public System.IO.MemoryStream SerializeBinary(object request)
        //{
        //    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter serializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //    System.IO.MemoryStream memStream = new System.IO.MemoryStream();
        //    serializer.Serialize(memStream, request);
        //    return memStream;
        //}

        ///// <summary>
        ///// MemoryStream转成实体对象
        ///// </summary>
        ///// <param name="memStream"></param>
        ///// <returns></returns>
        //public object DeSerializeBinary(System.IO.MemoryStream memStream)
        //{
        //    memStream.Position = 0;
        //    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter deserializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        //    object newobj = deserializer.Deserialize(memStream);
        //    memStream.Close();
        //    return newobj;
        //}

        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        //public static string SerializeObject(object obj)
        //{
        //    IFormatter formatter = new BinaryFormatter();
        //    string result = string.Empty;
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        formatter.Serialize(stream, obj);

        //        byte[] byt = new byte[stream.Length];
        //        byt = stream.ToArray();
        //        //result = Encoding.UTF8.GetString(byt, 0, byt.Length);
        //        result = Convert.ToBase64String(byt);
        //        stream.Flush();
        //    }
        //    return result;
        //}
        ///// <summary>
        ///// 反序列化对象
        ///// </summary>
        ///// <param name="str"></param>
        ///// <returns></returns>
        //public static object DeserializeObject(string str)
        //{
        //    IFormatter formatter = new BinaryFormatter();
        //    //byte[] byt = Encoding.UTF8.GetBytes(str);
        //    byte[] byt = Convert.FromBase64String(str);
        //    object obj = null;
        //    using (Stream stream = new MemoryStream(byt, 0, byt.Length))
        //    {
        //        obj = formatter.Deserialize(stream);
        //    }
        //    return obj;
        //}
        #endregion
        public static TcpPackage LoadPackage(byte[] buffer)
        {
            TcpPackage tp = new TcpPackage();
            tp.DeTcpPackage(buffer);
            return tp;
        }
        /// <summary>
        /// Int转成四位Byte[]
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ConvertIntToByte(int value)
        {
            return (System.BitConverter.GetBytes(IPAddress.HostToNetworkOrder(value)));
            //return SortByte((System.BitConverter.GetBytes(value)));
        }
        private static byte[] SortByte(byte[] bt)
        {
            Array array = bt;
            Array.Reverse(array);
            return (byte[])array;
        }
        /// <summary>
        /// Byte[] To Int
        /// </summary>
        /// <param name="Rdata"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static int ByteToInt(byte[] Rdata, int start, int length)
        {

            //byte[] data = new byte[length];
            //Rdata.CopyTo(data, s);
            // Rdata.
            // SortByte(data);
            //return IPAddress.NetworkToHostOrder(System.BitConverter.ToInt32(Rdata, start));
            return System.BitConverter.ToInt32(Rdata, start);
        }
        /// <summary>
        /// string 转成Byte[]
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ConvertStringToByte(string value)
        {
            return (System.Text.Encoding.Default.GetBytes(value));
        }
        /// <summary>
        /// Byte[] To String
        /// </summary>
        /// <param name="Rdata"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ByteToSting(byte[] Rdata, int start, int length)
        {
            return (System.Text.Encoding.Default.GetString(Rdata, start, length));
        }
        //public byte[] ByteAdd(byte[] value, byte[] target)
        //{
        //    Array.Copy(
        //}
        public static byte[] Concat(Array arr0, Array arr1)
        {
            Type t0 = arr0.GetType().GetElementType();
            Type t1 = arr1.GetType().GetElementType();
            Type t = (t0 == t1) ? t0 : typeof(object);
            int len = arr0.Length + arr1.Length;
            Array arr2 = Array.CreateInstance(t, len);
            Array.Copy(arr0, arr2, arr0.Length);
            Array.Copy(arr1, 0, arr2, arr0.Length, arr1.Length);
            return (byte[])arr2;
        }
        public static byte[] IpToByte(string ip)
        {
            IPAddress ipaddress = IPAddress.Parse(ip);
            return (System.BitConverter.GetBytes((uint)(ipaddress.Address)));
        }
        public static string ByteToIp(byte[] Rdata, int start, int length)
        {
            uint ipInt = System.BitConverter.ToUInt32(Rdata, start);
            int x = 192;
            char c = (char)x;
            IPAddress ip = new IPAddress(ipInt);
            return ip.ToString();
        }
    }
}
