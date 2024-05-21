namespace WebApi.Models.School;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

#nullable enable

public class SchoolModel
{
    [Required]
    public string? Name { get; set; }
}