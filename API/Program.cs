using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi.Helpers;
using WebApi.Repositories;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddSingleton<DataContext>();

    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses 
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        // ignore omitted parameters on models to enable optional params 
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

    services.AddSwaggerGen();
    

    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // configure DI for application services
    services.AddScoped<ISchoolRepository, SchoolRepository>();
    services.AddScoped<ISchoolService, SchoolService>();
    services.AddScoped<IClassRepository, ClassRepository>();
    services.AddScoped<IClassService, ClassService>();
    services.AddScoped<IGradeRepository, GradeRepository>();
    services.AddScoped<IGradeService, GradeService>();
    services.AddScoped<IStudentRepository, StudentRepository>();
    services.AddScoped<IStudentService, StudentService>();
    services.AddScoped<ITeacherRepository, TeacherRepository>();
    services.AddScoped<ITeacherService, TeacherService>();
}

var app = builder.Build();
 

// ensure database and tables exist
{
    using var scope = app.Services.CreateScope();
   
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    await context.Init();
}

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.MapControllers();
}

app.Run("http://localhost:4000");