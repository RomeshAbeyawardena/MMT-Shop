USE MMTShop

INSERT INTO [dbo].[Category]
    (
        [Name],
        [SKUIdentifier]
    )
VALUES
    (
        N'Home',  -- Name - nvarchar(200)
        10000     -- SKUIdentifier - int
    ),
	(
        N'Garden',  -- Name - nvarchar(200)
        20000     -- SKUIdentifier - int
    ),
	(
        N'Electronics',  -- Name - nvarchar(200)
        30000     -- SKUIdentifier - int
    ),
	(
        N'Fitness',  -- Name - nvarchar(200)
        40000     -- SKUIdentifier - int
    ),
	(
        N'Toys',  -- Name - nvarchar(200)
        50000     -- SKUIdentifier - int
    )

INSERT INTO [dbo].[Promotion]
    (
        [Name],
        [ValidFrom],
        [ValidTo]
    )
VALUES
    (
        N'Initial Launch',                 -- Name - nvarchar(200)
        SYSDATETIMEOFFSET(), -- ValidFrom - datetimeoffset
        NULL  -- ValidTo - datetimeoffset
    )

DECLARE @promotionId INT = SCOPE_IDENTITY()

-- Satisfies the requirement: For initial launch, 
-- featured products are defined as those with SKU
-- codes in the range 1xxxx,2xxxx and 3xxxx. However
-- featured products may be changed for future promotions.
INSERT INTO [dbo].[FeaturedPromotionCategory]
    (
        [PromotionId],
        [CategoryId]
    )
SELECT @promotionId, [Id]
FROM [dbo].[Category]
WHERE [SKUIdentifier] IN (10000,20000,30000)

DECLARE @categoryId INT = SCOPE_IDENTITY()

SELECT @categoryId = [Id] FROM [dbo].[Category]
WHERE [Name] = 'Home'

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Lamp', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        35.98 -- Price - decimal(19, 4),

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Desk', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        105.78 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Sofa', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        448.37 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Wardrobe', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        120.87 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Mattress', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        477.22 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Head Board', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        145.44 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Curtains', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        88.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Side Table', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        178.49 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Rug', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        74.33 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Dining Table', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        144.66 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'TV Stand', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        294.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Coffee Table', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        394.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Blinds', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        339.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Set Of Drawers', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        249.88 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Mirror', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        95.48 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Book Shelf', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        112.79 -- Price - decimal(19, 4)
    
SELECT @categoryId = [Id] FROM [dbo].[Category]
WHERE [Name] = 'Garden'

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Hot tub', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        799.98 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Green house', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        1799.98 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Lawn mower', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        299.98 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Outdoor heating', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        199.98 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Watering can', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        19.98 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Plant pots', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        9.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Ladder', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        9.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Water sprinkler system', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        149.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Hose', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        19.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Security Camera', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        249.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Storage shelves', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        159.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Shovel', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        19.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Outdoor Lighting', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        149.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Fence', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        88.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Paint', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        19.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Barbeque grill', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        449.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Shed', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        359.99 -- Price - decimal(19, 4)

SELECT @categoryId = [Id] FROM [dbo].[Category]
WHERE [Name] = 'Electronics'

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'PC Monitor', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        199.98 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Video Game', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        39.98 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'IPhone', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        999.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'IPad', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        499.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Bathroom Scales', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        98.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Smart Television', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        1999.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Radio', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        299.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Samsung Gaqlaxy', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        299.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Samsung Galaxy', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        799.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Laptop', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        1299.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Computer', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        899.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'XBox One', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        299.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Playstation', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        459.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Nintendo Switch', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        289.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Telephone', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        19.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Blu-Ray Player', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        49.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Freeview Box', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        239.99 -- Price - decimal(19, 4)
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Smart TV Stick', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

SELECT @categoryId = [Id] FROM [dbo].[Category]
WHERE [Name] = 'Fitness'


EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Dumbells', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Treadmill', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Fitness Bike', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Skipping Rope', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Stepper', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Trampoline', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Excercise Ball', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Yoga Mat', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)


EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Body building supplements', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Excercise Bench', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Fitnesss Smart Watch', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)
		
EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Bicycle', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Scooter', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Running Shoes', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Walking Pole', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Bicycle Computer', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Leaning pole', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)

EXEC [dbo].[usp_AddProduct]
        @categoryId,   -- CategoryId - int
        N'Kickboard', -- Name - nvarchar(250)
        N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras nec fringilla nibh. Vivamus vestibulum leo ligula, ac condimentum nunc semper laoreet. Sed sed nunc et nibh mollis tempor. In non ornare libero, eget venenatis magna. Ut faucibus dui sit amet nunc ultricies, vitae facilisis urna facilisis. Praesent consectetur, orci ut vestibulum aliquam, eros nibh tincidunt neque, sed malesuada nunc nunc ac erat. Nulla volutpat ultrices lectus vel convallis. Fusce odio ipsum, pulvinar sed nisl vel, interdum interdum ante. Proin et pharetra turpis. Suspendisse potenti. Sed varius dolor in libero rutrum pellentesque. Duis efficitur lorem ac orci pulvinar sagittis. Morbi eleifend interdum rhoncus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae;', -- Description - nvarchar(2000)
        89.99 -- Price - decimal(19, 4)