
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/08/2019 05:29:05
-- Generated from EDMX file: C:\Users\yo\GRH\Gestion de Recursos Humanos\Gestion de Recursos Humanos\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [datosempresa];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[empleadosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[empleadosSet];
GO
IF OBJECT_ID(N'[dbo].[departamentosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[departamentosSet];
GO
IF OBJECT_ID(N'[dbo].[cargosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[cargosSet];
GO
IF OBJECT_ID(N'[dbo].[nominasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[nominasSet];
GO
IF OBJECT_ID(N'[dbo].[salidaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[salidaSet];
GO
IF OBJECT_ID(N'[dbo].[permisosSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[permisosSet];
GO
IF OBJECT_ID(N'[dbo].[licenciasSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[licenciasSet];
GO
IF OBJECT_ID(N'[dbo].[vacacionesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[vacacionesSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'empleadosSet'
CREATE TABLE [dbo].[empleadosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [codigoempleado] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [apellido] nvarchar(max)  NOT NULL,
    [telefono] nvarchar(max)  NOT NULL,
    [departamento] nvarchar(max)  NOT NULL,
    [cargo] nvarchar(max)  NOT NULL,
    [fechaingreso] nvarchar(max)  NOT NULL,
    [salario] int  NOT NULL,
    [estatus] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'departamentosSet'
CREATE TABLE [dbo].[departamentosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [codigodepartamento] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'cargosSet'
CREATE TABLE [dbo].[cargosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cargo] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'nominasSet'
CREATE TABLE [dbo].[nominasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [año] int  NOT NULL,
    [mes] int  NOT NULL,
    [montototal] int  NOT NULL
);
GO

-- Creating table 'salidaSet'
CREATE TABLE [dbo].[salidaSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [empleado] nvarchar(max)  NOT NULL,
    [tiposalida] nvarchar(max)  NOT NULL,
    [motivo] nvarchar(max)  NOT NULL,
    [fechasalida] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'permisosSet'
CREATE TABLE [dbo].[permisosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [empleado] nvarchar(max)  NOT NULL,
    [desde] datetime  NOT NULL,
    [hasta] datetime  NOT NULL,
    [comentarios] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'licenciasSet'
CREATE TABLE [dbo].[licenciasSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [empleado] nvarchar(max)  NOT NULL,
    [desde] datetime  NOT NULL,
    [hasta] datetime  NOT NULL,
    [motivo] nvarchar(max)  NOT NULL,
    [comentarios] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'vacacionesSet'
CREATE TABLE [dbo].[vacacionesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [empleado] nvarchar(max)  NOT NULL,
    [desde] datetime  NOT NULL,
    [hasta] datetime  NOT NULL,
    [correspondiente] int  NOT NULL,
    [comentarios] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'empleadosSet'
ALTER TABLE [dbo].[empleadosSet]
ADD CONSTRAINT [PK_empleadosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'departamentosSet'
ALTER TABLE [dbo].[departamentosSet]
ADD CONSTRAINT [PK_departamentosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'cargosSet'
ALTER TABLE [dbo].[cargosSet]
ADD CONSTRAINT [PK_cargosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'nominasSet'
ALTER TABLE [dbo].[nominasSet]
ADD CONSTRAINT [PK_nominasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'salidaSet'
ALTER TABLE [dbo].[salidaSet]
ADD CONSTRAINT [PK_salidaSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'permisosSet'
ALTER TABLE [dbo].[permisosSet]
ADD CONSTRAINT [PK_permisosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'licenciasSet'
ALTER TABLE [dbo].[licenciasSet]
ADD CONSTRAINT [PK_licenciasSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'vacacionesSet'
ALTER TABLE [dbo].[vacacionesSet]
ADD CONSTRAINT [PK_vacacionesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------