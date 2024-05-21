namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Repositories;
using WebApi.Models.Student;
using System.Reflection;
using Microsoft.EntityFrameworkCore;


public interface IStudentService
{
    Task<IEnumerable<Student>> GetAll();
    Task<Student> GetById(int id);
    Task Create(StudentModel model);
    Task Update(int id, StudentModel model);
    Task Delete(int id);
    Task<IEnumerable<AverageStudentGradeModel>> AverageGradeOfStudent();
}

public class StudentService : IStudentService
{
    private IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(
        IStudentRepository StudentRepository,
        IMapper mapper)
    {
        _studentRepository = StudentRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AverageStudentGradeModel>> AverageGradeOfStudent()
    {
        return await _studentRepository.AverageGradeOfStudent();
    }

    public async Task<IEnumerable<Student>> GetAll()
    {
        return await _studentRepository.GetAll();
    }

    public async Task<Student> GetById(int id)
    {
        var student = await _studentRepository.GetById(id);

        if (student == null)
            throw new KeyNotFoundException("Student not found");

        return student;
    }

    public async Task Create(StudentModel model)
    {
        var student = _mapper.Map<Student>(model);

        // save Student 
        await _studentRepository.Create(student);
    }

    public async Task Update(int id, StudentModel model)
    {
        var student = await _studentRepository.GetById(id);

        if (student == null)
            throw new KeyNotFoundException("Student not found");

        // copy model props to Student
        _mapper.Map(model, student);

        // save Student
        await _studentRepository.Update(student);
    }

    public async Task Delete(int id)
    {
        await _studentRepository.Delete(id);
    }

}