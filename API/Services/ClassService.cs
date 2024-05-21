namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Repositories;
using WebApi.Models.Class;
using System.Reflection;


public interface IClassService
{
    Task<IEnumerable<Class>> GetAll();
    Task<Class> GetById(int id);
    Task Create(ClassModel model);
    Task Update(int id, ClassModel model);
    Task Delete(int id);
}

public class ClassService : IClassService
{
    private IClassRepository _classRepository;
    private readonly IMapper _mapper;

    public ClassService(
        IClassRepository ClassRepository,
        IMapper mapper)
    {
        _classRepository = ClassRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<Class>> GetAll()
    {
        return await _classRepository.GetAll();
    }

    public async Task<Class> GetById(int id)
    {
        var classes = await _classRepository.GetById(id);

        if (classes == null)
            throw new KeyNotFoundException("Class not found");

        return classes;
    }

    public async Task Create(ClassModel model)
    {
        var classes = _mapper.Map<Class>(model);

        // save Class 
        await _classRepository.Create(classes);
    }

    public async Task Update(int id, ClassModel model)
    {
        var classes = await _classRepository.GetById(id);

        if (classes == null)
            throw new KeyNotFoundException("Class not found");

        // copy model props to Class
        _mapper.Map(model, classes);

        // save Class
        await _classRepository.Update(classes);
    }

    public async Task Delete(int id)
    {
        await _classRepository.Delete(id);
    }

}