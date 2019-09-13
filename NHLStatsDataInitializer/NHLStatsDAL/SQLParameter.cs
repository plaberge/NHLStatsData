using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NHLStatsDAL
{
    public class SQLParameter
    {
        public string paramName { get; set; }
        public SqlDbType paramType { get; set; }
        public string paramValue { get; set; }
        public string paramDirection { get; set; }

        public SQLParameter(string theParamName, SqlDbType theParamType, string theParamValue, string theParamDirection)
        {
            paramName = theParamName;
            paramType = theParamType;
            paramValue = theParamValue;
            paramDirection = theParamDirection;

        }
    }
}
