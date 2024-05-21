using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;
#nullable enable

public class Teacher
{
    [Key]
    public int TeacherId { get; set; }
    public string? Name { get; set; }
}
