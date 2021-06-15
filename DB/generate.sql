/* BUILDINGS */
CREATE TABLE [dbo].[Buildings]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Building_Name] NVARCHAR(10) NOT NULL, 
    [Description] NVARCHAR(150) NULL
)

/*COURSES */
CREATE TABLE [dbo].[Courses]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Description] NVARCHAR(150) NULL
)
/* Classrooms */

CREATE TABLE [dbo].[Classrooms]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(10) NOT NULL, 
    [State] INT NOT NULL, 
    [Capacity] INT NULL, 
    [FloorId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Classrooms_ToFloorsBuilding] FOREIGN KEY ([FloorId]) REFERENCES [FloorsBuilding]([Id])
)

/* Gateways */


CREATE TABLE [dbo].[Gateways]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [GatewayId] VARCHAR(10) UNIQUE NOT NULL, 
    [FloorId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Gateways_ToFloorBuildings] FOREIGN KEY ([FloorId]) REFERENCES [FloorsBuilding]([Id])
)

/* Microcontrollers */

CREATE TABLE [dbo].[Microcontrollers] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [DeviceId]    NVARCHAR (10)    NOT NULL,
    [ClassroomId] UNIQUEIDENTIFIER NULL,
    [GatewayId]   UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([DeviceId] ASC),
    CONSTRAINT [FK_Microcontrollers_ToGateway] FOREIGN KEY ([GatewayId]) REFERENCES [dbo].[Gateways] ([Id]),
    CONSTRAINT [FK_Microcontrollers_ToClassroom] FOREIGN KEY ([ClassroomId]) REFERENCES [dbo].[Classrooms] ([Id])
);

/* Subjects */

CREATE TABLE [dbo].[Subjects]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Description] NVARCHAR(150) NULL
)

/* Teachers */

CREATE TABLE [dbo].[Teachers]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(20) NOT NULL, 
    [Surname] NVARCHAR(20) NOT NULL, 
    [Date] DATETIME NOT NULL
)

/* Teaches */

CREATE TABLE [dbo].[Teaches] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [TeacherId] UNIQUEIDENTIFIER NOT NULL,
    [SubjectId] UNIQUEIDENTIFIER NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Teachers_ToTeacher] FOREIGN KEY ([TeacherId]) REFERENCES [dbo].[Teachers] ([Id]), 
    CONSTRAINT [FK_Teaches_ToSubject] FOREIGN KEY ([SubjectId]) REFERENCES [Subjects]([Id])
);


/* Lessons */

CREATE TABLE [dbo].[Lessons]
(
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [StartDate] DATETIME NOT NULL, 
    [Duration] TIME NOT NULL, 
    [ClassroomId] UNIQUEIDENTIFIER NOT NULL, 
    [TeacherId] UNIQUEIDENTIFIER NOT NULL, 
    [SubjectId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Lessons_ToTeacher] FOREIGN KEY ([TeacherId]) REFERENCES [Teachers]([Id]),
    CONSTRAINT [FK_Lessons_ToSubject] FOREIGN KEY ([SubjectId]) REFERENCES [Subjects]([Id]),
    CONSTRAINT [FK_Lessons_ToClassroom] FOREIGN KEY ([ClassroomId]) REFERENCES [Classrooms]([Id]),
)
