using System;
using System.Collections.Generic;
using System.Text;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace NHLStatsDAL
{
    public class DivisionData
    {
        public static int InsertDivision(Division d)
        {
            DataAccessHelper dataAccess = new DataAccessHelper("");
            //string sqlStatement = "EXEC spCreateSchedule @scheduleDate, @season, @totalItems, @totalEvents, @totalGames, @totalMatches, @rawJson, @scheduleID OUT";
            string sqlStatement = "spCreateDivision";

            List<SQLParameter> sqlParameterList = new List<SQLParameter>();

            // Create the list of input parameters
            sqlParameterList.Add(new SQLParameter("@divisionId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(d.divisionId, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@divisionName", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(d.divisionName, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@shortName", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(d.shortName, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@abbreviation", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(d.abbreviation, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@conferenceId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(d.conference.conferenceID, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@active", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(d.active, "string"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));


            // Create the output parameter

            sqlParameterList.Add(new SQLParameter("@divisionIdentity", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));

            return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);

        }
    }
}
