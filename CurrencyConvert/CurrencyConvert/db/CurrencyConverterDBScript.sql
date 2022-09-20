CREATE DATABASE CurrencyConvertor;
GO
USE CurrencyConvertor;

-- -----------------------------------------------------
-- Table `Currency`
-- -----------------------------------------------------
CREATE TABLE Currencies (
  Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  Name VARCHAR(45) NOT NULL,
  Code VARCHAR(45) NOT NULL,
  IsActive bit NOT NULL
  )


-- -----------------------------------------------------
-- Tables `CurrencyRate`
-- -----------------------------------------------------
CREATE TABLE CurrencyRates
(
CurrencyRateId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
CurrencyId INT FOREIGN KEY REFERENCES Currencies(Id) ON DELETE CASCADE ,
TargetCode nchar(3),
RateDate DATETIME ,
RateValue DECIMAL(18,5)

)





