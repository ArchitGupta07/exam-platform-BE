using System.ComponentModel.DataAnnotations;

namespace ExamPlatformBE.Dtos;

public record class CreateExamDto
(
    [Required][StringLength(100)] string Title,
    [Required][StringLength(100)] string Description,
    [Required] int TotalMarks,
    [Required] int Duration
);

