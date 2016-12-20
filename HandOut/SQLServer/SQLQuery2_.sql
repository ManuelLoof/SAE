USE [SAE_RolePlayingGame]

SELECT * FROM PLAYERS WHERE name = 'Manuel';
DELETE FROM PLAYERS WHERE name = 'Manuel';

BEGIN TRANSACTION meineTransaktion;

INSERT INTO Players
VALUES
('Manuel',2,3,112,3,56,'jsdkbfjdfb');

COMMIT TRANSACTION meineTransaktion;
ROLLBACK TRANSACTION meineTransaktion;