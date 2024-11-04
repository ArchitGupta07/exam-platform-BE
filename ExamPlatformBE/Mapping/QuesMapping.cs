using System;
using ExamPlatformBE.Dtos;
using ExamPlatformBE.Entities;

namespace ExamPlatformBE.Mapping;

public static class QuesMapping
{

 public static QuestionDto ToDto(this Question question, List<string> options)
{
    return new QuestionDto(
        question.Id,
        question.Content,
        options,  // Pass options from the Answers table
        question.QuestionType
        
    );
}
}
