using System;
using ExamPlatformBE.Data;
using ExamPlatformBE.Entities;

namespace ExamPlatformBE.Endpoints;

public static class UsersEndpoints
{


    public static RouteGroupBuilder MapUsersEndpoint(this WebApplication app){

        var group = app.MapGroup("users").WithParameterValidation();

        group.MapGet("/", (ExamPlatformContext dbContext) => "Get all users");
        group.MapGet("/{id}",  (int id, ExamPlatformContext dbContext ) => $"Get user with ID {id}");
        group.MapPost("/", (User user) => "Create a new user");

        return group;

    }

}
