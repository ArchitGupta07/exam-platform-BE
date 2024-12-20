## How to run the Project

```

dotnet clean
dotnet build
```

## How to run the Project

```
dotnet watch run

```

## Entity Framework Core Installation

```
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.0
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.0

```

## Database Migrations

```
dotnet ef migrations add InitialCreate --output-dir Data\Migrations
dotnet ef migrations add InitialCreate --output-dir Data\Migrations

```

## Jwt Authentication Installation Guide

```
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 9.0.0-rc.1.24452.1


```

## Swagger Installation Guide

```
dotnet add package Swashbuckle.AspNetCore --version 6.9.0
dotnet add package Swashbuckle.AspNetCore.Swagger --version 6.9.0
dotnet add package Swashbuckle.AspNetCore.SwaggerGen --version 6.9.0
dotnet add package Swashbuckle.AspNetCore.SwaggerUI --version 6.9.0


```
