USE [master]
GO

USE [AccountingLedgerSystemDb]
GO
/****** Object:  UserDefinedTableType [dbo].[JournalEntryLineType]    Script Date: 6/23/2025 10:10:02 PM ******/
CREATE TYPE [dbo].[JournalEntryLineType] AS TABLE(
	[AccountId] [int] NULL,
	[Debit] [decimal](18, 2) NULL,
	[Credit] [decimal](18, 2) NULL
)
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/23/2025 10:10:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 6/23/2025 10:10:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Type] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JournalEntries]    Script Date: 6/23/2025 10:10:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalEntries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_JournalEntries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[JournalEntryLines]    Script Date: 6/23/2025 10:10:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[JournalEntryLines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[JournalEntryId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Debit] [decimal](18, 2) NOT NULL,
	[Credit] [decimal](18, 2) NOT NULL,
	[AccountName] [nvarchar](max) NULL,
 CONSTRAINT [PK_JournalEntryLines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_JournalEntryLines_JournalEntryId]    Script Date: 6/23/2025 10:10:02 PM ******/
CREATE NONCLUSTERED INDEX [IX_JournalEntryLines_JournalEntryId] ON [dbo].[JournalEntryLines]
(
	[JournalEntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[JournalEntryLines]  WITH CHECK ADD  CONSTRAINT [FK_JournalEntryLines_JournalEntries_JournalEntryId] FOREIGN KEY([JournalEntryId])
REFERENCES [dbo].[JournalEntries] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[JournalEntryLines] CHECK CONSTRAINT [FK_JournalEntryLines_JournalEntries_JournalEntryId]
GO
/****** Object:  StoredProcedure [dbo].[SP_CreateAccount]    Script Date: 6/23/2025 10:10:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Amran Bhuiyan>
-- Create date: <15 june 2025,,>
-- Description:	<saveAccount,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_CreateAccount]
    @Name NVARCHAR(100),
    @Type NVARCHAR(50),
    @NewId INT OUTPUT
AS
BEGIN
    INSERT INTO Accounts (Name, Type)
    VALUES (@Name, @Type);

    SET @NewId = SCOPE_IDENTITY(); 
END

GO
/****** Object:  StoredProcedure [dbo].[SP_CreateJournalEntry]    Script Date: 6/23/2025 10:10:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CreateJournalEntry]
    @Date DATE,
    @Description NVARCHAR(255),
    @Lines JournalEntryLineType READONLY, 
    @NewId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

   
        INSERT INTO JournalEntries ([Date], [Description])
        VALUES (@Date, @Description);

       
        SET @NewId = SCOPE_IDENTITY();

   
        INSERT INTO JournalEntryLines (JournalEntryId, AccountId, Debit, Credit)
        SELECT @NewId, AccountId, Debit, Credit
        FROM @Lines;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllAccounts]    Script Date: 6/23/2025 10:10:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Amran Bhuiyan>
-- Create date: <16 June 2025,>
-- Description:	<GetAllAccounts,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllAccounts]
AS
BEGIN
    SELECT Id, Name, Type
    FROM Accounts
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetAllJournalEntries]    Script Date: 6/23/2025 10:10:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Amran Bhuiyan>
-- Create date: <18 June 2025,>
-- Description:	<Get All Journal Entries,,>

-- SP_GetAllJournalEntries
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetAllJournalEntries]
AS
BEGIN
    SELECT 
        je.Id AS JournalEntryId,
        je.Date,
        je.Description,
        jel.Id AS LineId,
        jel.AccountId,
		ac.Name as AccountName,
        jel.Debit,
        jel.Credit
    FROM JournalEntries je
    INNER JOIN JournalEntryLines jel ON je.Id = jel.JournalEntryId
	left JOIN Accounts ac ON ac.Id = jel.AccountId
    ORDER BY je.Id
END

GO
/****** Object:  StoredProcedure [dbo].[SP_GetTrialBalance]    Script Date: 6/23/2025 10:10:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Amran Bhuiyan>
-- Create date: <18 june 2025>
-- Description:	<GetTrialBalance>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetTrialBalance]
AS
BEGIN
    SELECT 
        a.Id,
        a.Name,
        a.Type,
        ISNULL(SUM(CASE WHEN jel.Debit IS NOT NULL THEN jel.Debit ELSE 0 END), 0) AS TotalDebit,
        ISNULL(SUM(CASE WHEN jel.Credit IS NOT NULL THEN jel.Credit ELSE 0 END), 0) AS TotalCredit,
        ISNULL(SUM(CASE WHEN jel.Debit IS NOT NULL THEN jel.Debit ELSE 0 END), 0) - 
        ISNULL(SUM(CASE WHEN jel.Credit IS NOT NULL THEN jel.Credit ELSE 0 END), 0) AS NetBalance
    FROM 
        Accounts a
    LEFT JOIN 
        JournalEntryLines jel ON a.Id = jel.AccountId
    GROUP BY 
        a.Id, a.Name, a.Type
END

GO
USE [master]
GO
ALTER DATABASE [AccountingLedgerSystemDb] SET  READ_WRITE 
GO
