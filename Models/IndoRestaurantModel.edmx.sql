
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/24/2019 21:07:44
-- Generated from EDMX file: E:\STUDY\3. Semester 2 2019\FIT5032_Internet_Applications_Development\source\repos\IndoRestaurant\Models\IndoRestaurantModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Restaurant];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_BranchEmployee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_BranchEmployee];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchBranchTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BranchTables] DROP CONSTRAINT [FK_BranchBranchTable];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchBookingRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BookingRequests] DROP CONSTRAINT [FK_BranchBookingRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_BranchReview];
GO
IF OBJECT_ID(N'[dbo].[FK_BookingRequestReview]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Reviews] DROP CONSTRAINT [FK_BookingRequestReview];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Campaigns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Campaigns];
GO
IF OBJECT_ID(N'[dbo].[BookingRequests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BookingRequests];
GO
IF OBJECT_ID(N'[dbo].[BranchTables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BranchTables];
GO
IF OBJECT_ID(N'[dbo].[Branches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Branches];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Reviews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Reviews];
GO
IF OBJECT_ID(N'[dbo].[Menus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menus];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Campaigns'
CREATE TABLE [dbo].[Campaigns] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SendTo] nvarchar(max)  NOT NULL,
    [Subject] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [SendDate] datetime  NOT NULL,
    [AttachmentPath] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BookingRequests'
CREATE TABLE [dbo].[BookingRequests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Time] int  NOT NULL,
    [Persons] int  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Telephone] nvarchar(max)  NOT NULL,
    [Note] nvarchar(max)  NULL,
    [TransactionDate] datetime  NOT NULL,
    [BookingStatus] int  NULL,
    [ReviewCode] nvarchar(max)  NULL,
    [RealTimeStart] int  NULL,
    [RealTimeEnd] int  NULL,
    [BranchId] int  NOT NULL,
    [BranchTableId] int  NULL
);
GO

-- Creating table 'BranchTables'
CREATE TABLE [dbo].[BranchTables] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TableNo] nvarchar(max)  NOT NULL,
    [Capacity] int  NOT NULL,
    [BranchId] int  NOT NULL
);
GO

-- Creating table 'Branches'
CREATE TABLE [dbo].[Branches] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Telephone] nvarchar(max)  NOT NULL,
    [Lat] nvarchar(max)  NOT NULL,
    [Lng] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [Telephone] nvarchar(max)  NOT NULL,
    [LoginId] nvarchar(max)  NOT NULL,
    [BranchId] int  NOT NULL
);
GO

-- Creating table 'Reviews'
CREATE TABLE [dbo].[Reviews] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Menu] int  NOT NULL,
    [Place] int  NOT NULL,
    [Service] int  NOT NULL,
    [BookingProcess] int  NOT NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [ReviewDate] datetime  NOT NULL,
    [BranchId] int  NOT NULL,
    [BookingRequestId] int  NOT NULL
);
GO

-- Creating table 'Menus'
CREATE TABLE [dbo].[Menus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Calories] int  NOT NULL,
    [ImagePath] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Campaigns'
ALTER TABLE [dbo].[Campaigns]
ADD CONSTRAINT [PK_Campaigns]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BookingRequests'
ALTER TABLE [dbo].[BookingRequests]
ADD CONSTRAINT [PK_BookingRequests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BranchTables'
ALTER TABLE [dbo].[BranchTables]
ADD CONSTRAINT [PK_BranchTables]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [PK_Branches]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [PK_Reviews]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [PK_Menus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BranchId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_BranchEmployee]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchEmployee'
CREATE INDEX [IX_FK_BranchEmployee]
ON [dbo].[Employees]
    ([BranchId]);
GO

-- Creating foreign key on [BranchId] in table 'BranchTables'
ALTER TABLE [dbo].[BranchTables]
ADD CONSTRAINT [FK_BranchBranchTable]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchBranchTable'
CREATE INDEX [IX_FK_BranchBranchTable]
ON [dbo].[BranchTables]
    ([BranchId]);
GO

-- Creating foreign key on [BranchId] in table 'BookingRequests'
ALTER TABLE [dbo].[BookingRequests]
ADD CONSTRAINT [FK_BranchBookingRequest]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchBookingRequest'
CREATE INDEX [IX_FK_BranchBookingRequest]
ON [dbo].[BookingRequests]
    ([BranchId]);
GO

-- Creating foreign key on [BranchId] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_BranchReview]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchReview'
CREATE INDEX [IX_FK_BranchReview]
ON [dbo].[Reviews]
    ([BranchId]);
GO

-- Creating foreign key on [BookingRequestId] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_BookingRequestReview]
    FOREIGN KEY ([BookingRequestId])
    REFERENCES [dbo].[BookingRequests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookingRequestReview'
CREATE INDEX [IX_FK_BookingRequestReview]
ON [dbo].[Reviews]
    ([BookingRequestId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------