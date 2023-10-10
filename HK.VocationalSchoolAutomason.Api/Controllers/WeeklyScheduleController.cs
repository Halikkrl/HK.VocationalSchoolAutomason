using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.WeeklyScheduleDtos;
using Microsoft.AspNetCore.Mvc;

namespace HK.VocationalSchoolAutomason.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeeklyScheduleController : ControllerBase
    {
        private readonly IWeeklySchedule _service;

        public WeeklyScheduleController(IWeeklySchedule service)
        {
            _service = service;
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
            var Response = await _service.GetById<WeeklyScheduleListDto>(id);
            return Ok(Response);

        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromQuery] WeeklyScheduleCreateDto dto)
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
        public async Task<IActionResult> Update([FromBody] WeeklyScheduleUpdateDto dto)
        {
            var response = await _service.Update(dto);
            return Ok(response);


        }


    }
}
