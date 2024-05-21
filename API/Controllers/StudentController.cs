namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Student;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private IStudentService _studentService;

    public StudentController(
        IStudentService studentService)
    {
        _studentService = studentService;
    }

   
    [HttpGet("AverageGradeOfStudent")]
    public IActionResult AverageGradeOfStudent()
    {
        var student = _studentService.AverageGradeOfStudent();
        return Ok(student);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var student = _studentService.GetAll();
        return Ok(student);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = _studentService.GetById(id);
        return Ok(student);
    }

    [HttpPost]
    public IActionResult Create(StudentModel model)
    {
        _studentService.Create(model);
        return Ok(new { message = "Student created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, StudentModel model)
    {
        _studentService.Update(id, model);
        return Ok(new { message = "Student updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _studentService.Delete(id);
        return Ok(new { message = "Student deleted" });
    }
}