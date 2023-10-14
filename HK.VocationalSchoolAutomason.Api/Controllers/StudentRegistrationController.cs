using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentRegistrationDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HK.VocationalSchoolAutomason.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegistrationController : ControllerBase
    {
        private readonly IStudentRegistration _service;

        public StudentRegistrationController(IStudentRegistration service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllJoins()
        {
            var result = _service.GetAllStudents();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromQuery] StudentRegistrationCreateDto dto)
        {
            var response = await _service.Create(dto);
            return Created(string.Empty, response);

        }

    }
}
