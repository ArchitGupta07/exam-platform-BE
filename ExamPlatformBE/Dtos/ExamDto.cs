namespace ExamPlatformBE.Dtos;

public record class ExamDto
(
    int Id, 
    string Title, 
    string Description, 
    int TotalMarks,
    int Duration
);

