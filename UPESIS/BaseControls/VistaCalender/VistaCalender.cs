using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BaseControls.VistaCalender
{
    public partial class VistaCalendar : UserControl
    {
        Timer timer = new Timer();
        bool useToday = true;
        DateTime curDate;
        string strYearMonth, strDay, strDayOfWeek, strCnYearInfo;
        Font fontDefault = new Font("΢���ź�", 9);
        Font fontDay = new Font("΢���ź�", 46);
        Font fontCnYearInfo = new Font("΢���ź�", 7.5f);

        public enum VistaCalendarStyle
        {
            Default, Red, Purple, Green, Gray, Brown, Orange
        }

        private VistaCalendarStyle style = VistaCalendarStyle.Default;
        /// <summary>
        /// ��ʽ
        /// </summary>
        public VistaCalendarStyle Style
        {
            get { return style; }
            set { style = value; this.Invalidate(); }
        }

        public VistaCalendar()
        {
            InitializeComponent();

            curDate = DateTime.Today;
            UpdateCurrentDateInfo();

            timer.Interval = 6000;  //1����ˢ��һ��
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);

            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;

            this.Paint += new PaintEventHandler(VistaCalendar_Paint);
            this.Resize += new EventHandler(VistaCalendar_Resize);
            this.MouseUp += new MouseEventHandler(VistaCalendar_MouseUp);
        }

        void VistaCalendar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, e.Location);
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (useToday && curDate != DateTime.Today)
            {
                curDate = DateTime.Today;
                UpdateCurrentDateInfo();

                this.Invalidate();
            }
        }

        /// <summary>
        /// ���µ�ǰ������Ϣ
        /// </summary>
        private void UpdateCurrentDateInfo()
        {
            strYearMonth = curDate.Year.ToString() + "��  " + curDate.Month.ToString() + "��";
            strDay = curDate.Day.ToString();
            strDayOfWeek = GetDayOfWeekString(curDate);

            ChineseCalendarInfo cn = new ChineseCalendarInfo(curDate);
            string cnInfo = cn.LunarYearSexagenary;
            cnInfo += cn.LunarYearAnimal + "��  ";
            cnInfo += cn.LunarMonthText + "��";
            cnInfo += cn.LunarDayText;
            strCnYearInfo = cnInfo;
        }

        /// <summary>
        /// ��ȡ���ڵ������ַ���
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private string GetDayOfWeekString(DateTime date)
        {
            string weekday;
            int dayOfWeek = (int)date.DayOfWeek;
            if (dayOfWeek == 1)
                weekday = "����һ ";
            else if (dayOfWeek == 2)
                weekday = "���ڶ� ";
            else if (dayOfWeek == 3)
                weekday = "������ ";
            else if (dayOfWeek == 4)
                weekday = "������ ";
            else if (dayOfWeek == 5)
                weekday = "������ ";
            else if (dayOfWeek == 6)
                weekday = "������ ";
            else
                weekday = "������ ";
            return weekday;
        }

        private CustomRectangle positionRect = new CustomRectangle();
        /// <summary>
        /// λ�þ���
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CustomRectangle PositionRect
        {
            get { return positionRect; }
            set { positionRect = value; }
        }

        void VistaCalendar_Resize(object sender, EventArgs e)
        {
            if (positionRect == null) positionRect = new CustomRectangle();
            positionRect.Width = (int)ImageBg.Width;
            positionRect.Height = (int)ImageBg.Height;
            positionRect.Top = (int)(this.ClientSize.Height < ImageBg.Height ? 0 : (this.ClientSize.Height - ImageBg.Height) / 2f);
            positionRect.Left = (int)(this.ClientSize.Width < ImageBg.Width ? 0 : (this.ClientSize.Width - ImageBg.Width) / 2f);

            this.Invalidate();
        }

        internal SolidBrush FontBrush
        {
            get
            {
                if (style == VistaCalendarStyle.Green)
                    return new SolidBrush(Color.Black);
                else
                    return new SolidBrush(Color.White);
            }
        }

        void VistaCalendar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            //����
            e.Graphics.DrawImage(ImageBg, positionRect.ToRectangle());

            //��������
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(strYearMonth, fontDefault, FontBrush,
                new Rectangle((int)positionRect.X + 10, (int)positionRect.Y + 26, (int)positionRect.Width - 20, 20), format);
            e.Graphics.DrawString(strDayOfWeek, fontDefault, FontBrush,
                new Rectangle((int)positionRect.X + 10, (int)positionRect.Y + 106, (int)positionRect.Width - 20, 20), format);
            e.Graphics.DrawString(strCnYearInfo, fontCnYearInfo, FontBrush,
                new Rectangle((int)positionRect.X + 10, (int)positionRect.Y + 122, (int)positionRect.Width - 20, 20), format);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            e.Graphics.DrawString(strDay, fontDay, new SolidBrush(Color.Black),
                new Rectangle((int)positionRect.X + 12, (int)positionRect.Y + 40, (int)positionRect.Width - 20, 80), format);
            e.Graphics.DrawString(strDay, fontDay, new SolidBrush(Color.White),
                new Rectangle((int)positionRect.X + 10, (int)positionRect.Y + 38, (int)positionRect.Width - 20, 80), format);

        }

        /// <summary>
        /// ����ͼƬ
        /// </summary>
        private Bitmap ImageBg
        {
            get
            {
                switch (style)
                {
                    case VistaCalendarStyle.Orange:
                        return global::BaseControls.Properties.Resources.Calendar_bg;
                    case VistaCalendarStyle.Brown:
                        return global::BaseControls.Properties.Resources.Calendar_bg_brown;
                    case VistaCalendarStyle.Gray:
                        return global::BaseControls.Properties.Resources.Calendar_bg_gray;
                    case VistaCalendarStyle.Green:
                        return global::BaseControls.Properties.Resources.Calendar_bg_green;
                    case VistaCalendarStyle.Purple:
                        return global::BaseControls.Properties.Resources.Calendar_bg_purple;
                    case VistaCalendarStyle.Red:
                        return global::BaseControls.Properties.Resources.Calendar_bg_red;
                    default:
                        return global::BaseControls.Properties.Resources.Calendar_bg_blue;
                }
            }
        }

        private void mnu�ŷ��ٻ�_Click(object sender, EventArgs e)
        {
            this.style = VistaCalendarStyle.Orange;
            this.Invalidate();
        }

        private void mnuεȻ����_Click(object sender, EventArgs e)
        {
            this.style = VistaCalendarStyle.Default;
            this.Invalidate();
        }

        private void mnu��Ѭ����_Click(object sender, EventArgs e)
        {
            this.style = VistaCalendarStyle.Purple;
            this.Invalidate();
        }

        private void mnuʱ�о���_Click(object sender, EventArgs e)
        {
            this.style = VistaCalendarStyle.Red;
            this.Invalidate();
        }

        private void mnu����ӫ��_Click(object sender, EventArgs e)
        {
            this.style = VistaCalendarStyle.Green;
            this.Invalidate();
        }

        private void mnu��鿧��_Click(object sender, EventArgs e)
        {
            this.style = VistaCalendarStyle.Brown;
            this.Invalidate();
        }

        private void mnu�����Ż�_Click(object sender, EventArgs e)
        {
            this.style = VistaCalendarStyle.Gray;
            this.Invalidate();
        }

        private void mnuת����һ��_Click(object sender, EventArgs e)
        {
            useToday = false;
            curDate = curDate.AddMonths(-1);
            UpdateCurrentDateInfo();
            this.Invalidate();
        }

        private void mnuת����һ��_Click(object sender, EventArgs e)
        {
            useToday = false;
            curDate = curDate.AddDays(-1);
            UpdateCurrentDateInfo();
            this.Invalidate();
        }

        private void mnuת������_Click(object sender, EventArgs e)
        {
            useToday = true;
            curDate = DateTime.Today;
            UpdateCurrentDateInfo();
            this.Invalidate();
        }

        private void mnuת����һ��_Click(object sender, EventArgs e)
        {
            useToday = false;
            curDate = curDate.AddDays(1);
            UpdateCurrentDateInfo();
            this.Invalidate();
        }

        private void mnuת����һ��_Click(object sender, EventArgs e)
        {
            useToday = false;
            curDate = curDate.AddMonths(1);
            UpdateCurrentDateInfo();
            this.Invalidate();
        }


    }
}