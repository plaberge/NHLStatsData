using System;
using System.Collections.Generic;
using System.Text;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace NHLStatsDAL
{
    public class GameEventData
    {
        public static int InsertGameEvent(GameEvent ge, string gameId)
        {
            DataAccessHelper dataAccess = new DataAccessHelper("");
            //string sqlStatement = "EXEC spCreateSchedule @scheduleDate, @season, @totalItems, @totalEvents, @totalGames, @totalMatches, @rawJson, @scheduleID OUT";
            string sqlStatement = "spCreateGameEvent";

            List<SQLParameter> sqlParameterList = new List<SQLParameter>();

            // Create the list of input parameters
            sqlParameterList.Add(new SQLParameter("@eventId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(ge.eventID, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@correspondingGameId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(gameId, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@eventType", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(ge.eventType, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@eventCode", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(ge.eventCode, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@eventTypeId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(ge.eventTypeID, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@eventDescription", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(ge.eventDescription, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@eventSecondaryType", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(ge.eventSecondaryType, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@eventIdX", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(ge.eventIDx, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@period", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(ge.period, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@periodType", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(ge.periodType, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@periodOrdinalNumber", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(ge.ordinalPeriodNumber, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@periodTimeMinutes", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32(Utilities.GetTimeMinutesSeconds(ge.periodTime)[0]), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@periodTimeSeconds", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32(Utilities.GetTimeMinutesSeconds(ge.periodTime)[1]), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@periodTimeRemainingMinutes", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32(Utilities.GetTimeMinutesSeconds(ge.periodTimeRemaining)[0]), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@periodTimeRemainingSeconds", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32(Utilities.GetTimeMinutesSeconds(ge.periodTimeRemaining)[1]), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@eventTimeStamp", System.Data.SqlDbType.DateTime, DataAccessHelper.SafeOutput<string>(ge.dateTimeStamp, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@goalsAway", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(ge.goalsAway, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@goalsHome", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(ge.goalsHome, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@xCoordinate", System.Data.SqlDbType.Decimal, DataAccessHelper.SafeOutput<string>(ge.xCoordinate, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@yCoordinate", System.Data.SqlDbType.Decimal, DataAccessHelper.SafeOutput<string>(ge.yCoordinate, "number"), "in"));
            if (ge.team is null)
                sqlParameterList.Add(new SQLParameter("@teamId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(0, "number"), "in"));
            else
                sqlParameterList.Add(new SQLParameter("@teamId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(ge.team.NHLTeamID, "number"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));


            // Create the output parameter

            sqlParameterList.Add(new SQLParameter("@gameEventIdentity", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));

            return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);

        }
    }
}
