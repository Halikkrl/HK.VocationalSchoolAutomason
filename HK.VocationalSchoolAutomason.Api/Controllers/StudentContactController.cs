using AutoMapper;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Bussiness.Services;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentContactDtos;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HK.VocationalSchoolAutomason.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentContactController : ControllerBase
    {
        private readonly IStudentContactService _contactService;

        public StudentContactController(IStudentContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentsResponse = await _contactService.GetAllStudents();
            return Ok(studentsResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var studentResponse = await _contactService.GetById<StudentContactListDto>(id);
            return Ok(studentResponse);
            
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromQuery] StudentContactCreateDto student)
        {
            var response = await _contactService.Create(student);
            return Created(string.Empty, response);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _contactService.Remove(id);
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StudentContactUpdateDto dto)
        {
            var response = await _contactService.Update(dto);
            return Ok(response);
            
        }






    }
}
