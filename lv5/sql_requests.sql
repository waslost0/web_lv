--4.  Подготовьте SQL запрос получения списка всех DVD, год выпуска которых 2010, 
--отсортированных в алфавитном порядке по названию DVD.
SELECT * FROM dvd
WHERE strftime('%Y' ,production_year)= '2010'
ORDER BY title ASC;	
--5.  Получение списка DVD дисков, которые в настоящее время находятся у клиентов.
SELECT *
FROM dvd
WHERE dvd_id IN
(
	SELECT dvd_id
	FROM offer
	WHERE return_date < date('now') AND offer_date < date('now')
);

--6.  Напишите SQL запрос для получения списка клиентов, которые брали какие-либо DVD 
--	диски в текущем году. В результатах запроса необходимо также отразить какие диски 
--	брали клиенты.
SELECT 
	customer.customer_id, customer.first_name, customer.last_name, dvd.dvd_id, dvd.title, dvd.production_year
FROM customer
LEFT JOIN offer ON customer.customer_id = offer.customer_id
LEFT JOIN dvd ON dvd.dvd_id = offer.dvd_id
WHERE strftime('%Y', offer.offer_date) = '2020';