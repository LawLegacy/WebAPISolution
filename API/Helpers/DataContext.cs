namespace WebApi.Helpers;

using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;

public class DataContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(Configuration.GetConnectionString("WebApiDatabase"));
    }

    public async Task Init()
    {
        using var connection = CreateConnection();

        await _initSchools();
        await _initStudents();
        await _initTeachers();
        await _initClasses();
        await _initGrades();  

        async Task _initSchools()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS 
                Schools (
                    SchoolId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );
                INSERT OR REPLACE INTO Schools (SchoolId, Name) VALUES (1,'Senior High');
                INSERT OR REPLACE INTO Schools (SchoolId, Name) VALUES (2,'Roberts Middle School');
                INSERT OR REPLACE INTO Schools (SchoolId, Name) VALUES (3,'Janes Elementary');
                INSERT OR REPLACE INTO Schools (SchoolId, Name) VALUES (4,'West Academy');
            """;
            await connection.ExecuteAsync(sql);
        }

        async Task _initStudents()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS 
                Students (
                    StudentId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );
                INSERT OR REPLACE INTO Students (StudentId, Name) VALUES (1,'Earl');
                INSERT OR REPLACE INTO Students (StudentId, Name) VALUES (2,'Farah');
                INSERT OR REPLACE INTO Students (StudentId, Name) VALUES (3,'Gus');
                INSERT OR REPLACE INTO Students (StudentId, Name) VALUES (4,'Harriet');
                INSERT OR REPLACE INTO Students (StudentId, Name) VALUES (5,'Julio');
                INSERT OR REPLACE INTO Students (StudentId, Name) VALUES (6,'Kate');
                INSERT OR REPLACE INTO Students (StudentId, Name) VALUES (7,'Less');
                INSERT OR REPLACE INTO Students (StudentId, Name) VALUES (8,'Mary');
            """;
            await connection.ExecuteAsync(sql);
        }

        async Task _initTeachers()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS 
                Teachers (
                    TeacherId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );
                INSERT OR REPLACE INTO Teachers (TeacherId, Name) VALUES (1,'Alert');
                INSERT OR REPLACE INTO Teachers (TeacherId, Name) VALUES (2,'Beth');
                INSERT OR REPLACE INTO Teachers (TeacherId, Name) VALUES (3,'Charlie');
                INSERT OR REPLACE INTO Teachers (TeacherId, Name) VALUES (4,'Daisy');
            """;
            await connection.ExecuteAsync(sql);
        }

        async Task _initClasses()
        {
            var sql = """
                CREATE TABLE IF NOT EXISTS 
                Classes (
                    ClassId INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    StudentId INTEGER NOT NULL,
                    TeacherId INTEGER NOT NULL,
                    Subject TEXT NOT NULL
                );
                INSERT OR REPLACE INTO Classes (ClassId, StudentId, TeacherId, Subject) VALUES (1, 1, 4, 'CS');
                INSERT OR REPLACE INTO Classes (ClassId, StudentId, TeacherId, Subject) VALUES (2, 2, 3, 'Math');
                INSERT OR REPLACE INTO Classes (ClassId, StudentId, TeacherId, Subject) VALUES (3, 3, 2, 'Physics');
                INSERT OR REPLACE INTO Classes (ClassId, StudentId, TeacherId, Subject) VALUES (4, 4, 1, 'English');
                INSERT OR REPLACE INTO Classes (ClassId, StudentId, TeacherId, Subject) VALUES (5, 1, 4, 'Art');
                INSERT OR REPLACE INTO Classes (ClassId, StudentId, TeacherId, Subject) VALUES (6, 2, 3, 'History');

            """;
            await connection.ExecuteAsync(sql);
        }

        async Task _initGrades()
        {
            var sql = """
                DROP TABLE IF EXISTS GRADES;
                CREATE TABLE IF NOT EXISTS 
                Grades (
                    ClassId INTEGER NOT NULL,
                    StudentId INTEGER NOT NULL,
                    Value INTEGER NOT NULL
                );
                INSERT OR REPLACE INTO Grades (ClassId, StudentId, Value) VALUES (1, 8, 92);
                INSERT OR REPLACE INTO Grades (ClassId, StudentId, Value) VALUES (2, 7, 87);
                INSERT OR REPLACE INTO Grades (ClassId, StudentId, Value) VALUES (3, 6, 72);
                INSERT OR REPLACE INTO Grades (ClassId, StudentId, Value) VALUES (4, 5, 83);
                INSERT OR REPLACE INTO Grades (ClassId, StudentId, Value) VALUES (5, 4, 94);
                INSERT OR REPLACE INTO Grades (ClassId, StudentId, Value) VALUES (6, 3, 97);
                INSERT OR REPLACE INTO Grades (ClassId, StudentId, Value) VALUES (1, 2, 86);
                INSERT OR REPLACE INTO Grades (ClassId, StudentId, Value) VALUES (3, 1, 65);
                INSERT OR REPLACE INTO Grades (ClassId, StudentId, Value) VALUES (3, 8, 77);
            """;
            await connection.ExecuteAsync(sql);
        }
       
    }
}