using CS_DependencyInjected_SimpleAPI.Models;
using CS_DependencyInjected_SimpleAPI.Repositories.Interfaces;

namespace CS_DependencyInjected_SimpleAPI.Repositories
{
    public class StudentService: IStudentService
    {
        private readonly IStudentRepository iStudentRepository;
        private readonly ILogger<StudentService> iLogger;

        public StudentService(IStudentRepository iStudentRepository,
            ILogger<StudentService> iLogger)
        {
            this.iStudentRepository = iStudentRepository;
            this.iLogger = iLogger;
        }

        public async Task<ApiResponse> GetAllStudents()
        {
            ApiResponse apiRespose = await iStudentRepository.GetAllStudents();

            if (!apiRespose.Status)
            {
                iLogger.LogError(apiRespose.Message);                
            }

            return apiRespose;
        }

        public async Task<ApiResponse> GetStudentById(int id)
        {
            ApiResponse apiResponse = await iStudentRepository.GetStudentById(id);

            if (!apiResponse.Status)
            {
                iLogger.LogError(apiResponse.Message);
            }

            return apiResponse;
        }

        public async Task<ApiResponse> Post(Student student)
        {
            ApiResponse apiResponse = await iStudentRepository.Post(student);

            if (!apiResponse.Status)
            {
                iLogger.LogError(apiResponse.Message);
            }

            return apiResponse;
        }

        public async Task<ApiResponse> Put(Student student)
        {
            ApiResponse apiResponse = await iStudentRepository.Put(student);

            if (!apiResponse.Status)
            {
                iLogger.LogError(apiResponse.Message);
            }

            return apiResponse;
        }

        public async Task<ApiResponse> Delete(int id)
        {
            ApiResponse apiResponse = await iStudentRepository.Delete(id);

            if (!apiResponse.Status)
            {
                iLogger.LogError(apiResponse.Message);
            }

            return apiResponse;
        }
    }
}
