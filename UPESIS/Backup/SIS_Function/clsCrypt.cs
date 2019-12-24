using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace SIS_Function
{
    /// <summary>
    /// 加密
    /// </summary>
    public class clsCrypt
    {
        /// <summary>
        /// 功能：根据密钥字符串加密
        /// </summary>
        /// <param name="pToEncrypt">被加密的字符串</param>
        /// <param name="sKey">加密键</param>
        /// <returns>返回被加密的字符串</returns>
        public static string Encrypt(string pToEncrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //把字符串放到byte数组中
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);

            //建立加密对象的密钥和偏移量。使得输入密码必须输入英文文本
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);

            //写字节数组到待加密码数据流中
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //取内存流返回流
            StringBuilder ret = new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                //Format as hex
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }


        /// <summary>
        /// 功能：根据密钥字符串解密
        /// </summary>
        /// <param name="pToDecrypt">被解密的字符串</param>
        /// <param name="sKey">解密键</param>
        /// <returns>返回被解密的字符串</returns>
        public static string Decrypt(string pToDecrypt, string sKey)
        {
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            //Put the input string into the byte array
            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }

            //建立加密对象的密钥和偏移量，此值重要，不能修改
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            //Flush the data through the crypto stream into the memory stream
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();

            //Get the decrypted data back from the memory stream
            //建立StringBuild对象，CreateDecrypt使用的是流对象，必须把解密后的文本变成流对象
            StringBuilder ret = new StringBuilder();
            return System.Text.Encoding.Default.GetString(ms.ToArray());
        }

    }
}
