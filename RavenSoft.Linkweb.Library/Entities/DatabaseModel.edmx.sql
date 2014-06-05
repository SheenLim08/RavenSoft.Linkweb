
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/03/2014 18:18:47
-- Generated from EDMX file: D:\Shared Documents\Documents\Visual Studio 2013\Projects\RavenSoft.Linkweb\RavenSoft.Linkweb.Library\Entities\DatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Linkweb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerAccountAddresses_CustomerAccounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerAccountAddresses] DROP CONSTRAINT [FK_CustomerAccountAddresses_CustomerAccounts];
GO
IF OBJECT_ID(N'[dbo].[FK_PolicySubscriptions_CustomerAccountAddresses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PolicySubscriptions] DROP CONSTRAINT [FK_PolicySubscriptions_CustomerAccountAddresses];
GO
IF OBJECT_ID(N'[dbo].[FK_PolicySubscriptions_Policies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PolicySubscriptions] DROP CONSTRAINT [FK_PolicySubscriptions_Policies];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceTypeCharge_ServiceTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceTypeCharges] DROP CONSTRAINT [FK_ServiceTypeCharge_ServiceTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionPayments_Transactions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TransactionPayments] DROP CONSTRAINT [FK_TransactionPayments_Transactions];
GO
IF OBJECT_ID(N'[dbo].[FK_Transactions_CustomerAccounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_CustomerAccounts];
GO
IF OBJECT_ID(N'[dbo].[FK_Transactions_CustomerAccountsAddresss]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_CustomerAccountsAddresss];
GO
IF OBJECT_ID(N'[dbo].[FK_Transactions_ServiceTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transactions] DROP CONSTRAINT [FK_Transactions_ServiceTypes];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CustomerAccountAddresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerAccountAddresses];
GO
IF OBJECT_ID(N'[dbo].[CustomerAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerAccounts];
GO
IF OBJECT_ID(N'[dbo].[Logs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Logs];
GO
IF OBJECT_ID(N'[dbo].[MembershipPolicies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MembershipPolicies];
GO
IF OBJECT_ID(N'[dbo].[OrganizationPolicy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrganizationPolicy];
GO
IF OBJECT_ID(N'[dbo].[PolicySubscriptions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PolicySubscriptions];
GO
IF OBJECT_ID(N'[dbo].[ServiceTypeCharges]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceTypeCharges];
GO
IF OBJECT_ID(N'[dbo].[ServiceTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceTypes];
GO
IF OBJECT_ID(N'[dbo].[SystemAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemAccounts];
GO
IF OBJECT_ID(N'[dbo].[TransactionPayments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionPayments];
GO
IF OBJECT_ID(N'[dbo].[Transactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transactions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CustomerAccountAddresses'
CREATE TABLE [dbo].[CustomerAccountAddresses] (
    [GUID] nvarchar(100)  NOT NULL,
    [BillingAddress] nvarchar(800)  NOT NULL,
    [BillingAddressAccountID] nvarchar(100)  NOT NULL,
    [CustomerAccountID] nvarchar(100)  NOT NULL,
    [BillingAddressContact] nvarchar(100)  NOT NULL,
    [BillingAddressNotes] nvarchar(300)  NOT NULL
);
GO

-- Creating table 'CustomerAccounts'
CREATE TABLE [dbo].[CustomerAccounts] (
    [GUID] nvarchar(100)  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Notes] nvarchar(500)  NOT NULL
);
GO

-- Creating table 'Logs'
CREATE TABLE [dbo].[Logs] (
    [GUID] nvarchar(100)  NOT NULL,
    [LogType] nvarchar(100)  NOT NULL,
    [LogDescription] nvarchar(500)  NOT NULL,
    [TimeStamp] datetime  NOT NULL
);
GO

-- Creating table 'MembershipPolicies'
CREATE TABLE [dbo].[MembershipPolicies] (
    [GUID] nvarchar(100)  NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Description] nvarchar(800)  NOT NULL,
    [MonthlyFee] decimal(19,4)  NOT NULL,
    [MembershipFee] decimal(19,4)  NOT NULL,
    [WayBillCharge] decimal(19,4)  NOT NULL,
    [MaxPickupWayBillPerMonth] int  NOT NULL,
    [MaxDeliveryWayBillPerMonth] int  NOT NULL,
    [MaxBillEntries] int  NOT NULL,
    [Insurance] decimal(19,4)  NOT NULL,
    [MembershipMaturityInMonths] int  NOT NULL,
    [PenaltyCharge] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'OrganizationPolicies'
CREATE TABLE [dbo].[OrganizationPolicies] (
    [GUID] nvarchar(100)  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Description] nvarchar(300)  NOT NULL,
    [VATPercentage] float  NOT NULL,
    [LimitAllowedSystemLogin] bit  NOT NULL,
    [BeginAllowedTimeLogin] datetime  NOT NULL,
    [EndingAllowedTimeLogin] datetime  NOT NULL
);
GO

-- Creating table 'PolicySubscriptions'
CREATE TABLE [dbo].[PolicySubscriptions] (
    [GUID] nvarchar(100)  NOT NULL,
    [PolicyGUID] nvarchar(100)  NOT NULL,
    [CustomerAccountAddressGUID] nvarchar(100)  NOT NULL,
    [SubscriptionDate] datetime  NOT NULL,
    [NextRenewalDate] datetime  NOT NULL,
    [NextMonthlyFeePaymentDate] datetime  NOT NULL
);
GO

-- Creating table 'ServiceTypeCharges'
CREATE TABLE [dbo].[ServiceTypeCharges] (
    [GUID] nvarchar(100)  NOT NULL,
    [IndexLocation] int  NOT NULL,
    [ServiceTypeGUID] nvarchar(100)  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [Charge] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'ServiceTypes'
CREATE TABLE [dbo].[ServiceTypes] (
    [GUID] nvarchar(100)  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [Description] nvarchar(500)  NOT NULL,
    [AllowDelivery] bit  NOT NULL,
    [AllowPickup] bit  NOT NULL,
    [IsEnable] bit  NOT NULL
);
GO

-- Creating table 'SystemAccounts'
CREATE TABLE [dbo].[SystemAccounts] (
    [GUID] nvarchar(100)  NOT NULL,
    [Name] nvarchar(100)  NOT NULL,
    [LogonName] nvarchar(100)  NOT NULL,
    [Address] nvarchar(500)  NOT NULL,
    [Notes] nvarchar(500)  NOT NULL,
    [HashedPassword] nvarchar(100)  NOT NULL,
    [AccountType] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'TransactionPayments'
CREATE TABLE [dbo].[TransactionPayments] (
    [GUID] nvarchar(100)  NOT NULL,
    [TransactionID] nvarchar(100)  NOT NULL,
    [PaymentType] nvarchar(100)  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [DatePaid] datetime  NOT NULL,
    [Notes] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Transactions'
CREATE TABLE [dbo].[Transactions] (
    [TransactionID] nvarchar(100)  NOT NULL,
    [CustomerGUID] nvarchar(100)  NOT NULL,
    [CustomerAccountAddressGUID] nvarchar(100)  NOT NULL,
    [BillingAccountID] nvarchar(100)  NOT NULL,
    [TransactionType] nvarchar(100)  NOT NULL,
    [PolicyWayBillCharge] decimal(19,4)  NOT NULL,
    [ServiceTypeGUID] nvarchar(100)  NOT NULL,
    [ServiceTypeCharge] decimal(19,4)  NOT NULL,
    [TimeStamp] datetime  NOT NULL,
    [VATCharge] decimal(19,4)  NOT NULL,
    [BatchTransactionID] nvarchar(100)  NOT NULL,
    [Notes] nvarchar(200)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [GUID] in table 'CustomerAccountAddresses'
ALTER TABLE [dbo].[CustomerAccountAddresses]
ADD CONSTRAINT [PK_CustomerAccountAddresses]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'CustomerAccounts'
ALTER TABLE [dbo].[CustomerAccounts]
ADD CONSTRAINT [PK_CustomerAccounts]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'Logs'
ALTER TABLE [dbo].[Logs]
ADD CONSTRAINT [PK_Logs]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'MembershipPolicies'
ALTER TABLE [dbo].[MembershipPolicies]
ADD CONSTRAINT [PK_MembershipPolicies]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'OrganizationPolicies'
ALTER TABLE [dbo].[OrganizationPolicies]
ADD CONSTRAINT [PK_OrganizationPolicies]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'PolicySubscriptions'
ALTER TABLE [dbo].[PolicySubscriptions]
ADD CONSTRAINT [PK_PolicySubscriptions]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'ServiceTypeCharges'
ALTER TABLE [dbo].[ServiceTypeCharges]
ADD CONSTRAINT [PK_ServiceTypeCharges]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'ServiceTypes'
ALTER TABLE [dbo].[ServiceTypes]
ADD CONSTRAINT [PK_ServiceTypes]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'SystemAccounts'
ALTER TABLE [dbo].[SystemAccounts]
ADD CONSTRAINT [PK_SystemAccounts]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [GUID] in table 'TransactionPayments'
ALTER TABLE [dbo].[TransactionPayments]
ADD CONSTRAINT [PK_TransactionPayments]
    PRIMARY KEY CLUSTERED ([GUID] ASC);
GO

-- Creating primary key on [TransactionID] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [PK_Transactions]
    PRIMARY KEY CLUSTERED ([TransactionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerAccountID] in table 'CustomerAccountAddresses'
ALTER TABLE [dbo].[CustomerAccountAddresses]
ADD CONSTRAINT [FK_CustomerAccountAddresses_CustomerAccounts]
    FOREIGN KEY ([CustomerAccountID])
    REFERENCES [dbo].[CustomerAccounts]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerAccountAddresses_CustomerAccounts'
CREATE INDEX [IX_FK_CustomerAccountAddresses_CustomerAccounts]
ON [dbo].[CustomerAccountAddresses]
    ([CustomerAccountID]);
GO

-- Creating foreign key on [CustomerAccountAddressGUID] in table 'PolicySubscriptions'
ALTER TABLE [dbo].[PolicySubscriptions]
ADD CONSTRAINT [FK_PolicySubscriptions_CustomerAccountAddresses]
    FOREIGN KEY ([CustomerAccountAddressGUID])
    REFERENCES [dbo].[CustomerAccountAddresses]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PolicySubscriptions_CustomerAccountAddresses'
CREATE INDEX [IX_FK_PolicySubscriptions_CustomerAccountAddresses]
ON [dbo].[PolicySubscriptions]
    ([CustomerAccountAddressGUID]);
GO

-- Creating foreign key on [CustomerAccountAddressGUID] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_Transactions_CustomerAccountsAddresss]
    FOREIGN KEY ([CustomerAccountAddressGUID])
    REFERENCES [dbo].[CustomerAccountAddresses]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transactions_CustomerAccountsAddresss'
CREATE INDEX [IX_FK_Transactions_CustomerAccountsAddresss]
ON [dbo].[Transactions]
    ([CustomerAccountAddressGUID]);
GO

-- Creating foreign key on [CustomerGUID] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_Transactions_CustomerAccounts]
    FOREIGN KEY ([CustomerGUID])
    REFERENCES [dbo].[CustomerAccounts]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transactions_CustomerAccounts'
CREATE INDEX [IX_FK_Transactions_CustomerAccounts]
ON [dbo].[Transactions]
    ([CustomerGUID]);
GO

-- Creating foreign key on [PolicyGUID] in table 'PolicySubscriptions'
ALTER TABLE [dbo].[PolicySubscriptions]
ADD CONSTRAINT [FK_PolicySubscriptions_Policies]
    FOREIGN KEY ([PolicyGUID])
    REFERENCES [dbo].[MembershipPolicies]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PolicySubscriptions_Policies'
CREATE INDEX [IX_FK_PolicySubscriptions_Policies]
ON [dbo].[PolicySubscriptions]
    ([PolicyGUID]);
GO

-- Creating foreign key on [ServiceTypeGUID] in table 'ServiceTypeCharges'
ALTER TABLE [dbo].[ServiceTypeCharges]
ADD CONSTRAINT [FK_ServiceTypeCharge_ServiceTypes]
    FOREIGN KEY ([ServiceTypeGUID])
    REFERENCES [dbo].[ServiceTypes]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceTypeCharge_ServiceTypes'
CREATE INDEX [IX_FK_ServiceTypeCharge_ServiceTypes]
ON [dbo].[ServiceTypeCharges]
    ([ServiceTypeGUID]);
GO

-- Creating foreign key on [ServiceTypeGUID] in table 'Transactions'
ALTER TABLE [dbo].[Transactions]
ADD CONSTRAINT [FK_Transactions_ServiceTypes]
    FOREIGN KEY ([ServiceTypeGUID])
    REFERENCES [dbo].[ServiceTypes]
        ([GUID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Transactions_ServiceTypes'
CREATE INDEX [IX_FK_Transactions_ServiceTypes]
ON [dbo].[Transactions]
    ([ServiceTypeGUID]);
GO

-- Creating foreign key on [TransactionID] in table 'TransactionPayments'
ALTER TABLE [dbo].[TransactionPayments]
ADD CONSTRAINT [FK_TransactionPayments_Transactions]
    FOREIGN KEY ([TransactionID])
    REFERENCES [dbo].[Transactions]
        ([TransactionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionPayments_Transactions'
CREATE INDEX [IX_FK_TransactionPayments_Transactions]
ON [dbo].[TransactionPayments]
    ([TransactionID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------