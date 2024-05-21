namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.School;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class SchoolController : ControllerBase
{
    private ISchoolService _schoolService;

    public SchoolController(
        ISchoolService schoolService)
    {
        _schoolService = schoolService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var students = _schoolService.GetAll();
        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _schoolService.GetById(id);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(SchoolModel model)
    {
        _schoolService.Create(model);
        return Ok(new { message = "School created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, SchoolModel model)
    {
        _schoolService.Update(id, model);
        return Ok(new { message = "School updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _schoolService.Delete(id);
        return Ok(new { message = "School deleted" });
    }
}