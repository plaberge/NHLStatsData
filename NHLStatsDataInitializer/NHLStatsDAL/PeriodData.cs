using System;
using System.Collections.Generic;
using System.Text;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace NHLStatsDAL
{
    public class PeriodData
    {
        public static int InsertPeriod(Period p)
        {
            DataAccessHelper dataAccess = new DataAccessHelper("");
            string sqlStatement = "spCreatePeriod";

            List<SQLParameter> sqlParameterList = new List<SQLParameter>();

            // Create the list of input parameters
            sqlParameterList.Add(new SQLParameter("@gameId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.gameId, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@periodType", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.periodType, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@periodTimeStart", System.Data.SqlDbType.Time, DataAccessHelper.SafeOutput<string>(p.periodTimeStart, "time"), "in"));
            sqlParameterList.Add(new SQLParameter("@periodTimeEnd", System.Data.SqlDbType.Time, DataAccessHelper.SafeOutput<string>(p.periodTimeEnd, "time"), "in"));
            sqlParameterList.Add(new SQLParameter("@periodNum", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.periodNum, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@periodNumOrd", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.periodNumOrd, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeTeamId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.homeTeamId, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeGoals", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.homeGoals, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeShotsOnGoal", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.homeShotsOnGoal, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeRinkSide", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.homeRinkSide, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayTeamId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.awayTeamId, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayGoals", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.awayGoals, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayShotsOnGoal", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.awayShotsOnGoal, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayRinkSide", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.awayRinkSide, "string"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));



            // Create the output parameter

            sqlParameterList.Add(new SQLParameter("@periodIdentity", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));

            return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);

        }
    }
}
