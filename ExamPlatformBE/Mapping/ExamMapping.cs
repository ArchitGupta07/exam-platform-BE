using System;
using ExamPlatformBE.Dtos;
using ExamPlatformBE.Entities;

namespace ExamPlatformBE.Mapping;

public static class ExamMapping
{

      public static ExamDto ToDetailsDto(this Exam exam)
    {
            return new(
                    exam.Id,
                    exam.Title,
                    exam.Description,
                    exam.TotalMarks,
                    exam.Duration
                   
                );
    }
      public static ExamDto ToDto(this Exam exam)
    {
            return new(
                    exam.Id,
                    exam.Title,
                    exam.Description,
                    exam.TotalMarks,
                    exam.Duration
                );
    }

}

