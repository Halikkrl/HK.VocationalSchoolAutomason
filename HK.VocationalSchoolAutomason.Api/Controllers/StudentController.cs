using AutoMapper;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace HK.VocationalSchoolAutomason.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentsResponse = await _studentService.GetAllStudents();
            return Ok(studentsResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var studentResponse = await _studentService.GetById<StudentListDto>(id);
            return Ok(studentResponse);

        }


        //[HttpPost("createStudent")]
        //public async Task<IActionResult> CreateAsync([FromQuery] StudentCreateDto student)
        //{
        //    var response = await _studentService.Create(student);
        //    return Created(string.Empty, response);

        //}


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Remove(int id)
        //{
        //    var response = await _studentService.Remove(id);
        //    return Ok(response);
        //}


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] StudentUpdateDto dto)
        {
            var response = await _studentService.Update(dto);
            return Ok(response);
            

        }

    }
}
