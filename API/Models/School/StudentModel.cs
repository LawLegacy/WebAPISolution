namespace WebApi.Models.Student;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

#nullable enable

public class StudentModel
{
    public string? Name { get; set; }
}

public class AverageStudentGradeModel
{
    public string? Name { get; set; }
    public int AverageScore { get; set; }
}
