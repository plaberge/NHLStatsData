using System;
using System.Collections.Generic;
using System.Text;

namespace NHLStatsDAL
{
    public class Utilities
    {
        public static int TimeToInt(string timeString)
        {
            //TimeSpan ts = TimeSpan.Parse(timeString);
            string theTime = timeString;

            if (timeString == "NULL")
            {
                theTime = "0:00";
            }

            string[] minsSeconds = theTime.Split(':');

            return (Convert.ToInt32(minsSeconds[0]) * 60) + Convert.ToInt32(minsSeconds[1]);
            //return Convert.ToInt32(ts.TotalSeconds);


        }

        public static string[] GetTimeMinutesSeconds(string timeString)
        {
            string theTime = timeString;
            if (timeString == "NULL" || timeString is null)
            {
                theTime = "0:00";
            }

            string[] minsSeconds = theTime.Split(':');

            return minsSeconds;
        }

        public static decimal PareDecimals(string aDecimal)
        {
            decimal d;
            if (aDecimal is null)
                d = 100;
            else
                d = Decimal.Parse(aDecimal);

            return Convert.ToDecimal(d.ToString("F"));


        }
    }
}
