using System;

namespace ExamPlatformBE.Entities;


public enum QuestionType
{
    MultipleChoice,

    TrueFalse,

    Integer,

    Essay,

    FillInTheBlank
}

public class Question
{
    public int Id { get; set; }

    public int ExamId { get; set; } 

    public required string Content { get; set; } 

    public required string QuestionType { get; set; }  // E.g., Multiple Choice, True/False, etc

    public required Exam Exam { get; set; }

}