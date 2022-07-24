CREATE DATABASE AuxionizeAPI;

use AuxionizeAPI

CREATE TABLE dbo.[Category]
(
Id int primary key,
Name varchar(256)
)

CREATE TABLE dbo.[Product]
(
Id int primary key identity(1,1), /*I though about making EAN primary key, but this makes EAN column immutable/not easy to upade if it was mistaken*/
EAN varchar(13) not null unique, /* could be added index in future */
Price numeric(18, 2),
Name varchar(256),
CategoryId int foreign key references dbo.[Category](Id)
)

CREATE TABLE dbo.[GrossTurnoverByProduct]
(
Id int primary key identity(1,1),
ProductEAN varchar(13),
PercentageVAT int, --could be tiny int
NetTurnover numeric(18, 2),
GrossTurnover numeric(18, 2),
Jurisdiction varchar(256)
)

INSERT INTO dbo.[Category] values
(1, 'Bevarage'),
(2, 'Book'),
(3, 'ConsumerGoods')

INSERT INTO dbo.[Product](Name, Price, EAN, CategoryId) values
('CocaCola', 1.75, '12345678', 1),
('The Great Gatsby', 15.50, '123456789', 2),
('Pants', 50.00, '12345678910', 3)


select * from Product