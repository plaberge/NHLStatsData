using System;
using System.Collections.Generic;
using System.Text;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace NHLStatsDAL
{
    public class TeamData
    {
        public static int InsertTeam(Team t)
        {
            DataAccessHelper dataAccess = new DataAccessHelper("");
            //string sqlStatement = "EXEC spCreateSchedule @scheduleDate, @season, @totalItems, @totalEvents, @totalGames, @totalMatches, @rawJson, @scheduleID OUT";
            string sqlStatement = "spCreateTeam";

            List<SQLParameter> sqlParameterList = new List<SQLParameter>();

            // Create the list of input parameters
            sqlParameterList.Add(new SQLParameter("@nhlTeamId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(t.NHLTeamID, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@teamName", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(t.TeamName, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@teamCity", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(t.TeamCity, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@teamAbbreviation", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(t.TeamAbbreviation, "string"), "in"));

            if (t.TeamVenue is null)
                sqlParameterList.Add(new SQLParameter("@teamVenueId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>("0", "string"), "in"));
            else
                sqlParameterList.Add(new SQLParameter("@teamVenueId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(t.TeamVenue.venueID, "string"), "in"));

            sqlParameterList.Add(new SQLParameter("@firstYearOfPlay", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(t.FirstYearOfPlay, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@divisionId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<int>(t.teamDivision.divisionId, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@webSite", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(t.webSite, "string"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));

            // Create the output parameter

            sqlParameterList.Add(new SQLParameter("@teamIdentity", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));

            return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);

        }
    }
}
