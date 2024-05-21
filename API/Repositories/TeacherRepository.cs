namespace WebApi.Repositories;

using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Teacher;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetAll();
    Task<Teacher> GetById(int id);
    Task Create(Teacher Teacher);
    Task Update(Teacher Teacher);
    Task Delete(int id);
    Task<int> GradeOfTeacherStudent(int id);
   
}

public class TeacherRepository : ITeacherRepository
{
    private DataContext _context;

    public TeacherRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<int> GradeOfTeacherStudent(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT avg(g.Value) FROM Teachers t Inner Join
            Classes c on t.TeacherId = c.TeacherId Inner Join
            Grades g on c.ClassId = g.ClassId

            WHERE t.TeacherId = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<int>(sql, new { id });
    }


    public async Task<IEnumerable<Teacher>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Teachers
        """;
        return await connection.QueryAsync<Teacher>(sql);
    }

    public async Task<Teacher> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Teachers 
            WHERE TeacherId = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<Teacher>(sql, new { id });
    }

    public async Task Create(Teacher teacher)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO Teachers (Name)
            VALUES (@Name)
        """;
        await connection.ExecuteAsync(sql, teacher);
    }

    public async Task Update(Teacher teacher)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            UPDATE Teachers
            SET Name = @Name
            WHERE TeacherId = @Id
        """;
        await connection.ExecuteAsync(sql, teacher);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM Teachers 
            WHERE TeacherId = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }
     
}