using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.CourseBranchDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using Microsoft.AspNetCore.Mvc;

namespace HK.VocationalSchoolAutomason.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseBranchController : ControllerBase
    {
        private readonly ICourseBranch _service;

        public CourseBranchController(ICourseBranch service)
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
            var Response = await _service.GetById<CourseBranchListDto>(id);
            return Ok(Response);

        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromQuery] CourseBranchCreateDto dto)
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
        public async Task<IActionResult> Update([FromBody] CourseBranchUpdateDto dto)
        {
            var response = await _service.Update(dto);
            return Ok(response);


        }

    }
}
