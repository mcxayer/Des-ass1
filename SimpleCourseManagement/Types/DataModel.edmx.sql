
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/30/2015 21:38:35
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
IF OBJECT_ID(N'[dbo].[FK_CourseStudent_Course]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseStudent] DROP CONSTRAINT [FK_CourseStudent_Course];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseStudent_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseStudent] DROP CONSTRAINT [FK_CourseStudent_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseTeacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseSet] DROP CONSTRAINT [FK_CourseTeacher];
GO
IF OBJECT_ID(N'[dbo].[FK_ExamExamAttempt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExamAttemptSet] DROP CONSTRAINT [FK_ExamExamAttempt];
GO
IF OBJECT_ID(N'[dbo].[FK_ExamAttemptStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExamAttemptSet] DROP CONSTRAINT [FK_ExamAttemptStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_ExamStudent_Exam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExamStudent] DROP CONSTRAINT [FK_ExamStudent_Exam];
GO
IF OBJECT_ID(N'[dbo].[FK_ExamStudent_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExamStudent] DROP CONSTRAINT [FK_ExamStudent_Student];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseTypeCourse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CourseSet] DROP CONSTRAINT [FK_CourseTypeCourse];
GO
IF OBJECT_ID(N'[dbo].[FK_Student_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet_Student] DROP CONSTRAINT [FK_Student_inherits_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Teacher_inherits_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet_Teacher] DROP CONSTRAINT [FK_Teacher_inherits_User];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CourseSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseSet];
GO
IF OBJECT_ID(N'[dbo].[ExamSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExamSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[ExamAttemptSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExamAttemptSet];
GO
IF OBJECT_ID(N'[dbo].[CourseTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseTypeSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet_Student]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet_Student];
GO
IF OBJECT_ID(N'[dbo].[UserSet_Teacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet_Teacher];
GO
IF OBJECT_ID(N'[dbo].[CourseStudent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CourseStudent];
GO
IF OBJECT_ID(N'[dbo].[ExamStudent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExamStudent];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CourseSet'
CREATE TABLE [dbo].[CourseSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InstanceName] nvarchar(max)  NOT NULL,
    [Ects] nvarchar(max)  NOT NULL,
    [Schedule] datetime  NOT NULL,
    [CourseTypeId] int  NOT NULL,
    [Teacher_Id] int  NULL
);
GO

-- Creating table 'ExamSet'
CREATE TABLE [dbo].[ExamSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] int  NOT NULL,
    [CourseId] int  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [FamilyName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ExamAttemptSet'
CREATE TABLE [dbo].[ExamAttemptSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Grade] float  NOT NULL,
    [ExamId] int  NOT NULL,
    [Student_Id] int  NOT NULL
);
GO

-- Creating table 'CourseTypeSet'
CREATE TABLE [dbo].[CourseTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet_Student'
CREATE TABLE [dbo].[UserSet_Student] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'UserSet_Teacher'
CREATE TABLE [dbo].[UserSet_Teacher] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'CourseStudent'
CREATE TABLE [dbo].[CourseStudent] (
    [Courses_Id] int  NOT NULL,
    [Students_Id] int  NOT NULL
);
GO

-- Creating table 'ExamStudent'
CREATE TABLE [dbo].[ExamStudent] (
    [Exams_Id] int  NOT NULL,
    [Students_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

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

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ExamAttemptSet'
ALTER TABLE [dbo].[ExamAttemptSet]
ADD CONSTRAINT [PK_ExamAttemptSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CourseTypeSet'
ALTER TABLE [dbo].[CourseTypeSet]
ADD CONSTRAINT [PK_CourseTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet_Student'
ALTER TABLE [dbo].[UserSet_Student]
ADD CONSTRAINT [PK_UserSet_Student]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet_Teacher'
ALTER TABLE [dbo].[UserSet_Teacher]
ADD CONSTRAINT [PK_UserSet_Teacher]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Courses_Id], [Students_Id] in table 'CourseStudent'
ALTER TABLE [dbo].[CourseStudent]
ADD CONSTRAINT [PK_CourseStudent]
    PRIMARY KEY CLUSTERED ([Courses_Id], [Students_Id] ASC);
GO

-- Creating primary key on [Exams_Id], [Students_Id] in table 'ExamStudent'
ALTER TABLE [dbo].[ExamStudent]
ADD CONSTRAINT [PK_ExamStudent]
    PRIMARY KEY CLUSTERED ([Exams_Id], [Students_Id] ASC);
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
    REFERENCES [dbo].[UserSet_Student]
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
    REFERENCES [dbo].[UserSet_Teacher]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseTeacher'
CREATE INDEX [IX_FK_CourseTeacher]
ON [dbo].[CourseSet]
    ([Teacher_Id]);
GO

-- Creating foreign key on [ExamId] in table 'ExamAttemptSet'
ALTER TABLE [dbo].[ExamAttemptSet]
ADD CONSTRAINT [FK_ExamExamAttempt]
    FOREIGN KEY ([ExamId])
    REFERENCES [dbo].[ExamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExamExamAttempt'
CREATE INDEX [IX_FK_ExamExamAttempt]
ON [dbo].[ExamAttemptSet]
    ([ExamId]);
GO

-- Creating foreign key on [Student_Id] in table 'ExamAttemptSet'
ALTER TABLE [dbo].[ExamAttemptSet]
ADD CONSTRAINT [FK_ExamAttemptStudent]
    FOREIGN KEY ([Student_Id])
    REFERENCES [dbo].[UserSet_Student]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExamAttemptStudent'
CREATE INDEX [IX_FK_ExamAttemptStudent]
ON [dbo].[ExamAttemptSet]
    ([Student_Id]);
GO

-- Creating foreign key on [Exams_Id] in table 'ExamStudent'
ALTER TABLE [dbo].[ExamStudent]
ADD CONSTRAINT [FK_ExamStudent_Exam]
    FOREIGN KEY ([Exams_Id])
    REFERENCES [dbo].[ExamSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Students_Id] in table 'ExamStudent'
ALTER TABLE [dbo].[ExamStudent]
ADD CONSTRAINT [FK_ExamStudent_Student]
    FOREIGN KEY ([Students_Id])
    REFERENCES [dbo].[UserSet_Student]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExamStudent_Student'
CREATE INDEX [IX_FK_ExamStudent_Student]
ON [dbo].[ExamStudent]
    ([Students_Id]);
GO

-- Creating foreign key on [CourseTypeId] in table 'CourseSet'
ALTER TABLE [dbo].[CourseSet]
ADD CONSTRAINT [FK_CourseTypeCourse]
    FOREIGN KEY ([CourseTypeId])
    REFERENCES [dbo].[CourseTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseTypeCourse'
CREATE INDEX [IX_FK_CourseTypeCourse]
ON [dbo].[CourseSet]
    ([CourseTypeId]);
GO

-- Creating foreign key on [Id] in table 'UserSet_Student'
ALTER TABLE [dbo].[UserSet_Student]
ADD CONSTRAINT [FK_Student_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'UserSet_Teacher'
ALTER TABLE [dbo].[UserSet_Teacher]
ADD CONSTRAINT [FK_Teacher_inherits_User]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------