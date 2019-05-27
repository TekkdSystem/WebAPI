USE MalariaApp2
GO
/****** Object:  Table AreaAffected    Script Date: 2019/04/13 19:51:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_PADDING ON
GO
CREATE TABLE AreaAffected(
	AreaID int primary key identity (1,1),
	PatientCountry varchar(50) NULL,
	PatientRegion varchar(50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table Donor    Script Date: 2019/04/13 19:51:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE Donor(
	DonorID int primary key identity(1,1),
	DonationCurrency varchar(50) NULL,
	DonationAmount varchar(50) NULL,
	DonorFName varchar(50) NULL,
	DonorLName varchar(50) NULL,
	DonorAccNo decimal(18, 0) NULL,
	DonorTotal decimal(18, 0) NULL,
	DonorCellphone varchar(50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table Patient    Script Date: 2019/04/13 19:51:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE Patient(
	PatientID int primary key identity(1,1),
	PatientFName varchar(50) NULL,
	PatientSName varchar(50) NULL,
	PatientCellphone varchar(15) NULL,
	PatientEmail varchar(100) NULL,
	Medicating varchar(50) NULL,
	Race varchar(50) NULL,
	AreaID int NOT NULL,
	PatientAddress varchar(50) NULL,
	foreign key (AreaID) references AreaAffected(AreaID)
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table PlasmodiumType    Script Date: 2019/04/13 19:51:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE PlasmodiumType(
	PlasmodiumTypeID int primary key identity(1,1),
	PlasmodiumName varchar(50) NULL,
	IncubationPeriod varchar(50) NULL
	) ON [PRIMARY]
 --CONSTRAINT PK_PlasmodiumType PRIMARY KEY CLUSTERED 
--(
--	PlasmodiumTypeID ASC
--)WITH (PAD_INDEX = OFF, Statistics_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]


GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table Sponsor    Script Date: 2019/04/13 19:51:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE Sponsor(
	SponsorID int primary key identity(1,1),
	SponsorFName varchar(50) NULL,
	SponsorLName varchar(50) NULL,
	SponsorCellphone varchar(15) NULL,
	SponsorEmail varchar(50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table Statistic    Script Date: 2019/04/13 19:51:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE Statistic(
	StatisticID int primary key identity(1,1),
	Year datetime NULL,
	AreaID int NOT NULL,
	CrudeDeathRate int NULL,
	PerninatalMortalityRate varchar(10) NULL,
	MaternalMortalityRatio int NULL,
	MaternalMortalityRate int NULL,
	InfantMortalityRate int NULL,
	ChildMortalityRate int NULL,
	StandardizedMortalityRate int NULL,
	AgeSpecificMortalityRate int NULL,
	SexSpecificMortalityRate int NULL,
	Foreign Key (AreaID) References AreaAffected(AreaID)
) ON [PRIMARY]

GO
/****** Object:  Table Symptoms    Script Date: 2019/04/13 19:51:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE Symptoms(
	SymptomID varchar(10) primary key,
	SymptomName varchar(10) NULL,
	SymptonDescription varchar(10) NULL
) ON [PRIMARY]

GO
/****** Object:  Table Treatment    Script Date: 2019/04/13 19:51:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE Treatment(
	TreatmentID int primary key identity(1,1),
	TreatmentMode varchar(50) NULL,
	TreatmentDescription varchar(1000) NULL,
	TreatmentMedication varchar(1000) NULL
	) ON [PRIMARY]
-- CONSTRAINT PK_Treatment PRIMARY KEY CLUSTERED 
--(
--	TreatmentID ASC
--)WITH (PAD_INDEX = OFF, Statistics_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
--) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table VolunteerType    Script Date: 2019/04/13 19:51:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE VolunteerType(
	VolunteerTypeID int primary key identity(1,1),
	VolunteerTypeName varchar(50) NULL,
	EmergencyLevel varchar(50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table Volunteer    Script Date: 2019/04/13 19:51:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE Volunteer(
	VolunteerID int primary key identity(1,1) ,
	VolunteerTypeID int NOT NULL,
	VolunteerCellphone varchar(15) NULL,
	VolunteerEmergencyContact varchar(15) NULL,
	Foreign Key (VolunteerTypeID) References VolunteerType(VolunteerTypeID)
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'South Africa', N'Gauteng')  
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'South Africa', N'Cape Town') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'South Africa', N'North West') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'South Africa', N'Western Cape') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'South Africa', N'Northern Cape') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'South Africa', N'KwaZulu-Natal') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'South Africa', N'Mpumalanga') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'South Africa', N'Eastern Cape') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'South Africa', N'Free State') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'Mozambique', N'Cabo Delgado') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'Mozambique', N'Gaza') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'Mozambique', N'Inhambane') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'Mozambique', N'Manica') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'Mozambique', N'Maputo City') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'Mozambique', N'Maputo') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'Mozambique', N'Nampula')
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'Mozambique', N'Niassa') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'Mozambique', N'Sofala') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'Mozambique', N'Tete') 
INSERT AreaAffected (PatientCountry, PatientRegion) VALUES (N'Mozambique', N'Quelimane') SET IDENTITY_INSERT AreaAffected ON 
INSERT Donor (DonationCurrency, DonationAmount, DonorFName, DonorLName, DonorAccNo, DonorTotal, DonorCellphone) VALUES (NULL, NULL, NULL, NULL, NULL, NULL,null) 
INSERT Patient(PatientFName, PatientSName, PatientCellphone, PatientEmail, Medicating, Race, PatientAddress) VALUES (NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT PlasmodiumType (PlasmodiumName, IncubationPeriod) VALUES (N'Falciparum', N'9-14 Days') --SET IDENTITY_INSERT PlasmodiumType ON 
INSERT PlasmodiumType (PlasmodiumName, IncubationPeriod) VALUES (N'Vivax', N'12-18 Days') --SET IDENTITY_INSERT PlasmodiumType ON 
INSERT PlasmodiumType (PlasmodiumName, IncubationPeriod) VALUES (N'Ovale', N'12-18 Days') --SET IDENTITY_INSERT PlasmodiumType ON 
INSERT PlasmodiumType (PlasmodiumName, IncubationPeriod) VALUES (N'Malariae', N'18-40 Days') --SET IDENTITY_INSERT PlasmodiumType ON 
INSERT PlasmodiumType (PlasmodiumName, IncubationPeriod) VALUES (N'Knowlesi', NULL) --SET IDENTITY_INSERT PlasmodiumType ON 
INSERT Treatment (TreatmentMode, TreatmentDescription, TreatmentMedication) VALUES (N'Suppressive treatment', N'The symptoms of malaria can be alleviated by suppressing the erythrocytic stage of the parasitic development.', N'Suppressive therapy involves administration of appropriate blood schizonticidal drugs. In all cases of non-falciparum malaria (P. vivax, P. ovale, P. malariae and P. knowlesi), it involves administration of chloroquine.') 
INSERT Treatment (TreatmentMode, TreatmentDescription, TreatmentMedication) VALUES (N'Presumptive treatment', N'This strategy has been abandoned in recent years. NVBDCP-India now recommends first loading dose of chloroquine only for those areas where neither microscopy nor RDTs are available within 24 hours.', N'administration of blood schizonticidal drugs, such as chloroquine, to suspected cases of malaria, followed by full treatment after confirmation.') 
INSERT Treatment (TreatmentMode, TreatmentDescription, TreatmentMedication) VALUES (N'Radical treatment', N'Radical treatment is administration of primaquine to all confirmed cases of malaria.', N'administration of primaquine') 
Insert Into Sponsor(SponsorFName, SponsorLName, SponsorCellphone, SponsorEmail) Values('Wayne','Bruce','0116524380','NotTheBat@Gmail.com')
Insert Into Sponsor(SponsorFName, SponsorLName, SponsorCellphone, SponsorEmail) Values('Bruce','Banner','0605298356','TheHulk@Gmail.com')
Insert Into Sponsor(SponsorFName, SponsorLName, SponsorCellphone, SponsorEmail) Values('Tonny','Stark','0110536844','Avenger1@Yahoo.com')
Insert Into Sponsor(SponsorFName, SponsorLName, SponsorCellphone, SponsorEmail) Values('Widow','Black','0795506360','ScarlettaJH@Gmail.com')
