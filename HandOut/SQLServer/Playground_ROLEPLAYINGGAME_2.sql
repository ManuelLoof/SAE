ALTER TABLE Players
ADD password int;

Select * from Players;

ALTER TABLE Players
ALTER COLUMN password varchar(12);
