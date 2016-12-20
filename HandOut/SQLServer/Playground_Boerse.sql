CREATE DATABASE Boerse;

USE [Boerse]
GO

/****** Object:  Table [dbo].[Kurse]    Script Date: 14.12.2015 19:33:51 ******/
DROP TABLE [dbo].[Kurse]
GO

/****** Object:  Table [dbo].[Kurse]    Script Date: 14.12.2015 19:33:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Kurse](
	[Datum] [date] NOT NULL,
	[Eroeffnungskurs] [decimal](18, 6) NOT NULL,
	[Max] [decimal](18, 6) NOT NULL,
	[Tief] [decimal](18, 6) NOT NULL,
	[Schluss] [decimal](18, 6) NOT NULL,
	[Volumen] [decimal](18, 6) NOT NULL,
	[AdjSchluss] [decimal](18, 6) NOT NULL
) ON [PRIMARY]

GO


BULK 
INSERT Kurse
    FROM 'C:\Home\Work\SAE\Datenbanken\SQLServer\Testdata_dax.csv'
    WITH
    (
		FIRSTROW = 2,
		FIELDTERMINATOR = ',',  --CSV field delimiter
		ROWTERMINATOR = '\n',   --Use to shift the control to next row
		ERRORFILE = 'C:\Home\Work\SAE\Datenbanken\SQLServer\ImportErrorRowsBoerse.txt',
		TABLOCK
    )
GO




SELECT * FROM Kurse Order by [Max] desc; 

SELECT  Datum, Max - Tief as diff FROM Kurse order by diff desc;

SELECT * FROM Kurse;

SELECT * FROM Kurse group by [Max] - [Tief], Datum;


 SELECT * FROM Kurse where Datum > '01.02.2015';