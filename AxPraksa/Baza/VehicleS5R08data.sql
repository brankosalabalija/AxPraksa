USE [VehicleSetup]
GO
SET IDENTITY_INSERT [dbo].[AssetType] ON 

INSERT [dbo].[AssetType] ([ID], [Type]) VALUES (1, N'Vehicle')
INSERT [dbo].[AssetType] ([ID], [Type]) VALUES (2, N'Trailer')
SET IDENTITY_INSERT [dbo].[AssetType] OFF
SET IDENTITY_INSERT [dbo].[AssetSubType] ON 

INSERT [dbo].[AssetSubType] ([ID], [SubType], [AssetTypeID]) VALUES (1, N'Prime Mover', 1)
INSERT [dbo].[AssetSubType] ([ID], [SubType], [AssetTypeID]) VALUES (2, N'Rigid', 1)
INSERT [dbo].[AssetSubType] ([ID], [SubType], [AssetTypeID]) VALUES (3, N'Truck', 1)
INSERT [dbo].[AssetSubType] ([ID], [SubType], [AssetTypeID]) VALUES (4, N'A Trailer', 2)
INSERT [dbo].[AssetSubType] ([ID], [SubType], [AssetTypeID]) VALUES (5, N'B Trailer', 2)
SET IDENTITY_INSERT [dbo].[AssetSubType] OFF
SET IDENTITY_INSERT [dbo].[FleetAssetMake] ON 

INSERT [dbo].[FleetAssetMake] ([ID], [Manufacturer]) VALUES (1, N'Volvo')
INSERT [dbo].[FleetAssetMake] ([ID], [Manufacturer]) VALUES (2, N'Mercedes Benz')
INSERT [dbo].[FleetAssetMake] ([ID], [Manufacturer]) VALUES (3, N'Iveco')
INSERT [dbo].[FleetAssetMake] ([ID], [Manufacturer]) VALUES (4, N'Kamaz')
INSERT [dbo].[FleetAssetMake] ([ID], [Manufacturer]) VALUES (5, N'Man')
SET IDENTITY_INSERT [dbo].[FleetAssetMake] OFF
SET IDENTITY_INSERT [dbo].[FleetAssetModel] ON 

INSERT [dbo].[FleetAssetModel] ([ID], [Name], [FleetAssetMakeID]) VALUES (1, N'FH16', 1)
INSERT [dbo].[FleetAssetModel] ([ID], [Name], [FleetAssetMakeID]) VALUES (2, N'FH', 1)
INSERT [dbo].[FleetAssetModel] ([ID], [Name], [FleetAssetMakeID]) VALUES (3, N'Actros', 2)
INSERT [dbo].[FleetAssetModel] ([ID], [Name], [FleetAssetMakeID]) VALUES (4, N'NG', 2)
INSERT [dbo].[FleetAssetModel] ([ID], [Name], [FleetAssetMakeID]) VALUES (5, N'Zeta', 3)
INSERT [dbo].[FleetAssetModel] ([ID], [Name], [FleetAssetMakeID]) VALUES (6, N'6560', 4)
INSERT [dbo].[FleetAssetModel] ([ID], [Name], [FleetAssetMakeID]) VALUES (7, N'TGL', 5)
SET IDENTITY_INSERT [dbo].[FleetAssetModel] OFF
SET IDENTITY_INSERT [dbo].[FuelType] ON 

INSERT [dbo].[FuelType] ([ID], [Fuel]) VALUES (1, N'Diesel')
INSERT [dbo].[FuelType] ([ID], [Fuel]) VALUES (2, N'Off-Road Diesel')
INSERT [dbo].[FuelType] ([ID], [Fuel]) VALUES (3, N'Bio-Diesel')
SET IDENTITY_INSERT [dbo].[FuelType] OFF
SET IDENTITY_INSERT [dbo].[ComplienceType] ON 

INSERT [dbo].[ComplienceType] ([ID], [Class]) VALUES (1, N'License')
INSERT [dbo].[ComplienceType] ([ID], [Class]) VALUES (2, N'Incuranse')
INSERT [dbo].[ComplienceType] ([ID], [Class]) VALUES (3, N'Registration')
INSERT [dbo].[ComplienceType] ([ID], [Class]) VALUES (4, N'Accreditation')
INSERT [dbo].[ComplienceType] ([ID], [Class]) VALUES (5, N'Rating')
INSERT [dbo].[ComplienceType] ([ID], [Class]) VALUES (6, N'Induction')
SET IDENTITY_INSERT [dbo].[ComplienceType] OFF
SET IDENTITY_INSERT [dbo].[ComplienceSubType] ON 

INSERT [dbo].[ComplienceSubType] ([ID], [Name]) VALUES (1, N'Driver')
INSERT [dbo].[ComplienceSubType] ([ID], [Name]) VALUES (2, N'Subcontractor')
INSERT [dbo].[ComplienceSubType] ([ID], [Name]) VALUES (3, N'Vehicle')
INSERT [dbo].[ComplienceSubType] ([ID], [Name]) VALUES (4, N'Trailer')
SET IDENTITY_INSERT [dbo].[ComplienceSubType] OFF
