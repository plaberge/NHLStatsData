using System;
using System.Collections.Generic;
using System.Text;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace NHLStatsDAL
{
    public class PlayerGameStatsData
    {
        public static int InsertPlayerGameStats(PlayerGameStats p, string gameId)
        {
            DataAccessHelper dataAccess = new DataAccessHelper("");
            string sqlStatement = "spCreatePlayerGameStats";

            List<SQLParameter> sqlParameterList = new List<SQLParameter>();

            // Create the list of input parameters
            sqlParameterList.Add(new SQLParameter("@gameId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(gameId, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@playerId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(p.playerID, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@position", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.position, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@timeOnIce", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Utilities.TimeToInt(DataAccessHelper.SafeOutput<string>(p.timeOnIce, "number")), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@assists", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.assists, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@goals", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.goals, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@shots", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.shots, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@hits", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.hits, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@powerPlayGoals", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.powerPlayGoals, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@powerPlayAssists", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.powerPlayAssists, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@penaltyMinutes", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.penaltyMinutes, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@faceoffWins", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.faceoffWins, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@faceoffWinPercentage", System.Data.SqlDbType.Decimal, DataAccessHelper.SafeOutput<string>(Utilities.PareDecimals(p.faceoffWinPercentage).ToString(), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@faceoffsTaken", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.faceoffsTaken, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@takeaways", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.takeaways, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@giveaways", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.giveaways, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@shorthandedGoals", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.shorthandedGoals, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@shorthandedAssists", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.shorthandedAssists, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@blocked", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.blocked, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@plusMinus", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.plusMinus, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@evenTimeOnIce", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Utilities.TimeToInt(DataAccessHelper.SafeOutput<string>(p.evenTimeOnIce, "number")), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@powerPlayTimeOnIce", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Utilities.TimeToInt(DataAccessHelper.SafeOutput<string>(p.powerPlayTimeOnIce, "number")), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@shorthandedTimeOnIce", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Utilities.TimeToInt(DataAccessHelper.SafeOutput<string>(p.shorthandedTimeOnIce, "number")), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@goalieTimeOnIce", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Utilities.TimeToInt(DataAccessHelper.SafeOutput<string>(p.goalieTimeOnIce, "number")), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@shotsFaced", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.shotsFaced, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@shotsSaved", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.shotsSaved, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@powerPlayShotsSaved", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.powerPlayShotsSaved, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@shorthandedShotsSaved", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.shorthandedShotsSaved, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@evenSaved", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.evenSaved, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@shorthandedShotsAgainst", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.shorthandedShotsAgainst, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@evenShotsAgainst", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.evenShotsAgainst, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@powerPlayShotsAgainst", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(p.powerPlayShotsAgainst, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@decision", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.decision, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@savePercentage", System.Data.SqlDbType.Decimal, DataAccessHelper.SafeOutput<string>(Utilities.PareDecimals(p.savePercentage).ToString(), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@evenSavePercentage", System.Data.SqlDbType.Decimal, DataAccessHelper.SafeOutput<string>(Utilities.PareDecimals(p.evenSavePercentage).ToString(), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@powerPlaySavePercentage", System.Data.SqlDbType.Decimal, DataAccessHelper.SafeOutput<string>(Utilities.PareDecimals(p.powerPlaySavePercentage).ToString(), "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@shorthandedSavePercentage", System.Data.SqlDbType.Decimal, DataAccessHelper.SafeOutput<string>(Utilities.PareDecimals(p.shorthandedSavePercentage).ToString(), "number"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));

            string theQuery = "EXEC spCreatePlayerGameStats ";
            foreach (SQLParameter s in sqlParameterList)
            {
                Console.WriteLine("{0} = {1} ({2})", s.paramName, s.paramValue, s.paramType);
                if (s.paramType.ToString().ToUpper() == "VARCHAR" || s.paramType.ToString().ToUpper() == "N")
                    theQuery = theQuery + "'" + s.paramValue + "', ";
                else
                    theQuery = theQuery + s.paramValue + ", ";
            }

            // Create the output parameter

            sqlParameterList.Add(new SQLParameter("@playerGameStatsIdentity", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));

            return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);
        }
    }
}
