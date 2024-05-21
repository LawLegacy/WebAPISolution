namespace WebApi.Models.Class;

using System.ComponentModel.DataAnnotations;

#nullable enable

 

public class ClassModel
{
    [Required]
    public int ClassId { get; set; }
    [Required]
    public int SchoolId { get; set; }
    [Required]
    public int TeacherId { get; set; }
    [Required]
    public string? Subject { get; set; }
}

 