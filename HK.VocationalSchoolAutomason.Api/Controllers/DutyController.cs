using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DutiesDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.EmployeeDtos;
using Microsoft.AspNetCore.Mvc;

namespace HK.VocationalSchoolAutomason.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DutyController : ControllerBase
    {
        private readonly InterfaceGenel<DutyListDto, DutyCreateDto, DutyUpdateDto> _service;

        public DutyController(InterfaceGenel<DutyListDto, DutyCreateDto, DutyUpdateDto> duty)
        {
            _service = duty;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Response = await _service.GetAllStudents();
            return Ok(Response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Response = await _service.GetById<DutyListDto>(id);
            return Ok(Response);

        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromQuery] DutyCreateDto dto)
        {
            var response = await _service.Create(dto);
            return Created(string.Empty, response);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _service.Remove(id);
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DutyUpdateDto dto)
        {
            var response = await _service.Update(dto);
            return Ok(response);


        }
    }
}
