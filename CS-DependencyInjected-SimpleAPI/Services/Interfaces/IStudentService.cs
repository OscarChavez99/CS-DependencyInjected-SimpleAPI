using CS_DependencyInjected_SimpleAPI.Models;

namespace CS_DependencyInjected_SimpleAPI.Repositories.Interfaces
{
    public interface IStudentService
    {
        Task<ApiResponse> GetAllStudents();
        Task<ApiResponse> GetStudentById(int id);
        Task<ApiResponse> Post(Student student);
        Task<ApiResponse> Put(Student student);
        Task<ApiResponse> Delete(int id);
    }
}
