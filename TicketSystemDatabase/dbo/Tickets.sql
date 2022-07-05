CREATE TABLE [dbo].[Tickets] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [RequestorId] INT            NOT NULL,
    [DateTime]    NVARCHAR (50)  NOT NULL,
    [Title]       NVARCHAR (50)  NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Status]      INT            NOT NULL,
    [SolvedById]  INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

