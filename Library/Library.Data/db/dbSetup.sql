CREATE TABLE [dbo].[Users] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [DateOfBirth] DATE         NOT NULL,
    [Name]        VARCHAR (50) NOT NULL,
    [Surname]     VARCHAR (50) NOT NULL,
    [Email]       VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Authors] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Name]    VARCHAR (50) NOT NULL,
    [Surname] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Nations] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Languages] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Genres] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] VARBINARY (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Books] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [Title]      VARCHAR (50) NOT NULL,
    [AuthorId]   INT          NOT NULL,
    [Year]       INT          NOT NULL,
    [NationId]   INT          NOT NULL,
    [LanguageId] INT          NOT NULL,
    [Price]      DECIMAL (2)  NOT NULL,
    [Pages]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [AuthorIdForeignKey] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id]),
    CONSTRAINT [NationIdForeignKey] FOREIGN KEY ([NationId]) REFERENCES [dbo].[Nations] ([Id]),
    CONSTRAINT [LanguageIdForeignKey] FOREIGN KEY ([LanguageId]) REFERENCES [dbo].[Languages] ([Id])
);

CREATE TABLE [dbo].[Loans] (
    [Id]         INT  IDENTITY (1, 1) NOT NULL,
    [UserId]     INT  NOT NULL,
    [BookId]     INT  NOT NULL,
    [DateOfLoan] DATE NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [LoansUserIdForeignKey] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]),
    CONSTRAINT [LoansBookIdForeignKey] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id])
);

CREATE TABLE [dbo].[Bookings] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    [BookId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [BookingBookIdForeignKey] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]),
    CONSTRAINT [BookingUserIdForeignKey] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);


