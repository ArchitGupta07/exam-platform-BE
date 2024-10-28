using System.ComponentModel.DataAnnotations;

namespace ExamPlatformBE.Dtos;

public record class CreateUserDto(
    // int Id,
    [Required][StringLength(100)] string Username,
    [Required][StringLength(100)] string Email,
    [Required][StringLength(50)] string Password
);


