namespace WebApi.Models.Grade;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

#nullable enable


public class GradeModel
{
    public int GradeId { get; set; }
    public string? Value { get; set; }
}
