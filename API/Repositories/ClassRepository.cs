namespace WebApi.Repositories;

using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Class;

public interface IClassRepository
{
    Task<IEnumerable<Class>> GetAll();
    Task<Class> GetById(int id);
    Task Create(Class Class);
    Task Update(Class Class);
    Task Delete(int id);
}

public class ClassRepository : IClassRepository
{
    private DataContext _context;

    public ClassRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Class>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM classes
        """;
        return await connection.QueryAsync<Class>(sql);
    }

    public async Task<Class> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM classes 
            WHERE ClassId = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<Class>(sql, new { id });
    }

    public async Task Create(Class classes)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO classes (Name)
            VALUES (@Name)
        """;
        await connection.ExecuteAsync(sql, classes);
    }

    public async Task Update(Class classes)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            UPDATE classes
            SET Name = @Name
            WHERE ClassId = @Id
        """;
        await connection.ExecuteAsync(sql, classes);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM classes 
            WHERE ClassId = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }
     
}