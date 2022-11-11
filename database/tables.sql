CREATE DATABASE IF NOT EXISTS TennisCourtBooking; 

USE TennisCourtBooking;

CREATE TABLE IF NOT EXISTS Court (
courtId int NOT NULL AUTO_INCREMENT,
label varchar(255),
PRIMARY KEY(courtId)
);

CREATE TABLE IF NOT EXISTS Bocking (
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
