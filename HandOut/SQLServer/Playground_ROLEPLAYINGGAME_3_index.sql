USE [SAE_RolePlayingGame]

Select [level] from Players where [level] = 5;

CREATE INDEX levelIndex ON Players([level]);