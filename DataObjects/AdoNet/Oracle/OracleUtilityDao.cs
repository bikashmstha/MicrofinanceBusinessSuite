using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObjects.AdoNet.Oracle
{
    public static class OracleUtilityDao
    {
        public static string ConvertNullToNumber(string value)
        {
            if (string.IsNullOrEmpty(value) || value=="null")
            {
                return "0";
            }
            else
            {
                return value;
            }
        }
    }
}
