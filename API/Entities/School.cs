using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;
#nullable enable

public class School
{
    [Key]
    public int SchoolId { get; set; }
    public string? Name { get; set; }
}
