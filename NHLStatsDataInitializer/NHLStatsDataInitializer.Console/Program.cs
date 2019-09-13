using System;
using NHLStats;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using NHLStatsDAL;


namespace NHLStatsDataInitializer.Console
{
    public class Program
    {


        static void Main(string[] args)
        {
            
            string[] schedArray =
            {

              // SEPTEMBER
              //"1998-09-01",
              //"1998-09-02",
              //"1998-09-03",
              //"1998-09-04",
              //"1998-09-05",
              //"1998-09-06",
              //"1998-09-07",
              //"1998-09-08",
              //"1998-09-09",
              //"1998-09-10",
              //"1998-09-11",
              //"1998-09-12",
              //"1998-09-13",
              //"1998-09-14",
              //"1998-09-15",
              //"1998-09-16",
              //"1998-09-17",
              //"1998-09-18",
              //"1998-09-19",
              //"1998-09-20",
              //"1998-09-21",
              //"1998-09-22",
              //"1998-09-23",
              //"1998-09-24",
              //"1998-09-25",
              //"1998-09-26",
              //"1998-09-27",
              //"1998-09-28",
              //"1998-09-29",
              //"1998-09-30",

              // OCTOBER
              //"1998-10-01",
              //"1998-10-02",
              //"1998-10-03",
              //"1998-10-04",
              //"1998-10-05",
              //"1998-10-06",
              //"1998-10-07",
              //"1998-10-08",
              "1998-10-09",
              "1998-10-10",
              "1998-10-11",
              "1998-10-12",
              "1998-10-13",
              "1998-10-14",
              "1998-10-15",
              "1998-10-16",
              "1998-10-17",
              "1998-10-18",
              "1998-10-19",
              "1998-10-20",
              "1998-10-21",
              "1998-10-22",
              "1998-10-23",
              "1998-10-24",
              "1998-10-25",
              "1998-10-26",
              "1998-10-27",
              "1998-10-28",
              "1998-10-29",
              "1998-10-30",
              "1998-10-31",

              // NOVEMBER
              "1998-11-01",
              "1998-11-02",
              "1998-11-03",
              "1998-11-04",
              "1998-11-05",
              "1998-11-06",
              "1998-11-07",
              "1998-11-08",
              "1998-11-09",
              "1998-11-10",
              "1998-11-11",
              "1998-11-12",
              "1998-11-13",
              "1998-11-14",
              "1998-11-15",
              "1998-11-16",
              "1998-11-17",
              "1998-11-18",
              "1998-11-19",
              "1998-11-20",
              "1998-11-21",
              "1998-11-22",
              "1998-11-23",
              "1998-11-24",
              "1998-11-25",
              "1998-11-26",
              "1998-11-27",
              "1998-11-28",
              "1998-11-29",
              "1998-11-30",

              // DECEMBER
              "1998-12-01",
              "1998-12-02",
              "1998-12-03",
              "1998-12-04",
              "1998-12-05",
              "1998-12-06",
              "1998-12-07",
              "1998-12-08",
              "1998-12-09",
              "1998-12-10",
              "1998-12-11",
              "1998-12-12",
              "1998-12-13",
              "1998-12-14",
              "1998-12-15",
              "1998-12-16",
              "1998-12-17",
              "1998-12-18",
              "1998-12-19",
              "1998-12-20",
              "1998-12-21",
              "1998-12-22",
              "1998-12-23",
              "1998-12-24",
              "1998-12-25",
              "1998-12-26",
              "1998-12-27",
              "1998-12-28",
              "1998-12-29",
              "1998-12-30",
              "1998-12-31",
            
              // JANUARY
              "1999-01-01",
              "1999-01-02",
              "1999-01-03",
              "1999-01-04",
              "1999-01-05",
              "1999-01-06",
              "1999-01-07",
              "1999-01-08",
              "1999-01-09",
              "1999-01-10",
              "1999-01-11",
              "1999-01-12",
              "1999-01-13",
              "1999-01-14",
              "1999-01-15",
              "1999-01-16",
              "1999-01-17",
              "1999-01-18",
              "1999-01-19",
              "1999-01-20",
              "1999-01-21",
              "1999-01-22",
              "1999-01-23",
              "1999-01-24",
              "1999-01-25",
              "1999-01-26",
              "1999-01-27",
              "1999-01-28",
              "1999-01-29",
              "1999-01-30",
              "1999-01-31",
            
              //// FEBRUARY
              "1999-02-01",
              "1999-02-02",
              "1999-02-03",
              "1999-02-04",
              "1999-02-05",
              "1999-02-06",
              "1999-02-07",
              "1999-02-08",
              "1999-02-09",
              "1999-02-10",
              "1999-02-11",
              "1999-02-12",
              "1999-02-13",
              "1999-02-14",
              "1999-02-15",
              "1999-02-16",
              "1999-02-17",
              "1999-02-18",
              "1999-02-19",
              "1999-02-20",
              "1999-02-21",
              "1999-02-22",
              "1999-02-23",
              "1999-02-24",
              "1999-02-25",
              "1999-02-26",
              "1999-02-27",
              "1999-02-28",
                            "1999-02-29",

              //// MARCH
              "1999-03-01",
              "1999-03-02",
              "1999-03-03",
              "1999-03-04",
              "1999-03-05",
              "1999-03-06",
              "1999-03-07",
              "1999-03-08",
              "1999-03-09",
              "1999-03-10",
              "1999-03-11",
              "1999-03-12",
              "1999-03-13",
              "1999-03-14",
              "1999-03-15",
              "1999-03-16",
              "1999-03-17",
              "1999-03-18",
              "1999-03-19",
              "1999-03-20",
              "1999-03-21",
              "1999-03-22",
              "1999-03-23",
              "1999-03-24",
              "1999-03-25",
              "1999-03-26",
              "1999-03-27",
              "1999-03-28",
              "1999-03-29",
              "1999-03-30",
              "1999-03-31",

              // APRIL
              "1999-04-01",
              "1999-04-02",
              "1999-04-03",
              "1999-04-04",
              "1999-04-05",
              "1999-04-06",
              "1999-04-07",
              "1999-04-08",
              "1999-04-09",
              "1999-04-10",
              "1999-04-11",
              "1999-04-12",
              "1999-04-13",
              "1999-04-14",
              "1999-04-15",
              "1999-04-16",
              "1999-04-17",
              "1999-04-18",
              "1999-04-19",
              "1999-04-20",
              "1999-04-21",
              "1999-04-22",
              "1999-04-23",
              "1999-04-24",
              "1999-04-25",
              "1999-04-26",
              "1999-04-27",
              "1999-04-28",
              "1999-04-29",
              "1999-04-30",


              //// MAY
              "1999-05-01",
              "1999-05-02",
              "1999-05-03",
              "1999-05-04",
              "1999-05-05",
              "1999-05-06",
              "1999-05-07",
              "1999-05-08",
              "1999-05-09",
              "1999-05-10",
              "1999-05-11",
              "1999-05-12",
              "1999-05-13",
              "1999-05-14",
              "1999-05-15",
              "1999-05-16",
              "1999-05-17",
              "1999-05-18",
              "1999-05-19",
              "1999-05-20",
              "1999-05-21",
              "1999-05-22",
              "1999-05-23",
              "1999-05-24",
              "1999-05-25",
              "1999-05-26",
              "1999-05-27",
              "1999-05-28",
              "1999-05-29",
              "1999-05-30",
              "1999-05-31",

              // JUNE
              "1999-06-01",
              "1999-06-02",
              "1999-06-03",
              "1999-06-04",
              "1999-06-05",
              "1999-06-06",
              "1999-06-07",
              "1999-06-08",
              "1999-06-09",
              "1999-06-10",
              "1999-06-11",
              "1999-06-12",
              "1999-06-13",
              "1999-06-14",
              "1999-06-15",
              "1999-06-16",
              "1999-06-17",
              "1999-06-18",
              "1999-06-19",
              //"1999-06-20",
              //"1999-06-21",
              //"1999-06-22",
              //"1999-06-23",
              //"1999-06-24",
              //"1999-06-25",
              //"1999-06-26",
              //"1999-06-27",
              //"1999-06-28",
              //"1999-06-29",
              //"1999-06-30",
             
              // STANLEY CUP 2009-2010 SEASON ENDS 1999-06-19
            };
            DataAccessHelper dataAccess = new DataAccessHelper("");

            List<string> gameID, List = new List<string>();

            //string scheduleDay = "2018-10-03";  // Season Opener 2018/2019
            //string scheduleDay = "2018-09-15"; // Pre-season opener 2018/2019
            //string scheduleDay = "2018-10-13";  // Date on and before change to spCreateGameEvent code change
            //string scheduleDay = "2018-11-06";  // CURRENT
            //string scheduleDay = "2018-06-07"; // Stanley Cup final (1 game in schedule)
            //string scheduleDay = "2019-04-24"; // Stanley Cup final (1 game in schedule)



            foreach (string sched in schedArray)
            {
                doIt(sched);
            }

        }


