-- firstname, lastname and title of all employees with a position

SELECT e.firstname, e.lastname, p.title
FROM employee e
INNER JOIN position p on e.position = p.id
-- JOIN position p on e.position = p.id


-- title and department name of all positions assigned to an department

SELECT p.title, d.name
FROM position p 
INNER JOIN department d on p.department = d.id


-- firstname, lastname, title, and department name of all assigned employees

SELECT e.firstname, e.lastname, p.title,  d.name
FROM employee e
INNER JOIN position p on e.position = p.id
INNER JOIN department d on p.department = d.id


-- firstname and lastname of all employees (assigned or not), include title for those that are assigned

SELECT e.firstname, e.lastname, p.title
FROM employee e
LEFT OUTER JOIN position p on e.position = p.id
--LEFT JOIN position p on e.position = p.id


-- all position titles (assigned or not) and all employees assigned to a position (firstname and lastname)

SELECT e.firstname, e.lastname, p.title
FROM employee e
RIGHT OUTER JOIN position p on e.position = p.id


-- above, with the opposite outer join (left or right)

SELECT e.firstname, e.lastname, p.title
FROM position p 
LEFT OUTER JOIN employee e on e.position = p.id


-- show all employees, asigned or not (firstname and lastname) and all poistion titles, 
-- asigned or not. Show mattches where they exist (FULL OUTER JOIN)

SELECT e.firstname, e.lastname, p.title
FROM employee e
FULL OUTER JOIN position p on e.position = p.id
--FULL JOIN position p on e.position = p.id


-- show all possible combinations of employees (firstname and lastname) and position titles, 
-- whether the combinations exist or not (CROSS JOIN)

SELECT e.firstname, e.lastname, p.title
FROM employee e
CROSS JOIN position p 







--
--
--










