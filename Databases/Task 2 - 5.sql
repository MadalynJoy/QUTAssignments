/* Task 2*/

/* Query 1*/
SELECT hotelNo, type, price 
FROM Room 
WHERE (type = "Double" OR type = "Deluxe") 
	AND (price > 99);

/*Query 2*/
SELECT hotelNo 
FROM Room 
WHERE type = "Double" 
GROUP BY hotelNo 
HAVING COUNT(hotelNo) > 2;

/*Query 3*/
SELECT DISTINCT guestName, hotelName 
FROM Guest g
JOIN Booking b
ON g.guestNo = b.guestNo
JOIN Hotel h
ON b.hotelNo = h.hotelNo 
WHERE hotelName = "Ridge Hotel";

/*Query 4*/
SELECT SUM(price) as total_income
FROM Room r
JOIN Booking b
ON r.hotelNo = b.hotelNo
JOIN Hotel h
on b.hotelNo = h.hotelNo
WHERE hotelName LIKE '%Grosvenor%';

/*Query 5*/
SELECT type, price, price*1.2 
AS price_increase 
FROM Room 
WHERE type = "Deluxe";

/*Query 6*/
SELECT guestName
FROM Guest g
JOIN Booking b
on g.guestNo = b.guestNo
JOIN Hotel h
ON b.hotelNo = h.hotelNo
WHERE city == guestAddress;

/*Task 3*/
/*INSERT*/
/*1. Hotel*/
INSERT INTO Hotel (hotelNo, hotelName, city)
VALUES ('H8', 'Madalyn Hotel', 'Melbourne');

/*2. Room*/
INSERT INTO Room (roomNo, hotelNo, type, price)
VALUES ('R6', 'H8', "Deluxe", "269");

/*3. Booking*/
INSERT INTO Booking (hotelNo, guestNo, dateFrom, dateTo, roomNo)
VALUES ('H8', 'G8', '2021-04-01', '2021-04-07', 'R6');

/*4. Guest*/
INSERT INTO Guest (guestNo, guestName, guestAddress)
VALUES ('G8', 'Mitchell', 'Hobart');

/*DELETE*/
DELETE FROM Guest WHERE guestNo = 'G8';

/*UPDATE*/
UPDATE Room SET price = price *1.1;

/*Task 4*/
/*INDEX*/
CREATE INDEX guestIndex 
ON Guest(guestName);

/*VIEW*/
/*Column names in Task 4 question and relational schema do not match. Assumptions have been made where 
	staffFirstName = fName, propertyRent = rent, propertyOwner = ownerNo*/

CREATE VIEW taskFourView
AS
	SELECT
		s.staffNo,
		s.fName,
		r.propertyNo,
		r.rent,
		r.ownerNo
	FROM Staff AS s
	JOIN PropertyForRent as r on s.StaffNo = r.StaffNo;

/*Task 5*/
/*Nikki GRANT*/
GRANT INSERT ON Booking TO nikki;

/*Nikki REVOKE*/
REVOKE DELETE ON Booking TO nikki;

/*Phil GRANT*/
GRANT INSERT ON Guest TO phil;
 
/*Phil REVOKE*/
REVOKE DELETE ON Guest TO phil;
