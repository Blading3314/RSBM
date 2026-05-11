IF DB_ID('RestaurantDB') IS NULL
BEGIN
    CREATE DATABASE RestaurantDB;
END
GO

USE RestaurantDB;
GO

/* DROP OLD TABLES */

IF OBJECT_ID('Bills', 'U') IS NOT NULL
    DROP TABLE Bills;

IF OBJECT_ID('Reservations', 'U') IS NOT NULL
    DROP TABLE Reservations;

IF OBJECT_ID('RestaurantTables', 'U') IS NOT NULL
    DROP TABLE RestaurantTables;

IF OBJECT_ID('Customers', 'U') IS NOT NULL
    DROP TABLE Customers;
GO

/* CUSTOMERS TABLE */

CREATE TABLE Customers
(
    CustomerID INT PRIMARY KEY IDENTITY(1,1),

    CustomerName VARCHAR(100) NOT NULL,

    Phone VARCHAR(20) NOT NULL,
);
GO

/* RESTAURANT TABLES */

CREATE TABLE RestaurantTables
(
    TableID INT PRIMARY KEY IDENTITY(1,1),

    TableNumber INT NOT NULL UNIQUE,

    Capacity INT NOT NULL,

    Status VARCHAR(20) NOT NULL
        CHECK (Status IN ('Available', 'Reserved', 'Occupied'))
);
GO

INSERT INTO RestaurantTables (TableNumber, Capacity, Status)
VALUES
    (1, 2, 'Available'),
    (2, 2, 'Available'),
    (3, 4, 'Available'),
    (4, 4, 'Available'),
    (5, 4, 'Available'),
    (6, 6, 'Available'),
    (7, 6, 'Available'),
    (8, 8, 'Available');
GO

/* RESERVATIONS */

CREATE TABLE Reservations
(
    ReservationID INT PRIMARY KEY IDENTITY(1,1),

    CustomerID INT NOT NULL,

    TableID INT NOT NULL,

    ReservationDate DATE NOT NULL,

    ReservationTime TIME NOT NULL,

    Guests INT NOT NULL,

    Status VARCHAR(20) NOT NULL,

    FOREIGN KEY (CustomerID)
        REFERENCES Customers(CustomerID),

    FOREIGN KEY (TableID)
        REFERENCES RestaurantTables(TableID)
);
GO

/* BILLS */

CREATE TABLE Bills
(
    BillID INT PRIMARY KEY IDENTITY(1,1),

    ReservationID INT NOT NULL,

    SubTotal DECIMAL(10,2) NOT NULL,

    TaxAmount DECIMAL(10,2) NOT NULL,

    TotalAmount DECIMAL(10,2) NOT NULL,

    PaymentMethod VARCHAR(20),

    PaymentStatus VARCHAR(20),

    BillDate DATETIME DEFAULT GETDATE(),

    FOREIGN KEY (ReservationID)
        REFERENCES Reservations(ReservationID)
);
GO
