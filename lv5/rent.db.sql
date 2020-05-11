-- 2. Добавьте таблицы
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "offer" (
	"offer_id "	INTEGER PRIMARY KEY AUTOINCREMENT,
	"dvd_id"	INTEGER NOT NULL,
	"customer_id"	INTEGER NOT NULL,
	"offer_date"	TEXT NOT NULL,
	"return_date"	TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "customer" (
	"customer_id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"first_name"	TEXT NOT NULL,
	"last_name"	TEXT NOT NULL,
	"passport_code"	TEXT NOT NULL,
	"registration_date"	TEXT NOT NULL
);
CREATE TABLE IF NOT EXISTS "dvd" (
	"dvd_id"	INTEGER PRIMARY KEY AUTOINCREMENT,
	"title"	TEXT NOT NULL,
	"production_year"	TEXT NOT NULL
);
-- 3.  Подготовьте SQL запросы для заполнения таблиц данными.
INSERT INTO "offer" VALUES (1,1,1,'2018-10-17','2018-10-21');
INSERT INTO "offer" VALUES (2,1,2,'2018-11-02','2018-11-13');
INSERT INTO "offer" VALUES (3,2,6,'2020-10-17','2020-10-21');
INSERT INTO "offer" VALUES (4,3,6,'2020-11-02','2020-11-13');
INSERT INTO "offer" VALUES (5,10,5,'2020-11-17','2020-11-21');
INSERT INTO "offer" VALUES (6,9,5,'2020-10-02','2021-10-13');
INSERT INTO "offer" VALUES (7,8,8,'2015-11-17','2015-11-21');
INSERT INTO "offer" VALUES (8,6,8,'2015-10-02','2015-10-13');
INSERT INTO "offer" VALUES (9,7,5,'2016-11-17','2016-11-21');
INSERT INTO "offer" VALUES (10,6,4,'2016-10-02','2016-10-13');
INSERT INTO "customer" VALUES (1,'Станислав','Борисович','1436743479','2019-01-02');
INSERT INTO "customer" VALUES (2,'Павел','Борисович','1244792141','2019-02-11');
INSERT INTO "customer" VALUES (3,'Семен','Витальевич','1282915578','2013-06-01');
INSERT INTO "customer" VALUES (4,'Григорий','Маркович','1588179952','2018-03-06');
INSERT INTO "customer" VALUES (5,'Семен','Игоревич','1378508037','2014-08-04');
INSERT INTO "customer" VALUES (6,'Валерий','Кириллович','1807776917','2018-10-28');
INSERT INTO "dvd" VALUES (1,'Побег из Шоушенка','1994-04-21');
INSERT INTO "dvd" VALUES (2,'Зеленая миля','1999-05-13');
INSERT INTO "dvd" VALUES (3,'Форрест Гамп','1994-05-13');
INSERT INTO "dvd" VALUES (4,'Список Шиндлера','1993-05-13');
INSERT INTO "dvd" VALUES (5,'1+1','2011-05-13');
INSERT INTO "dvd" VALUES (6,'Начало','2010-05-13');
INSERT INTO "dvd" VALUES (7,'Леон','1994-05-13');
INSERT INTO "dvd" VALUES (8,'Король Лев','2010-05-13');
INSERT INTO "dvd" VALUES (9,'Бойцовский клуб','1994-05-13');
INSERT INTO "dvd" VALUES (10,'Жизнь прекрасна','1973-05-13');
COMMIT;
