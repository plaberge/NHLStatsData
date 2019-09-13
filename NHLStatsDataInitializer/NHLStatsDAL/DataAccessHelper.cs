using System;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace NHLStatsDAL
{
    public class DataAccessHelper
    {
        private static string _databaseConnectionString { get; set; }
        private static string _userName { get; set; }
        private static string _password { get; set; }
        private static string _dataSource { get; set; }
        private static string _databaseName { get; set; }

        // The Azure Cosmos DB endpoint
        //private static readonly string EndpointUri = "https://nhlstats.documents.azure.com:443/";
        // The primary key for the Azure Cosmos account.
        //private static readonly string PrimaryKey = "jai58IvOWYMiqjE0yeGcNfaxOYK09g7FPahsl3DhayHe7ArWt1beIFDN36VaunvypANiIy0zplG4SElewdb9dA==";

        // The Cosmos client instance
        //private CosmosClient cosmosClient;

        // The Comsmos database 
        //private CosmosDatabase database;

        // The container we will create.
        //private CosmosContainer container;

        // The name of the database and containers 
        //private string databaseId = "NHLStatsJSON";
        //private string conferenceContainerId = "Conference";
        //private string divisionContainerId = "Division";
        //private string gameContainerId = "Game";
        //private string gameContentContainerId = "GameContent";
        //private string playerContainerId = "Player";
        //private string scheduleContainerId = "Schedule";
        //private string teamContainerId = "Team";
        //private string venueContainerId = "Venue";

        private SqlConnectionStringBuilder _connectionStringBuilder;


        public DataAccessHelper(string SQLconnection)
        {

            // CosmosDB connectivity
            //cosmosClient = new CosmosClient(EndpointUri, PrimaryKey);


            // SQL Database functionality
            if (SQLconnection == "")
            {
                // If you can't get the DB Connection string from an environment variable, build it now.



                // SQL DB data Source value (you may want to be more secure with this - feel free to change!)
                _userName = "PUT_DB_USERNAME_HERE";
                _password = "PUT_PASSWORD_HERE";
                _dataSource = "PUT_DATABASE_SERVER_NAME_HERE";
                _databaseName = "PUT_DATABASE_NAME_HERE";

             




                _connectionStringBuilder = new SqlConnectionStringBuilder();
                _connectionStringBuilder.DataSource = DataAccessHelper._dataSource;
                _connectionStringBuilder.InitialCatalog = DataAccessHelper._databaseName;
                _connectionStringBuilder.Encrypt = true;
                _connectionStringBuilder.TrustServerCertificate = true;
                _connectionStringBuilder.UserID = DataAccessHelper._userName;
                _connectionStringBuilder.Password = DataAccessHelper._password;

            }
            else
            {
                _connectionStringBuilder = new SqlConnectionStringBuilder(SQLconnection);
            }
        }

        public DataTable ExecuteQuery(string queryString)
        {
            SqlDataReader queryResult;

            DataTable dtSQLData = new DataTable();

            using (SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString);
                command.Connection = connection;
                connection.Open();

                queryResult = command.ExecuteReader();
                dtSQLData.Load(queryResult);
                connection.Close();
            }

            return dtSQLData;
        }

        public static string SafeOutput<T>(T dataInput, string desiredOutputType)
        {
            if (dataInput == null)
            {
                if (desiredOutputType == "string")
                    return "NULL";
                else if (desiredOutputType == "time")
                    return "00:00";
                else
                    return "0";
            }
            else
            {

                Type paramType = dataInput.GetType();

                if (paramType.Equals(typeof(string)) || paramType.Equals(typeof(JObject)))
                {
                    if (dataInput == null)
                        return "NULL";
                    else
                        return dataInput.ToString();
                }
                else if (paramType.Equals(typeof(int)) || paramType.Equals(typeof(float)) || paramType.Equals(typeof(decimal)))
                {
                    if (dataInput == null)
                        return "0";
                    else
                        return dataInput.ToString();
                }
                else if (dataInput == null)
                {
                    return "NULL";
                }
                else
                    return dataInput.ToString();

            }
        }

        public int ExecuteParameterizedQuery(List<SQLParameter> paramList, string queryString)
        {
            int returnValue;
            DataTable dtSQLData = new DataTable();
            int usesOutputParam = 0; // Flag to determine if an output parameter is included in the statement.


            using (SqlConnection connection = new SqlConnection(_connectionStringBuilder.ConnectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                string outputParamName = "";

                //SqlCommand command = new SqlCommand(queryString, connection);
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = queryString;

                //DEBUG CODE:
                foreach (SQLParameter s in paramList)
                {
                    Console.WriteLine("{0} = {1} ({2})", s.paramName, s.paramValue, s.paramType);
                }


                foreach (SQLParameter aParameter in paramList)
                {

                    SqlParameter returnParameter;

                    if (aParameter.paramDirection == "in")
                    {
                        command.Parameters.AddWithValue(aParameter.paramName, aParameter.paramValue);
                    }
                    else
                    {
                        returnParameter = new SqlParameter(aParameter.paramName, aParameter.paramType);
                        command.Parameters.Add(returnParameter);
                        returnParameter.Direction = ParameterDirection.Output;
                        outputParamName = aParameter.paramName;
                        usesOutputParam = 1;
                    }

                }


                try
                {


                    //dataAdapter.Fill(dtSQLData);

                    connection.Open();
                    Int32 rowsAffected = command.ExecuteNonQuery();
                    if (usesOutputParam == 1)
                    {
                        if (command.Parameters[outputParamName].Value == null)
                        {
                            returnValue = -2;
                        }
                        else
                        {
                            returnValue = Convert.ToInt32(command.Parameters[outputParamName].Value);
                        }
                    }
                    else returnValue = -1;

                }
                catch (Exception ex)
                {
                    returnValue = -1;
                    throw ex;
                }
            }

            return returnValue;
        }
    }
}
