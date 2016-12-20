CREATE TABLE ROLEPLAYINGGAME
(
	name VARCHAR(30),
	rasse VARCHAR(30),
	klasse VARCHAR(30),
	muenzen INT,
	[level] INT,
	energie INT
)


SELECT * FROM Players;


INSERT INTO ROLEPLAYINGGAME
SELECT Players.name,
		Rassen.name as rasse, 
		Klassen.name as klasse,
		Players.muenzen,
		Players.level,
		Players.energie
			FROM Players 
			INNER JOIN Rassen ON Players.rasseID = Rassen.ID
			INNER JOIN Klassen ON Players.klasseID = Klassen.ID;


SELECT * FROM ROLEPLAYINGGAME;



DELETE FROM ROLEPLAYINGGAME;


-- CSV IMPORT 

BULK 
INSERT ROLEPLAYINGGAME
    FROM 'C:\Home\Work\SAE\Datenbanken\SQLServer\Testdata_ROLEPLAYINGGAME.csv'
    WITH
    (
		FIRSTROW = 2,
		FIELDTERMINATOR = ';',  --CSV field delimiter
		ROWTERMINATOR = '\n',   --Use to shift the control to next row
		ERRORFILE = 'C:\Home\Work\SAE\Datenbanken\SQLServer\ImportErrorRows.txt',
		TABLOCK
    )
GO


-- Temp Table
-- # nur in der Seassion auf 
-- @ Temp in Speicher. Kann aber kein BulkInsert.

CREATE TABLE #ROLEPLAYINGGAMETemp
(
	name VARCHAR(30),
	rasse VARCHAR(30),
	klasse VARCHAR(30),
	muenzen INT,
	[level] INT,
	energie INT
)
GO

BULK 
INSERT #ROLEPLAYINGGAMETemp
    FROM 'C:\Home\Work\SAE\Datenbanken\SQLServer\Testdata_ROLEPLAYINGGAME.csv'
    WITH
    (
		FIRSTROW = 2,
		FIELDTERMINATOR = ';',  --CSV field delimiter
		ROWTERMINATOR = '\n',   --Use to shift the control to next row
		ERRORFILE = 'C:\Home\Work\SAE\Datenbanken\SQLServer\ImportErrorRows.txt',
		TABLOCK
    )
GO

SELECT * FROM #ROLEPLAYINGGAMETemp;

-- @ Temp in Speicher.
DECLARE @ROLEPLAYINGGAMETempII TABLE
(
	name VARCHAR(30),
	rasse VARCHAR(30)
);

INSERT INTO @ROLEPLAYINGGAMETempII VALUES ('Msnuel','Blub');
INSERT INTO @ROLEPLAYINGGAMETempII VALUES ('Maanuel','Blub');
INSERT INTO @ROLEPLAYINGGAMETempII VALUES ('Manuel','Blub');

SELECT * FROM @ROLEPLAYINGGAMETempII;

GO
