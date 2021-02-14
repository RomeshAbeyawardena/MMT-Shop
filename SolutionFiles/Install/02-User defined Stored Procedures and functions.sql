USE MMTShop
GO
-- =============================================
-- Author:      Anthony Romesh Abeyawardena
-- Create date: 14/02/2021
-- Description: 1b. Calculates the current SKU  
--					for a product of a specific 
--					category.
-- =============================================
CREATE FUNCTION [dbo].[udf_CalculateSKU] (
	@categoryId INT
)
RETURNS INT
AS BEGIN
	DECLARE @SKUIdentifier INT
	DECLARE @currentItemCount INT

	SELECT @SKUIdentifier = [SKUIdentifier]
	FROM [dbo].[Category]
	WHERE [Id] = @categoryId

	SELECT @currentItemCount = COUNT([Id])
	FROM [dbo].[Product]
	WHERE [CategoryId] = @categoryId

	RETURN @SKUIdentifier + @currentItemCount + 1
END

GO

-- =============================================
-- Author:      Anthony Romesh Abeyawardena
-- Create date: 14/02/2021
-- Description: Adds a new product to the 
--				database.
-- =============================================
CREATE PROC [dbo].[usp_AddProduct]
	 @categoryId INT
	,@productName NVARCHAR(200)
	,@productDescription NVARCHAR(2000)
	,@productPrice DECIMAL(19,4)
AS BEGIN
	IF NOT EXISTS(SELECT [Id] FROM [dbo].[Category] WHERE [Id] = @categoryId)
		THROW 50001, 'Category not found', 1;
	ELSE
	BEGIN
		INSERT INTO [dbo].[Product]
			(
				[CategoryId],
				[Sku],
				[Name],
				[Description],
				[Price]
			)
		VALUES
			(
				@categoryId,   -- CategoryId - int
				dbo.udf_CalculateSKU(@categoryId), -- Sku - nvarchar(7)
				@productName, -- Name - nvarchar(250)
				@productDescription, -- Description - nvarchar(2000)
				@productPrice -- Price - decimal(19, 4)
			)

		RETURN 0;
	END
	RETURN -1;
END
GO

-- =============================================
-- Author:      Anthony Romesh Abeyawardena
-- Create date: 14/02/2021
-- Description: 1a. Retrieves a list of  
--				featured products for a 
--				current promotion.
-- =============================================
CREATE PROC [dbo].[usp_GetFeaturedProducts]
	 @validFrom DATETIME = NULL
    ,@validTo DATETIME = NULL
AS BEGIN
	DECLARE @promotionId INT = NULL

	DECLARE @dateNow DATETIME = SYSDATETIME()
	IF @validFrom IS NULL 
	BEGIN
		SET @validFrom = @dateNow
	END

	IF @validTo = NULL
	BEGIN
		SET @validTo = @dateNow
	END
    
	-- Get last current promotion
	SELECT TOP(1) @promotionId = [Id] 
	FROM [dbo].[Promotion]
	WHERE [ValidFrom] <= @validFrom 
		AND ([ValidTo] IS NULL 
		OR [ValidTo] >= @validTo)
	ORDER BY [ValidTo] DESC

	IF @promotionId IS NULL	
		THROW 
			50001, --error number 
			'No featured promotions available', -- message
			1 -- state
	ELSE
	BEGIN
		SELECT	[dbo].[Product].[Sku], 
				[dbo].[Product].[Name], 
				[dbo].[Product].[Description], 
				[dbo].[Product].[Price]
		FROM [dbo].[Product]
			INNER JOIN [dbo].[FeaturedPromotionCategory]
				ON [FeaturedPromotionCategory].[CategoryId] = [Product].[CategoryId]
			INNER JOIN [dbo].[Category]
				ON [Category].[Id] = [FeaturedPromotionCategory].[CategoryId]
		WHERE [PromotionId] = @promotionId

		RETURN 0
	END
END
GO

-- =============================================
-- Author:      Anthony Romesh Abeyawardena
-- Create date: 14/02/2021
-- Description: 1b. Retrieves a list of  
--					available categories
-- =============================================
CREATE PROC [dbo].[usp_GetCategories]
AS BEGIN
	SELECT [Name] FROM [dbo].[Category]
END
GO

-- =============================================
-- Author:      Anthony Romesh Abeyawardena
-- Create date: 14/02/2021
-- Description: 1c. Retrieves a list of  
--					products for a specific 
--					category
-- =============================================
CREATE PROC [dbo].[usp_GetProductsByCategory]
	 @categoryId INT = NULL
	,@category NVARCHAR(200) = NULL
AS BEGIN
	IF @category IS NOT NULL
	BEGIN
		SELECT @categoryId = [Id] 
		FROM [dbo].[Category]
		WHERE [Name] = @category
	END
		
		IF @categoryId IS NULL
			THROW 50001, 'Category not found', 1
		ELSE
		BEGIN
			SELECT	[dbo].[Product].[Sku], 
					[dbo].[Product].[Name], 
					[dbo].[Product].[Description], 
					[dbo].[Product].[Price]
			FROM [dbo].[Product]
			WHERE [CategoryId] = @categoryId
			ORDER BY [Sku]
			RETURN 0;
		END
END
GO
