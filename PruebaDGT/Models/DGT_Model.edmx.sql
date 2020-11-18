
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/19/2020 00:23:14
-- Generated from EDMX file: C:\Users\kasmo\source\repos\PruebaDGT\PruebaDGT\Models\DGT_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DGT];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ConductorVehiculo_Conductores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConductorVehiculo] DROP CONSTRAINT [FK_ConductorVehiculo_Conductores];
GO
IF OBJECT_ID(N'[dbo].[FK_ConductorVehiculo_Vehiculos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConductorVehiculo] DROP CONSTRAINT [FK_ConductorVehiculo_Vehiculos];
GO
IF OBJECT_ID(N'[dbo].[FK_InfraccionVehiculo_Conductores]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InfraccionVehiculo] DROP CONSTRAINT [FK_InfraccionVehiculo_Conductores];
GO
IF OBJECT_ID(N'[dbo].[FK_InfraccionVehiculo_Infracciones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InfraccionVehiculo] DROP CONSTRAINT [FK_InfraccionVehiculo_Infracciones];
GO
IF OBJECT_ID(N'[dbo].[FK_InfraccionVehiculo_Vehiculos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InfraccionVehiculo] DROP CONSTRAINT [FK_InfraccionVehiculo_Vehiculos];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Conductores]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Conductores];
GO
IF OBJECT_ID(N'[dbo].[ConductorVehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConductorVehiculo];
GO
IF OBJECT_ID(N'[dbo].[Infracciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Infracciones];
GO
IF OBJECT_ID(N'[dbo].[InfraccionVehiculo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InfraccionVehiculo];
GO
IF OBJECT_ID(N'[dbo].[Vehiculos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehiculos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Conductores'
CREATE TABLE [dbo].[Conductores] (
    [dni] varchar(9)  NOT NULL,
    [nombre] varchar(50)  NOT NULL,
    [apellidos] varchar(50)  NOT NULL,
    [puntos] int  NULL
);
GO

-- Creating table 'ConductorVehiculo'
CREATE TABLE [dbo].[ConductorVehiculo] (
    [id] int IDENTITY(1,1) NOT NULL,
    [matricula] varchar(50)  NOT NULL,
    [dni] varchar(9)  NOT NULL
);
GO

-- Creating table 'Infracciones'
CREATE TABLE [dbo].[Infracciones] (
    [id] int IDENTITY(1,1) NOT NULL,
    [descripcion] varchar(50)  NOT NULL,
    [puntos] int  NOT NULL
);
GO

-- Creating table 'InfraccionVehiculo'
CREATE TABLE [dbo].[InfraccionVehiculo] (
    [id] int IDENTITY(1,1) NOT NULL,
    [dniConductor] varchar(9)  NOT NULL,
    [matricula] varchar(50)  NOT NULL,
    [idInfraccion] int  NOT NULL,
    [fecha] datetime  NOT NULL
);
GO

-- Creating table 'Vehiculos'
CREATE TABLE [dbo].[Vehiculos] (
    [matricula] varchar(50)  NOT NULL,
    [marca] varchar(50)  NOT NULL,
    [modelo] varchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [dni] in table 'Conductores'
ALTER TABLE [dbo].[Conductores]
ADD CONSTRAINT [PK_Conductores]
    PRIMARY KEY CLUSTERED ([dni] ASC);
GO

-- Creating primary key on [id] in table 'ConductorVehiculo'
ALTER TABLE [dbo].[ConductorVehiculo]
ADD CONSTRAINT [PK_ConductorVehiculo]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Infracciones'
ALTER TABLE [dbo].[Infracciones]
ADD CONSTRAINT [PK_Infracciones]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'InfraccionVehiculo'
ALTER TABLE [dbo].[InfraccionVehiculo]
ADD CONSTRAINT [PK_InfraccionVehiculo]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [matricula] in table 'Vehiculos'
ALTER TABLE [dbo].[Vehiculos]
ADD CONSTRAINT [PK_Vehiculos]
    PRIMARY KEY CLUSTERED ([matricula] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [dni] in table 'ConductorVehiculo'
ALTER TABLE [dbo].[ConductorVehiculo]
ADD CONSTRAINT [FK_ConductorVehiculo_Conductores]
    FOREIGN KEY ([dni])
    REFERENCES [dbo].[Conductores]
        ([dni])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConductorVehiculo_Conductores'
CREATE INDEX [IX_FK_ConductorVehiculo_Conductores]
ON [dbo].[ConductorVehiculo]
    ([dni]);
GO

-- Creating foreign key on [dniConductor] in table 'InfraccionVehiculo'
ALTER TABLE [dbo].[InfraccionVehiculo]
ADD CONSTRAINT [FK_InfraccionVehiculo_Conductores]
    FOREIGN KEY ([dniConductor])
    REFERENCES [dbo].[Conductores]
        ([dni])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InfraccionVehiculo_Conductores'
CREATE INDEX [IX_FK_InfraccionVehiculo_Conductores]
ON [dbo].[InfraccionVehiculo]
    ([dniConductor]);
GO

-- Creating foreign key on [matricula] in table 'ConductorVehiculo'
ALTER TABLE [dbo].[ConductorVehiculo]
ADD CONSTRAINT [FK_ConductorVehiculo_Vehiculos]
    FOREIGN KEY ([matricula])
    REFERENCES [dbo].[Vehiculos]
        ([matricula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConductorVehiculo_Vehiculos'
CREATE INDEX [IX_FK_ConductorVehiculo_Vehiculos]
ON [dbo].[ConductorVehiculo]
    ([matricula]);
GO

-- Creating foreign key on [idInfraccion] in table 'InfraccionVehiculo'
ALTER TABLE [dbo].[InfraccionVehiculo]
ADD CONSTRAINT [FK_InfraccionVehiculo_Infracciones]
    FOREIGN KEY ([idInfraccion])
    REFERENCES [dbo].[Infracciones]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InfraccionVehiculo_Infracciones'
CREATE INDEX [IX_FK_InfraccionVehiculo_Infracciones]
ON [dbo].[InfraccionVehiculo]
    ([idInfraccion]);
GO

-- Creating foreign key on [matricula] in table 'InfraccionVehiculo'
ALTER TABLE [dbo].[InfraccionVehiculo]
ADD CONSTRAINT [FK_InfraccionVehiculo_Vehiculos]
    FOREIGN KEY ([matricula])
    REFERENCES [dbo].[Vehiculos]
        ([matricula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_InfraccionVehiculo_Vehiculos'
CREATE INDEX [IX_FK_InfraccionVehiculo_Vehiculos]
ON [dbo].[InfraccionVehiculo]
    ([matricula]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------