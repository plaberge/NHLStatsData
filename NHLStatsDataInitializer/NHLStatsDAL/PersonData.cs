using System;
using System.Collections.Generic;
using System.Text;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace NHLStatsDAL
{
    public class PersonData
    {
        public static int InsertPerson(Person p)
        {
            if (!(p is null))
            {
                DataAccessHelper dataAccess = new DataAccessHelper("");
                //string sqlStatement = "EXEC spCreateSchedule @scheduleDate, @season, @totalItems, @totalEvents, @totalGames, @totalMatches, @rawJson, @scheduleID OUT";
                string sqlStatement = "spCreatePerson";

                List<SQLParameter> sqlParameterList = new List<SQLParameter>();

                // Create the list of input parameters
                sqlParameterList.Add(new SQLParameter("@personId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.personId, "string"), "in"));
                sqlParameterList.Add(new SQLParameter("@fullName", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.fullName, "string"), "in"));
                sqlParameterList.Add(new SQLParameter("@role", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.role, "string"), "in"));
                sqlParameterList.Add(new SQLParameter("@subRole", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(p.subRole, "string"), "in"));
                //sqlParameterList.Add(new SQLParameter("@rawJson", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>("NULL", "string"), "in"));


                // Create the output parameter

                sqlParameterList.Add(new SQLParameter("@personIdentity", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));

                return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);
            }
            else
                return -1;

        }

        public static int InsertGameOfficials(string personId, string gameId)
        {
            DataAccessHelper dataAccess = new DataAccessHelper("");
            //string sqlStatement = "EXEC spCreateSchedule @scheduleDate, @season, @totalItems, @totalEvents, @totalGames, @totalMatches, @rawJson, @scheduleID OUT";
            string sqlStatement = "spCreateGameOfficials";

            List<SQLParameter> sqlParameterList = new List<SQLParameter>();

            // Create the list of input parameters
            sqlParameterList.Add(new SQLParameter("@personId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(personId, "string"), "in"));
            sqlParameterList.Add(new SQLParameter("@gameId", System.Data.SqlDbType.VarChar, DataAccessHelper.SafeOutput<string>(gameId, "string"), "in"));


            // Create the output parameter

            sqlParameterList.Add(new SQLParameter("@gameOfficialsIdentity", System.Data.SqlDbType.Int, DataAccessHelper.SafeOutput<int>(Convert.ToInt32("0"), "number"), "out"));

            return dataAccess.ExecuteParameterizedQuery(sqlParameterList, sqlStatement);

        }
    }
}
