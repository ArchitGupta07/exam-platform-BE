using System;
using Microsoft.EntityFrameworkCore;

namespace ExamPlatformBE.Data;

public static class DataExtensions
{

    public static async Task  MigrateDbAsync(this WebApplication app){


        using var scope = app.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ExamPlatformContext>();

        await dbContext.Database.MigrateAsync();
    }

}

// Why Do We Need to Create a Scope?
// Scoped Services Have a Limited Lifetime:

// Services registered as scoped are designed to be created once per request (or per scope). DbContext is typically registered as a scoped service, meaning a new instance is created for each web request.
// If you try to resolve a scoped service (like DbContext) outside of a request scope (for example, during application startup), ASP.NET Core will throw an error because there is no active request or scope to manage the lifetime of that service.
// Scopes Manage Service Lifetimes:

// When you manually create a scope using app.Services.CreateScope(), you're explicitly telling ASP.NET Core to create a temporary "mini-lifetime" where scoped services can exist.
// Inside this scope, the scoped services are created and disposed of automatically when the scope ends. This ensures proper resource management (such as database connections in DbContext).
// Preventing Memory Leaks and Resource Contention:

// If you were to resolve a scoped service like DbContext without creating a scope, it could lead to memory leaks or resource contention, especially if you're dealing with things like database connections.
// Each scope has a well-defined lifetime: services created in the scope are cleaned up when the scope is disposed of. Without a scope, services that require cleanup (like DbContext, which manages database connections) might stay around longer than necessary.
// Why Can't We Use the Service Directly?
// If you try to resolve a scoped service (like DbContext) directly from app.Services without creating a scope, you'll run into problems because:

// No Active Scope for Scoped Services: ASP.NET Core's built-in dependency injection container expects scoped services like DbContext to only be used within a request or a scope. Outside of that context, the system won’t know how to manage the lifecycle of the DbContext properly.

// Service Lifetimes are Important:

// Singleton Services: These services live for the entire lifetime of the application. They are created once and reused across all requests.
// Scoped Services: These services are created once per request or scope and are disposed of at the end of the request or scope.
// Transient Services: These services are created every time they are requested and are short-lived.
