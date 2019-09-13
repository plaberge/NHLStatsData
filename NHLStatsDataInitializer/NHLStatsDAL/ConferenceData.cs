using System;
using System.Collections.Generic;
using System.Text;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using NHLStatsDAL;

namespace NHLStatsDataInitializer.Console
{
    public class ConferenceData
    {
        public static int InsertConference(Conference c)
        {
            DataAccessHelper dataAccess = new DataAccessHelper("");
            //string sqlStatement = "EXEC spCreateSchedule @scheduleDate, @season, @totalItems, @totalEvents, @totalGames, @totalMatches, @rawJson, @scheduleID OUT";
            string sqlStatement = "spCreateConference";

            List<SQLParameter> sqlParameterList = new List<SQLParameter>();

            // Create the list of input parameters
            sqlParameterList.Add(new SQLParameter("@conferenceId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(c.conferenceID, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@conferenceName", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(c.conferenceName, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@conferenceAbbreviation", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(c.conferenceAbbreviation, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@shortName", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(c.shortName, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@active", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(c.active, "string"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));


            // Create the output parameter

            sqlParameterList.Add(new SQLParameter("@conferenceIdentity", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));

            return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);

        }
    }
}
