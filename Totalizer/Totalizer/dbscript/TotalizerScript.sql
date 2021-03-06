USE [master]
GO
/****** Object:  Database [Totalizer]    Script Date: 29.07.2019 16:21:14 ******/
CREATE DATABASE [Totalizer]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Totalizer', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Totalizer.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Totalizer_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\Totalizer_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Totalizer] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Totalizer].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Totalizer] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Totalizer] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Totalizer] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Totalizer] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Totalizer] SET ARITHABORT OFF 
GO
ALTER DATABASE [Totalizer] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Totalizer] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Totalizer] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Totalizer] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Totalizer] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Totalizer] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Totalizer] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Totalizer] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Totalizer] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Totalizer] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Totalizer] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Totalizer] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Totalizer] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Totalizer] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Totalizer] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Totalizer] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Totalizer] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Totalizer] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Totalizer] SET  MULTI_USER 
GO
ALTER DATABASE [Totalizer] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Totalizer] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Totalizer] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Totalizer] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Totalizer] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Totalizer] SET QUERY_STORE = OFF
GO
USE [Totalizer]
GO
/****** Object:  User [NT AUTHORITY\СИСТЕМА]    Script Date: 29.07.2019 16:21:14 ******/
CREATE USER [NT AUTHORITY\СИСТЕМА] FOR LOGIN [NT AUTHORITY\СИСТЕМА] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [NT AUTHORITY\СИСТЕМА]
GO
/****** Object:  Table [dbo].[Bets]    Script Date: 29.07.2019 16:21:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Person] [int] NOT NULL,
	[Event] [int] NOT NULL,
	[Coefficient] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[Amount] [decimal](10, 8) NOT NULL,
	[Team] [int] NOT NULL,
 CONSTRAINT [PK_Bets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 29.07.2019 16:21:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_Countrys] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Events]    Script Date: 29.07.2019 16:21:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Events](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
	[Team1] [int] NOT NULL,
	[Team2] [int] NOT NULL,
	[SportType] [int] NOT NULL,
	[Status] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 29.07.2019 16:21:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
 CONSTRAINT [PK_Persons_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SportTypes]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SportTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_SportTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Country] [int] NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [varchar](50) NOT NULL,
	[PersonId] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bets]  WITH CHECK ADD  CONSTRAINT [FK_Bets_Events] FOREIGN KEY([Event])
REFERENCES [dbo].[Events] ([ID])
GO
ALTER TABLE [dbo].[Bets] CHECK CONSTRAINT [FK_Bets_Events]
GO
ALTER TABLE [dbo].[Bets]  WITH CHECK ADD  CONSTRAINT [FK_Bets_Persons] FOREIGN KEY([Person])
REFERENCES [dbo].[Persons] ([ID])
GO
ALTER TABLE [dbo].[Bets] CHECK CONSTRAINT [FK_Bets_Persons]
GO
ALTER TABLE [dbo].[Bets]  WITH CHECK ADD  CONSTRAINT [FK_Bets_Teams] FOREIGN KEY([Team])
REFERENCES [dbo].[Teams] ([ID])
GO
ALTER TABLE [dbo].[Bets] CHECK CONSTRAINT [FK_Bets_Teams]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_SportTypes] FOREIGN KEY([SportType])
REFERENCES [dbo].[SportTypes] ([ID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_SportTypes]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Teams] FOREIGN KEY([Team1])
REFERENCES [dbo].[Teams] ([ID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Teams]
GO
ALTER TABLE [dbo].[Events]  WITH CHECK ADD  CONSTRAINT [FK_Events_Teams1] FOREIGN KEY([Team2])
REFERENCES [dbo].[Teams] ([ID])
GO
ALTER TABLE [dbo].[Events] CHECK CONSTRAINT [FK_Events_Teams1]
GO
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Countrys] FOREIGN KEY([Country])
REFERENCES [dbo].[Countries] ([ID])
GO
ALTER TABLE [dbo].[Teams] CHECK CONSTRAINT [FK_Teams_Countrys]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Persons] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Persons] ([ID])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Persons]
GO
/****** Object:  StoredProcedure [dbo].[AddBet]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddBet]
    @Person int,
	@Event int,
	@Coefficient int,
	@Date date,
	@Amount decimal(10,8),
	@Team int
AS
BEGIN
    SET NOCOUNT ON;
		INSERT INTO dbo.Bets
    values (@Person, @Event, @Coefficient,@Date,@Amount,@Team)
END
GO
/****** Object:  StoredProcedure [dbo].[AddCountry]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCountry]
    @Name varchar(50)
AS
BEGIN
    SET NOCOUNT ON;
		INSERT INTO dbo.Countries
    values (@Name)
END
GO
/****** Object:  StoredProcedure [dbo].[AddEvent]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddEvent]
    @Date date,
	@Team1 int,
	@Team2 int,
	@SportType int,
	@Status varchar(50)
AS
BEGIN
    SET NOCOUNT ON;
		INSERT INTO dbo.Events
    values (@Date,@Team1,@Team2,@SportType,@Status)
END
GO
/****** Object:  StoredProcedure [dbo].[AddPerson]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddPerson]
    @Name varchar(50),
	@MiddleName varchar(50),
	@LastName varchar(50),
	@Phone varchar(50)
AS
BEGIN
    SET NOCOUNT ON;
		INSERT INTO dbo.Persons
    values (@Name,@MiddleName,@LastName,@Phone)
END
GO
/****** Object:  StoredProcedure [dbo].[AddRole]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddRole]
    @Name varchar(50)
AS
BEGIN
    SET NOCOUNT ON;
		INSERT INTO dbo.Roles
    values (@Name)
END
GO
/****** Object:  StoredProcedure [dbo].[AddSportType]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[AddSportType]
    @Name varchar(50)
AS
BEGIN
    SET NOCOUNT ON;
		INSERT INTO dbo.SportTypes
    values (@Name)
END
GO
/****** Object:  StoredProcedure [dbo].[AddTeam]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[AddTeam]
    @Name varchar(50),
	@Country int
AS
BEGIN
    SET NOCOUNT ON;
		INSERT INTO dbo.Teams
    values (@Name, @Country)
END
GO
/****** Object:  StoredProcedure [dbo].[AddUndefinedPerson]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUndefinedPerson]
AS
BEGIN
    SET NOCOUNT ON;
		INSERT INTO dbo.Persons
    values ('Undefined','Undefined','Undefined','Undefined')
	SELECT SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]
    @Login varchar(50),
	@PersonId int
AS
BEGIN
    SET NOCOUNT ON;
		INSERT INTO dbo.Users
    values (@Login, @PersonId)
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteBet]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[DeleteBet]
    @ID int
AS
BEGIN
DELETE FROM Bets WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCountry]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteCountry]
    @ID int
AS
BEGIN
DELETE FROM dbo.Countries WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteEvent]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[DeleteEvent]
    @ID int
AS
BEGIN
DELETE FROM Events WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeletePerson]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[DeletePerson]
    @ID int
AS
BEGIN
DELETE FROM Persons WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteRole]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteRole]
    @ID int
AS
BEGIN
DELETE FROM Roles WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSportType]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[DeleteSportType]
    @ID int
AS
BEGIN
DELETE FROM SportTypes WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeam]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[DeleteTeam]
    @ID int
AS
BEGIN
DELETE FROM Teams WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]
    @ID int
AS
BEGIN
DELETE FROM Users WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[FullBetSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FullBetSelect]

AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM
  dbo.Bets
  INNER JOIN
  dbo.Persons
    ON Bets.Person = Persons.ID
	  INNER JOIN
  dbo.Events
    ON Bets.Event = Events.ID
		INNER JOIN
  dbo.Teams Team1
    ON Events.Team1 = Team1.ID
	  INNER JOIN
  dbo.Teams Team2
    ON Events.Team2 = Team2.ID
		  INNER JOIN
  dbo.SportTypes Sport
    ON Events.SportType = Sport.ID
	INNER JOIN
	dbo.Teams
	ON Bets.Team = Teams.ID
END
GO
/****** Object:  StoredProcedure [dbo].[FullCountrySelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FullCountrySelect]

AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM dbo.Countries 
END
GO
/****** Object:  StoredProcedure [dbo].[FullEventSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FullEventSelect]

AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM
  dbo.Events
  INNER JOIN
  dbo.Teams Team1
    ON Events.Team1 = Team1.ID
	  INNER JOIN
  dbo.Teams Team2
    ON Events.Team2 = Team2.ID
		  INNER JOIN
  dbo.SportTypes
    ON Events.SportType = SportTypes.ID
END
GO
/****** Object:  StoredProcedure [dbo].[FullPersonSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[FullPersonSelect]

AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM Persons
END
GO
/****** Object:  StoredProcedure [dbo].[FullRolesSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FullRolesSelect]

AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM Roles
END
GO
/****** Object:  StoredProcedure [dbo].[FullSportTypesSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[FullSportTypesSelect]

AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM SportTypes
END
GO
/****** Object:  StoredProcedure [dbo].[FullTeamsSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FullTeamsSelect]

AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM
  dbo.Teams
  INNER JOIN
  dbo.Countries
    ON Teams.Country = Countries.ID
END
GO
/****** Object:  StoredProcedure [dbo].[FullUserSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FullUserSelect]

AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM dbo.Users 
END
GO
/****** Object:  StoredProcedure [dbo].[GetMatchingBet]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMatchingBet]
    @ID int
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM
  dbo.Bets
  INNER JOIN
  dbo.Persons
    ON Bets.Person = Persons.ID
	  INNER JOIN
  dbo.Events
    ON Bets.Event = Events.ID
		INNER JOIN
  dbo.Teams Team1
    ON Events.Team1 = Team1.ID
	  INNER JOIN
  dbo.Teams Team2
    ON Events.Team2 = Team2.ID
		  INNER JOIN
  dbo.SportTypes Sport
    ON Events.SportType = Sport.ID
	INNER JOIN
	dbo.Teams
	ON Bets.Team = Teams.ID
WHERE Person = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[GetMatchingUser]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMatchingUser]
    @Login varchar(50)
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM dbo.Users WHERE Login = @Login
END
GO
/****** Object:  StoredProcedure [dbo].[IDBetSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IDBetSelect]
    @ID int
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM
  dbo.Bets
  INNER JOIN
  dbo.Persons
    ON Bets.Person = Persons.ID
	  INNER JOIN
  dbo.Events
    ON Bets.Event = Events.ID
		INNER JOIN
  dbo.Teams Team1
    ON Events.Team1 = Team1.ID
	  INNER JOIN
  dbo.Teams Team2
    ON Events.Team2 = Team2.ID
		  INNER JOIN
  dbo.SportTypes Sport
    ON Events.SportType = Sport.ID
	INNER JOIN
	dbo.Teams
	ON Bets.Team = Teams.ID
WHERE Bets.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[IDCountrySelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IDCountrySelect]
    @ID int
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM dbo.Countries WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[IDEventSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IDEventSelect]
    @ID int
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM
  dbo.Events
  INNER JOIN
  dbo.Teams Team1
    ON Events.Team1 = Team1.ID
	  INNER JOIN
  dbo.Teams Team2
    ON Events.Team2 = Team2.ID
		  INNER JOIN
  dbo.SportTypes
    ON Events.SportType = SportTypes.ID
WHERE Events.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[IDPersonSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[IDPersonSelect]
    @ID int
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM Persons WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[IDRoleSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IDRoleSelect]
    @ID int
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM Roles WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[IDSportTypeSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[IDSportTypeSelect]
    @ID int
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM SportTypes WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[IDTeamsSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IDTeamsSelect]
    @ID int
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM
  dbo.Teams
  INNER JOIN
  dbo.Countries
    ON Teams.Country = Countries.ID
WHERE Teams.ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[IDUserSelect]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IDUserSelect]
    @ID int
AS
BEGIN
    SET NOCOUNT ON;
SELECT * FROM dbo.Users WHERE ID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateBets]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateBets]
    @ID int,
    @Person int,
	@Event int,
	@Coefficient int,
	@Date date,
	@Amount decimal(10,8),
	@Team int
AS
BEGIN
UPDATE Bets
Set
Person = @Person,
Event = @Event,
Coefficient = @Coefficient,
Date = @Date,
Amount = @Amount,
Team = @Team
WHERE ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCountries]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCountries]
    @ID int,
    @Name varchar(50)
AS
BEGIN
UPDATE dbo.Countries
Set
NAME = @Name
WHERE ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateEvents]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateEvents]
    @ID int,
    @Date date,
	@Team1 int,
	@Team2 int,
	@SportType int,
	@Status varchar(50)
AS
BEGIN
UPDATE Events
Set
Date = @Date,
Team1 = @Team1,
Team2 = @Team2,
SportType = @SportType,
Status = @Status
WHERE ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdatePersons]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdatePersons]
    @ID int,
    @Name varchar(50),
	@MiddleName varchar(50),
	@LastName varchar(50),
	@Phone varchar(50)
AS
BEGIN
UPDATE Persons
Set
NAME = @Name,
MiddleName = @MiddleName,
LastName = @LastName,
Phone = @Phone
WHERE ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateRoles]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateRoles]
    @ID int,
    @Name varchar(50)
AS
BEGIN
UPDATE Roles
Set
Name = @Name
WHERE ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSportTypes]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[UpdateSportTypes]
    @ID int,
    @Name varchar(50)
AS
BEGIN
UPDATE SportTypes
Set
NAME = @Name
WHERE ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeam]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTeam]
    @ID int,
    @Name varchar(50),
	@Country int
AS
BEGIN
UPDATE Teams
Set
NAME = @Name,
Country = @Country
WHERE ID = @ID;
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUsers]    Script Date: 29.07.2019 16:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUsers]
    @ID int,
    @Login varchar(50),
	@PersonId int
AS
BEGIN
UPDATE dbo.Users
Set
Login = @Login,
PersonId = @PersonId
WHERE ID = @ID;
END
GO
USE [master]
GO
ALTER DATABASE [Totalizer] SET  READ_WRITE 
GO
