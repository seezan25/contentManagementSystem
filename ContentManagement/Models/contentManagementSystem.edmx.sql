
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/29/2023 23:59:30
-- Generated from EDMX file: D:\6th semester\C_Sharp\ContentManagement\ContentManagement\Models\contentManagementSystem.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
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
IF OBJECT_ID(N'[dbo].[FK_AdminLogin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Admins] DROP CONSTRAINT [FK_AdminLogin];
GO
IF OBJECT_ID(N'[dbo].[FK_UploaderLogin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uploaders] DROP CONSTRAINT [FK_UploaderLogin];
GO
IF OBJECT_ID(N'[dbo].[FK_VerifierLogin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Verifiers] DROP CONSTRAINT [FK_VerifierLogin];
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
IF OBJECT_ID(N'[dbo].[Logins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logins];
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
    [VerifierId] int  NOT NULL,
    [Login_Id] int  NOT NULL
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
    [Password] nvarchar(max)  NOT NULL,
    [Login_Id] int  NOT NULL
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
    [AdminId] int  NOT NULL,
    [Login_Id] int  NOT NULL
);
GO

-- Creating table 'Logins'
CREATE TABLE [dbo].[Logins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [User_Type] nvarchar(max)  NOT NULL
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

-- Creating primary key on [Id] in table 'Logins'
ALTER TABLE [dbo].[Logins]
ADD CONSTRAINT [PK_Logins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UploaderId] in table 'Contents'
ALTER TABLE [dbo].[Contents]
ADD CONSTRAINT [FK_UploaderContent]
    FOREIGN KEY ([UploaderId])
    REFERENCES [dbo].[Uploaders]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UploaderContent'
CREATE INDEX [IX_FK_UploaderContent]
ON [dbo].[Contents]
    ([UploaderId]);
GO

-- Creating foreign key on [AdminId] in table 'Contents'
ALTER TABLE [dbo].[Contents]
ADD CONSTRAINT [FK_AdminContent]
    FOREIGN KEY ([AdminId])
    REFERENCES [dbo].[Admins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdminContent'
CREATE INDEX [IX_FK_AdminContent]
ON [dbo].[Contents]
    ([AdminId]);
GO

-- Creating foreign key on [VerifierId] in table 'Contents'
ALTER TABLE [dbo].[Contents]
ADD CONSTRAINT [FK_VerifierContent]
    FOREIGN KEY ([VerifierId])
    REFERENCES [dbo].[Verifiers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VerifierContent'
CREATE INDEX [IX_FK_VerifierContent]
ON [dbo].[Contents]
    ([VerifierId]);
GO

-- Creating foreign key on [AdminId] in table 'Verifiers'
ALTER TABLE [dbo].[Verifiers]
ADD CONSTRAINT [FK_AdminVerifier]
    FOREIGN KEY ([AdminId])
    REFERENCES [dbo].[Admins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdminVerifier'
CREATE INDEX [IX_FK_AdminVerifier]
ON [dbo].[Verifiers]
    ([AdminId]);
GO

-- Creating foreign key on [AdminId] in table 'Uploaders'
ALTER TABLE [dbo].[Uploaders]
ADD CONSTRAINT [FK_AdminUploader]
    FOREIGN KEY ([AdminId])
    REFERENCES [dbo].[Admins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdminUploader'
CREATE INDEX [IX_FK_AdminUploader]
ON [dbo].[Uploaders]
    ([AdminId]);
GO

-- Creating foreign key on [VerifierId] in table 'Uploaders'
ALTER TABLE [dbo].[Uploaders]
ADD CONSTRAINT [FK_VerifierUploader]
    FOREIGN KEY ([VerifierId])
    REFERENCES [dbo].[Verifiers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VerifierUploader'
CREATE INDEX [IX_FK_VerifierUploader]
ON [dbo].[Uploaders]
    ([VerifierId]);
GO

-- Creating foreign key on [Login_Id] in table 'Admins'
ALTER TABLE [dbo].[Admins]
ADD CONSTRAINT [FK_AdminLogin]
    FOREIGN KEY ([Login_Id])
    REFERENCES [dbo].[Logins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdminLogin'
CREATE INDEX [IX_FK_AdminLogin]
ON [dbo].[Admins]
    ([Login_Id]);
GO

-- Creating foreign key on [Login_Id] in table 'Uploaders'
ALTER TABLE [dbo].[Uploaders]
ADD CONSTRAINT [FK_UploaderLogin]
    FOREIGN KEY ([Login_Id])
    REFERENCES [dbo].[Logins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UploaderLogin'
CREATE INDEX [IX_FK_UploaderLogin]
ON [dbo].[Uploaders]
    ([Login_Id]);
GO

-- Creating foreign key on [Login_Id] in table 'Verifiers'
ALTER TABLE [dbo].[Verifiers]
ADD CONSTRAINT [FK_VerifierLogin]
    FOREIGN KEY ([Login_Id])
    REFERENCES [dbo].[Logins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VerifierLogin'
CREATE INDEX [IX_FK_VerifierLogin]
ON [dbo].[Verifiers]
    ([Login_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------