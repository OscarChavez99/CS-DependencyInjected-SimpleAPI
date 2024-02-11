using CS_DependencyInjected_SimpleAPI.Models;
using CS_DependencyInjected_SimpleAPI.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Transactions;

namespace CS_DependencyInjected_SimpleAPI.Repositories
{
    public class StudentRepository: IStudentRepository
    {
        private readonly IDbConnection iConnection;

        public StudentRepository(IConfiguration iConfigurarion)
        {
            // Initializing connection using the MySQL connection string from 'appsettings.json'
            iConnection = new MySqlConnection(iConfigurarion.
                GetSection("ConnectionStrings")["MySQL"]);
        }

        public async Task<ApiResponse> GetAllStudents()
        {
            ApiResponse apiResponse = new() { Status = true };

            try
            {
                using (iConnection)
                {
                    if (iConnection.State != ConnectionState.Open)
                    {
                        iConnection.Open();
                    }

                    var sqlBuilder = new SqlBuilder();
                    var template   = sqlBuilder.AddTemplate("SELECT * FROM students");

                    List<Student> studentsList = (await iConnection.
                        QueryAsync<Student>(template.RawSql, template.Parameters)).
                        ToList();

                    apiResponse.Data    = studentsList;
                    apiResponse.Message = "Students retrieved successfully";
                }
            }
            catch (Exception ex)
            {
                apiResponse.Status = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

        public async Task<ApiResponse> GetStudentById(int id)
        {
            ApiResponse apiResponse = new() { Status = true };

            try
            {
                using (iConnection)
                {
                    if (iConnection.State != ConnectionState.Open)
                    {
                        iConnection.Open();
                    }

                    var sqlBuilder = new SqlBuilder();
                    var template   = sqlBuilder.AddTemplate("SELECT * FROM students " +
                        "WHERE id = @id");
                    var parameter  = new DynamicParameters();
                    parameter.Add("@id", id);

                    Student? student = (await iConnection.
                        QueryAsync<Student>(template.RawSql, parameter)).
                        FirstOrDefault();

                    if (student != null)
                    {
                        apiResponse.Data = student;
                        apiResponse.Message = "Student retrieved successfully";
                    }
                    else
                    {
                        apiResponse.Message = "No student found with ID " + id;
                    }

                }
            }
            catch(Exception ex)
            {
                apiResponse.Status = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

        public async Task<ApiResponse> Post(Student student)
        {
            ApiResponse apiResponse = new() { Status = true };

            try
            {
                using (iConnection)
                {
                    if (iConnection.State != ConnectionState.Open)
                    {
                        iConnection.Open();
                    }

                    var sqlBuilder = new SqlBuilder();
                    var template = sqlBuilder.AddTemplate("INSERT INTO students " +
                        "(id, name, age) " +
                        "VALUES " +
                        "(@id, @name, @age)");
                    var parameters = new DynamicParameters();
                    parameters.Add("@id", student.ID);
                    parameters.Add("@name", student.Name);
                    parameters.Add("@age", student.Age);

                    await iConnection.ExecuteAsync(template.RawSql, parameters);

                    apiResponse.Message = "Student inserted successfully";
                }
            }
            catch (Exception ex)
            {
                apiResponse.Status = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

        public async Task<ApiResponse> Put(Student student)
        {
            ApiResponse apiResponse = new() { Status = true };

            if (iConnection.State != ConnectionState.Open)
            {
                iConnection.Open();
            }

            using (var transaction = iConnection.BeginTransaction())
            {
                try
                {
                    var sqlBuilder = new SqlBuilder();
                    var template   = sqlBuilder.AddTemplate("UPDATE students " +
                        "SET " +
                        "name = @name, age = @age " +
                        "WHERE id = @id");

                    var parameters = new DynamicParameters();
                    parameters.Add("@name", student.Name);
                    parameters.Add("@age" , student.Age);
                    parameters.Add("@id"  , student.ID);

                    await iConnection.ExecuteAsync(template.RawSql, parameters,
                        transaction);
                    transaction.Commit();

                    apiResponse.Message = "Student updated successfully";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    apiResponse.Status = false;
                    apiResponse.Message = ex.Message;
                }

            }
                
            return apiResponse;
        }

        public async Task<ApiResponse> Delete(int id)
        {
            ApiResponse apiResponse = new() { Status = true };

            try
            {
                using (iConnection)
                {
                    if (iConnection.State != ConnectionState.Open)
                    {
                        iConnection.Open();
                    }

                    var sqlBuilder = new SqlBuilder();
                    var template   = sqlBuilder.AddTemplate("DELETE FROM students " +
                        "WHERE id = @id");
                    var parameter  = new DynamicParameters();
                    parameter.Add("@id", id);
                    await iConnection.ExecuteAsync(template.RawSql, parameter);

                    apiResponse.Message = "Student deleted successfully";
                }
            }
            catch (Exception ex)
            {
                apiResponse.Status = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

    }
}
