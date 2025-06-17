# ASP.NET Core MVC - Dynamic Dropdown Example (State & District)

## 📘 Project Overview

This project demonstrates how to dynamically populate a second dropdown (Districts) based on the selection from the first dropdown (States) using jQuery and ASP.NET Core MVC (8/9). 
---

## 🎯 Key Features

- ASP.NET Core MVC with Razor Views
- jQuery-based dynamic dropdown population
- SQL Server for backend database
- Entity Framework integration (optional)
- Dropdowns linked via foreign keys

---

## 🛠️ Technologies Used

- ASP.NET Core MVC 8/9
- C#
- Razor Views
- jQuery
- SQL Server
- Bootstrap (optional for styling)

---

## 🗄️ Database Schema

### 1. **States Table**, 2. **District Table**, 3. **Worker Table**

```sql
CREATE TABLE States (
    stateId INT IDENTITY(1001,1) CONSTRAINT pk_stateId PRIMARY KEY,
    stateName VARCHAR(100)
);


CREATE TABLE states (
    stateId INT IDENTITY(1001,1) CONSTRAINT pk_stateId PRIMARY KEY,
    stateName VARCHAR(100)
);

INSERT INTO states(stateName) VALUES('Uttarpadesh');
INSERT INTO states(stateName) VALUES('Bihar');
INSERT INTO states(stateName) VALUES('Lucknow');
INSERT INTO states(stateName) VALUES('Delhi');
INSERT INTO states(stateName) VALUES('Mahastra');
INSERT INTO states(stateName) VALUES('Madayapradesh');

SELECT * FROM states;

CREATE TABLE districts (
    distId INT IDENTITY(10001,1) CONSTRAINT pk_distId PRIMARY KEY,
    disName VARCHAR(100),
    stateId INT CONSTRAINT fk_stateId FOREIGN KEY REFERENCES states(stateId)
);

INSERT INTO districts(disName, stateId) VALUES('mahim', 1001);
INSERT INTO districts(disName, stateId) VALUES('gaya', 1002);
INSERT INTO districts(disName, stateId) VALUES('jharkand', 1003);
INSERT INTO districts(disName, stateId) VALUES('thane', 1004);
INSERT INTO districts(disName, stateId) VALUES('kahlyan', 1005);
INSERT INTO districts(disName, stateId) VALUES('malad', 1006);
INSERT INTO districts(disName, stateId) VALUES('shviaji', 1001);
INSERT INTO districts(disName, stateId) VALUES('kurla', 1002);
INSERT INTO districts(disName, stateId) VALUES('adheri', 1003);
INSERT INTO districts(disName, stateId) VALUES('bandra', 1004);
INSERT INTO districts(disName, stateId) VALUES('jhuhu', 1005);

SELECT * FROM districts;


CREATE TABLE Worker (
    workId INT IDENTITY(100001,1) CONSTRAINT pk_workId PRIMARY KEY,
    workName VARCHAR(100),
    workDob DATE,
    stateId INT CONSTRAINT fk_stateId1 FOREIGN KEY REFERENCES states(stateId),
    distId INT CONSTRAINT fk_distId FOREIGN KEY REFERENCES districts(distId)
);

SELECT * FROM Worker;
