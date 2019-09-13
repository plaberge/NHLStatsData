CREATE PROCEDURE [dbo].[spCreatePlayer]
	@playerId INT,
    @firstName VARCHAR(100),
    @lastName VARCHAR(100),
    @primaryNumber TINYINT,
    @birthDate DATE,
    @currentAge TINYINT,
    @birthCity VARCHAR(50),
    @birthStateProvince VARCHAR(50),
    @birthCountry VARCHAR(50),
    @nationality VARCHAR(50),
    @height TINYINT,
    @weight SMALLINT,
    @active VARCHAR(7),
    @alternateCaptain VARCHAR(7),
    @captain VARCHAR(7),
    @rookie VARCHAR(7),
    @shootsCatches VARCHAR(10),
    @rosterStatus VARCHAR(15),
    @currentTeamID INT,
    @primaryPositionCode VARCHAR(5),
    @primaryPositionName VARCHAR(15),
    @primaryPositionType VARCHAR(15),
    @primaryPositionAbbr VARCHAR(5),
    @playerIdentity INT OUTPUT
AS
BEGIN

	IF NOT EXISTS (SELECT playerId FROM tblPlayer WHERE playerId = @playerId)
	BEGIN
		INSERT INTO tblPlayer (
								playerId,
								firstName,
								lastName,
								primaryNumber,
								birthDate,
								currentAge,
								birthCity,
								birthStateProvince,
								birthCountry,
								nationality,
								height,
								[weight],
								active,
								alternateCaptain,
								rookie,
								shootsCatches,
								rosterStatus,
								currentTeamID,
								primaryPositionCode,
								primaryPositionName,
								primaryPositionType,
								primaryPositionAbbr
							  )
		VALUES (
				@playerId,
				@firstName,
				@lastName,
				@primaryNumber,
				@birthDate,
				@currentAge,
				@birthCity,
				@birthStateProvince,
				@birthCountry,
				@nationality,
				@height,
				@weight,
				@active,
				@alternateCaptain,
				@rookie,
				@shootsCatches,
				@rosterStatus,
				@currentTeamID,
				@primaryPositionCode,
				@primaryPositionName,
				@primaryPositionType,
				@primaryPositionAbbr
			   )

			   SET @playerIdentity = SCOPE_IDENTITY()
	END
	ELSE
		SET @playerIdentity = -100
	

END
RETURN SELECT @playerIdentity