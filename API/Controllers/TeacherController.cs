namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Teacher;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private ITeacherService _teacherService;

    public TeacherController(
        ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet("{id}/teachid")]
    public IActionResult GradeOfTeacherStudent(int id)
    {
        var teacher = _teacherService.GradeOfTeacherStudent(id);
        return Ok(teacher);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var teacher = _teacherService.GetAll();
        return Ok(teacher);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var teacher = _teacherService.GetById(id);
        return Ok(teacher);
    }

    [HttpPost]
    public IActionResult Create(TeacherModel model)
    {
        _teacherService.Create(model);
        return Ok(new { message = "Teacher created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, TeacherModel model)
    {
        _teacherService.Update(id, model);
        return Ok(new { message = "Teacher updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _teacherService.Delete(id);
        return Ok(new { message = "Teacher deleted" });
    }
}