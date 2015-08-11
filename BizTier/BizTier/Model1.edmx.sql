
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/10/2015 17:48:47
-- Generated from EDMX file: C:\Users\m\Desktop\New Folder\BudgetUP\BizTier\BizTier\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbo];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TravelAccommodation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Accommodations] DROP CONSTRAINT [FK_TravelAccommodation];
GO
IF OBJECT_ID(N'[dbo].[FK_ActivityExpense]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expenses] DROP CONSTRAINT [FK_ActivityExpense];
GO
IF OBJECT_ID(N'[dbo].[FK_ObjectiveActivity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activities] DROP CONSTRAINT [FK_ObjectiveActivity];
GO
IF OBJECT_ID(N'[dbo].[FK_TravelAirlineExpense]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AirlineExpenses] DROP CONSTRAINT [FK_TravelAirlineExpense];
GO
IF OBJECT_ID(N'[dbo].[FK_TravelAllowance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Allowances] DROP CONSTRAINT [FK_TravelAllowance];
GO
IF OBJECT_ID(N'[dbo].[FK_BursaryNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bursaries] DROP CONSTRAINT [FK_BursaryNote];
GO
IF OBJECT_ID(N'[dbo].[FK_BursaryTypeBursary]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bursaries] DROP CONSTRAINT [FK_BursaryTypeBursary];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectBursary]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Bursaries] DROP CONSTRAINT [FK_ProjectBursary];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpenseContractor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contractors] DROP CONSTRAINT [FK_ExpenseContractor];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpenseEquipment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Equipments] DROP CONSTRAINT [FK_ExpenseEquipment];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpenseNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expenses] DROP CONSTRAINT [FK_ExpenseNote];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpenseOperational]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operationals] DROP CONSTRAINT [FK_ExpenseOperational];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpenseTravel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Travels] DROP CONSTRAINT [FK_ExpenseTravel];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpenseUPStaffMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UPStaffMembers] DROP CONSTRAINT [FK_ExpenseUPStaffMember];
GO
IF OBJECT_ID(N'[dbo].[FK_FacultyUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_FacultyUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TravelGautrain]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gautrains] DROP CONSTRAINT [FK_TravelGautrain];
GO
IF OBJECT_ID(N'[dbo].[FK_IncomeNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incomes] DROP CONSTRAINT [FK_IncomeNote];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectIncome]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Incomes] DROP CONSTRAINT [FK_ProjectIncome];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectObjective]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Objectives] DROP CONSTRAINT [FK_ProjectObjective];
GO
IF OBJECT_ID(N'[dbo].[FK_Operation_TypeOperational]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Operationals] DROP CONSTRAINT [FK_Operation_TypeOperational];
GO
IF OBJECT_ID(N'[dbo].[FK_PostLevelUPStaffMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UPStaffMembers] DROP CONSTRAINT [FK_PostLevelUPStaffMember];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProject_Settings]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_ProjectProject_Settings];
GO
IF OBJECT_ID(N'[dbo].[FK_UserProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_UserProject];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_RoleUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TitleUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_TitleUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TravelVisa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Visas] DROP CONSTRAINT [FK_TravelVisa];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCredentialsUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserCredentials] DROP CONSTRAINT [FK_UserCredentialsUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ExpensCar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Cars] DROP CONSTRAINT [FK_ExpensCar];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accommodations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accommodations];
GO
IF OBJECT_ID(N'[dbo].[Activities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activities];
GO
IF OBJECT_ID(N'[dbo].[Admin_SysSettings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Admin_SysSettings];
GO
IF OBJECT_ID(N'[dbo].[AirlineExpenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AirlineExpenses];
GO
IF OBJECT_ID(N'[dbo].[Allowances]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Allowances];
GO
IF OBJECT_ID(N'[dbo].[Bursaries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Bursaries];
GO
IF OBJECT_ID(N'[dbo].[BursaryTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BursaryTypes];
GO
IF OBJECT_ID(N'[dbo].[Contractors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contractors];
GO
IF OBJECT_ID(N'[dbo].[EmailDomains]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailDomains];
GO
IF OBJECT_ID(N'[dbo].[Equipments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Equipments];
GO
IF OBJECT_ID(N'[dbo].[Expenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expenses];
GO
IF OBJECT_ID(N'[dbo].[Faculties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Faculties];
GO
IF OBJECT_ID(N'[dbo].[Gautrains]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gautrains];
GO
IF OBJECT_ID(N'[dbo].[Incomes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Incomes];
GO
IF OBJECT_ID(N'[dbo].[Notes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Notes];
GO
IF OBJECT_ID(N'[dbo].[Objectives]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Objectives];
GO
IF OBJECT_ID(N'[dbo].[Operation_Type]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operation_Type];
GO
IF OBJECT_ID(N'[dbo].[Operationals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Operationals];
GO
IF OBJECT_ID(N'[dbo].[PostLevels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PostLevels];
GO
IF OBJECT_ID(N'[dbo].[Project_Settings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project_Settings];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Titles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Titles];
GO
IF OBJECT_ID(N'[dbo].[Travels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Travels];
GO
IF OBJECT_ID(N'[dbo].[UPStaffMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UPStaffMembers];
GO
IF OBJECT_ID(N'[dbo].[UserCredentials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserCredentials];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Visas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Visas];
GO
IF OBJECT_ID(N'[dbo].[Cars]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cars];
GO
IF OBJECT_ID(N'[dbo].[Verifications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Verifications];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accommodations'
CREATE TABLE [dbo].[Accommodations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] float  NOT NULL,
    [Travel_Id] int  NOT NULL
);
GO

-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ObjectiveId] int  NOT NULL,
    [ActivityName] nvarchar(150)  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NOT NULL
);
GO

-- Creating table 'Admin_SysSettings'
CREATE TABLE [dbo].[Admin_SysSettings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EscalationRate] float  NOT NULL,
    [SubventionRate] float  NOT NULL,
    [InstitutionalCost] float  NOT NULL,
    [MaximumProjectSpan] int  NOT NULL,
    [UPFleetDailyRate] float  NOT NULL,
    [FCkmRate] float  NOT NULL,
    [UPFleetKmRate] float  NOT NULL
);
GO

-- Creating table 'AirlineExpenses'
CREATE TABLE [dbo].[AirlineExpenses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ReturnTicket] bit  NOT NULL,
    [Amount] float  NOT NULL,
    [Travel_Id] int  NOT NULL
);
GO

-- Creating table 'Allowances'
CREATE TABLE [dbo].[Allowances] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] float  NOT NULL,
    [Travel_Id] int  NOT NULL
);
GO

-- Creating table 'Bursaries'
CREATE TABLE [dbo].[Bursaries] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BursaryTypeId] int  NOT NULL,
    [ProjectId] int  NOT NULL,
    [Note_Id] int  NOT NULL,
    [StartDate] datetime  NOT NULL
);
GO

-- Creating table 'BursaryTypes'
CREATE TABLE [dbo].[BursaryTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(200)  NOT NULL,
    [AnnualCost] float  NOT NULL,
    [DurationYears] int  NOT NULL
);
GO

-- Creating table 'Contractors'
CREATE TABLE [dbo].[Contractors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ContractorName] nvarchar(150)  NOT NULL,
    [Expense_Id] int  NOT NULL
);
GO

-- Creating table 'EmailDomains'
CREATE TABLE [dbo].[EmailDomains] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Domain] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Equipments'
CREATE TABLE [dbo].[Equipments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EquipmentName] nvarchar(max)  NOT NULL,
    [Expense_Id] int  NOT NULL
);
GO

-- Creating table 'Expenses'
CREATE TABLE [dbo].[Expenses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActivityId] int  NOT NULL,
    [Amount] float  NOT NULL,
    [Note_Id] int  NOT NULL
);
GO

-- Creating table 'Faculties'
CREATE TABLE [dbo].[Faculties] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FacultyName] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'Gautrains'
CREATE TABLE [dbo].[Gautrains] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] float  NOT NULL,
    [Travel_Id] int  NOT NULL
);
GO

-- Creating table 'Incomes'
CREATE TABLE [dbo].[Incomes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] int  NOT NULL,
    [DonorName] nvarchar(150)  NOT NULL,
    [Amount] float  NOT NULL,
    [Note_Id] int  NOT NULL
);
GO

-- Creating table 'Notes'
CREATE TABLE [dbo].[Notes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserNote] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Objectives'
CREATE TABLE [dbo].[Objectives] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectId] int  NOT NULL,
    [ObjectiveName] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'Operation_Type'
CREATE TABLE [dbo].[Operation_Type] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Operationals'
CREATE TABLE [dbo].[Operationals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExpenseId] int  NOT NULL,
    [Operation_TypeId] int  NOT NULL,
    [Quantity] int  NOT NULL,
    [PricePerUnit] float  NOT NULL,
    [Expense_Id] int  NOT NULL
);
GO

-- Creating table 'PostLevels'
CREATE TABLE [dbo].[PostLevels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [AnnualSalary] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Project_Settings'
CREATE TABLE [dbo].[Project_Settings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EscalationRate] float  NOT NULL,
    [SubventionRate] float  NOT NULL,
    [InstitutionalCost] float  NOT NULL,
    [UPFleetDailyRate] float  NOT NULL,
    [FCkmRate] float  NOT NULL,
    [UPFleetKmRate] float  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [Title] nvarchar(200)  NOT NULL,
    [Goal] nvarchar(max)  NOT NULL,
    [Length] int  NOT NULL,
    [Project_Settings_Id] int  NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(150)  NOT NULL
);
GO

-- Creating table 'Titles'
CREATE TABLE [dbo].[Titles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Travels'
CREATE TABLE [dbo].[Travels] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DurationDays] int  NOT NULL,
    [DepartureDate] datetime  NOT NULL,
    [Destination] nvarchar(200)  NOT NULL,
    [Expense_Id] int  NOT NULL,
    [DepatureLocation] nvarchar(max)  NOT NULL,
    [TravellerName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UPStaffMembers'
CREATE TABLE [dbo].[UPStaffMembers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PostLevelId] int  NOT NULL,
    [DaysInvolved] int  NOT NULL,
    [SubventionLevy] bit  NOT NULL,
    [Expense_Id] int  NOT NULL
);
GO

-- Creating table 'UserCredentials'
CREATE TABLE [dbo].[UserCredentials] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(200)  NOT NULL,
    [Password] nvarchar(300)  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TitleId] int  NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Surname] nvarchar(200)  NOT NULL,
    [RoleId] int  NOT NULL,
    [FacultyId] int  NOT NULL,
    [Admin] bit  NULL
);
GO

-- Creating table 'Visas'
CREATE TABLE [dbo].[Visas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Amount] float  NOT NULL,
    [Travel_Id] int  NOT NULL
);
GO

-- Creating table 'Cars'
CREATE TABLE [dbo].[Cars] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ExpensId] int  NOT NULL,
    [TypeofRental] int  NOT NULL,
    [Days] int  NOT NULL,
    [Kilometers] int  NOT NULL
);
GO

-- Creating table 'Verifications'
CREATE TABLE [dbo].[Verifications] (
    [Email] nvarchar(max)  NOT NULL,
    [VericicationCode] nvarchar(max)  NOT NULL,
    [DateIssues] datetime  NOT NULL,
    [UserID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accommodations'
ALTER TABLE [dbo].[Accommodations]
ADD CONSTRAINT [PK_Accommodations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Admin_SysSettings'
ALTER TABLE [dbo].[Admin_SysSettings]
ADD CONSTRAINT [PK_Admin_SysSettings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AirlineExpenses'
ALTER TABLE [dbo].[AirlineExpenses]
ADD CONSTRAINT [PK_AirlineExpenses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Allowances'
ALTER TABLE [dbo].[Allowances]
ADD CONSTRAINT [PK_Allowances]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Bursaries'
ALTER TABLE [dbo].[Bursaries]
ADD CONSTRAINT [PK_Bursaries]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BursaryTypes'
ALTER TABLE [dbo].[BursaryTypes]
ADD CONSTRAINT [PK_BursaryTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contractors'
ALTER TABLE [dbo].[Contractors]
ADD CONSTRAINT [PK_Contractors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmailDomains'
ALTER TABLE [dbo].[EmailDomains]
ADD CONSTRAINT [PK_EmailDomains]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [PK_Equipments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [PK_Expenses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Faculties'
ALTER TABLE [dbo].[Faculties]
ADD CONSTRAINT [PK_Faculties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Gautrains'
ALTER TABLE [dbo].[Gautrains]
ADD CONSTRAINT [PK_Gautrains]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Incomes'
ALTER TABLE [dbo].[Incomes]
ADD CONSTRAINT [PK_Incomes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Notes'
ALTER TABLE [dbo].[Notes]
ADD CONSTRAINT [PK_Notes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Objectives'
ALTER TABLE [dbo].[Objectives]
ADD CONSTRAINT [PK_Objectives]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operation_Type'
ALTER TABLE [dbo].[Operation_Type]
ADD CONSTRAINT [PK_Operation_Type]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Operationals'
ALTER TABLE [dbo].[Operationals]
ADD CONSTRAINT [PK_Operationals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PostLevels'
ALTER TABLE [dbo].[PostLevels]
ADD CONSTRAINT [PK_PostLevels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Project_Settings'
ALTER TABLE [dbo].[Project_Settings]
ADD CONSTRAINT [PK_Project_Settings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Titles'
ALTER TABLE [dbo].[Titles]
ADD CONSTRAINT [PK_Titles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Travels'
ALTER TABLE [dbo].[Travels]
ADD CONSTRAINT [PK_Travels]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UPStaffMembers'
ALTER TABLE [dbo].[UPStaffMembers]
ADD CONSTRAINT [PK_UPStaffMembers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserCredentials'
ALTER TABLE [dbo].[UserCredentials]
ADD CONSTRAINT [PK_UserCredentials]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Visas'
ALTER TABLE [dbo].[Visas]
ADD CONSTRAINT [PK_Visas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [PK_Cars]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserID] in table 'Verifications'
ALTER TABLE [dbo].[Verifications]
ADD CONSTRAINT [PK_Verifications]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Travel_Id] in table 'Accommodations'
ALTER TABLE [dbo].[Accommodations]
ADD CONSTRAINT [FK_TravelAccommodation]
    FOREIGN KEY ([Travel_Id])
    REFERENCES [dbo].[Travels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelAccommodation'
CREATE INDEX [IX_FK_TravelAccommodation]
ON [dbo].[Accommodations]
    ([Travel_Id]);
GO

-- Creating foreign key on [ActivityId] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [FK_ActivityExpense]
    FOREIGN KEY ([ActivityId])
    REFERENCES [dbo].[Activities]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityExpense'
CREATE INDEX [IX_FK_ActivityExpense]
ON [dbo].[Expenses]
    ([ActivityId]);
GO

-- Creating foreign key on [ObjectiveId] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [FK_ObjectiveActivity]
    FOREIGN KEY ([ObjectiveId])
    REFERENCES [dbo].[Objectives]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ObjectiveActivity'
CREATE INDEX [IX_FK_ObjectiveActivity]
ON [dbo].[Activities]
    ([ObjectiveId]);
GO

-- Creating foreign key on [Travel_Id] in table 'AirlineExpenses'
ALTER TABLE [dbo].[AirlineExpenses]
ADD CONSTRAINT [FK_TravelAirlineExpense]
    FOREIGN KEY ([Travel_Id])
    REFERENCES [dbo].[Travels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelAirlineExpense'
CREATE INDEX [IX_FK_TravelAirlineExpense]
ON [dbo].[AirlineExpenses]
    ([Travel_Id]);
GO

-- Creating foreign key on [Travel_Id] in table 'Allowances'
ALTER TABLE [dbo].[Allowances]
ADD CONSTRAINT [FK_TravelAllowance]
    FOREIGN KEY ([Travel_Id])
    REFERENCES [dbo].[Travels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelAllowance'
CREATE INDEX [IX_FK_TravelAllowance]
ON [dbo].[Allowances]
    ([Travel_Id]);
GO

-- Creating foreign key on [Note_Id] in table 'Bursaries'
ALTER TABLE [dbo].[Bursaries]
ADD CONSTRAINT [FK_BursaryNote]
    FOREIGN KEY ([Note_Id])
    REFERENCES [dbo].[Notes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BursaryNote'
CREATE INDEX [IX_FK_BursaryNote]
ON [dbo].[Bursaries]
    ([Note_Id]);
GO

-- Creating foreign key on [BursaryTypeId] in table 'Bursaries'
ALTER TABLE [dbo].[Bursaries]
ADD CONSTRAINT [FK_BursaryTypeBursary]
    FOREIGN KEY ([BursaryTypeId])
    REFERENCES [dbo].[BursaryTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BursaryTypeBursary'
CREATE INDEX [IX_FK_BursaryTypeBursary]
ON [dbo].[Bursaries]
    ([BursaryTypeId]);
GO

-- Creating foreign key on [ProjectId] in table 'Bursaries'
ALTER TABLE [dbo].[Bursaries]
ADD CONSTRAINT [FK_ProjectBursary]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectBursary'
CREATE INDEX [IX_FK_ProjectBursary]
ON [dbo].[Bursaries]
    ([ProjectId]);
GO

-- Creating foreign key on [Expense_Id] in table 'Contractors'
ALTER TABLE [dbo].[Contractors]
ADD CONSTRAINT [FK_ExpenseContractor]
    FOREIGN KEY ([Expense_Id])
    REFERENCES [dbo].[Expenses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpenseContractor'
CREATE INDEX [IX_FK_ExpenseContractor]
ON [dbo].[Contractors]
    ([Expense_Id]);
GO

-- Creating foreign key on [Expense_Id] in table 'Equipments'
ALTER TABLE [dbo].[Equipments]
ADD CONSTRAINT [FK_ExpenseEquipment]
    FOREIGN KEY ([Expense_Id])
    REFERENCES [dbo].[Expenses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpenseEquipment'
CREATE INDEX [IX_FK_ExpenseEquipment]
ON [dbo].[Equipments]
    ([Expense_Id]);
GO

-- Creating foreign key on [Note_Id] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [FK_ExpenseNote]
    FOREIGN KEY ([Note_Id])
    REFERENCES [dbo].[Notes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpenseNote'
CREATE INDEX [IX_FK_ExpenseNote]
ON [dbo].[Expenses]
    ([Note_Id]);
GO

-- Creating foreign key on [Expense_Id] in table 'Operationals'
ALTER TABLE [dbo].[Operationals]
ADD CONSTRAINT [FK_ExpenseOperational]
    FOREIGN KEY ([Expense_Id])
    REFERENCES [dbo].[Expenses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpenseOperational'
CREATE INDEX [IX_FK_ExpenseOperational]
ON [dbo].[Operationals]
    ([Expense_Id]);
GO

-- Creating foreign key on [Expense_Id] in table 'Travels'
ALTER TABLE [dbo].[Travels]
ADD CONSTRAINT [FK_ExpenseTravel]
    FOREIGN KEY ([Expense_Id])
    REFERENCES [dbo].[Expenses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpenseTravel'
CREATE INDEX [IX_FK_ExpenseTravel]
ON [dbo].[Travels]
    ([Expense_Id]);
GO

-- Creating foreign key on [Expense_Id] in table 'UPStaffMembers'
ALTER TABLE [dbo].[UPStaffMembers]
ADD CONSTRAINT [FK_ExpenseUPStaffMember]
    FOREIGN KEY ([Expense_Id])
    REFERENCES [dbo].[Expenses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpenseUPStaffMember'
CREATE INDEX [IX_FK_ExpenseUPStaffMember]
ON [dbo].[UPStaffMembers]
    ([Expense_Id]);
GO

-- Creating foreign key on [FacultyId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_FacultyUser]
    FOREIGN KEY ([FacultyId])
    REFERENCES [dbo].[Faculties]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacultyUser'
CREATE INDEX [IX_FK_FacultyUser]
ON [dbo].[Users]
    ([FacultyId]);
GO

-- Creating foreign key on [Travel_Id] in table 'Gautrains'
ALTER TABLE [dbo].[Gautrains]
ADD CONSTRAINT [FK_TravelGautrain]
    FOREIGN KEY ([Travel_Id])
    REFERENCES [dbo].[Travels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelGautrain'
CREATE INDEX [IX_FK_TravelGautrain]
ON [dbo].[Gautrains]
    ([Travel_Id]);
GO

-- Creating foreign key on [Note_Id] in table 'Incomes'
ALTER TABLE [dbo].[Incomes]
ADD CONSTRAINT [FK_IncomeNote]
    FOREIGN KEY ([Note_Id])
    REFERENCES [dbo].[Notes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IncomeNote'
CREATE INDEX [IX_FK_IncomeNote]
ON [dbo].[Incomes]
    ([Note_Id]);
GO

-- Creating foreign key on [ProjectId] in table 'Incomes'
ALTER TABLE [dbo].[Incomes]
ADD CONSTRAINT [FK_ProjectIncome]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectIncome'
CREATE INDEX [IX_FK_ProjectIncome]
ON [dbo].[Incomes]
    ([ProjectId]);
GO

-- Creating foreign key on [ProjectId] in table 'Objectives'
ALTER TABLE [dbo].[Objectives]
ADD CONSTRAINT [FK_ProjectObjective]
    FOREIGN KEY ([ProjectId])
    REFERENCES [dbo].[Projects]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectObjective'
CREATE INDEX [IX_FK_ProjectObjective]
ON [dbo].[Objectives]
    ([ProjectId]);
GO

-- Creating foreign key on [Operation_TypeId] in table 'Operationals'
ALTER TABLE [dbo].[Operationals]
ADD CONSTRAINT [FK_Operation_TypeOperational]
    FOREIGN KEY ([Operation_TypeId])
    REFERENCES [dbo].[Operation_Type]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Operation_TypeOperational'
CREATE INDEX [IX_FK_Operation_TypeOperational]
ON [dbo].[Operationals]
    ([Operation_TypeId]);
GO

-- Creating foreign key on [PostLevelId] in table 'UPStaffMembers'
ALTER TABLE [dbo].[UPStaffMembers]
ADD CONSTRAINT [FK_PostLevelUPStaffMember]
    FOREIGN KEY ([PostLevelId])
    REFERENCES [dbo].[PostLevels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PostLevelUPStaffMember'
CREATE INDEX [IX_FK_PostLevelUPStaffMember]
ON [dbo].[UPStaffMembers]
    ([PostLevelId]);
GO

-- Creating foreign key on [Project_Settings_Id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_ProjectProject_Settings]
    FOREIGN KEY ([Project_Settings_Id])
    REFERENCES [dbo].[Project_Settings]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProject_Settings'
CREATE INDEX [IX_FK_ProjectProject_Settings]
ON [dbo].[Projects]
    ([Project_Settings_Id]);
GO

-- Creating foreign key on [UserId] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_UserProject]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserProject'
CREATE INDEX [IX_FK_UserProject]
ON [dbo].[Projects]
    ([UserId]);
GO

-- Creating foreign key on [RoleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_RoleUser]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleUser'
CREATE INDEX [IX_FK_RoleUser]
ON [dbo].[Users]
    ([RoleId]);
GO

-- Creating foreign key on [TitleId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_TitleUser]
    FOREIGN KEY ([TitleId])
    REFERENCES [dbo].[Titles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TitleUser'
CREATE INDEX [IX_FK_TitleUser]
ON [dbo].[Users]
    ([TitleId]);
GO

-- Creating foreign key on [Travel_Id] in table 'Visas'
ALTER TABLE [dbo].[Visas]
ADD CONSTRAINT [FK_TravelVisa]
    FOREIGN KEY ([Travel_Id])
    REFERENCES [dbo].[Travels]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelVisa'
CREATE INDEX [IX_FK_TravelVisa]
ON [dbo].[Visas]
    ([Travel_Id]);
GO

-- Creating foreign key on [User_Id] in table 'UserCredentials'
ALTER TABLE [dbo].[UserCredentials]
ADD CONSTRAINT [FK_UserCredentialsUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCredentialsUser'
CREATE INDEX [IX_FK_UserCredentialsUser]
ON [dbo].[UserCredentials]
    ([User_Id]);
GO

-- Creating foreign key on [ExpensId] in table 'Cars'
ALTER TABLE [dbo].[Cars]
ADD CONSTRAINT [FK_ExpensCar]
    FOREIGN KEY ([ExpensId])
    REFERENCES [dbo].[Expenses]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ExpensCar'
CREATE INDEX [IX_FK_ExpensCar]
ON [dbo].[Cars]
    ([ExpensId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------