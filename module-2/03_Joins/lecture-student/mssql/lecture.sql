-- ********* INNER JOIN ***********

-- Let's find out who made payment 16666:
SELECT *
FROM payment
WHERE payment_id = 16666
-- Ok, that gives us a customer_id, but not the name. We can use the customer_id to get the name FROM the customer table
SELECT * 
FROM customer
WHERE customer_id = 204

SELECT payment_id, payment.customer_id, first_name, last_name
FROM payment
JOIN customer ON payment.customer_id = customer.customer_id
WHERE payment_id = 16666
-- We can see that the * pulls back everything from both tables. We just want everything from payment and then the first and last name of the customer:

-- But when did they return the rental? Where would that data come from? From the rental table, so let’s join that.
SELECT payment.*, first_name, last_name, rental.*
FROM payment
JOIN customer ON payment.customer_id = customer.customer_id
JOIN rental 
ON payment.rental_id = rental.rental_id
WHERE payment_id = 16666
-- What did they rent? Film id can be gotten through inventory.
SELECT payment.*, first_name, last_name, rental.*, inventory.*
FROM payment
JOIN customer ON payment.customer_id = customer.customer_id
JOIN rental ON payment.rental_id = rental.rental_id
JOIN inventory ON rental.inventory_id = inventory.inventory_id
WHERE payment_id = 16666
-- What if we wanted to know who acted in that film?
SELECT payment.*, first_name, last_name, rental.*, inventory.*, film_actor.*
FROM payment
JOIN customer ON payment.customer_id = customer.customer_id
JOIN rental ON payment.rental_id = rental.rental_id
JOIN inventory ON rental.inventory_id = inventory.inventory_id
JOIN film_actor ON inventory.film_id = film_actor.film_id
WHERE payment_id = 16666

SELECT *
FROM actor
WHERE actor_id = 14 OR actor_id = 17 OR actor_id = 165
-- What if we wanted a list of all the films and their categories ordered by film title
SELECT * 
FROM film
JOIN film_category ON film.film_id = film_category.film_id
JOIN category ON film_category.category_id = category.category_id
-- Show all the 'Comedy' films ordered by film title
SELECT * 
FROM film
JOIN film_category ON film.film_id = film_category.film_id
JOIN category ON film_category.category_id = category.category_id
WHERE category.name = 'Comedy' 
ORDER BY film.title

-- Finally, let's count the number of films under each category
SELECT COUNT(*) 'count', category.name
FROM film f
JOIN film_category ON f.film_id = film_category.film_id
JOIN category ON film_category.category_id = category.category_id
GROUP BY category.name
-- ********* LEFT JOIN ***********

-- (There aren't any great examples of left joins in the "dvdstore" database, so the following queries are for the "world" database)

-- A Left join, selects all records from the "left" table and matches them with records from the "right" table if a matching record exists.

-- Let's display a list of all countries and their capitals, if they have some.
SELECT *
FROM country
JOIN city ON country.capital = city.id
-- Only 232 rows
-- But we’re missing entries:

-- There are 239 countries. So how do we show them all even if they don’t have a capital?
-- That’s because if the rows don’t exist in both tables, we won’t show any information for it. If we want to show data FROM the left side table everytime, we can use a different join:

SELECT *
FROM country
 LEFT JOIN city ON country.capital = city.id

 SELECT *
FROM city
RIGHT JOIN country ON country.capital = city.id
-- *********** UNION *************

-- Back to the "dvdstore" database...

-- Gathers a list of all first names used by actors and customers
-- By default removes duplicates

-- Gather the list, but this time note the source table with 'A' for actor and 'C' for customer
