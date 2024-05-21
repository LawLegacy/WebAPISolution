namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Repositories;
using WebApi.Models.School;
using System.Reflection;


public interface ISchoolService
{
    Task<IEnumerable<School>> GetAll();
    Task<School> GetById(int id);
    Task Create(SchoolModel model);
    Task Update(int id, SchoolModel model);
    Task Delete(int id);
}

public class SchoolService : ISchoolService
{
    private ISchoolRepository _schoolRepository;
    private readonly IMapper _mapper;

    public SchoolService(
        ISchoolRepository SchoolRepository,
        IMapper mapper)
    {
        _schoolRepository = SchoolRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<School>> GetAll()
    {
        return await _schoolRepository.GetAll();
    }

    public async Task<School> GetById(int id)
    {
        var school = await _schoolRepository.GetById(id);

        if (school == null)
            throw new KeyNotFoundException("School not found");

        return school;
    }

    public async Task Create(SchoolModel model)
    {
        var school = _mapper.Map<School>(model);

        // save School 
        await _schoolRepository.Create(school);
    }

    public async Task Update(int id, SchoolModel model)
    {
        var school = await _schoolRepository.GetById(id);

        if (school == null)
            throw new KeyNotFoundException("School not found");

        // copy model props to School
        _mapper.Map(model, school);

        // save School
        await _schoolRepository.Update(school);
    }

    public async Task Delete(int id)
    {
        await _schoolRepository.Delete(id);
    }

}