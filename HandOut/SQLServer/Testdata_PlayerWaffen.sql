USE [SAE_RolePlayingGame]
GO

DECLARE @RandomWaffen INT;
DECLARE @UpperWaffen INT;
DECLARE @LowerWaffen INT

SET @LowerWaffen = (SELECT MIN(ID) from Waffen) ---- The lowest random number
SET @UpperWaffen = (SELECT MAX(ID) from Waffen) ---- The highest random number

DECLARE @RandomPlayer INT;
DECLARE @UpperPlayer INT;
DECLARE @LowerPlayer INT

SET @LowerPlayer = (SELECT MIN(ID) from Players) ---- The lowest random number
SET @UpperPlayer = (SELECT MAX(ID) from Players) ---- The highest random number

DECLARE @counter int
SET @counter = 1
WHILE @counter < 1000 BEGIN
    
	SELECT @RandomWaffen = ROUND(((@UpperWaffen - @LowerWaffen -1) * RAND() + @LowerWaffen), 0)
	SELECT @RandomPlayer = ROUND(((@UpperPlayer - @LowerPlayer -1) * RAND() + @LowerPlayer), 0)

	INSERT INTO dbo.PlayerWaffen(playerID, waffenID) VALUES (@RandomPlayer, @RandomWaffen);

    SET @counter = @counter + 1
END
GO

-- DELETE FROM PlayerWaffen WHERE 1 = 1