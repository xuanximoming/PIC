using System;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace ComSocket
{
    internal class TcpCommon
    {
        private static readonly int _blockLength = 1024 * 1024;//包体长度
        private static readonly int _headLength = 86;          //包 头长度
        //internal byte[] MsgBuff = new byte[_blockLength];
        /// <summary>
        /// 计算文件的hash值 
        /// </summary>
        internal string CalcFileHash(string FilePath)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash;
            using (FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096))
            {
                hash = md5.ComputeHash(fs);
            }
            return BitConverter.ToString(hash);

        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        internal bool SendFile(string filePath, NetworkStream stream)
        {
            FileStream fs = File.Open(filePath, FileMode.Open);
            int readLength = 0;
            byte[] data = new byte[_blockLength];

            //发送大小
            byte[] length = new byte[8];
            BitConverter.GetBytes(new FileInfo(filePath).Length).CopyTo(length, 0);
            stream.Write(length, 0, 8);

            //发送文件
            while ((readLength = fs.Read(data, 0, _blockLength)) > 0)
            {
                stream.Write(data, 0, readLength);
            }
            fs.Close();
            return true;
        }

        /// <summary>
        /// 接收文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        internal bool ReceiveFile(string filePath, NetworkStream stream)
        {
            try
            {
                long count = GetSize(stream);
                if (count == 0)
                {
                    return false;
                }

                long index = 0;
                byte[] clientData = new byte[_blockLength];
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                string path = new FileInfo(filePath).Directory.FullName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream fs = File.Open(filePath, FileMode.OpenOrCreate);
                try
                {
                    //计算当前要读取的块的大小
                    int currentBlockLength = 0;
                    if (_blockLength < count - index)
                    {
                        currentBlockLength = _blockLength;
                    }
                    else
                    {
                        currentBlockLength = (int)(count - index);
                    }

                    int receivedBytesLen = stream.Read(clientData, 0, currentBlockLength);
                    index += receivedBytesLen;
                    fs.Write(clientData, 0, receivedBytesLen);

                    while (receivedBytesLen > 0 && index < count)
                    {
                        clientData = new byte[_blockLength];
                        receivedBytesLen = 0;

                        if (_blockLength < count - index)
                        {
                            currentBlockLength = _blockLength;
                        }
                        else
                        {
                            currentBlockLength = (int)(count - index);
                        }
                        receivedBytesLen = stream.Read(clientData, 0, currentBlockLength);
                        index += receivedBytesLen;
                        fs.Write(clientData, 0, receivedBytesLen);
                    }
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        internal bool SendMessage(TcpPackage tp, NetworkStream stream)
        {
            byte[] resultData = tp.CreateBuffer();
            stream.Write(resultData, 0, resultData.Length);
            return true;
        }

        /// <summary>
        /// 读取消息
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        internal TcpPackage ReadMessage(NetworkStream stream)
        {
            int maxlenght = 0;
            int i = 0;
            byte[] resultbyte = new byte[_blockLength];

            byte[] msghead = new byte[_headLength];
            stream.Read(msghead, 0, _headLength);
            TcpPackage tp = new TcpPackage();
            tp.DeTcpPackage(msghead);
            int currev = tp.MsgLength;
            while (maxlenght < tp.MsgLength)
            {
                try
                {
                    currev = stream.Read(tp.MsgBuffer, 0, tp.MsgLength);
                    Array.Copy(tp.MsgBuffer, 0, resultbyte, maxlenght, currev);
                    maxlenght += currev;
                }
                catch (Exception ex)
                {
                    break;
                }
            }
            Array.Copy(resultbyte, 0, tp.MsgBuffer, 0, maxlenght);
            return tp;
        }

        /// <summary>
        /// 获取要读取的数据的大小
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private int GetSize(NetworkStream stream)
        {
            int count = 0;
            byte[] countBytes = new byte[8];
            try
            {
                if (stream.Read(countBytes, 0, 8) == 8)
                {
                    count = BitConverter.ToInt32(countBytes, 0);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

            }
            return count;
        }
    }
}
