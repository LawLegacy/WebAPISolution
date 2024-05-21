namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Grade;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class GradeController : ControllerBase
{
    private IGradeService _gradeService;

    public GradeController(
        IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var grades = _gradeService.GetAll();
        return Ok(grades);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var grades = _gradeService.GetById(id);
        return Ok(grades);
    }

    [HttpPost]
    public IActionResult Create(GradeModel model)
    {
        _gradeService.Create(model);
        return Ok(new { message = "Grade created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, GradeModel model)
    {
        _gradeService.Update(id, model);
        return Ok(new { message = "Grade updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _gradeService.Delete(id);
        return Ok(new { message = "Grade deleted" });
    }
}