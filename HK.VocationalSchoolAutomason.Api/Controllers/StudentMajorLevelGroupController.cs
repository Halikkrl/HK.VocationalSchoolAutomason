using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.DayDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentMajorLevelGroupDtos;
using Microsoft.AspNetCore.Mvc;

namespace HK.VocationalSchoolAutomason.Api.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    //public class StudentMajorLevelGroupController : ControllerBase
    //{
    //    private readonly IStudentMajorLevelGroup _service;

    //    public StudentMajorLevelGroupController(IStudentMajorLevelGroup service)
    //    {
    //        _service = service;
    //    }


    //    [HttpGet]
    //    public async Task<IActionResult> GetAll()
    //    {
    //        var Response = await _service.GetAllStudents();
    //        return Ok(Response);
    //    }

    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GetById(int id)
    //    {
    //        var Response = await _service.GetById<StudentMajorLevelGroupListDto>(id);
    //        return Ok(Response);

    //    }


    //    [HttpPost]
    //    public async Task<IActionResult> CreateAsync([FromQuery] StudentMajorLevelGroupCreateDto dto)
    //    {
    //        var response = await _service.Create(dto);
    //        return Created(string.Empty, response);

    //    }


    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> Remove(int id)
    //    {
    //        var response = await _service.Remove(id);
    //        return Ok(response);
    //    }


    //    [HttpPut]
    //    public async Task<IActionResult> Update([FromBody] StudentMajorLevelGroupUpdateDto dto)
    //    {
    //        var response = await _service.Update(dto);
    //        return Ok(response);


    //    }


    //}
}
