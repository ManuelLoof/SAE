DROP DATABASE Benutzerverwaltung;

CREATE DATABASE Benutzerverwaltung;


USE [Benutzerverwaltung]


CREATE TABLE benutzer
(
	vorname VARCHAR(30),
	nachname VARCHAR(30),
	adresse VARCHAR(100),
	nickname VARCHAR(10),
	[password] VARCHAR(20)
);


SELECT * FROM benutzer;


DROP TABLE benutzer;


SELECT * FROM benutzer;

SELECT * FROM benutzer where country = 'Mexico';

SELECT COUNT(id) FROM benutzer where country = 'Mexico';
SELECT COUNT(id) FROM benutzer;


BEGIN TRANSACTION loesch;
DELETE FROM benutzer where country = 'Mexico';



COMMIT TRANSACTION loesch;

ROLLBACK TRANSACTION loesch;

TRUNCATE TABLE benutzer;

DECLARE @counter int
SET @counter = 1
WHILE @counter < 15 BEGIN
    INSERT INTO benutzer SELECT * FROM benutzer;
	SET @counter = @counter + 1
END
GO


CREATE INDEX benutzerCountry
ON benutzer (country);

DROP INDEX benutzerCountry ON benutzer; 
DROP INDEX MeinTollerIndex ON benutzer; 

Select Count(id) from benutzer;

SELECT country FROM benutzer where country = 'Germany';
SELECT first_name FROM benutzer where first_name = 'Kathleen';