using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;
#nullable enable

public class Student
{
    [Key]
    public int StudentId { get; set; }
    public string? Name { get; set; }
}
