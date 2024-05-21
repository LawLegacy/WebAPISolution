using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;
#nullable enable

public class Grade
{
    [Key]
    public int ClassId { get; set; }
    public int StudentId { get; set; }
    public string? Value { get; set; }
}
