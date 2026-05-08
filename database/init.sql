IF DB_ID('RestaurantDB') IS NULL
BEGIN
    CREATE DATABASE RestaurantDB;
END
GO

USE RestaurantDB;
GO

-- Drop tables if they already exist
IF OBJECT_ID('Bills', 'U') IS NOT NULL
    DROP TABLE Bills;

IF OBJECT_ID('Reservations', 'U') IS NOT NULL
    DROP TABLE Reservations;

IF OBJECT_ID('RestaurantTables', 'U') IS NOT NULL
    DROP TABLE RestaurantTables;

IF OBJECT_ID('Customers', 'U') IS NOT NULL
    DROP TABLE Customers;
GO

-- Customers table
CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    CustomerName VARCHAR(100) NOT NULL,
    Phone VARCHAR(20)
);

-- Restaurant tables
CREATE TABLE RestaurantTables (
    TableID INT PRIMARY KEY IDENTITY(1,1),
    Capacity INT NOT NULL,
    Status VARCHAR(20)
);

-- Reservations table
CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT,
    TableID INT,
    ReservationDate DATETIME,
    Guests INT,

    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (TableID) REFERENCES RestaurantTables(TableID)
);

-- Bills table
CREATE TABLE Bills (
    BillID INT PRIMARY KEY IDENTITY(1,1),
    ReservationID INT,
    TotalAmount DECIMAL(10,2),
    TaxAmount DECIMAL(10,2),
    PaymentStatus VARCHAR(20),

    FOREIGN KEY (ReservationID) REFERENCES Reservations(ReservationID)
);

-- Sample restaurant tables
INSERT INTO RestaurantTables (Capacity, Status)
VALUES
(2, 'Available'),
(4, 'Reserved'),
(6, 'Available');

-- Sample customers
INSERT INTO Customers (CustomerName, Phone)
VALUES
('John Smith', '514-111-2222'),
('Alice Brown', '514-333-4444');

-- Sample reservations
INSERT INTO Reservations
(CustomerID, TableID, ReservationDate, Guests)
VALUES
(1, 1, '2026-05-10 18:00:00', 4),
(2, 3, '2026-05-11 19:30:00', 2);

-- Sample bills
INSERT INTO Bills
(ReservationID, TotalAmount, TaxAmount, PaymentStatus)
VALUES
(1, 120.00, 18.00, 'Paid'),
(2, 75.00, 11.25, 'Pending');