using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeRegistrationDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HK.VocationalSchoolAutomason.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeRegistrationController : ControllerBase
    {
        private readonly IEmployeeInformationAll _employee;

        public EmployeeRegistrationController(IEmployeeInformationAll employee)
        {
            _employee = employee;
        }

        [HttpGet]
        public IActionResult GetAllJoins()
        {
            var result = _employee.GetAllEmployee();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromQuery]EmployeeRegistrationCreateDto dto)
        {
            var response = await _employee.Create(dto);
            return Created(string.Empty, response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _employee.Remove(id);
            return Ok(response);
        }
    }
}
