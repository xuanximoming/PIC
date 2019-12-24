using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace BaseControls
{
    public class DataRelationEx:System.Data.DataRelation
    {
        private string[] relationCodes;

        public DataRelationEx(string relationName, DataColumn parentColumn, DataColumn childColumn, string relationCode)
            : base(relationName, parentColumn, childColumn)
        {
            this.relationCodes = new string[1];
            this.relationCodes[0] = relationCode;
        }

        public DataRelationEx(string relationName, DataColumn[] parentColumn, DataColumn[] childColumn, string[] relationCodes)
            : base(relationName, parentColumn, childColumn)
        {
            this.relationCodes = relationCodes;
        }

        public string[] GetRelationCodes()
        {
            return this.relationCodes;
        }
    }
}
