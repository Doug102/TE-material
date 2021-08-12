-- INSERT

-- 1. Add Klingon as a spoken language in the USA
SELECT *
FROM countrylanguage
WHERE countrycode = 'GBR'


INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('USA', 'Klingon', 1, 0.002)

-- 2. Add Klingon as a spoken language in Great Britain (GBR)

INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('GBR', 'Klingon', 1, 0.002)

-- UPDATE

-- 1. Update the capital of the USA to Houston

SELECT id
FROM city
WHERE name = 'Houston'

UPDATE country
SET capital = (
SELECT id
FROM city
WHERE name = 'Houston'
)
WHERE code = 'USA'

SELECT * 
FROM country
WHERE code = 'USA'

-- 2. Update the capital of the USA to Washington DC and the head of state

SELECT id
FROM city
WHERE name = 'Washington'

UPDATE country
SET capital = (
SELECT id
FROM city
WHERE name = 'Washington'
),
headofstate = 'Joe Biden'
WHERE code = 'USA'



-- DELETE

-- 1. Delete English as a spoken language in the USA

DELETE
FROM countrylanguage
WHERE language = 'English' AND countrycode = 'USA'

SELECT *
FROM countrylanguage
WHERE countrycode = 'USA'

-- 2. Delete all occurrences of the Klingon language 

DELETE
FROM countrylanguage
WHERE language = 'Klingon'

-- REFERENTIAL INTEGRITY

-- 1. Try just adding Elvish to the country language table.

INSERT INTO countrylanguage (language)
VALUES ('Elvish')

-- 2. Try inserting English as a spoken language in the country ZZZ. What happens?

-- 3. Try deleting the country USA. What happens?

DELETE
FROM country
WHERE code = 'USA'

-- CONSTRAINTS

-- 1. Try inserting English as a spoken language in the USA
INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('USA', 'English', 0, 57.0)


-- 2. Try again. What happens?

-- 3. Let's relocate the USA to the continent - 'Outer Space'

UPDATE country
SET continent = 'Outer Space'
WHERE code = 'USA'

-- How to view all of the constraints

SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
SELECT * FROM INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE
SELECT * FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS


-- TRANSACTIONS

-- 1. Try deleting all of the rows from the country language table and roll it back.

-- 2. Try updating all of the cities to be in the USA and roll it back

-- 3. Demonstrate two different SQL connections trying to access the same table where one happens to be inside of a transaction but hasn't committed yet.