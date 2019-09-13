using System;
using System.Collections.Generic;
using System.Text;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace NHLStatsDAL
{
    public class GameData
    {
        public static int InsertGame(Game game, int scheduleID)
        {
            DataTable dtSQLData = new DataTable();
            // Make the SQL statement template
            DataAccessHelper dataAccess = new DataAccessHelper("");
            //string sqlStatement = "EXEC spCreateSchedule @scheduleDate, @season, @totalItems, @totalEvents, @totalGames, @totalMatches, @rawJson, @scheduleID OUT";
            string sqlStatement = "spCreateGame";

            List<SQLParameter> sqlParameterList = new List<SQLParameter>();

            // Create the list of input parameters
            sqlParameterList.Add(new SQLParameter("@gameID", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameID, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@scheduleID", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(scheduleID, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@gameLink", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameLink, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@gameType", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameType, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@season", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.season, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@gameDate", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameDate, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@abstractGameState", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.abstractGameState, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@codedGameState", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.codedGameState, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@detailedState", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.detailedState, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@statusCode", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.statusCode, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeTeamId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(game.homeTeam.NHLTeamID, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayTeamId", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(game.awayTeam.NHLTeamID, "number"), "in"));

            if (game.gameVenue is null)
                sqlParameterList.Add(new SQLParameter("@venueId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("0", "string"), "in"));
            else
                sqlParameterList.Add(new SQLParameter("@venueId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameVenue.venueID, "string"), "in"));

            //sqlParameterList.Add(new SQLParameter("@rawGameJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewTitle", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewTitle, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewHeadline", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewHeadline, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewSubHead", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewSubHead, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewSeoDescription", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewSeoDescription, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewUrl", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewUrl, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto2568x1444", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto2568x1444, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto2208x1242", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto2208x1242, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto2048x1152", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto2048x1152, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto1704x960", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto1704x960, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto1536x864", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto1536x864, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto1284x722", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto1284x722, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto1136x640", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto1136x640, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto1024x576", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto1024x576, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto960x540", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto960x540, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto768x432", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto768x432, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto640x360", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto640x360, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto568x320", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto568x320, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto372x210", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto372x210, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto320x180", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto320x180, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto248x140", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto248x140, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@previewMediaPhoto124x70", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.previewMediaPhoto124x70, "string"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawGameContentJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapTitle", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapTitle, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapHeadline", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapHeadline, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapSubHead", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapSubHead, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapSeoDescription", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapSeoDescription, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapUrl", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapUrl, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto2568x1444", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto2568x1444, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto2208x1242", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto2208x1242, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto2048x1152", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto2048x1152, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto1704x960", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto1704x960, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto1536x864", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto1536x864, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto1284x722", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto1284x722, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto1136x640", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto1136x640, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto1024x576", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto1024x576, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto960x540", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto960x540, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto768x432", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto768x432, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto640x360", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto640x360, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto568x320", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto568x320, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto372x210", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto372x210, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto320x180", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto320x180, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto248x140", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto248x140, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapMediaPhoto124x70", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapMediaPhoto124x70, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapPlaybackFLASH_192K_320X180", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapPlaybackFLASH_192K_320X180, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapPlaybackFLASH_450K_400X224", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapPlaybackFLASH_450K_400X224, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapPlaybackFLASH_1200K_640X360", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapPlaybackFLASH_1200K_640X360, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@recapPlaybackFLASH_1800K_960X540", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameContent.recapPlaybackFLASH_1800K_960X540, "string"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawBoxScoreJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawHomeBoxScoreJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));
            //sqlParameterList.Add(new SQLParameter("@rawAwayBoxScoreJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeTotalGoals", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.homeTeamStats.totalGoals, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeTotalPIM", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.homeTeamStats.totalPIM, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeTotalShots", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.homeTeamStats.totalShots, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@homePowerPlayPercentage", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.homeTeamStats.powerPlayPercentage, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@homePowerPlayGoals", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.homeTeamStats.powerPlayGoals, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@homePowerPlayOpportunities", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.homeTeamStats.powerPlayOpportunities, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeFaceOffWinPercentage", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.homeTeamStats.faceOffWinPercentage, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeBlockedShots", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.homeTeamStats.blockedShots, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeTakeaways", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.homeTeamStats.takeaways, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@homeGiveaways", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.homeTeamStats.giveaways, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayTotalGoals", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.awayTeamStats.totalGoals, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayTotalPIM", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.awayTeamStats.totalPIM, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayTotalShots", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.awayTeamStats.totalShots, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayPowerPlayPercentage", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.awayTeamStats.powerPlayPercentage, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayPowerPlayGoals", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.awayTeamStats.powerPlayGoals, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayPowerPlayOpportunities", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.awayTeamStats.powerPlayOpportunities, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayFaceOffWinPercentage", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.awayTeamStats.faceOffWinPercentage, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayBlockedShots", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.awayTeamStats.blockedShots, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayTakeaways", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.awayTeamStats.takeaways, "number"), "in"));
            sqlParameterList.Add(new SQLParameter("@awayGiveaways", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.awayTeamStats.giveaways, "number"), "in"));

            if (game.gameBoxScore.homeTeamStats.coach is null)
            {
                sqlParameterList.Add(new SQLParameter("@homeCoachId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));
            }
            else
            {
                sqlParameterList.Add(new SQLParameter("@homeCoachId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.homeTeamStats.coach.personId, "string"), "in"));
            }

            if (game.gameBoxScore.awayTeamStats.coach is null)
            {
                sqlParameterList.Add(new SQLParameter("@awayCoachId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));

            }
            else
            {
                sqlParameterList.Add(new SQLParameter("@awayCoachId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(game.gameBoxScore.awayTeamStats.coach.personId, "string"), "in"));
            }


            // Create the output parameter
            sqlParameterList.Add(new SQLParameter("@gameIdentity", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));

            return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);
        }
    }
}
