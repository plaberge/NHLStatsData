using System;
using System.Collections.Generic;
using System.Text;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace NHLStatsDAL
{
    public class VenueData
    {
        public static int InsertVenue(Venue v)
        {
            DataAccessHelper dataAccess = new DataAccessHelper("");
            //string sqlStatement = "EXEC spCreateSchedule @scheduleDate, @season, @totalItems, @totalEvents, @totalGames, @totalMatches, @rawJson, @scheduleID OUT";
            string sqlStatement = "spCreateVenue";

            List<SQLParameter> sqlParameterList = new List<SQLParameter>();

            // Create the list of input parameters
            sqlParameterList.Add(new SQLParameter("@venueId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(v.venueID, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@venueName", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(v.venueName, "string"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));


            // Create the output parameter

            sqlParameterList.Add(new SQLParameter("@venueIdentity", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));

            return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);

        }
    }
}
