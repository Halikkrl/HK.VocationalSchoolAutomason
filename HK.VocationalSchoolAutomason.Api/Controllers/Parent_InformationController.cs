using AutoMapper;
using HK.VocationalSchoolAutomason.Bussiness.Interfaces;
using HK.VocationalSchoolAutomason.Bussiness.Services;
using HK.VocationalSchoolAutomason.Common.ResponsObjects;
using HK.VocationalSchoolAutomason.Dtos.Interfaces;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.Parent_Information;
using HK.VocationalSchoolAutomason.Dtos.SchoolDtos.StudentDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HK.VocationalSchoolAutomason.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Parent_InformationController : ControllerBase
    {
        private readonly IParent_Information _parent;

        public Parent_InformationController(IParent_Information parent)
        {
            _parent = parent;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Response = await _parent.GetAllStudents();
            return Ok(Response);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var Response = await _parent.GetById<Parent_InformationList>(id);
            return Ok(Response);
           
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromQuery] Parent_InformationCreate dto)
        {
            var response = await _parent.Create(dto);
            return Created(string.Empty, response);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var response = await _parent.Remove(id);
            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Parent_InformationUpdate dto)
        {
            var response = await _parent.Update(dto);
            return Ok(response);
        }


    }
}
