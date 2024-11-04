using System;
using ExamPlatformBE.Data;
using ExamPlatformBE.Dtos;
using ExamPlatformBE.Entities;
using ExamPlatformBE.Mapping;
using Microsoft.EntityFrameworkCore;

namespace ExamPlatformBE.Endpoints;

public static class QuestionsEndpoints
{
    public static RouteGroupBuilder MapQuestionsEndpoint(this WebApplication app){

        var group = app.MapGroup("questions").WithParameterValidation();

        group.MapGet("/{examId}", async (ExamPlatformContext dbContext, int examId) =>
        {
            var questions = await dbContext.Questions
                .Where(question => question.ExamId == examId)
                .Select(question => new
                {
                    Question = question,
                    Options = dbContext.Answers
                        .Where(answer => answer.QuestionId == question.Id)
                        .Select(answer => answer.Content) 
                        .ToList()
                })
                .AsNoTracking()
                .ToListAsync();

            return questions.Select(q => q.Question.ToDto(q.Options)).ToList();
        });




        // group.MapGet("/{id}", async (int id, ExamPlatformContext dbContext ) => {


        //     Exam? exam = await dbContext.Exams.FindAsync(id);   

        //     return exam is null ? Results.NotFound() : Results.Ok(exam.ToDto());
        // }).WithName("GetExam");



        group.MapPost("/{examId:int}", async (int examId, List<CreateQuesDto> questions, ExamPlatformContext dbContext) =>
            {
              
                var exam = await dbContext.Exams.FindAsync(examId);
                if (exam == null)
                {
                    return Results.NotFound("Exam not found.");
                }
                foreach (var question in questions)
            {
                var ques = new Question
                {
                    Content = question.Content,
                    QuestionType = question.QuestionType,
                    ExamId = examId,
                    Exam = exam
                };

                dbContext.Questions.Add(ques);
                await dbContext.SaveChangesAsync();

                if (question.Options != null && question.Options.Any())
                {
                    foreach (var option in question.Options)
                    {
                        var isCorrect = option == question.Answer;

                        dbContext.Answers.Add(new Answer
                        {
                            Content = option,
                            IsCorrect = isCorrect,
                            QuestionId = ques.Id,
                            

                        });
                    }
                }
                else
                {
                    dbContext.Answers.Add(new Answer
                    {
                        Content = question.Answer,
                        IsCorrect = true,
                        QuestionId = ques.Id
                    });
                }

                await dbContext.SaveChangesAsync();
            }

            return Results.Ok("Questions inserted in table");
            // return Results.CreatedAtRoute("GetUser", new {id = user.Id}, user.ToDetailsDto() );

            });


        return group;

    }

}
