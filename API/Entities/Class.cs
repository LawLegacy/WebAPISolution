using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;
#nullable enable

public class Class
{
    [Key]
    public int ClassId { get; set; }
    public int SchoolId { get; set; }
    public int TeacherId { get; set; }
    public string? Subject { get; set; }
}
