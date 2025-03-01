-- Create the PetAdoptionDB database
CREATE DATABASE IF NOT EXISTS PetAdoptionDB;

-- Use the PetAdoptionDB database
USE PetAdoptionDB;

-- Create Users table
CREATE TABLE IF NOT EXISTS Users (
    UserId INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    PhoneNumber VARCHAR(15),
    Address VARCHAR(255),
    Role VARCHAR(50) NOT NULL CHECK (Role IN ('Admin', 'User'))
);

-- Create Pets table
CREATE TABLE IF NOT EXISTS Pets (
    PetId INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Type VARCHAR(50) NOT NULL,
    Breed VARCHAR(50),
    Age INT,
    Color VARCHAR(50),
    Size VARCHAR(50),
    Description TEXT,
    ImageUrl VARCHAR(255),
    Status VARCHAR(50) NOT NULL CHECK (Status IN ('Available', 'Adopted'))
);

-- Create AdoptionRequests table
CREATE TABLE IF NOT EXISTS AdoptionRequests (
    RequestId INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    PetId INT NOT NULL,
    RequestDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Status VARCHAR(50) NOT NULL CHECK (Status IN ('Pending', 'Approved', 'Denied')),
    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE,
    FOREIGN KEY (PetId) REFERENCES Pets(PetId) ON DELETE CASCADE
);

-- Create Payments table (optional if you want to manage payments)
CREATE TABLE IF NOT EXISTS Payments (
    PaymentId INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    PaymentDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    PaymentMethod VARCHAR(50),
    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);

-- Create Donations table (optional if you want to manage donations)
CREATE TABLE IF NOT EXISTS Donations (
    DonationId INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    Amount DECIMAL(18, 2) NOT NULL,
    DonationDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    Purpose VARCHAR(100),
    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);
