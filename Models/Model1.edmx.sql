
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/06/2025 16:08:09
-- Generated from EDMX file: C:\Users\Mon Pc\source\repos\WebApplication1\WebApplication1\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_HistoriqueEmploye_ProfilEmploye]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HistoriqueEmploye] DROP CONSTRAINT [FK_HistoriqueEmploye_ProfilEmploye];
GO
IF OBJECT_ID(N'[dbo].[FK_OffreCritere_CriteresEligibilite]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OffreCritere] DROP CONSTRAINT [FK_OffreCritere_CriteresEligibilite];
GO
IF OBJECT_ID(N'[dbo].[FK_OffreCritere_OffresEmploi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OffreCritere] DROP CONSTRAINT [FK_OffreCritere_OffresEmploi];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfilEmploye_Diplomes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfilEmploye] DROP CONSTRAINT [FK_ProfilEmploye_Diplomes];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfilEmploye_OffresEmploi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfilEmploye] DROP CONSTRAINT [FK_ProfilEmploye_OffresEmploi];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfilEmploye_Postes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfilEmploye] DROP CONSTRAINT [FK_ProfilEmploye_Postes];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfilExterne_Diplomes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfilExterne] DROP CONSTRAINT [FK_ProfilExterne_Diplomes];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfilExterne_OffresEmploi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfilExterne] DROP CONSTRAINT [FK_ProfilExterne_OffresEmploi];
GO
IF OBJECT_ID(N'[dbo].[FK_ProfilScoring_ProfilExterne]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProfilScoring] DROP CONSTRAINT [FK_ProfilScoring_ProfilExterne];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CriteresEligibilite]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CriteresEligibilite];
GO
IF OBJECT_ID(N'[dbo].[Diplomes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Diplomes];
GO
IF OBJECT_ID(N'[dbo].[HistoriqueEmploye]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HistoriqueEmploye];
GO
IF OBJECT_ID(N'[dbo].[OffreCritere]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OffreCritere];
GO
IF OBJECT_ID(N'[dbo].[OffresEmploi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OffresEmploi];
GO
IF OBJECT_ID(N'[dbo].[Postes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Postes];
GO
IF OBJECT_ID(N'[dbo].[ProfilEmploye]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfilEmploye];
GO
IF OBJECT_ID(N'[dbo].[ProfilExterne]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfilExterne];
GO
IF OBJECT_ID(N'[dbo].[ProfilScoring]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProfilScoring];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProfilEmploye'
CREATE TABLE [dbo].[ProfilEmploye] (
    [IdProfilEmploye] int  NOT NULL,
    [Nom] varchar(255)  NOT NULL,
    [Prenom] varchar(255)  NOT NULL,
    [DateNaissance] datetime  NOT NULL,
    [Adresse] varchar(255)  NOT NULL,
    [Sexe] varchar(20)  NULL,
    [NbCongesRestants] int  NOT NULL,
    [TypeContrat] varchar(20)  NULL,
    [LocalisationPoste] varchar(20)  NULL,
    [Email] varchar(255)  NOT NULL,
    [Telephone] varchar(50)  NOT NULL,
    [DateEmbauche] datetime  NOT NULL,
    [DateFinContrat] datetime  NULL,
    [StatutActif] bit  NOT NULL,
    [NbHeuresHebdo] int  NOT NULL,
    [IdDiplome] int  NOT NULL,
    [IdPosteActuel] int  NOT NULL,
    [IdOffreSouhaitee] int  NULL
);
GO

-- Creating table 'ProfilExterne'
CREATE TABLE [dbo].[ProfilExterne] (
    [IdProfilExterne] int  NOT NULL,
    [Nom] varchar(255)  NOT NULL,
    [Prenom] varchar(255)  NOT NULL,
    [DateNaissance] datetime  NOT NULL,
    [Adresse] varchar(255)  NOT NULL,
    [Sexe] varchar(20)  NULL,
    [Email] varchar(255)  NOT NULL,
    [Telephone] varchar(50)  NULL,
    [DateCandidature] datetime  NOT NULL,
    [IdDiplome] int  NOT NULL,
    [IdOffreEmploi] int  NOT NULL
);
GO

-- Creating table 'CriteresEligibilite'
CREATE TABLE [dbo].[CriteresEligibilite] (
    [IdCritere] int  NOT NULL,
    [NomCritere] varchar(255)  NOT NULL,
    [Description] varchar(max)  NULL,
    [Poids] int  NULL
);
GO

-- Creating table 'Diplomes'
CREATE TABLE [dbo].[Diplomes] (
    [IdDiplome] int  NOT NULL,
    [NomDiplome] varchar(255)  NOT NULL,
    [NiveauDiplome] varchar(100)  NOT NULL,
    [Domaine] varchar(255)  NOT NULL
);
GO

-- Creating table 'HistoriqueEmploye'
CREATE TABLE [dbo].[HistoriqueEmploye] (
    [IdHistoriqueEmploye] int  NOT NULL,
    [DateDebut] datetime  NOT NULL,
    [DateFin] datetime  NULL,
    [SuiviHierarchique] varchar(255)  NULL,
    [Salaire] float  NOT NULL,
    [EvaluationPerformance] varchar(255)  NOT NULL,
    [PosteOccupe] varchar(255)  NOT NULL,
    [Departement] varchar(255)  NOT NULL,
    [TypeContrat] varchar(20)  NULL,
    [MotifFinContrat] varchar(255)  NULL,
    [CommentairesRH] varchar(max)  NULL,
    [IdEmploye] int  NOT NULL
);
GO

-- Creating table 'OffresEmploi'
CREATE TABLE [dbo].[OffresEmploi] (
    [IdOffreEmploi] int  NOT NULL,
    [IntitulePoste] varchar(255)  NOT NULL,
    [Localisation] varchar(255)  NOT NULL,
    [NiveauPoste] varchar(100)  NOT NULL,
    [DatePublication] datetime  NOT NULL,
    [Disponibilite] varchar(20)  NOT NULL,
    [TeletravailPossible] bit  NOT NULL,
    [TypeContrat] varchar(20)  NOT NULL,
    [SalairePropose] float  NOT NULL,
    [Description] varchar(max)  NOT NULL,
    [DateLimiteCandidature] datetime  NOT NULL,
    [NbPostesOuverts] int  NOT NULL
);
GO

-- Creating table 'Postes'
CREATE TABLE [dbo].[Postes] (
    [IdPoste] int  NOT NULL,
    [Intitule] varchar(255)  NOT NULL,
    [NiveauDiplomeRequis] varchar(100)  NOT NULL,
    [NiveauHierarchique] varchar(100)  NOT NULL,
    [Description] varchar(max)  NOT NULL,
    [MobiliteRequise] bit  NOT NULL
);
GO

-- Creating table 'ProfilScoring'
CREATE TABLE [dbo].[ProfilScoring] (
    [IdScoring] int  NOT NULL,
    [IdProfilExterne] int  NOT NULL
);
GO

-- Creating table 'OffreCritere'
CREATE TABLE [dbo].[OffreCritere] (
    [CriteresEligibilite_IdCritere] int  NOT NULL,
    [OffresEmploi_IdOffreEmploi] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdProfilEmploye] in table 'ProfilEmploye'
ALTER TABLE [dbo].[ProfilEmploye]
ADD CONSTRAINT [PK_ProfilEmploye]
    PRIMARY KEY CLUSTERED ([IdProfilEmploye] ASC);
GO

-- Creating primary key on [IdProfilExterne] in table 'ProfilExterne'
ALTER TABLE [dbo].[ProfilExterne]
ADD CONSTRAINT [PK_ProfilExterne]
    PRIMARY KEY CLUSTERED ([IdProfilExterne] ASC);
GO

-- Creating primary key on [IdCritere] in table 'CriteresEligibilite'
ALTER TABLE [dbo].[CriteresEligibilite]
ADD CONSTRAINT [PK_CriteresEligibilite]
    PRIMARY KEY CLUSTERED ([IdCritere] ASC);
GO

-- Creating primary key on [IdDiplome] in table 'Diplomes'
ALTER TABLE [dbo].[Diplomes]
ADD CONSTRAINT [PK_Diplomes]
    PRIMARY KEY CLUSTERED ([IdDiplome] ASC);
GO

-- Creating primary key on [IdHistoriqueEmploye] in table 'HistoriqueEmploye'
ALTER TABLE [dbo].[HistoriqueEmploye]
ADD CONSTRAINT [PK_HistoriqueEmploye]
    PRIMARY KEY CLUSTERED ([IdHistoriqueEmploye] ASC);
GO

-- Creating primary key on [IdOffreEmploi] in table 'OffresEmploi'
ALTER TABLE [dbo].[OffresEmploi]
ADD CONSTRAINT [PK_OffresEmploi]
    PRIMARY KEY CLUSTERED ([IdOffreEmploi] ASC);
GO

-- Creating primary key on [IdPoste] in table 'Postes'
ALTER TABLE [dbo].[Postes]
ADD CONSTRAINT [PK_Postes]
    PRIMARY KEY CLUSTERED ([IdPoste] ASC);
GO

-- Creating primary key on [IdScoring], [IdProfilExterne] in table 'ProfilScoring'
ALTER TABLE [dbo].[ProfilScoring]
ADD CONSTRAINT [PK_ProfilScoring]
    PRIMARY KEY CLUSTERED ([IdScoring], [IdProfilExterne] ASC);
GO

-- Creating primary key on [CriteresEligibilite_IdCritere], [OffresEmploi_IdOffreEmploi] in table 'OffreCritere'
ALTER TABLE [dbo].[OffreCritere]
ADD CONSTRAINT [PK_OffreCritere]
    PRIMARY KEY CLUSTERED ([CriteresEligibilite_IdCritere], [OffresEmploi_IdOffreEmploi] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdProfilExterne] in table 'ProfilScoring'
ALTER TABLE [dbo].[ProfilScoring]
ADD CONSTRAINT [FK_ProfilScoring_ProfilExterne]
    FOREIGN KEY ([IdProfilExterne])
    REFERENCES [dbo].[ProfilExterne]
        ([IdProfilExterne])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfilScoring_ProfilExterne'
CREATE INDEX [IX_FK_ProfilScoring_ProfilExterne]
ON [dbo].[ProfilScoring]
    ([IdProfilExterne]);
GO

-- Creating foreign key on [CriteresEligibilite_IdCritere] in table 'OffreCritere'
ALTER TABLE [dbo].[OffreCritere]
ADD CONSTRAINT [FK_OffreCritere_CriteresEligibilite]
    FOREIGN KEY ([CriteresEligibilite_IdCritere])
    REFERENCES [dbo].[CriteresEligibilite]
        ([IdCritere])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OffresEmploi_IdOffreEmploi] in table 'OffreCritere'
ALTER TABLE [dbo].[OffreCritere]
ADD CONSTRAINT [FK_OffreCritere_OffresEmploi]
    FOREIGN KEY ([OffresEmploi_IdOffreEmploi])
    REFERENCES [dbo].[OffresEmploi]
        ([IdOffreEmploi])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OffreCritere_OffresEmploi'
CREATE INDEX [IX_FK_OffreCritere_OffresEmploi]
ON [dbo].[OffreCritere]
    ([OffresEmploi_IdOffreEmploi]);
GO

-- Creating foreign key on [IdDiplome] in table 'ProfilEmploye'
ALTER TABLE [dbo].[ProfilEmploye]
ADD CONSTRAINT [FK_ProfilEmploye_Diplomes]
    FOREIGN KEY ([IdDiplome])
    REFERENCES [dbo].[Diplomes]
        ([IdDiplome])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfilEmploye_Diplomes'
CREATE INDEX [IX_FK_ProfilEmploye_Diplomes]
ON [dbo].[ProfilEmploye]
    ([IdDiplome]);
GO

-- Creating foreign key on [IdDiplome] in table 'ProfilExterne'
ALTER TABLE [dbo].[ProfilExterne]
ADD CONSTRAINT [FK_ProfilExterne_Diplomes]
    FOREIGN KEY ([IdDiplome])
    REFERENCES [dbo].[Diplomes]
        ([IdDiplome])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfilExterne_Diplomes'
CREATE INDEX [IX_FK_ProfilExterne_Diplomes]
ON [dbo].[ProfilExterne]
    ([IdDiplome]);
GO

-- Creating foreign key on [IdEmploye] in table 'HistoriqueEmploye'
ALTER TABLE [dbo].[HistoriqueEmploye]
ADD CONSTRAINT [FK_HistoriqueEmploye_ProfilEmploye]
    FOREIGN KEY ([IdEmploye])
    REFERENCES [dbo].[ProfilEmploye]
        ([IdProfilEmploye])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HistoriqueEmploye_ProfilEmploye'
CREATE INDEX [IX_FK_HistoriqueEmploye_ProfilEmploye]
ON [dbo].[HistoriqueEmploye]
    ([IdEmploye]);
GO

-- Creating foreign key on [IdOffreSouhaitee] in table 'ProfilEmploye'
ALTER TABLE [dbo].[ProfilEmploye]
ADD CONSTRAINT [FK_ProfilEmploye_OffresEmploi]
    FOREIGN KEY ([IdOffreSouhaitee])
    REFERENCES [dbo].[OffresEmploi]
        ([IdOffreEmploi])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfilEmploye_OffresEmploi'
CREATE INDEX [IX_FK_ProfilEmploye_OffresEmploi]
ON [dbo].[ProfilEmploye]
    ([IdOffreSouhaitee]);
GO

-- Creating foreign key on [IdOffreEmploi] in table 'ProfilExterne'
ALTER TABLE [dbo].[ProfilExterne]
ADD CONSTRAINT [FK_ProfilExterne_OffresEmploi]
    FOREIGN KEY ([IdOffreEmploi])
    REFERENCES [dbo].[OffresEmploi]
        ([IdOffreEmploi])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfilExterne_OffresEmploi'
CREATE INDEX [IX_FK_ProfilExterne_OffresEmploi]
ON [dbo].[ProfilExterne]
    ([IdOffreEmploi]);
GO

-- Creating foreign key on [IdPosteActuel] in table 'ProfilEmploye'
ALTER TABLE [dbo].[ProfilEmploye]
ADD CONSTRAINT [FK_ProfilEmploye_Postes]
    FOREIGN KEY ([IdPosteActuel])
    REFERENCES [dbo].[Postes]
        ([IdPoste])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProfilEmploye_Postes'
CREATE INDEX [IX_FK_ProfilEmploye_Postes]
ON [dbo].[ProfilEmploye]
    ([IdPosteActuel]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------