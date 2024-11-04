using System.ComponentModel.DataAnnotations;

namespace ExamPlatformBE.Dtos;

public record class CreateQuesDto
(
    [Required] string Content ,
    // [Required][StringLength(50)] string Content ,

    List<string>? Options ,
    [Required]  string Answer ,
    [Required]  string QuestionType 
);
