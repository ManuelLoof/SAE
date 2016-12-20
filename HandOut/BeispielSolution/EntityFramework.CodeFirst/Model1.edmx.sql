
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/13/2015 15:34:36
-- Generated from EDMX file: C:\Home\Work\SAE\Datenbanken\ConsoleDatabaseApp\EntityFramework.CodeFirst\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EntityFrameworkCodeFirst];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Entity1Set'
CREATE TABLE [dbo].[Entity1Set] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Entity2Set'
CREATE TABLE [dbo].[Entity2Set] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Entity1Set'
ALTER TABLE [dbo].[Entity1Set]
ADD CONSTRAINT [PK_Entity1Set]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Entity2Set'
ALTER TABLE [dbo].[Entity2Set]
ADD CONSTRAINT [PK_Entity2Set]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------