# MMT Shop

## System Requirements

This section outlines the requirements to build and run the application

### Development enviroment
The project was built using vanilla (without extensions) 
Visual Studio 2019 (v16.8.4) targetting .NET 5 (v5.0.103) - it should build 
and compile with any version of .NET 5.

The database server used during development was SQL Server 2019, 
however the database scripts should be compatible with SQL Server 2017+.

## Database Installation
See Readme.md in SolutionFiles/Install within the solution directory

## Application Setup

### Connection Strings
Connection strings are stored as user secrets in 
order to prevent sharing sensitive credentials in GitHub
and this needs to be configured correctly in order for the
MMT Shop Server infrastructure to work. 

Visit
[Safe storage of app secrets in development in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows)
for more information.

As long as the connection string is valid and all included data scripts have
been run the application should work without a hitch.

### Starting the server and client applications
Open the solution directory and right-click *Start-Server.ps1* and click **Run
with Powershell**, the server should run on the default ports 5000 and 5001 
(HTTPS). You may need to change these in the project properties in Visual Studio,
if this conflicts with anything else you may have set up.

If you had to change the port, the BaseUrl property in the  *appsettings.json* 
file in the MMTShop.Client project will need to be updated to match in order
for the MMT.Client to work in harmony with MMT.Server.

The client can be started in the same way using the *Start-Client.ps1* file 
located in the same directory.

#### Additional Notes
The above Powershell files are not signed, you will need to temporarily
allow execution of unsigned Powershell scripts using *Set-ExecutionPolicy* 
before running the aforementioned scripts.

Further information on this is available on the Microsoft Documentation website 

[Set-ExecutionPolicy (Microsoft.PowerShell.Security) - PowerShell](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.security/set-executionpolicy?view=powershell-7.1)

## Structure and Layout

The project is structured in three main projects to keep the solution
as simple as possible.
- MMTShop.Client
    - The console application is implemented here using the RestSharp library 
      as a HTTP client to interact with the API. 
      Each feature is contained within a module and the Program.cs is considered 
      as the director that calls upon the modules when they are required using
      dependency injection.
- MMTShop.Server
    - The API itself is implemented here, using Mediatr to 'glue' together 
      request and response object behaviours following the Mediator 
      pattern and pipelines along with some FluentValidation to keep 
      dependency injection in classes to a minimum.
- MMTShop.Shared
    - Shared domain models and constants are housed here to keep things 
      as DRY as possible. Careful consideration was made to ensure classes
      that are absolutely needed to be shared ended up here.

The design approach taken with this assignment is feature slice, 
this takes away from the traditional application design where 
we have various layers to design and build. Feature slice enables us
to concentrate on the individual features themselves and not worry about
having to build up large amounts of infrastructure before being able to
do any development on the task at hand, it works nicely with SCRUM
or agile from a planning perspective too. 

The only drawback of feature slice is ideally nothing should be shared 
with other features unless necessary. This is why I went with the approach 
of having features and sub-features. This way sub-features can have some 
shareable logic between them. 

In the case of this project, the Product feature contains two 
sub-components as they both depend on the **Product** model.
- GetFeaturedProducts
- GetProductsByCategory

I decided that Category can live on its own in a seperate feature, 
however I came across some exception to this and had to implement 
an ICategoryProvider to ensure my "get products by category name" validator 
and get categories logic was not using duplicate code. 

Another optimisation completed was to allow the client and server to share 
response objects to reduce effort when requirements change, such as 
paging may be required and we need to output a total number of rows 
and pages for a paging component to generate a pager on the MMT website. 

A further enhancement would be to cache the categories using a form of
distributed caching implementation, such as Redis cache, to reduce the 
resources used to constantly connect to the database each time for this
information.

---

## Application documentation

### MMT Server

#### List of endpoints

- Get featured products part of the current promotion

*HTTP GET* `http://localhost:5000/product`

- Get all available categories

*HTTP GET* `http://localhost:5000/category`

- Get all products under a particular category (replace home with any valid category name)

*HTTP GET* `http://localhost:5000/product/home`

---

### MMT Client

The client as requested is a console application implemented 
with a simple menu interface, outlined below

Welcome to MMT Shop.
Please select an option

1. Display featured products
2. Display categories and get products for a specific category
q. Quit


To proceed enter a number (1 and 2 are available) and hitting Q will cause
the application to exit. Any other input is deemed invalid and will return 
you back to the menu.

#### 1st Option - Featured products
The first menu option will print out a list of featured products for the 
current promotion - all products with the SKU range of 1xxxx, 2xxxx and 3xxxx
and then return you back to the menu.

#### 2nd Option - List of categories and products from specified category
The second menu option will print out a list of categories, it will then ask
you to select which one you would like to view products for, simply enter
the category name and hit enter and it will print out the list of products
within the specified category and then return you back to the menu.

## Appendix

### Nuget packages used
- [RestSharp](https://restsharp.dev/)
- [Mediatr](https://github.com/jbogard/MediatR)
- [Fluent Validation](https://fluentvalidation.net/)
- [NUnit](https://nunit.org/)
- [Moq](https://github.com/Moq)

### General guidances and useful documentation
- [Set-ExecutionPolicy (Microsoft.PowerShell.Security) - PowerShell](https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.security/set-executionpolicy?view=powershell-7.1)
- [Safe storage of app secrets in development in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows)
