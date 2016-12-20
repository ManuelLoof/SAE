SELECT first_name FROM benutzer
	where last_name like 'B%';

CREATE INDEX lastNameIndex
	ON benutzer (last_name, first_name) 

DROP INDEX lastNameIndex ON benutzer;