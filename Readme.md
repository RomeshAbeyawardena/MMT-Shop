# MMT Shop

## Database Installation
See Readne.md in Install sub-directory

## Application Setup

### Connection Strings
Connection strings are stored as user secrets in 
order to prevent sharing sensitive credentials in GitHub
and this needs to be configured correctly in order for the
MMTShop Server infrastructure to work. 

Visit
[Safe storage of app secrets in development in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows)
for more information.

## Structure and Layout

The project is structured in three main projects to keep the solution
as simple as possible.
- MMTShop.Client
    - The console application is implemented here using the RestSharp library 
      as a means to consume a HTTPClient to interact with the API. 
- MMTShop.Server
    - The API itself is implemented here, using Mediatr to 'glue' together 
      request and response object behaviours following the Mediator 
      pattern and pipelines along with some FluentValidation to keep 
      dependency injection in classes to a minimum.
- MMTShop.Shared
    - Shared domain models and constants are housed here to keep things 
      as DRY as possible. Careful consideration was made to ensure classes
      that are absolutely needed to be re-used ended up here.

The design approach taken with this assignment is feature slice, 
this takes away from the traditional application design where 
we have various layers to design and build. Feature slice enables us
to concentrate on the individual features themselves and not worry about
having to build up large amounts of infrastructure before being able to
do any development on the task at hand, it works nicely with SCRUM
or agile from a planning perspective too. 

The only drawback of feature slice is ideally nothing should be shared 
with other features unless necessary. This is why I went with the approach 
of having a feature and sub-features. This way 
sub-features can have some form of shareable logic. 

In the case of this project, the Product feature contains two 
sub-components as they both depend on the **Product** model.
- GetFeaturedProducts
- GetProductsByCategory

Category can live on its own in a seperate feature, however I came across an
exception to this and had to implement an ICategoryProvider in the server 
project to ensure my "get products by category name" validator and get 
categories logic was not using duplicate code. 

Another optimisation completed was to allow the client and server to share 
response objects to reduce effort when requirements change.

A further enhancement would be to cache the categories using a form of
distributed cache to reduce the resources used to constantly connect
to the database each time, however I did not get time to implement this

## MMT Server

## MMT Client

The client as requested is a console application implemented 
with a simple menu interface, outlined below

Welcome to MMT Shop.
Please select an option

1. Display featured products
2. Display categories and get products for a specific category
q. Quit


To proceed enter a number (1 and 2 are available) and hitting Q will cause
the application to exit.

### 1st Option - Featured products
The first menu option will print out a list of featured products for the 
current promotion - all products with the SKU range of 1xxxx,2xxxx and 3xxxx
and then return you back to the menu.

### 2nd Option - List of categories
The second menu option will print out a list of categories, it will then ask
you to select which one you would like to view products for, simply enter
the category name and hit enter and it will print out the list of products
within the specified category and then return you back to the menu.