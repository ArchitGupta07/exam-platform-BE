using System;
using ExamPlatformBE.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamPlatformBE.Data;

public class ExamPlatformContext(DbContextOptions<ExamPlatformContext> options) : DbContext(options)
{

    public DbSet<User> Users => Set<User>();
    public DbSet<Exam> Exams => Set<Exam>();
    public DbSet<Question> Questions => Set<Question>();
    public DbSet<Answer> Answers => Set<Answer>();

}
