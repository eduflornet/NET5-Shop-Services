# [CQRS PostgreSQL Microservice](https://github.com/eduflornet/NET5-Shop-Services/tree/main/ShopServices/ShopServices.Api.Autor)

This demo contains a simple CQRS PostgreSQL Microservice REST-style API that can be used for CRUD operations on a Shop Book Author.

I have using the following tools:

- Visual Studio 2019 
- Postman 8.9.1
- NET5
- Entity Framework Core 5
- MediatR 9.0.0
- Fluent Validation 10.3.0
- AutoMapper 8.1.1
- Swashbuckle.AspNetCore 5.6.3
- Docker Hub Image PostgreSQL 13.3
  
  A [ShopServices.Api.Autor.postman_collection](https://github.com/eduflornet/NET5-Shop-Services/blob/main/ShopServices/ShopServices.Api.Autor.postman_collection) is also included with the basic structure to test each of the CRUD methods of the API.

# [CQRS SQL Server Microservice](https://github.com/eduflornet/NET5-Shop-Services/tree/main/ShopServices/ShopService.Api.Book)

This demo contains a simple CQRS SQL Server Microservice REST-style API that can be used for the maintenance of the API Author and Books.

I have using the following tools:

- Visual Studio 2019 
- Postman 8.9.1
- NET5
- Entity Framework Core 5
- MediatR 9.0.0
- Fluent Validation 10.3.0
- AutoMapper 8.1.1
- Swashbuckle.AspNetCore 5.6.3
- Docker Hub Image SQL Server 15.0.4

A [ShopServices.Api.Book.postman_collection](https://github.com/eduflornet/NET5-Shop-Services/blob/main/ShopServices/ShopService.Api.Book.postman_collection) is also included with the basic structure to test each of the CRUD methods of the API.
# [CQRS SQL Server Microservice Unit Test](https://github.com/eduflornet/NET5-Shop-Services/tree/main/ShopServices/ShopService.Api.Book.Tests)

This project contains the unit tests corresponding to the methods of the Book service.

I have using the following tools:

- xUnit 2.4.1
- Moq 4.16.1
- GenFu 1.6.0
- Entity Framework Core in memory 5.0.9


# [CQRS MySQL Microservice](https://github.com/eduflornet/NET5-Shop-Services/tree/main/ShopServices/ShopService.Api.ShoppingCart)

This demo contains a simple CQRS MySQL Microservice REST-style API that can be used for the maintenance of the API Author and Books.

I have using the following tools:

- Visual Studio 2019 
- Postman 8.9.1
- NET5
- Entity Framework Core 5
- MySql EntityFrameworkCore 5.0.5
- MediatR 9.0.0
- Fluent Validation 10.3.0
- AutoMapper 8.1.1
- Swashbuckle.AspNetCore 5.6.3
- Docker Hub Image MySQL 8.0.26

A [ShopService.Api.ShoppingCart.postman_collection](https://github.com/eduflornet/NET5-Shop-Services/blob/main/ShopServices/ShopService.Api.ShoppingCart.postman_collection) is also included with the basic structure to test each of the methods of the API.
  
## References:
- [CQRS](https://martinfowler.com/bliki/CQRS.html)
- [MediatR](https://github.com/jbogard/MediatR)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/)
- [Fluent Validation](https://fluentvalidation.net/)
- [Swashbuckle and ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-5.0&tabs=visual-studio)
- [PostgreSQL](https://www.postgresql.org/)
- [SQL Server](https://docs.microsoft.com/en-us/sql/sql-server/?view=sql-server-ver15)
- [Run SQL Server container images with Docker](https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&pivots=cs1-bash) 
- [Docker Hub Image PostgreSQL](https://hub.docker.com/_/postgres)
- [Dockerize PostgreSQL](https://docs.docker.com/samples/postgresql_service/)
- [Local Development Set-Up of PostgreSQL with Docker](https://towardsdatascience.com/local-development-set-up-of-postgresql-with-docker-c022632f13ea)
- [GenFu is all about smartly building up objects to use for test and prototype data](https://github.com/MisterJames/GenFu)
- [xUnit.net is a free, open source, community-focused unit testing tool for the .NET Framework](https://xunit.net/)
- [moq is the most popular and friendly mocking library for .NET](https://github.com/moq/moq4)
  