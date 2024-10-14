using System;

namespace ExamPlatformBE.Entities;

public class User
{

    public int id { get; set; }

    public string username { get; set; } = string.Empty;

    public required string email { get; set; }

    public required string Password { get; set; }

}
