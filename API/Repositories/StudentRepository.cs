namespace WebApi.Repositories;

using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Student;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAll();
    Task<Student> GetById(int id);
    Task Create(Student Student);
    Task Update(Student Student);
    Task Delete(int id);
    Task<IEnumerable<AverageStudentGradeModel>> AverageGradeOfStudent();
}

public class StudentRepository : IStudentRepository
{
    private DataContext _context;

    public StudentRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AverageStudentGradeModel>> AverageGradeOfStudent()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT s.Name, g.Value as AverageScore FROM Students s Inner Join
            Grades g on s.StudentId = g.StudentId
            
        """;
        return await connection.QueryAsync<AverageStudentGradeModel>(sql);
    }

    public async Task<IEnumerable<Student>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Students
        """;
        return await connection.QueryAsync<Student>(sql);
    }

    public async Task<Student> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Students 
            WHERE StudentId = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<Student>(sql, new { id });
    }

    public async Task Create(Student student)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO Students (Name)
            VALUES (@Name)
        """;
        await connection.ExecuteAsync(sql, student);
    }

    public async Task Update(Student student)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            UPDATE Students
            SET Name = @Name
            WHERE StudentId = @Id
        """;
        await connection.ExecuteAsync(sql, student);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM Students 
            WHERE StudentId = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }

    

}