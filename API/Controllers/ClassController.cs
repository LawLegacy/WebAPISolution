namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Class;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class ClassController : ControllerBase
{
    private IClassService _classService;

    public ClassController(
        IClassService classService)
    {
        _classService = classService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var classs = _classService.GetAll();
        return Ok(classs);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var classes = _classService.GetById(id);
        return Ok(classes);
    }

    [HttpPost]
    public IActionResult Create(ClassModel model)
    {
        _classService.Create(model);
        return Ok(new { message = "Class created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, ClassModel model)
    {
        _classService.Update(id, model);
        return Ok(new { message = "Class updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _classService.Delete(id);
        return Ok(new { message = "Class deleted" });
    }
}