CREATE DATABASE IF NOT EXISTS TennisCourtBooking; 

USE TennisCourtBooking;

CREATE TABLE IF NOT EXISTS Court (
    courtId int NOT NULL AUTO_INCREMENT,
    label varchar(255),
    PRIMARY KEY (courtId)
);


CREATE TABLE IF NOT EXISTS Booking (
bookingId int NOT NULL AUTO_INCREMENT,
courtId int,
type ENUM('BOOKED', 'BLOCKED'),
firstname varchar(255),
lastname varchar(255),
date DATE,
startTime int,
endTime int,
PRIMARY KEY(bookingId),
FOREIGN KEY(courtId) REFERENCES Court(courtId)
);

USE TennisCourtBooking;

INSERT INTO COURT(label) 
VALUES('CourtOne');

INSERT INTO Booking(courtId, Enum, firstname, lastname, date, startTime, endTime) 
VALUES(1, 'Booked','Moritz', 'Abend', "2017-06-15", 9, 12);