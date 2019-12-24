using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using ILL;
using SIS_Function.GatherCard;

namespace SIS.ImgGather
{
    public class Gather
    {
        public IntPtr parentHwnd;
        private OKGather okGather;
        private MVGather mvGather;
        private SIS.frmImageGather.GatherCallBack bt;

        public Gather(SIS.frmImageGather.GatherCallBack bt)
        {
            this.bt = bt;
            this.okGather = new OKGather();
            this.mvGather = new MVGather();
            this.okGather.GetCallBack += new Comment.GetCallBackEventHandler(okGather_GetCallBack);
            this.mvGather.GetCallBack += new Comment.GetCallBackEventHandler(mvGather_GetCallBack);
        }

        void axHYImage_OnEventCallback(object sender, EventArgs e)
        {

        }

        void mvGather_GetCallBack(Bitmap bm)
        {
            this.bt(bm);
        }

        void okGather_GetCallBack(Bitmap bm)
        {
            this.bt(bm);
        }

        /// <summary>
        /// 初始化卡参数
        /// </summary>
        public bool initCard()
        {
            bool success = false;
            switch (GetConfig.IMS_CardProduct)
            {
                case "OK":
                    //success = okGather.initCard();
                    break;
                case "MV":
                    mvGather.parentHwnd = parentHwnd;
                    success = mvGather.initCard();
                    success &= mvGather.StartSample();
                    break;
                case "UsbMygica":
                    break;
            }
            return success;
        }


        /// <summary>
        /// 打开卡
        /// </summary>
        public bool OpenCard()
        {
            bool success = false;
            switch (GetConfig.IMS_CardProduct)
            {
                case "OK":
                    success = okGather.initCard();
                    success &= okGather.OpenCard();
                    break;
                case "MV":
                    success = mvGather.OpenCard();
                    break;
                case "UsbMygica":
                   
                   break;
            }
            return success;
        }


        /// <summary>
        /// 关闭卡
        /// </summary>
        public bool CloseCard()
        {
            bool success = false;
            switch (GetConfig.IMS_CardProduct)
            {
                case "OK":
                    success = okGather.CloseCard();
                    break;
                case "MV":
                    if (mvGather.isSampled)
                        mvGather.StopSample();
                    success = mvGather.CloseCard();
                    break;
                case "UsbMygica":
                    break;
            }
            return success;
        }
    }
}
