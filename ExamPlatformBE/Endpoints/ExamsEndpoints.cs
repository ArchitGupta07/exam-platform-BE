using System;
using ExamPlatformBE.Data;
using ExamPlatformBE.Dtos;
using ExamPlatformBE.Entities;
using ExamPlatformBE.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ExamPlatformBE.Endpoints;

public static class ExamsEndpoints
{
    public static RouteGroupBuilder MapExamsEndpoint(this WebApplication app){

        var group = app.MapGroup("exams").WithParameterValidation();

        group.MapGet("/", (ExamPlatformContext dbContext) => dbContext.Exams
                            .Select(exam =>exam.ToDto())
                            .AsNoTracking()
                            .ToListAsync());


        group.MapGet("/{id}", async (int id, ExamPlatformContext dbContext ) => {


            Exam? exam = await dbContext.Exams.FindAsync(id);   

            return exam is null ? Results.NotFound() : Results.Ok(exam.ToDto());
        }).WithName("GetExam");



        group.MapPost("/", async (CreateExamDto newExam, ExamPlatformContext dbContext) => {
            Exam exam = new(){
               
                Title = newExam.Title,
                Description = newExam.Description,
                TotalMarks = newExam.TotalMarks,
                Duration = newExam.Duration
            };

            dbContext.Exams.Add(exam);
            await dbContext.SaveChangesAsync();
            
            return Results.CreatedAtRoute("GetExam", new {id = exam.Id}, exam.ToDto() );
           
        });

        return group;

    }


}
