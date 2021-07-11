sqlite3 Oktomook
PRAGMA foreign_keys = 1;
Create table Branch (branchNumber Text Primary Key, branchName Text, streetNo Text, 
	streetName Text, branchCity Text, branchState Text, numberEmployees Integer);
Create table Publisher (publisherCode Text Primary Key, publisherName Text, 
	publisherCity Text, publisherState Text);
Create table Author (authorID Text Primary Key, firstName Text, lastName Text);
Create table Book (ISBN Text Primary Key, title Text, publisherCode Text, genre Text, 
	retailPrice Real, paperback Text, Foreign Key (publisherCode) references Publisher 
	(publisherCode));
Create table Wrote (ISBN Text, authorID Text, sequenceNumber Text, Primary Key (ISBN, authorID),
	Foreign Key (ISBN) references Book (ISBN), Foreign Key (authorID) references Author 
	(authorID));
Create table Inventory (ISBN Text, branchNumber Text, quantityInStock Integer, 
	Primary Key (ISBN, branchNumber), Foreign Key (ISBN) references Book (ISBN), 
	Foreign Key (branchNumber) references Branch (branchNumber));

