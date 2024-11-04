using System;

namespace ExamPlatformBE.Entities;

public class UserAnswers
{

    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public required string Email { get; set; }

    public required string Password { get; set; }

}
