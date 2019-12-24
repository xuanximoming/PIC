using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.RegisterCls
{
    class AgeBirth
    {
        # region 年龄、年龄单位、出身日期同步区


        /// <summary>
        /// 出生日期转换成年龄
        /// </summary>
        /// <param name="AgeUnit"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public string BirthToAge(int AgeUnit,DateTime Value)
        {
            string Age = "";
            switch (AgeUnit)
            {
                case 0://岁
                    int Yspan = 0;
                    Yspan = System.DateTime.Now.Year - Value.Year;
                    if (DateTime.Compare(Value, DateTime.Now.AddYears(-Yspan)) < 0)
                        Age = Convert.ToString(DateTime.Now.Year - Value.Year);
                    else
                        Age = Convert.ToString(DateTime.Now.Year - Value.Year-1);
                        //Yspan = Yspan - 1;
                    //Age = Yspan.ToString();
                   // Age = Convert.ToString(DateTime.Now.Year - Value.Year);
                        break;
                case 1://月
                    Age = Convert.ToString((System.DateTime.Now.Year * 12 + System.DateTime.Now.Month) - (Value.Year * 12 + Value.Month));
                    break;
                case 2://天
                    TimeSpan ts = System.DateTime.Now - Value;
                    Age = Convert.ToString(ts.Days);
                    break;
            }
            return Age;
        }

        /// <summary>
        /// 年龄转换成出生日期
        /// </summary>
        /// <param name="Age"></param>
        /// <param name="AgeUnit"></param>
        /// <param name="Value"></param>
        /// <param name="MinYear">日期控件的最小年值</param>
        /// <param name="MinMonth">日期控件的最小月值</param>
        /// <param name="MinDay">日期控件的最小天值</param>
        /// <returns></returns>
        public DateTime AgeToBirth(string Age, int AgeUnit, DateTime Value, DateTime MinDate)
        {
            if (Age == "")
                return Value;
                int age = Convert.ToInt32(Age);
            if (age > 0)
            {
                DateTime now = System.DateTime.Now;
                int MinYear = MinDate.Year;
                int MinMonth = MinDate.Month;
                int MinDay = MinDate.Day;
                switch (AgeUnit)
                {
                    case 0:
                        if (age <= (now.Year - MinYear))
                        {
                            int year = now.AddYears(-age).Year - Value.Year;
                            if (DateTime.Compare(Value, DateTime.Now.AddYears(-age)) > 0)
                                //   Value = Value.AddYears(year);
                                //else
                                Value = Value.AddYears(year - 1);
                            else
                            {
                                //Value = DateTime.Now.AddYears(-age).AddDays(1);
                            }
                        }
                        else
                            Value = MinDate;
                        break;
                    case 1:
                        int NowMonth = System.DateTime.Now.Month;
                        if (age <= (now.Year * 12 + NowMonth - MinYear * 12 + MinMonth))
                        {
                            int month = now.AddMonths(-age).Year * 12 + now.AddMonths(-age).Month - Value.Year * 12 - Value.Month;
                           Value = Value.AddMonths(month);
                        }
                        else
                            Value = MinDate;
                        break;
                    case 2:
                        int NowDay = System.DateTime.Now.DayOfYear;
                        if (age <= (now.Year * 365 + NowDay - (MinYear * 365 + MinDay)))
                        {
                            TimeSpan ts = now.AddDays(-age) - Value;
                            int days = ts.Days;
                            Value = Value.AddDays(days);
                        }
                        else
                            Value = MinDate;
                        break;
                }
            }
                return Value;
            //System.Windows.Forms.MessageBox.Show("输入年龄太大!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //this.tx_Age.Text = "0";
            //this.dateTimePicker_Birth.Value = System.DateTime.Now;
        }
        #endregion

    }
}
