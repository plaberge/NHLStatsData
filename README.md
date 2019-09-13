# NHLStatsData - NHLStats SQL Server Database Schema and Sample Data Insertion Utility
## Purpose of this repository
The code in this repository provides an example of how to create a SQL Azure database with a schema that holds ice hockey statistical data as well as a sample utility application to insert data using the open NHL Statistics API.

## What''s in this repository?
The following projects are found within this repository:
* [NHLStatsData/NHLStatsDataInitializer/NHLStats.Database/](https://github.com/plaberge/NHLStatsData/tree/master/NHLStatsDataInitializer/NHLStats.Database): A Visual Studio  Data Application project holding the DB schema
* [NHLStatsData/NHLStatsDataInitializer/NHLStatsDAL/](https://github.com/plaberge/NHLStatsData/tree/master/NHLStatsDataInitializer/NHLStatsDAL):  A Data Access Layer Visual Studio .NET Standard Library project for communicating with a database
* [NHLStatsData/NHLStatsDataInitializer/NHLStatsDataInitializer.Console/](https://github.com/plaberge/NHLStatsData/tree/master/NHLStatsDataInitializer/NHLStatsDataInitializer.Console): A sample utility that makes use of the NHLStatsDAL project to insert hockey statistics data into a database using the schema from NHLStats.Database project

### Notes
* In order to use the NHLStatsDAL project, you will need to modify the database connection code found in [NHLStatsData/NHLStatsDataInitializer/NHLStatsDAL/DataAccessHelper.cs](https://github.com/plaberge/NHLStatsData/blob/master/NHLStatsDataInitializer/NHLStatsDAL/DataAccessHelper.cs) as I have put placeholders there.
* The code in this repository relies heavily on a public NuGet package called NHLStats.  You can find the code for that project [here](https://github.com/plaberge/nhlstats).
