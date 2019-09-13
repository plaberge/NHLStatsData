using System;
using System.Collections.Generic;
using System.Text;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace NHLStatsDAL
{
    public class PlayerData
    {
        public static int InsertPlayer(PlayerGameStats p)
        {
            DataAccessHelper dataAccess = new DataAccessHelper("");
            //string sqlStatement = "EXEC spCreateSchedule @scheduleDate, @season, @totalItems, @totalEvents, @totalGames, @totalMatches, @rawJson, @scheduleID OUT";
            string sqlStatement = "spCreatePlayer";

            List<SQLParameter> sqlParameterList = new List<SQLParameter>();

            // Create the list of input parameters
            sqlParameterList.Add(new SQLParameter("@playerId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(p.playerID, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@firstName", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.firstName, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@lastName", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.lastName, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@primaryNumber", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<int>(p.primaryNumber, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@birthDate", System.Data.SqlDbType.Date, DataAccessHelper.SafeOutput<string>(p.birthDate, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@currentAge", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(p.currentAge, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@birthCity", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.birthCity, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@birthStateProvince", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.birthStateProvince, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@birthCountry", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.birthCountry, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@nationality", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.nationality, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@height", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(p.height, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@weight", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(p.weight, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@active", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.active, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@alternateCaptain", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.alternateCaptain, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@captain", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.captain, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@rookie", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.rookie, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@shootsCatches", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.shootsCatches, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@rosterStatus", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.rosterStatus, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@currentTeamID", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(p.currentTeamID, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@primaryPositionCode", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.primaryPositionCode, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@primaryPositionName", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.primaryPositionName, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@primaryPositionType", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.primaryPositionType, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@primaryPositionAbbr", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.primaryPositionAbbr, "string"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));


            // Create the output parameter

            sqlParameterList.Add(new SQLParameter("@playerIdentity", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));

            return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);

        }
    }
}
