using System;
using ExamPlatformBE.Data;
using ExamPlatformBE.Dtos;
using ExamPlatformBE.Entities;
using ExamPlatformBE.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ExamPlatformBE.Endpoints;

public static class UsersEndpoints
{


    public static RouteGroupBuilder MapUsersEndpoint(this WebApplication app){

        var group = app.MapGroup("users").WithParameterValidation();

        group.MapGet("/", (ExamPlatformContext dbContext) => dbContext.Users
                            .Select(user =>user.ToDto())
                            .AsNoTracking()
                            .ToListAsync());




        group.MapGet("/{id}", async (int id, ExamPlatformContext dbContext ) => {
            User? user = await dbContext.Users.FindAsync(id);   
            return user is null ? Results.NotFound() : Results.Ok(user.ToDetailsDto());
        }).WithName("GetUser");


        group.MapPost("/", async (CreateUserDto newUser, ExamPlatformContext dbContext) => {
            User user = new(){
               
                Username = newUser.Username,
                Email = newUser.Email,
                Password = newUser.Password
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            
            return Results.CreatedAtRoute("GetUser", new {id = user.Id}, user.ToDetailsDto() );


        });

        return group;

    }

}
