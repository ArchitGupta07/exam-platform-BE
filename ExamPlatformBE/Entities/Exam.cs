using System;

namespace ExamPlatformBE.Entities;

public class Exam
{
    public int Id { get; set; }

    public required string Title { get; set; } = string.Empty;

    public required string Description { get; set; }

    public required int TotalMarks { get; set; }

    public required int Duration { get; set; }
}
