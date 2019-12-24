using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace SIS_Function.GatherCard
{
    public class MVGather:Comment
    {
        public event GetCallBackEventHandler GetCallBack;
        public bool isOpened,isSampled;
        public IntPtr parentHwnd;
        private int m_hBoard, width, height, bits;
        private MicroView mv;
        private System.Drawing.Bitmap bm = null;

        public bool OpenCard()
        {
            if (isOpened)
                return true;
            try
            {
                string strVal = "" ;
                uint nBdNum = MicroView.MV_GetDeviceNumber();
                if (nBdNum == 0)
                {
                    MessageBox.Show("请正确安装板卡！", "警告");
                    return false;
                }
                else
                {
                    if (nBdNum > 1)
                        MessageBox.Show("发现" + nBdNum.ToString() + "块板卡,本版本程序只使用第一块卡,多卡使用请升级程序", "警告");
                }
                m_hBoard = MicroView.MV_OpenDevice(0, true);
                switch (MicroView.MV_GetDeviceParameter(m_hBoard, (int)MicroView.MV_PARAMTER.GET_BOARD_TYPE))
                {
                    case MicroView.LEVIN_M10:
                        strVal = "Levin M10";
                        break;
                    case MicroView.LEVIN_RGB10:
                        strVal = "Levin RGB10";
                        break;
                    case MicroView.LEVIN_M20:
                        strVal = "Levin M20";
                        break;
                    case MicroView.LEVIN_RGB20:
                        strVal = "Levin RGB20";
                        break;
                    case MicroView.LEVIN_VGA100:
                        strVal = "Levin VGA100";
                        break;
                    case MicroView.LEVIN_VGA170:
                        strVal = "Levin VGA170";
                        break;
                    case MicroView.V3A:
                        strVal = "MVPCI V3A";
                        break;
                    case MicroView.V300:
                        strVal = "MVPCI V300";
                        break;
                    case MicroView.V200:
                        strVal = "MVPCI V200";
                        break;
                    case MicroView.V110:
                        strVal = "MVPCI V110";
                        break;
                    case MicroView.V120:
                        strVal = "MVPCI V120";
                        break;
                    case MicroView.V130:
                        strVal = "MVPCI V130";
                        break;
                    case MicroView.MOKAC10:
                        strVal = "Moka-C10";
                        break;
                    case MicroView.MOKAC20:
                        strVal = "Moka-C20";
                        break;
                    case MicroView.S100:
                        strVal = "MVPCI S100";
                        break;
                    case MicroView.V500:
                        strVal = "MVPCI V500";
                        break;
                    case MicroView.V510:
                        strVal = "MVPCI V510/Moka-C51";
                        break;
                    case MicroView.V520:
                        strVal = "MVPCI V520/Moka-C50";
                        break;
                    case MicroView.V8T:
                        strVal = "MVPCI V8T";
                        break;
                    case MicroView.V400:
                        strVal = "MVPCI V400";
                        break;
                    case MicroView.X400:
                        strVal = "MVPCI X400";
                        break;
                    case MicroView.V410:
                        strVal = "MVPCI V410";
                        break;
                    case MicroView.V411:
                        strVal = "MVPCI V411";
                        break;
                    case MicroView.V412:
                        strVal = "MVPCI V412";
                        break;
                    //case MicroView.X800:
                    //    strVal = "MVPCI X800";
                    //    break;
                    case MicroView.MOKAC40:
                        strVal = "Moka-C40";
                        break;
                    case MicroView.MOKAC41:
                        strVal = "Moka-C41";
                        break;
                    case MicroView.S450:
                        strVal = "MVPCI S450";
                        break;
                    case MicroView.S451:
                        strVal = "MVPCI S451";
                        break;
                    case MicroView.S400S420:
                        strVal = "MVPCI S400/S420";
                        break;
                    case MicroView.S260:
                        strVal = "MVPCI S260";
                        break;
                    case MicroView.E450:
                        strVal = "MVPCI E450";
                        break;
                    case MicroView.E410:
                        strVal = "MVPCI E410";
                        break;
                    case MicroView.E412:
                        strVal = "MVPCI E412";
                        break;
                    case MicroView.V211:
                        strVal = "V211采集卡";
                        break;
                    case MicroView.S211:
                        strVal = "S211采集卡";
                        break;
                    case MicroView.V401:
                        strVal = "V401采集卡";
                        break;
                    case MicroView.S401:
                        strVal = "S401采集卡";
                        break;
                    case MicroView.V221:
                        strVal = "V221采集卡";
                        break;
                    case MicroView.S251:
                        strVal = "S251采集卡";
                        break;
                    case MicroView.MP110:
                        strVal = "MP110采集卡";
                        break;
                    case MicroView.MP200:
                        strVal = "MP200采集卡";
                        break;
                    case MicroView.MP210:
                        strVal = "MP210采集卡";
                        break;
                    case MicroView.MP220:
                        strVal = "MP220采集卡";
                        break;
                    case MicroView.MP230:
                        strVal = "MP230采集卡";
                        break;
                    case MicroView.MP240:
                        strVal = "MP240采集卡";
                        break;
                    case MicroView.E400:
                        strVal = "E400采集卡";
                        break;
                    default:
                        MessageBox.Show("无法判断采集卡类型，请检查驱动版本及安装是否正确！", "警告");
                        return false;
                }
                isOpened = true;
            }
            catch
            {
                //MicroView.MV_GetLastError(true);
                return false;
            }
            return true;
        }

        public unsafe bool initCard()
        {
            mv = new MicroView();
            // okLoadInitParam(m_hBoard,0);
            try
            {
                MicroView.MV_IMAGEINFO BufInfo = new MicroView.MV_IMAGEINFO();
                MicroView.MV_IMAGEINFO* pBufInfo;  //定义结构指针
                pBufInfo = &BufInfo;
                bool aa = MicroView.MV_SetDeviceParameter(m_hBoard, (int)MicroView.MV_PARAMTER.WORK_FIELD, MicroView.COLLECTION_FRAME);		//设置按帧采集方式 
                bool ss = MicroView.MV_SetDeviceParameter(m_hBoard, (int)MicroView.MV_PARAMTER.SET_GARBIMAGEINFO, (uint)pBufInfo);
                //MicroView.MV_SetDeviceParameter(m_hBoard, (int)MicroView.MV_PARAMTER.GARB_IN_HEIGHT, 576);//GARB_IN_HEIGHT			= 30, 
                //MicroView.MV_SetDeviceParameter(m_hBoard, (int)MicroView.MV_PARAMTER.GARB_IN_WIDTH, 768);//GARB_IN_WIDTH			= 31, 					
                //MicroView.MV_SetDeviceParameter(m_hBoard, (int)MicroView.MV_PARAMTER.GARB_HEIGHT, 576);//GARB_HEIGHT				= 28, 
                //MicroView.MV_SetDeviceParameter(m_hBoard, (int)MicroView.MV_PARAMTER.GARB_WIDTH, 768);//GARB_WIDTH				= 29, 
                //MicroView.MV_SetDeviceParameter(m_hBoard, MicroView.MV_PARAMTER.ADJUST_LUMINANCE, 128);
                //MicroView.MV_SetDeviceParameter(m_hBoard, MicroView.MV_PARAMTER.ADJUST_SATURATION, 128);
                //MicroView.MV_SetDeviceParameter(m_hBoard, MicroView.MV_PARAMTER.ADJUST_HUE, 128);
                //MicroView.MV_SetDeviceParameter(m_hBoard, MicroView.MV_PARAMTER.ADJUST_CONTRAST, 128);
                //MicroView.MV_SetDeviceParameter(m_hBoard, (int)MicroView.MV_PARAMTER.GARB_BITDESCRIBE, (uint)MicroView.DATA_aRGB8888);
                width = MicroView.MV_GetDeviceParameter(m_hBoard, (int)MicroView.MV_PARAMTER.GARB_WIDTH);
                height = MicroView.MV_GetDeviceParameter(m_hBoard, (int)MicroView.MV_PARAMTER.GARB_HEIGHT);
                bits = MicroView.MV_GetDeviceParameter(m_hBoard, (int)MicroView.MV_PARAMTER.GARB_BITDESCRIBE);
            }
            catch
            {
                MicroView.MV_GetLastError(true);
                return false;
            }
            return true;
        }

        public bool StartSample()
        {
            if (isSampled)
                return true;
            try
            {
                MicroView.MV_OperateDevice(m_hBoard, (int)MicroView.RUNOPER.MVRUN);//开始当前板卡的采集和显示工作
                isSampled = true;
                mv.seq = new MicroView.CALLBACKFUNC(seqprogress);
                MicroView.MV_SetCallBack(m_hBoard, mv.seq, this.parentHwnd, (int)MicroView.CALLBACKTYPE.BEFORE_PROCESS);
            }
            catch
            {
                MicroView.MV_GetLastError(true);
                return false;
            }
            return true;
        }


        public bool StopSample()
        {
            isSampled = false;
            try
            {
                MicroView.MV_OperateDevice(m_hBoard, (int)MicroView.RUNOPER.MVSTOP);		//停止当前板卡的采集和显示工作
            }
            catch
            {
                MicroView.MV_GetLastError(true);
                return false;
            }
            return true;
        }


        public bool CloseCard()
        {
            if (!isOpened)
                return true;
            try
            {
                MicroView.MV_CloseDevice(m_hBoard);
                isOpened = false;
            }
            catch
            {
                MicroView.MV_GetLastError(true);
                return false;
            }
            return true;
        }
        public bool seqprogress(IntPtr pData,ref MicroView.MV_IMAGEINFO pImageInfo, IntPtr pUserData, uint Index)
        {
            int stride = 0;
            switch (bits)
            {
                case MicroView.DATA_MONOCHOY8:
                    stride = width;
                    bm = new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, pData);
                    //创建灰阶
                    ColorPalette palette = bm.Palette;
                    for (int i = 0; i < palette.Entries.Length; i++)
                    {
                        palette.Entries[i] = Color.FromArgb(i, i, i);
                    }
                    bm.Palette = palette;
                    break;
                case MicroView.DATA_aRGB8888:
                    stride = 4 * width;
                    bm = new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format32bppRgb, pData);
                    break;
                case MicroView.DATA_CO_RGB24:
                    stride = 3 * width;
                    bm = new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format24bppRgb, pData);
                    break;
                case MicroView.DATA_CO_RGB565:
                    stride = 2 * width;
                    bm = new Bitmap(width, height, stride, System.Drawing.Imaging.PixelFormat.Format16bppRgb565, pData);
                    break;
                default:
                    MessageBox.Show("没找到卡!");
                    CloseCard();
                    break;
            }
            GetCallBackEventHandler temp = GetCallBack;
            if (temp != null)
                temp(bm);
            return true;
        }
    }
}
