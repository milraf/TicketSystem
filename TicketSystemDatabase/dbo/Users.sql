CREATE TABLE [dbo].[Users] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [EmailAddress] NVARCHAR (MAX) NOT NULL,
    [IsAdmin]      BIT            NOT NULL,
    [PasswordHash] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

