namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Repositories;
using WebApi.Models.Teacher;
using System.Reflection;


public interface ITeacherService
{
    Task<IEnumerable<Teacher>> GetAll();
    Task<Teacher> GetById(int id);
    Task Create(TeacherModel model);
    Task Update(int id, TeacherModel model);
    Task Delete(int id);
    Task<int> GradeOfTeacherStudent(int teacherId);
  
}

public class TeacherService : ITeacherService
{
    private ITeacherRepository _teacherRepository;
    private readonly IMapper _mapper;

    public TeacherService(
        ITeacherRepository TeacherRepository,
        IMapper mapper)
    {
        _teacherRepository = TeacherRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Teacher>> GetAll()
    {
        return await _teacherRepository.GetAll();
    }
    public async Task<int> GradeOfTeacherStudent(int teacherId)
    {
        var teacher = await _teacherRepository.GradeOfTeacherStudent(teacherId);

        return teacher;
    }
    public async Task<Teacher> GetById(int id)
    {
        var teacher = await _teacherRepository.GetById(id);

        if (teacher == null)
            throw new KeyNotFoundException("Teacher not found");

        return teacher;
    }

    public async Task Create(TeacherModel model)
    {
        var teacher = _mapper.Map<Teacher>(model);

        // save Teacher 
        await _teacherRepository.Create(teacher);
    }

    public async Task Update(int id, TeacherModel model)
    {
        var teacher = await _teacherRepository.GetById(id);

        if (teacher == null)
            throw new KeyNotFoundException("Teacher not found");

        // copy model props to Teacher
        _mapper.Map(model, teacher);

        // save Teacher
        await _teacherRepository.Update(teacher);
    }

    public async Task Delete(int id)
    {
        await _teacherRepository.Delete(id);
    }

}