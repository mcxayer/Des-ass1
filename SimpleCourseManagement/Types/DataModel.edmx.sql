
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/29/2015 20:29:59
-- Generated from EDMX file: C:\Skole\Software Engineering\3. Semester\DES\Afleveringsopgave 1\Des-ass1\SimpleCourseManagement\Types\DataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CourseExam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExamSet] DROP CONSTRAINT [FK_CourseExam];
GO
IF OBJECT_ID(N'[dbo].[FK_ExamStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExamSet] DROP CONSTRAINT [FK_ExamStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseStudent_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseStudent] DROP CONSTRAINT [FK_CourseStudent_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseStudent_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseStudent] DROP CONSTRAINT [FK_CourseStudent_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseTeacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseSet] DROP CONSTRAINT [FK_CourseTeacher];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TeacherSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeacherSet];
GO
IF OBJECT_ID(N'[dbo].[StudentSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudentSet];
GO
IF OBJECT_ID(N'[dbo].[CourseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseSet];
GO
IF OBJECT_ID(N'[dbo].[ExamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExamSet];
GO
IF OBJECT_ID(N'[dbo].[CourseStudent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseStudent];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TeacherSet'
CREATE TABLE [dbo].[TeacherSet] (
    [Id] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [FamilyName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'StudentSet'
CREATE TABLE [dbo].[StudentSet] (
    [Id] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [FamilyName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CourseSet'
CREATE TABLE [dbo].[CourseSet] (
    [Id] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [InstanceName] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Ects] nvarchar(max)  NOT NULL,
    [Schedule] datetime  NOT NULL,
    [Teacher_Id] int  NULL
);
GO

-- Creating table 'ExamSet'
CREATE TABLE [dbo].[ExamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] int  NOT NULL,
    [CourseId] int  NOT NULL,
    [Grade] float  NOT NULL,
    [Student_Id] int  NOT NULL
);
GO

-- Creating table 'CourseStudent'
CREATE TABLE [dbo].[CourseStudent] (
    [Courses_Id] int  NOT NULL,
    [Students_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TeacherSet'
ALTER TABLE [dbo].[TeacherSet]
ADD CONSTRAINT [PK_TeacherSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StudentSet'
ALTER TABLE [dbo].[StudentSet]
ADD CONSTRAINT [PK_StudentSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourseSet'
ALTER TABLE [dbo].[CourseSet]
ADD CONSTRAINT [PK_CourseSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExamSet'
ALTER TABLE [dbo].[ExamSet]
ADD CONSTRAINT [PK_ExamSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Courses_Id], [Students_Id] in table 'CourseStudent'
ALTER TABLE [dbo].[CourseStudent]
ADD CONSTRAINT [PK_CourseStudent]
    PRIMARY KEY CLUSTERED ([Courses_Id], [Students_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CourseId] in table 'ExamSet'
ALTER TABLE [dbo].[ExamSet]
ADD CONSTRAINT [FK_CourseExam]
    FOREIGN KEY ([CourseId])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseExam'
CREATE INDEX [IX_FK_CourseExam]
ON [dbo].[ExamSet]
    ([CourseId]);
GO

-- Creating foreign key on [Student_Id] in table 'ExamSet'
ALTER TABLE [dbo].[ExamSet]
ADD CONSTRAINT [FK_ExamStudent]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[StudentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExamStudent'
CREATE INDEX [IX_FK_ExamStudent]
ON [dbo].[ExamSet]
    ([Student_Id]);
GO

-- Creating foreign key on [Courses_Id] in table 'CourseStudent'
ALTER TABLE [dbo].[CourseStudent]
ADD CONSTRAINT [FK_CourseStudent_Course]
    FOREIGN KEY ([Courses_Id])
    REFERENCES [dbo].[CourseSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Students_Id] in table 'CourseStudent'
ALTER TABLE [dbo].[CourseStudent]
ADD CONSTRAINT [FK_CourseStudent_Student]
    FOREIGN KEY ([Students_Id])
    REFERENCES [dbo].[StudentSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseStudent_Student'
CREATE INDEX [IX_FK_CourseStudent_Student]
ON [dbo].[CourseStudent]
    ([Students_Id]);
GO

-- Creating foreign key on [Teacher_Id] in table 'CourseSet'
ALTER TABLE [dbo].[CourseSet]
ADD CONSTRAINT [FK_CourseTeacher]
    FOREIGN KEY ([Teacher_Id])
    REFERENCES [dbo].[TeacherSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseTeacher'
CREATE INDEX [IX_FK_CourseTeacher]
ON [dbo].[CourseSet]
    ([Teacher_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------