namespace ExamPlatformBE.Dtos;

public record class UserDto
(
    int Id, 
    string Username, 
    string Email, 
    string Password
);
