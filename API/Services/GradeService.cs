namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Repositories;
using WebApi.Models.Grade;
using System.Reflection;


public interface IGradeService
{
    Task<IEnumerable<Grade>> GetAll();
    Task<Grade> GetById(int id);
    Task Create(GradeModel model);
    Task Update(int id, GradeModel model);
    Task Delete(int id);
}

public class GradeService : IGradeService
{
    private IGradeRepository _gradeRepository;
    private readonly IMapper _mapper;

    public GradeService(
        IGradeRepository GradeRepository,
        IMapper mapper)
    {
        _gradeRepository = GradeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Grade>> GetAll()
    {
        return await _gradeRepository.GetAll();
    }

    public async Task<Grade> GetById(int id)
    {
        var grade = await _gradeRepository.GetById(id);

        if (grade == null)
            throw new KeyNotFoundException("Grade not found");

        return grade;
    }

    public async Task Create(GradeModel model)
    {
        var grade = _mapper.Map<Grade>(model);

        // save Grade 
        await _gradeRepository.Create(grade);
    }

    public async Task Update(int id, GradeModel model)
    {
        var grade = await _gradeRepository.GetById(id);

        if (grade == null)
            throw new KeyNotFoundException("Grade not found");

        // copy model props to Grade
        _mapper.Map(model, grade);

        // save Grade
        await _gradeRepository.Update(grade);
    }

    public async Task Delete(int id)
    {
        await _gradeRepository.Delete(id);
    }

}