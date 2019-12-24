using System;
using System.Collections.Generic;
using System.Text;
using ILL;

namespace SIS.ImgGather
{
    public class MSComm
    {
        private System.IO.Ports.SerialPort serialPort;    //串行端口
        private AxMSCommLib.AxMSComm axMScomm;     //MSCOMM32.OCX中的AxMSCommLib库的串口通信控件AxMSComm  
        private System.Timers.Timer timer;    //Timer
        private char comStrCur = 'A';
        private char comStrPre = 'A';
        private char comStrContent = 'A';
        private bool isComConn = false;
        private bool isComDown = false;
        public string CommMode=GetConfig.COS_CommMode;  //0:脚踏开关; 1:按钮
        public string Settings = "9600,N,8,1";
        public int CommPort = 1;
        public delegate void OnCommGather(string GatherMode);
        public OnCommGather onCommGather;
        private long begin = System.DateTime.Now.Ticks;
        private string[] Buttons = GetConfig.COS_ButtonCatch.Split(',');

        /// <summary>
        /// MSComm构造方法1
        /// </summary>
        /// <param name="MScomm">参数为AxMSComm类型</param>
        public MSComm(AxMSCommLib.AxMSComm MScomm)
        {
            this.axMScomm = MScomm;
            this.axMScomm.OnComm += new EventHandler(MScomm_OnComm);
            if (this.CommMode == "0")
            {
                this.timer = new System.Timers.Timer();
                this.timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            }
        }

        /// <summary>
        /// MSComm构造方法2
        /// </summary>
        /// <param name="sp">参数为串行端口</param>
        public MSComm(System.IO.Ports.SerialPort sp)
        {
            this.serialPort = sp;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort_DataReceived);
            this.serialPort.PinChanged += new System.IO.Ports.SerialPinChangedEventHandler(serialPort_PinChanged);
            if (this.CommMode == "0")
            {
                this.timer = new System.Timers.Timer();
                this.timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            }
        }

        void serialPort_PinChanged(object sender, System.IO.Ports.SerialPinChangedEventArgs e)
        {
            switch (this.CommMode)
            {
                case "1":
                    switch (e.EventType)
                    {
                        case System.IO.Ports.SerialPinChange.CtsChanged:
                            if (this.serialPort.CtsHolding)
                                this.onCommGather(Buttons[0]);
                            break;
                        case System.IO.Ports.SerialPinChange.DsrChanged:
                            if (this.serialPort.DsrHolding)
                                this.onCommGather(Buttons[1]);
                            break;
                        case System.IO.Ports.SerialPinChange.CDChanged:
                            if (this.serialPort.CDHolding)
                                this.onCommGather(Buttons[2]);
                            break;
                        case System.IO.Ports.SerialPinChange.Ring:
                            this.onCommGather(Buttons[3]);
                            break;
                    }
                    break;
                default :
                    break;
            }
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (this.CommMode == "0")
                if (e.EventType == System.IO.Ports.SerialData.Chars)
                {
                    int c = this.serialPort.ReadChar();
                    this.comStrCur = Convert.ToChar(c);
                    this.isComConn = true;

                }
        }


        public bool OpenCom()
        {
            try
            {
                axMScomm.CommPort = (short)CommPort;
                axMScomm.Settings = Settings;
                axMScomm.RTSEnable = true;
                axMScomm.RThreshold = 1;
                axMScomm.InputMode = MSCommLib.InputModeConstants.comInputModeBinary;
                axMScomm.InputLen = 1;
                axMScomm.PortOpen = true;
                if (this.CommMode == "0")
                    this.timer.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void MScomm_OnComm(object sender, EventArgs e)
        {
            if (this.CommMode == "1")
            {
                switch (axMScomm.CommEvent)
                {
                    case 3:
                        if (this.axMScomm.CTSHolding)
                            this.onCommGather(Buttons[0]);
                        break;
                    case 4:
                        if (this.axMScomm.DSRHolding)
                            this.onCommGather(Buttons[1]);
                        break;
                    case 5:
                        if (this.axMScomm.CDHolding)
                            this.onCommGather(Buttons[2]);
                        break;
                    case 6:
                        this.onCommGather(Buttons[3]);
                        break;
                }
            }
            else
            {
                if (axMScomm.CommEvent == 2)
                {
                    object input = axMScomm.Input;
                    byte[] inb = (byte[])input;
                    this.comStrCur = Convert.ToChar(inb[0]);
                    this.isComConn = true;
                }
            }
        }

        public void CloseComm()
        {
            if (this.timer != null)
                this.timer.Stop();
            this.axMScomm = null;
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.timer.Stop();
            if (this.comStrContent == 'B')
                this.comStrContent = 'E';
            else
                this.comStrContent = 'B';

            byte[] outb = Encoding.Default.GetBytes(this.comStrContent.ToString());
            this.axMScomm.Output = outb;
            if (isComDown)
            {
                if (this.comStrPre == this.comStrCur)
                {
                    this.isComConn = false;
                    this.isComDown = false;
                }
            }
            else
                if (this.isComConn)
                {
                    this.isComDown = true;
                    if (GetConfig.COS_IsPerlinNoise)
                    {
                        long end = System.DateTime.Now.Ticks;
                        TimeSpan ts = new TimeSpan(end - begin);
                        if (ts.Milliseconds > 300)
                        {
                            this.onCommGather("0");
                        }
                        begin = System.DateTime.Now.Ticks;
                    }
                    else
                        this.onCommGather("0");
                }
            this.comStrPre = this.comStrCur;
            this.axMScomm.InputLen = 0;
            this.timer.Start();
        }

    }
}
