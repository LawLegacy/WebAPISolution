namespace WebApi.Repositories;

using AutoMapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.School;

public interface ISchoolRepository
{
    Task<IEnumerable<School>> GetAll();
    Task<School> GetById(int id);
    Task Create(School School);
    Task Update(School School);
    Task Delete(int id);
}

public class SchoolRepository : ISchoolRepository
{
    private DataContext _context;

    public SchoolRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<School>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Schools
        """;
        return await connection.QueryAsync<School>(sql);
    }

    public async Task<School> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            SELECT * FROM Schools 
            WHERE SchoolId = @id
        """;
        return await connection.QuerySingleOrDefaultAsync<School>(sql, new { id });
    }

    public async Task Create(School school)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            INSERT INTO Schools (Name)
            VALUES (@Name)
        """;
        await connection.ExecuteAsync(sql, school);
    }

    public async Task Update(School school)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            UPDATE Schools
            SET Name = @Name
            WHERE SchoolId = @Id
        """;
        await connection.ExecuteAsync(sql, school);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = """
            DELETE FROM Schools 
            WHERE SchoolId = @id
        """;
        await connection.ExecuteAsync(sql, new { id });
    }
     
}