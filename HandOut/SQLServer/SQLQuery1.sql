SELECT * from PLayers;

SELECT * FROM Waffen;

SELECT * FROM PlayerWaffen;

SELECT Players.name, Waffen.name
	FROM Players INNER JOIN PlayerWaffen
		ON Players.ID = PlayerWaffen.playerID
		INNER JOIN Waffen
		ON PlayerWaffen.waffenID = Waffen.ID
	WHERE Players.ID = 1;

SELECT MAX(Players.muenzen) as Anzahl 
from Players;

SELECT Players.name from Players
where Players.id in
(
	SELECT TOP 1 ID FROM Players order by muenzen desc
)

SELECT * FROM Rassen;


SELECT Players.rasseID, Count(Players.rasseID) from Players
group by Players.rasseID;
