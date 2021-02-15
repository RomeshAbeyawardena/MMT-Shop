
/* --Use to clean database installation
USE master
--Schema
IF DB_ID('MMTShop') IS NOT NULL
BEGIN --ensures database is wiped out if it exists for a clean installation
	DROP DATABASE MMTShop
END
GO
*/


CREATE DATABASE MMTShop
GO

USE MMTShop

CREATE TABLE [dbo].[Category]
(
	 [Id] INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_Category PRIMARY KEY
	,[Name] NVARCHAR(200) NOT NULL
	,[SKUIdentifier] INT NOT NULL
	,CONSTRAINT UQ_Category_Name UNIQUE([Name]) -- prevent multiple categories with the same name
	,INDEX IDX_Category_Name NONCLUSTERED ([Name])
)

--Managing promotions to support future promotions.
CREATE TABLE [dbo].[Promotion]
(
	[Id] INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_Promotion PRIMARY KEY
	,[Name] NVARCHAR(200) NOT NULL -- This wasn't asked for but could be useful to identify future promotions
	,[ValidFrom] DATETIMEOFFSET NOT NULL
	,[ValidTo] DATETIMEOFFSET NULL -- Promotions can be infinite or have a fixed period
	,INDEX IDX_Promotion_Name NONCLUSTERED ([Name])
)

--Promotions by category
CREATE TABLE [dbo].[FeaturedPromotionCategory]
(
	[Id] INT NOT NULL IDENTITY(1,1)
	,[PromotionId] INT NOT NULL
		CONSTRAINT FK_FeaturedPromotionCategory_Promotion
		REFERENCES [dbo].[Promotion]
	,[CategoryId] INT NOT NULL
		CONSTRAINT FK_FeaturedPromotionCategory_Category
		REFERENCES [dbo].[Category]
	,CONSTRAINT UQ_FeaturedPromotionCategory 
		UNIQUE ([PromotionId],[CategoryId]) -- Prevent the same promotion with the same categories
)

CREATE TABLE [dbo].[Product]
(
	 [Id] INT NOT NULL IDENTITY(1,1)
		CONSTRAINT PK_ProductId PRIMARY KEY
	,[CategoryId] INT NOT NULL
		CONSTRAINT FK_Product_Category
		REFERENCES [dbo].[Category]
	,[Sku] INT NOT NULL
	,[Name] NVARCHAR(250) NOT NULL -- Using NVARCHAR to support UTF-8 characters
	,[Description] NVARCHAR(2000) NULL 
	,[Price] DECIMAL(19, 4) -- Addresses rounding issues mentioned here 
							-- https://stackoverflow.com/questions/224462/storing-money-in-a-decimal-column-what-precision-and-scale
	,INDEX IDX_Product NONCLUSTERED ([Name]) 
	,CONSTRAINT UQ_Product UNIQUE(
		[Name], 
		[CategoryId]) -- prevent multiple products with the same name
)

GO