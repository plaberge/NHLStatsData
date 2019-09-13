using System;
using System.Collections.Generic;
using System.Text;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace NHLStatsDAL
{
    public class ScheduleData
    {
        public static int InsertSchedule(Schedule theSchedule)
        {
            DataTable dtSQLData = new DataTable();
            // Make the SQL statement template
            DataAccessHelper dataAccess = new DataAccessHelper("");
            //string sqlStatement = "EXEC spCreateSchedule @scheduleDate, @season, @totalItems, @totalEvents, @totalGames, @totalMatches, @rawJson, @scheduleID OUT";
            string sqlStatement = "spCreateSchedule";

            List<SQLParameter> sqlParameterList = new List<SQLParameter>();

            sqlParameterList.Add(new SQLParameter("@scheduleDate", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(theSchedule.scheduleDate, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@season", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(theSchedule.season, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@totalItems", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32(theSchedule.totalItems), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@totalEvents", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32(theSchedule.totalEvents), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@totalGames", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32(theSchedule.totalGames), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@totalMatches", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32(theSchedule.totalMatches), "number"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@scheduleID", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));


            return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);

        }
    }
}
