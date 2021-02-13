# MMTShop

## Database Installation
See Readne.md in Install sub-directory

## Application Setup

### Connection Strings
Connection strings are stored as user secrets in 
order to prevent sharing sensitive credentials being shared and 
need to be configured correctly in order for the
MMTShop Server infrastructure to work. 

Visit for more information:
[Safe storage of app secrets in development in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows)

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
      as DRY as possible. Careful consideration was made to ensure things
      that are absolutely needed to be re-used end up here only.

The design approach taken with this assignment is feature slice, 
this takes us away from the traditional application design where 
we have various layers to design and build. Feature slice enables us
to concentrate on the individual features themselves and not worry about
having to build up large amounts of infrastructure before being able to
do any development on the task your working on it works nicely with SCRUM
or agile from a planning perspective. 

The only drawback of feature slice is nothing should be shared with
other features unless necessary. This is why I went with approach of
having a feature and sub-features of that feature. This way 
sub-feature can have some form of shareable logic. 

In the case of this project, the Product feature contains two 
sub-components as they both depend on the **Product** model.
- GetFeaturedProducts
- GetProductsByCategory

Category can live on its own in a seperate feature