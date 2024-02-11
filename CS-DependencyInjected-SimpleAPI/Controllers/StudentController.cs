using CS_DependencyInjected_SimpleAPI.Models;
using CS_DependencyInjected_SimpleAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CS_DependencyInjected_SimpleAPI.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService iStudentService;
        private readonly ILogger<StudentController> iLogger;

        public StudentController(IStudentService iStudentService,
            ILogger<StudentController> iLogger)
        {
            this.iStudentService = iStudentService;
            this.iLogger = iLogger;
        }

        [HttpGet("GetAllStudents")]
        public async Task<ApiResponse> GetAllStudents()
        {
            ApiResponse apiResponse = await iStudentService.GetAllStudents();
            return apiResponse;
        }

        [HttpGet("GetStudentById/{id}")]
        public async Task<ApiResponse> GetStudentById(int id)
        {
            ApiResponse apiResponse = await iStudentService.GetStudentById(id);
            return apiResponse;
        }

        [HttpPost]
        public async Task<ApiResponse> Post([FromBody] Student student)
        {
            ApiResponse apiResponse = await iStudentService.Post(student);
            return apiResponse;
        }

        [HttpPut]
        public async Task<ApiResponse> Put([FromBody] Student student)
        {
            ApiResponse apiResponse = await iStudentService.Put(student);
            return apiResponse;
        }

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id)
        {
            ApiResponse apiResponse = await iStudentService.Delete(id);
            return apiResponse;
        }
    }
}
