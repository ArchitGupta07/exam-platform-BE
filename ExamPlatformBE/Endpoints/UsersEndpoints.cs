using System;
using ExamPlatformBE.Entities;

namespace ExamPlatformBE.Endpoints;

public static class UsersEndpoints
{


    public static RouteGroupBuilder MapUsersEndpoint(this WebApplication app){

        var group = app.MapGroup("users").WithParameterValidation();

        group.MapGet("/", () => "Get all users");
        group.MapGet("/{id}", (int id) => $"Get user with ID {id}");
        group.MapPost("/", (User user) => "Create a new user");

        return group;

    }

}
