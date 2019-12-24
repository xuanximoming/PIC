using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Function
{
    public sealed class ExpressionValidat
    {

        public static bool IsNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg1
                = new System.Text.RegularExpressions.Regex(@"^[-]?\d+[.]?\d*$");
            return reg1.IsMatch(str);
        }

        public static bool IsInt(string str)
        {
            System.Text.RegularExpressions.Regex reg1
                = new System.Text.RegularExpressions.Regex(@"^[0-9]*[1-9][0-9]*$");
            return reg1.IsMatch(str);
        }
    }
}
