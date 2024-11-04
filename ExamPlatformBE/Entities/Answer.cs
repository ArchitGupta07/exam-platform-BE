using System;

namespace ExamPlatformBE.Entities;

public class Answer
{
    public int Id { get; set; }

    public int QuestionId { get; set; } 

    public required string Content { get; set; } 

    public bool IsCorrect { get; set; }

    // public required Question Question { get; set; }

}