        public static void doIt(string sched)
        {
            Schedule schedule = new Schedule(sched);

            // ***********PAUL CHANGE SQL STRING TO PARAMETERIZED COMMAND!!!*******
            // https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand.parameters?redirectedfrom=MSDN&view=netframework-4.7.2#System_Data_SqlClient_SqlCommand_Parameters


            //---------------------------------------------------
            // Insert the SCHEDULE into the DB

            int scheduleID = ScheduleData.InsertSchedule(schedule);
            int i = 0;

            //---------------------------------------------------

            //---------------------------------------------------
            // Insert the list of GAMEs into the DB
            //  INCLUDES:  Insert the TEAMs (insert the CONFERENCE, DIVISION, VENUE), VENUE, list of PERIODs, BOXSCOREs(insert the TEAMGAMESTATS(insert the PERSON/coach, list of PLAYERGAMESTATS), list of PERSON/officials), list of PLAYERs, list of GAMEEVENTs(insert TEAMs, list of PLAYERs), GAMECONTENT)
            if (Convert.ToInt16(schedule.totalGames) > 0)
            {
                foreach (Game g in schedule.games)
                {
                    i = GameData.InsertGame(g, scheduleID);
                    //---------------------------------------------------
                    // Insert the Home and Away TEAMs into the DB
                    //  INCLUDES:  Insert the VENUE, list of PERIODs, BOXSCOREs(insert the TEAMGAMESTATS(insert the PERSON/coach, list of PLAYERGAMESTATS), list of PERSON/officials), list of PLAYERs, list of GAMEEVENTs(insert TEAMs, list of PLAYERs), GAMECONTENT)

                    // Insert the Coach (PERSON) for each team
                    if (!(g.gameBoxScore.homeTeamStats.coach is null))
                    {
                        i = PersonData.InsertPerson(g.gameBoxScore.homeTeamStats.coach);
                    }

                    if (!(g.gameBoxScore.awayTeamStats.coach is null))
                    {
                        i = PersonData.InsertPerson(g.gameBoxScore.awayTeamStats.coach);
                    }


                    // Insert the game VENUE
                    if (!(g.gameVenue is null))
                    {
                        i = VenueData.InsertVenue(g.gameVenue);
                    }


                    // Insert the game Officials (PERSON)
                    if (!(g.gameBoxScore.officials is null))
                    {
                        foreach (Person p in g.gameBoxScore.officials)
                        {
                            i = PersonData.InsertPerson(p);

                            // Insert officials list to the cross reference table (tblGameOfficials)
                            i = PersonData.InsertGameOfficials(g.gameID, p.personId);
                        }
                    }

                    // Insert the Home Team:
                    i = TeamData.InsertTeam(g.homeTeam);
                    i = TeamData.InsertTeam(g.awayTeam);

                    // Insert the CONFERENCE of each team:
                    i = ConferenceData.InsertConference(g.homeTeam.teamConference);
                    i = ConferenceData.InsertConference(g.awayTeam.teamConference);

                    //Insert the DIVISION of each team:
                    if (!(g.homeTeam.teamDivision is null))
                        i = DivisionData.InsertDivision(g.homeTeam.teamDivision);
                    if (!(g.awayTeam.teamDivision is null))
                        i = DivisionData.InsertDivision(g.awayTeam.teamDivision);

                    //Insert the PERIODs of the Game
                    if (!(g.periodData is null))
                    {
                        foreach (Period p in g.periodData)
                        {
                            i = PeriodData.InsertPeriod(p);
                        }
                    }

                    // Insert the details and stats for each home PLAYER
                    if (!(g.gameBoxScore.homeTeamStats.teamPlayers is null))
                    {
                        foreach (PlayerGameStats homepgs in g.gameBoxScore.homeTeamStats.teamPlayers)
                        {
                            i = PlayerData.InsertPlayer(homepgs);
                            i = PlayerGameStatsData.InsertPlayerGameStats(homepgs, g.gameID);
                        }
                    }

                    // Insert the details and stats for each away PLAYER
                    if (!(g.gameBoxScore.awayTeamStats.teamPlayers is null))
                    {
                        foreach (PlayerGameStats awaypgs in g.gameBoxScore.awayTeamStats.teamPlayers)
                        {
                            i = PlayerData.InsertPlayer(awaypgs);
                            i = PlayerGameStatsData.InsertPlayerGameStats(awaypgs, g.gameID);
                        }
                    }

                    // Insert the GAMEEVENTS for the game
                    if (!(g.gameEvents is null))
                    {
                        foreach (GameEvent ge in g.gameEvents)
                        {
                            i = GameEventData.InsertGameEvent(ge, g.gameID);
                        }
                    }



                    //---------------------------------------------------
                }
            }

        }
    }
}
