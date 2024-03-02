
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/03/2024 00:34:08
-- Generated from EDMX file: C:\Users\Administrator\Documents\GitHub\Project-C-Sharp\Project-C-Sharp\doanNet\doanNet\Models\KTXTDTUV3.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KTXTDTU];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Account__IDSinhV__4CA06362]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Account] DROP CONSTRAINT [FK__Account__IDSinhV__4CA06362];
GO
IF OBJECT_ID(N'[dbo].[FK__AccountTy__IDAcc__4F7CD00D]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountType] DROP CONSTRAINT [FK__AccountTy__IDAcc__4F7CD00D];
GO
IF OBJECT_ID(N'[dbo].[FK__Contract__IDPlac__3E52440B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contract] DROP CONSTRAINT [FK__Contract__IDPlac__3E52440B];
GO
IF OBJECT_ID(N'[dbo].[FK__ContractB__IDCon__412EB0B6]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractBridge] DROP CONSTRAINT [FK__ContractB__IDCon__412EB0B6];
GO
IF OBJECT_ID(N'[dbo].[FK__ContractB__IDPri__4222D4EF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractBridge] DROP CONSTRAINT [FK__ContractB__IDPri__4222D4EF];
GO
IF OBJECT_ID(N'[dbo].[FK__Fee__IDLog__5812160E]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fee] DROP CONSTRAINT [FK__Fee__IDLog__5812160E];
GO
IF OBJECT_ID(N'[dbo].[FK__Fee__IDRoom__571DF1D5]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fee] DROP CONSTRAINT [FK__Fee__IDRoom__571DF1D5];
GO
IF OBJECT_ID(N'[dbo].[FK__Log__IDSinhVien__49C3F6B7]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Log] DROP CONSTRAINT [FK__Log__IDSinhVien__49C3F6B7];
GO
IF OBJECT_ID(N'[dbo].[FK__Mistake__IDAccou__534D60F1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mistake] DROP CONSTRAINT [FK__Mistake__IDAccou__534D60F1];
GO
IF OBJECT_ID(N'[dbo].[FK__Mistake__IDRoom__5441852A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mistake] DROP CONSTRAINT [FK__Mistake__IDRoom__5441852A];
GO
IF OBJECT_ID(N'[dbo].[FK__Mistake__IDSinhV__52593CB8]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Mistake] DROP CONSTRAINT [FK__Mistake__IDSinhV__52593CB8];
GO
IF OBJECT_ID(N'[dbo].[FK__SinhVien__IDCont__45F365D3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SinhVien] DROP CONSTRAINT [FK__SinhVien__IDCont__45F365D3];
GO
IF OBJECT_ID(N'[dbo].[FK__SinhVien__IDFalc__44FF419A]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SinhVien] DROP CONSTRAINT [FK__SinhVien__IDFalc__44FF419A];
GO
IF OBJECT_ID(N'[dbo].[FK__SinhVien__IDRoom__46E78A0C]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SinhVien] DROP CONSTRAINT [FK__SinhVien__IDRoom__46E78A0C];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Account]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Account];
GO
IF OBJECT_ID(N'[dbo].[AccountType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountType];
GO
IF OBJECT_ID(N'[dbo].[Contract]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contract];
GO
IF OBJECT_ID(N'[dbo].[ContractBridge]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContractBridge];
GO
IF OBJECT_ID(N'[dbo].[Faculty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Faculty];
GO
IF OBJECT_ID(N'[dbo].[Fee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fee];
GO
IF OBJECT_ID(N'[dbo].[Log]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log];
GO
IF OBJECT_ID(N'[dbo].[Mistake]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Mistake];
GO
IF OBJECT_ID(N'[dbo].[Place]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Place];
GO
IF OBJECT_ID(N'[dbo].[Priority]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Priority];
GO
IF OBJECT_ID(N'[dbo].[Room]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Room];
GO
IF OBJECT_ID(N'[dbo].[SinhVien]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SinhVien];
GO
IF OBJECT_ID(N'[KTXTDTUModelV3StoreContainer].[Menu]', 'U') IS NOT NULL
    DROP TABLE [KTXTDTUModelV3StoreContainer].[Menu];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [IDAccount] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(50)  NOT NULL,
    [Password] varchar(max)  NOT NULL,
    [Available] binary(1)  NOT NULL,
    [Name] varchar(max)  NOT NULL,
    [IDSinhVien] int  NOT NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'AccountTypes'
CREATE TABLE [dbo].[AccountTypes] (
    [IDAccountType] int IDENTITY(1,1) NOT NULL,
    [TypeDescription] varchar(max)  NOT NULL,
    [IDAccount] int  NOT NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'Contracts'
CREATE TABLE [dbo].[Contracts] (
    [IDContract] int IDENTITY(1,1) NOT NULL,
    [MSSV] nvarchar(30)  NOT NULL,
    [IDCitizen] nvarchar(20)  NOT NULL,
    [ProfilePlace] binary(1)  NOT NULL,
    [IDPlace] nvarchar(10)  NOT NULL,
    [Ending] int  NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'ContractBridges'
CREATE TABLE [dbo].[ContractBridges] (
    [IDContract] int  NOT NULL,
    [IDPriority] int  NOT NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'Faculties'
CREATE TABLE [dbo].[Faculties] (
    [IDFalcuty] int  NOT NULL,
    [NameFalculty] nvarchar(70)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'Fees'
CREATE TABLE [dbo].[Fees] (
    [IDFee] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(max)  NOT NULL,
    [Description] varchar(max)  NOT NULL,
    [DateStart] datetime  NOT NULL,
    [DateEnd] datetime  NOT NULL,
    [Status] binary(1)  NOT NULL,
    [IDRoom] int  NOT NULL,
    [IDLog] int  NOT NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'Logs'
CREATE TABLE [dbo].[Logs] (
    [IDLog] int IDENTITY(1,1) NOT NULL,
    [DateDone] datetime  NOT NULL,
    [Quantity] int  NOT NULL,
    [IDSinhVien] int  NOT NULL,
    [Note] nvarchar(max)  NOT NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'Mistakes'
CREATE TABLE [dbo].[Mistakes] (
    [IDMistake] int IDENTITY(1,1) NOT NULL,
    [MistakeDes] varchar(max)  NOT NULL,
    [TimeCaught] datetime  NOT NULL,
    [BedID] nvarchar(10)  NOT NULL,
    [IDSinhVien] int  NOT NULL,
    [IDAccount] int  NOT NULL,
    [IDRoom] int  NOT NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'Places'
CREATE TABLE [dbo].[Places] (
    [IDPlace] nvarchar(10)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'Priorities'
CREATE TABLE [dbo].[Priorities] (
    [IDPriority] int  NOT NULL,
    [PriorityDescription] nvarchar(max)  NOT NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'Rooms'
CREATE TABLE [dbo].[Rooms] (
    [IDRoom] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Floor] int  NOT NULL,
    [Building] varchar(10)  NOT NULL,
    [RoomType] int  NOT NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'SinhViens'
CREATE TABLE [dbo].[SinhViens] (
    [IDSinhVien] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(50)  NOT NULL,
    [Address] varchar(max)  NOT NULL,
    [BirthDay] datetime  NOT NULL,
    [AttendDate] datetime  NOT NULL,
    [AttendYear] int  NOT NULL,
    [GraduateYear] int  NOT NULL,
    [MSSV] nvarchar(50)  NOT NULL,
    [IDFalcuty] int  NOT NULL,
    [IDContract] int  NOT NULL,
    [IDRoom] int  NOT NULL,
    [Order] int  NULL,
    [Meta] varchar(max)  NULL,
    [DateBegin] datetime  NOT NULL,
    [Hide] int  NOT NULL
);
GO

-- Creating table 'Menus'
CREATE TABLE [dbo].[Menus] (
    [Order] int IDENTITY(1,1) NOT NULL,
    [Meta] varchar(max)  NOT NULL,
    [DateBegin] datetime  NULL,
    [Hide] int  NOT NULL,
    [TextMenu] varchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDAccount] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([IDAccount] ASC);
GO

-- Creating primary key on [IDAccountType] in table 'AccountTypes'
ALTER TABLE [dbo].[AccountTypes]
ADD CONSTRAINT [PK_AccountTypes]
    PRIMARY KEY CLUSTERED ([IDAccountType] ASC);
GO

-- Creating primary key on [IDContract] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [PK_Contracts]
    PRIMARY KEY CLUSTERED ([IDContract] ASC);
GO

-- Creating primary key on [IDContract], [IDPriority] in table 'ContractBridges'
ALTER TABLE [dbo].[ContractBridges]
ADD CONSTRAINT [PK_ContractBridges]
    PRIMARY KEY CLUSTERED ([IDContract], [IDPriority] ASC);
GO

-- Creating primary key on [IDFalcuty] in table 'Faculties'
ALTER TABLE [dbo].[Faculties]
ADD CONSTRAINT [PK_Faculties]
    PRIMARY KEY CLUSTERED ([IDFalcuty] ASC);
GO

-- Creating primary key on [IDFee] in table 'Fees'
ALTER TABLE [dbo].[Fees]
ADD CONSTRAINT [PK_Fees]
    PRIMARY KEY CLUSTERED ([IDFee] ASC);
GO

-- Creating primary key on [IDLog] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [PK_Logs]
    PRIMARY KEY CLUSTERED ([IDLog] ASC);
GO

-- Creating primary key on [IDMistake] in table 'Mistakes'
ALTER TABLE [dbo].[Mistakes]
ADD CONSTRAINT [PK_Mistakes]
    PRIMARY KEY CLUSTERED ([IDMistake] ASC);
GO

-- Creating primary key on [IDPlace] in table 'Places'
ALTER TABLE [dbo].[Places]
ADD CONSTRAINT [PK_Places]
    PRIMARY KEY CLUSTERED ([IDPlace] ASC);
GO

-- Creating primary key on [IDPriority] in table 'Priorities'
ALTER TABLE [dbo].[Priorities]
ADD CONSTRAINT [PK_Priorities]
    PRIMARY KEY CLUSTERED ([IDPriority] ASC);
GO

-- Creating primary key on [IDRoom] in table 'Rooms'
ALTER TABLE [dbo].[Rooms]
ADD CONSTRAINT [PK_Rooms]
    PRIMARY KEY CLUSTERED ([IDRoom] ASC);
GO

-- Creating primary key on [IDSinhVien] in table 'SinhViens'
ALTER TABLE [dbo].[SinhViens]
ADD CONSTRAINT [PK_SinhViens]
    PRIMARY KEY CLUSTERED ([IDSinhVien] ASC);
GO

-- Creating primary key on [Order], [Meta], [Hide], [TextMenu] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [PK_Menus]
    PRIMARY KEY CLUSTERED ([Order], [Meta], [Hide], [TextMenu] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IDSinhVien] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [FK__Account__IDSinhV__4CA06362]
    FOREIGN KEY ([IDSinhVien])
    REFERENCES [dbo].[SinhViens]
        ([IDSinhVien])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Account__IDSinhV__4CA06362'
CREATE INDEX [IX_FK__Account__IDSinhV__4CA06362]
ON [dbo].[Accounts]
    ([IDSinhVien]);
GO

-- Creating foreign key on [IDAccount] in table 'AccountTypes'
ALTER TABLE [dbo].[AccountTypes]
ADD CONSTRAINT [FK__AccountTy__IDAcc__4F7CD00D]
    FOREIGN KEY ([IDAccount])
    REFERENCES [dbo].[Accounts]
        ([IDAccount])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__AccountTy__IDAcc__4F7CD00D'
CREATE INDEX [IX_FK__AccountTy__IDAcc__4F7CD00D]
ON [dbo].[AccountTypes]
    ([IDAccount]);
GO

-- Creating foreign key on [IDAccount] in table 'Mistakes'
ALTER TABLE [dbo].[Mistakes]
ADD CONSTRAINT [FK__Mistake__IDAccou__534D60F1]
    FOREIGN KEY ([IDAccount])
    REFERENCES [dbo].[Accounts]
        ([IDAccount])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Mistake__IDAccou__534D60F1'
CREATE INDEX [IX_FK__Mistake__IDAccou__534D60F1]
ON [dbo].[Mistakes]
    ([IDAccount]);
GO

-- Creating foreign key on [IDPlace] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK__Contract__IDPlac__3E52440B]
    FOREIGN KEY ([IDPlace])
    REFERENCES [dbo].[Places]
        ([IDPlace])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Contract__IDPlac__3E52440B'
CREATE INDEX [IX_FK__Contract__IDPlac__3E52440B]
ON [dbo].[Contracts]
    ([IDPlace]);
GO

-- Creating foreign key on [IDContract] in table 'ContractBridges'
ALTER TABLE [dbo].[ContractBridges]
ADD CONSTRAINT [FK__ContractB__IDCon__412EB0B6]
    FOREIGN KEY ([IDContract])
    REFERENCES [dbo].[Contracts]
        ([IDContract])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IDContract] in table 'SinhViens'
ALTER TABLE [dbo].[SinhViens]
ADD CONSTRAINT [FK__SinhVien__IDCont__45F365D3]
    FOREIGN KEY ([IDContract])
    REFERENCES [dbo].[Contracts]
        ([IDContract])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SinhVien__IDCont__45F365D3'
CREATE INDEX [IX_FK__SinhVien__IDCont__45F365D3]
ON [dbo].[SinhViens]
    ([IDContract]);
GO

-- Creating foreign key on [IDPriority] in table 'ContractBridges'
ALTER TABLE [dbo].[ContractBridges]
ADD CONSTRAINT [FK__ContractB__IDPri__4222D4EF]
    FOREIGN KEY ([IDPriority])
    REFERENCES [dbo].[Priorities]
        ([IDPriority])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__ContractB__IDPri__4222D4EF'
CREATE INDEX [IX_FK__ContractB__IDPri__4222D4EF]
ON [dbo].[ContractBridges]
    ([IDPriority]);
GO

-- Creating foreign key on [IDFalcuty] in table 'SinhViens'
ALTER TABLE [dbo].[SinhViens]
ADD CONSTRAINT [FK__SinhVien__IDFalc__44FF419A]
    FOREIGN KEY ([IDFalcuty])
    REFERENCES [dbo].[Faculties]
        ([IDFalcuty])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SinhVien__IDFalc__44FF419A'
CREATE INDEX [IX_FK__SinhVien__IDFalc__44FF419A]
ON [dbo].[SinhViens]
    ([IDFalcuty]);
GO

-- Creating foreign key on [IDLog] in table 'Fees'
ALTER TABLE [dbo].[Fees]
ADD CONSTRAINT [FK__Fee__IDLog__5812160E]
    FOREIGN KEY ([IDLog])
    REFERENCES [dbo].[Logs]
        ([IDLog])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Fee__IDLog__5812160E'
CREATE INDEX [IX_FK__Fee__IDLog__5812160E]
ON [dbo].[Fees]
    ([IDLog]);
GO

-- Creating foreign key on [IDRoom] in table 'Fees'
ALTER TABLE [dbo].[Fees]
ADD CONSTRAINT [FK__Fee__IDRoom__571DF1D5]
    FOREIGN KEY ([IDRoom])
    REFERENCES [dbo].[Rooms]
        ([IDRoom])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Fee__IDRoom__571DF1D5'
CREATE INDEX [IX_FK__Fee__IDRoom__571DF1D5]
ON [dbo].[Fees]
    ([IDRoom]);
GO

-- Creating foreign key on [IDSinhVien] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [FK__Log__IDSinhVien__49C3F6B7]
    FOREIGN KEY ([IDSinhVien])
    REFERENCES [dbo].[SinhViens]
        ([IDSinhVien])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Log__IDSinhVien__49C3F6B7'
CREATE INDEX [IX_FK__Log__IDSinhVien__49C3F6B7]
ON [dbo].[Logs]
    ([IDSinhVien]);
GO

-- Creating foreign key on [IDRoom] in table 'Mistakes'
ALTER TABLE [dbo].[Mistakes]
ADD CONSTRAINT [FK__Mistake__IDRoom__5441852A]
    FOREIGN KEY ([IDRoom])
    REFERENCES [dbo].[Rooms]
        ([IDRoom])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Mistake__IDRoom__5441852A'
CREATE INDEX [IX_FK__Mistake__IDRoom__5441852A]
ON [dbo].[Mistakes]
    ([IDRoom]);
GO

-- Creating foreign key on [IDSinhVien] in table 'Mistakes'
ALTER TABLE [dbo].[Mistakes]
ADD CONSTRAINT [FK__Mistake__IDSinhV__52593CB8]
    FOREIGN KEY ([IDSinhVien])
    REFERENCES [dbo].[SinhViens]
        ([IDSinhVien])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Mistake__IDSinhV__52593CB8'
CREATE INDEX [IX_FK__Mistake__IDSinhV__52593CB8]
ON [dbo].[Mistakes]
    ([IDSinhVien]);
GO

-- Creating foreign key on [IDRoom] in table 'SinhViens'
ALTER TABLE [dbo].[SinhViens]
ADD CONSTRAINT [FK__SinhVien__IDRoom__46E78A0C]
    FOREIGN KEY ([IDRoom])
    REFERENCES [dbo].[Rooms]
        ([IDRoom])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__SinhVien__IDRoom__46E78A0C'
CREATE INDEX [IX_FK__SinhVien__IDRoom__46E78A0C]
ON [dbo].[SinhViens]
    ([IDRoom]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------