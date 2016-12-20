SELECT * FROM benutzer 
	WHERE first_name like 'Li%' 
	order by country;


INSERT INTO benutzer
	(id,first_name,last_name)
	values 
	('5000000','Manuel','Loof');


SELECT * FROM benutzer where last_name='Loof';

Update benutzer
 SET email= 'yahoo@google.com';

 SELECT * FROM benutzer;

 DELETE FROM benutzer where last_name = 'loof';

CREATE TABLE players(
	ID INTEGER IDENTITY(1,1),
	player VARCHAR(30),
	score INTEGER,
	PRIMARY KEY (ID)
);

SELECT * from players;

INSERT INTO players
	(player,score)
	VALUES
	('Sophia',15614);

TRUNCATE TABLE players;

ALTER TABLE players MODIFY COLUMN player INT;

ALTER TABLE players
ALTER COLUMN player VARCHAR(30);

ALTER TABLE players
ALTER COLUMN player INT;