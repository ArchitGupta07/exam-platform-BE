namespace ExamPlatformBE.Dtos;

public record class QuestionDto
(
    int Id, 
    string Content ,
    List<string>? Options ,
   
    string QuestionType 

);
