
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/30/2023 06:36:13
-- Generated from EDMX file: D:\6th semester\C_Sharp\ContentManagement\ContentManagement\Models\contentManagementSystem.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [contentManagementSystem];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UploaderContent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contents] DROP CONSTRAINT [FK_UploaderContent];
GO
IF OBJECT_ID(N'[dbo].[FK_AdminContent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contents] DROP CONSTRAINT [FK_AdminContent];
GO
IF OBJECT_ID(N'[dbo].[FK_VerifierContent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contents] DROP CONSTRAINT [FK_VerifierContent];
GO
IF OBJECT_ID(N'[dbo].[FK_AdminVerifier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Verifiers] DROP CONSTRAINT [FK_AdminVerifier];
GO
IF OBJECT_ID(N'[dbo].[FK_AdminUploader]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uploaders] DROP CONSTRAINT [FK_AdminUploader];
GO
IF OBJECT_ID(N'[dbo].[FK_VerifierUploader]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uploaders] DROP CONSTRAINT [FK_VerifierUploader];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Uploaders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uploaders];
GO
IF OBJECT_ID(N'[dbo].[Contents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contents];
GO
IF OBJECT_ID(N'[dbo].[Admins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admins];
GO
IF OBJECT_ID(N'[dbo].[Verifiers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Verifiers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Uploaders'
CREATE TABLE [dbo].[Uploaders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Phone_no] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [AdminId] int  NOT NULL,
    [VerifierId] int  NOT NULL
);
GO

-- Creating table 'Contents'
CREATE TABLE [dbo].[Contents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PdfContent] nvarchar(max)  NOT NULL,
    [UploaderName] nvarchar(max)  NOT NULL,
    [UploaderId] int  NOT NULL,
    [AdminId] int  NOT NULL,
    [VerifierId] int  NOT NULL
);
GO

-- Creating table 'Admins'
CREATE TABLE [dbo].[Admins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Verifiers'
CREATE TABLE [dbo].[Verifiers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Phone_no] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [AdminId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Uploaders'
ALTER TABLE [dbo].[Uploaders]
ADD CONSTRAINT [PK_Uploaders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contents'
ALTER TABLE [dbo].[Contents]
ADD CONSTRAINT [PK_Contents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [PK_Admins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Verifiers'
ALTER TABLE [dbo].[Verifiers]
ADD CONSTRAINT [PK_Verifiers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------