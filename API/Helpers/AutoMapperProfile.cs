namespace WebApi.Helpers;

using AutoMapper;
using WebApi.Entities;
using WebApi.Models.School;
using WebApi.Models.Class;
using WebApi.Models.Grade;
using WebApi.Models.Student;
using WebApi.Models.Teacher;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SchoolModel, School>();
        CreateMap<ClassModel, Class>();
        CreateMap<GradeModel, Grade>();
        CreateMap<StudentModel, Student>();
        CreateMap<TeacherModel, Teacher>();
    }
}