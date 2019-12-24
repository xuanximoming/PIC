using System;
using System.Collections.Generic;
using System.Text;

namespace SIS_Model
{
    public static class SingleSysFunClass
    {
        private static int modelidclassone;
        private static int modelidclasstwo;
        public static int ModelIdClassOne
        {
            get { return modelidclassone; }
            set { modelidclassone = value; }
        }

       public static int ModelIdClassTwo
       {
           get { return modelidclasstwo; }
           set { modelidclasstwo = value; }
       }
    }
}
