-- CREATE DATABASE DeltaDB

--Table creation Commands
-- CREATE TABLE Masters
-- (
--     MasterID int IDENTITY(1,1) PRIMARY KEY,
--     MasterName varchar(50) NOT NULL,
--     MasterType VARCHAR(50) NOT NULL
-- )

-- CREATE TABLE Actors
-- (  
--     ActorID int IDENTITY(1,1) PRIMARY KEY,
--     ActorName nvarchar(50) NOT NULL,
--     Bio varchar(200) NOT NULL,
--     DateOfBirth DATE NULL,
--     Gender int NULL
-- );

-- CREATE TABLE Producers
-- (  
--     ProducerID int IDENTITY(1,1) PRIMARY KEY,
--     ProducerName nvarchar(50) NOT NULL,
--     Bio varchar(200) NOT NULL,
--     DateOfBirth DATE NULL,
--     Gender int NULL,
--     Comapny varchar(50) NOT NULL
-- );

-- CREATE TABLE Movies
-- (  
--     MovieID int IDENTITY(1,1) PRIMARY KEY,
--     MovieName nvarchar(50) NOT NULL,
--     Plot nvarchar(max) NULL,
--     Poster nvarchar(max) NOT NULL,
--     ReleaseDate date,
--     ProducerID int NOT NULL
-- );

-- CREATE TABLE MovieDetails
-- (  
--     MovieDetailsID int IDENTITY(1,1) PRIMARY KEY,
--     MovieID int NOT NULL,
--     ActorID int NOT NULL
-- );


--Adding foreign key relations
-- ALTER TABLE Movies    
-- ADD CONSTRAINT FK_Movies_Producer FOREIGN KEY (ProducerID)     
-- REFERENCES Producers (ProducerID)     
-- ON DELETE CASCADE    
-- ON UPDATE CASCADE

-- ALTER TABLE MovieDetails    
-- ADD CONSTRAINT FK_MovieDetails_Movies FOREIGN KEY (MovieID)     
-- REFERENCES Movies (MovieID)     
-- ON DELETE CASCADE    
-- ON UPDATE CASCADE

-- ALTER TABLE MovieDetails    
-- ADD CONSTRAINT FK_MovieDetails_Actors FOREIGN KEY (ActorID)     
-- REFERENCES Actors (ActorID)     
-- ON DELETE CASCADE    
-- ON UPDATE CASCADE


--Inserting masters
-- INSERT INTO Masters VALUES
-- ('Male','Gender'),
-- ('Female','Gender'),
-- ('Others','Gender')
-- select * from Masters
-- insert into Producers values('Kevin Fiege','Black Panther Producer',GETDATE(),1,'Marvel')

-- select * from Movies
-- select * from Producers

-- insert into Movies values('Black Panther','Wakanda king does rampage','Black panther poster',GETDATE(),2)

-- insert into Actors values('Chadwick Boseman','Black Panther actor',GETDATE(),1),('Michael B Jordon','Black Panther actor',GETDATE(),1)

select * from MovieDetails

insert into MovieDetails values (1,1),(1,2)

select m.*,a.ActorName,p.ProducerName from Movies as m 
JOIN MovieDetails as md on m.MovieID = md.MovieID 
join Actors as a on md.ActorID = a.ActorID
join Producers as p on m.ProducerID=p.ProducerID