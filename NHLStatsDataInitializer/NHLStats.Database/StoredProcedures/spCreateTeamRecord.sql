CREATE PROCEDURE [dbo].[spCreateTeamRecord]
	@nhlTeamId INT,
    @season INT,
    @asOfDate DATE,
    @wins INT,
    @losses INT,
    @overtimeLosses INT,
    @goalsScored INT,
    @goalsAgainst INT,
    @points INT,
    @divisionRank INT,
    @leagueRank INT,
    @wildcardRank INT,
    @row VARCHAR(50),
    @gamesPlayed INT,
    @streakType VARCHAR(20),
    @streakNumber INT,
    @streakCode VARCHAR(15),
    @lastUpdated VARCHAR(50),
	@teamRecordIdentity INT OUTPUT
AS
BEGIN
    IF NOT EXISTS (SELECT nhlTeamId FROM tblTeamRecord WHERE nhlTeamId = @nhlTeamId AND season = @season AND asOfDate = @asOfDate)
	BEGIN
		INSERT INTO tblTeamRecord(
									nhlTeamId,
    								season,
    								asOfDate,
    								wins,
    								losses,
    								overtimeLosses,
    								goalsScored,
    								goalsAgainst,
    								points,
    								divisionRank,
    								leagueRank,
    								wildcardRank,
    								[row],
    								gamesPlayed,
    								streakType,
    								streakNumber,
    								streakCode,
    								lastUpdated
								 )
		VALUES (
				@nhlTeamId,
    			@season,
    			@asOfDate,
    			@wins,
    			@losses,
    			@overtimeLosses,
    			@goalsScored,
    			@goalsAgainst,
    			@points,
    			@divisionRank,
    			@leagueRank,
    			@wildcardRank,
    			@row,
    			@gamesPlayed,
    			@streakType,
    			@streakNumber,
    			@streakCode,
    			@lastUpdated
			   )

			   SET @teamRecordIdentity = SCOPE_IDENTITY()
	END
	ELSE
		SET @teamRecordIdentity = -100
	

END
RETURN SELECT @teamRecordIdentity