﻿CREATE TABLE Faculty
(
  IDFalcuty INT NOT NULL,
  NameFalculty NVARCHAR(70) NOT NULL,
  Description NTEXT NOT NULL,
  PRIMARY KEY (IDFalcuty)
);

CREATE TABLE Place
(
  IDPlace NVARCHAR(10) NOT NULL,
  Description NTEXT NOT NULL,
  PRIMARY KEY (IDPlace)
);

CREATE TABLE Priority
(
  IDPriority INT NOT NULL,
  PriorityDescription INT NOT NULL,
  PRIMARY KEY (IDPriority)
);

CREATE TABLE Room
(
  IDRoom INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  Name NVARCHAR(50) NOT NULL,
  Floor INT NOT NULL,
  Building VARCHAR(10) NOT NULL,
  RoomType INT NOT NULL,
);

CREATE TABLE Contract
(
  IDContract INT NOT NULL IDENTITY(1,1),
  MSSV NVARCHAR(30) NOT NULL,
  IDCitizen NVARCHAR(20) NOT NULL,
  ProfilePlace BINARY NOT NULL,
  IDPlace NVARCHAR(10) NOT NULL,
  PRIMARY KEY (IDContract),
  FOREIGN KEY (IDPlace) REFERENCES Place(IDPlace)
);

CREATE TABLE ContractBridge
(
  IDContract INT NOT NULL,
  IDPriority INT NOT NULL,
  PRIMARY KEY (IDContract, IDPriority),
  FOREIGN KEY (IDContract) REFERENCES Contract(IDContract),
  FOREIGN KEY (IDPriority) REFERENCES Priority(IDPriority)
);

CREATE TABLE SinhVien
(
  IDSinhVien INT NOT NULL IDENTITY(1,1),
  FullName NVARCHAR(50) NOT NULL,
  Address TEXT NOT NULL,
  BirthDay DATE NOT NULL,
  AttendDate DATE NOT NULL,
  AttendYear INT NOT NULL,
  GraduateYear INT NOT NULL,
  MSSV NVARCHAR(50) NOT NULL,
  IDFalcuty INT NOT NULL,
  IDContract INT NOT NULL,
  IDRoom INT NOT NULL,
  PRIMARY KEY (IDSinhVien),
  FOREIGN KEY (IDFalcuty) REFERENCES Faculty(IDFalcuty),
  FOREIGN KEY (IDContract) REFERENCES Contract(IDContract),
  FOREIGN KEY (IDRoom) REFERENCES Room(IDRoom)
);

CREATE TABLE Log
(
  IDLog INT NOT NULL IDENTITY(1,1),
  DateDone DATETIME NOT NULL,
  Quantity INT NOT NULL,
  IDSinhVien INT NOT NULL,
  PRIMARY KEY (IDLog),
  FOREIGN KEY (IDSinhVien) REFERENCES SinhVien(IDSinhVien)
);

CREATE TABLE Account
(
  IDAccount INT NOT NULL IDENTITY(1,1),
  Email NVARCHAR(50) NOT NULL,
  Password TEXT NOT NULL,
  Available BINARY NOT NULL,
  Name TEXT NOT NULL,
  IDSinhVien INT NOT NULL,
  PRIMARY KEY (IDAccount),
  FOREIGN KEY (IDSinhVien) REFERENCES SinhVien(IDSinhVien)
);

CREATE TABLE AccountType
(
  IDAccountType INT NOT NULL IDENTITY(1,1),
  TypeDescription TEXT NOT NULL,
  IDAccount INT NOT NULL,
  PRIMARY KEY (IDAccountType),
  FOREIGN KEY (IDAccount) REFERENCES Account(IDAccount)
);

CREATE TABLE Mistake
(
  IDMistake INT NOT NULL IDENTITY(1,1),
  MistakeDes TEXT NOT NULL,
  TimeCaught DATETIME NOT NULL,
  BedID NVARCHAR(10) NOT NULL,
  IDSinhVien INT NOT NULL,
  IDAccount INT NOT NULL,
  IDRoom INT NOT NULL,
  PRIMARY KEY (IDMistake),
  FOREIGN KEY (IDSinhVien) REFERENCES SinhVien(IDSinhVien),
  FOREIGN KEY (IDAccount) REFERENCES Account(IDAccount),
  FOREIGN KEY (IDRoom) REFERENCES Room(IDRoom)
);

CREATE TABLE Fee
(
  IDFee INT NOT NULL IDENTITY(1,1),
  Name TEXT NOT NULL,
  Description TEXT NOT NULL,
  DateStart DATETIME NOT NULL,
  DateEnd DATETIME NOT NULL,
  Status BINARY NOT NULL,
  IDRoom INT NOT NULL,
  IDLog INT NOT NULL,
  PRIMARY KEY (IDFee),
  FOREIGN KEY (IDRoom) REFERENCES Room(IDRoom),
  FOREIGN KEY (IDLog) REFERENCES Log(IDLog)
);
-----Data-----
USE [KTXTDTU]
GO

INSERT INTO [dbo].[Place]
           ([IDPlace]
           ,[Description]
           ,[Order]
           ,[Meta]
           ,[DateBegin]
           ,[Hide])
     VALUES
           ('KV1'
           ,N'Khu Vực 1'
           ,null
           ,null
           ,GETDATE()
           ,0)
GO

INSERT INTO [dbo].[Priority]
           ([IDPriority]
           ,[PriorityDescription]
           ,[Order]
           ,[Meta]
           ,[DateBegin]
           ,[Hide])
     VALUES
           (10
           ,N'Sinh viên khu vực tuyển sinh theo thứ tự: KV1 không thuộc thành phố, thị xã, KV2-NT không thuộc thành phố, thị xã; KV1 thuộc thành phố, thị xã; KV2-NT thuộc thành phố, thị xã; KV2; KV3.'
           ,null
           ,null
           ,GETDATE()
           ,0)
GO