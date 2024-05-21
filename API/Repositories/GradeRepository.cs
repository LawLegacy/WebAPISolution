namespace WebApi.Repositories;

using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Grade;

public interface IGradeRepository
{
    Task<IEnumerable<Grade>> GetAll();
    Task<Grade> GetById(int id);
    Task Create(Grade Grade);
    Task Update(Grade Grade);
    Task Delete(int id);
}

public class GradeRepository : IGradeRepository
{
    private DataContext _context;

    public GradeRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Grade>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM grades
        """;
        return await connection.QueryAsync<Grade>(sql);
    }

    public async Task<Grade> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM grades
            WHERE GradeId = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<Grade>(sql, new { id });
    }

    public async Task Create(Grade grade)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO grades (Name)
            VALUES (@Name)
        """;
        await connection.ExecuteAsync(sql, grade);
    }

    public async Task Update(Grade grade)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            UPDATE grades
            SET Name = @Name
            WHERE GradeId = @Id
        """;
        await connection.ExecuteAsync(sql, grade);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM grades 
            WHERE GradeId = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }
     
}