# MMT Shop

## Database Installation

To setup the database, run the SQL scripts stored in SolutionFiles/Install 
directory in the following order:

1. 01-Database and schema.sql
2. 02-User defined stored procedures and functions.sql
3. 03-Data.sql

If you need to carry out a clear-down operation, run lines 3 to 9 first 
from the 01-Database and schema.sql script.

## Database Design

### Schema

#### Tables

**Category**

| Column | Data Type  | Comments    |
| :----: | :--------: | ----------- |
| Id            | Integer        | Primary key for category |
| Name          | Nvarchar(200)  | [Nvarchar](https://docs.microsoft.com/en-us/sql/t-sql/data-types/nchar-and-nvarchar-transact-sql?view=sql-server-ver15) is used to support Unicode characters, not supported in ASCII and to support variable length values |
| SkuIdentifier | Integer        | Sku identifier used by products in this category 1xxxx, 2xxxx, etc. 

**Product**

| Column      | Data Type      | Comments    |
| :---------: | :------------: | ----------- |
| Id          | Integer        | Primary key for product |
| CategoryId  | Integer        | Foreign key for category, one category per product |
| Sku         | Integer        | Sku will be calculated by usp_AddProduct based on Category.SkuIdentifier |
| Name        | Nvarchar(250)  | Name of product |
| Description | Nvarchar(2000) | Description of product, [Microsoft recommends we try to avoid MAX where possible - see warning](https://docs.microsoft.com/en-us/sql/t-sql/data-types/nchar-and-nvarchar-transact-sql?view=sql-server-ver15) |
| Price       | Decimal(19,4)  | Price of product, stored as decimal to support flexibility of mathematical operations |


**Promotion**

The promotion table was added to meet the requirement
> However featured products may be changed for future promotions.

| Column      | Data Type      | Comments    |
| :---------: | :------------: | ----------- |
| Id          | Integer        | Primary key for promotion |
| Name        | Nvarchar(200)  | Name of the promotion, (not implemented) this may be useful when multiple promotions are active at the same time and could help from an admin perspective |
| ValidFrom   | DateTime       | Used as an active flag to determine whether the promotion should be considered active along with the ValidTo field outlined |
| ValidTo     | DateTime       | Used as an active flag to determine whether the promotion should be considered active along with the ValidFrom field outlined, if this field is left null it will be considered the promotion is on-going. |

**FeaturedPromotionCategory**

The FeaturedPromotionCategory table was added to meet the requirement
> However featured products may be changed for future promotions.

This has been implemented so many categories can have many promotions.

| Column      | Data Type      | Comments    |
| :---------: | :------------: | ----------- |
| Id          | Integer        | Primary key for FeaturedPromotionCategory |
| PromotionId | Integer        | Foreign key for Promotion |
| CategoryId  | Integer        | Foreign key for Category  |

The current implementation adds the home, garden and electronics categories 
to the current promotion to satisfy the requirement
> For initial launch, featured products are defined as those with SKU codes in the range 1xxxx,2xxxx and 3xxxx. 

### Stored Procedures

- udf_CalculateSKU - Calculates the current SKU for a new product in a 
specific category.
- usp_AddProduct -  Inserts a product including the calculated SKU
- usp_GetFeaturedProducts - Retrieves a list of products for a current promotion in an optional 
date range (defaults to now)
- usp_GetCategories - Retrieves a list of categories

### Considerations

#### Unique constraints placed on the category, product and FeaturedPromotionCategory tables

To prevent duplicate records, unique constraints were setup on the *Product*, 
*Category* and *FeaturedPromotionCategory*

- Category has a unique constraint to prevent duplicate names  
- Product has a unique constraint to prevent duplicate names within a category
- FeaturedPromotionCategory has a unique constraint to prevent duplicate 
  categories for a promotion

#### Calculating the SKU for an inserted product
I initially considered using an insert trigger to ensure the SKU generated 
meets the following requirements
> - Home - All SKU’s in the range 1xxxx
> -  Garden - All SKU’s in the range 2xxxx
> - Electronics - All SKU’s in the range 3xxxx
> - Fitness - All SKU’s in the range 4xxxx
> - Toys - All SKU’s in the range 5xxxx

However using triggers can reduce visibility, especially if a new developer
takes over and there are a few key performance issues that can slow down inserts
against the product table.

The best approach was a stored procedure that uses a user defined function to
generate the SKU based on the specified category, this enabled the data script 
to insert dummy data to work with.

The only issue with this approach is if the application and any third party 
systems are involved in inserting products in the database, they must use this
stored  procedure and should be restricted from directly inserting into the 
**Product** table.

It was not indicated in the requirements, however if the application was 
responsible for inserting product data, these business rules could live in the 
application layer and this would have been considered another way this could 
have been approached. 

### Future enhancements

#### Add a featured promotion product table

If additional requirements become necessary to have specific products for a 
promotion, that could be easily implemented with a new promotion product table
to fully satify this requirement. The stored procedure usp_GetFeaturedProducts 
would need to be updated, but no further code changes would be required.

#### Move business rules to application layer

The API would implement an endpoint to POST new product data, the endpoint
would then have a service to calculate the next SKU for the specified category,
all third parties responsible for adding product data will need to consume this 
API to ensure the business rules are fulfilled.