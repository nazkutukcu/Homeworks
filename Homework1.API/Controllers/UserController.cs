using AutoMapper;
using Homework1.API.Models;
using Homework1.API.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Homework1.API.Controllers
{
    /// schema: domain name : port number : api : controller name
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //controller class handles client requests and returns responses.

        private readonly IUserService userService;

        public UserController(IMapper mapper)
        {
            userService = new UserService(mapper);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok(userService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = userService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Save(UserSaveDtoRequest request)
        {
            var result = userService.Save(request);
            return Created("", result);
        }

        [HttpPut]
        public IActionResult Update(UserUpdateDtoRequest request)
        {
            userService.Update(request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            userService.Delete(id);
            return NoContent();
        }

        [HttpGet("search/{name}/{minAge?}/{maxAge?}")]
        public IActionResult Search(string name, int? minAge, int? maxAge)
        {
            var result = userService.Search(name, minAge, maxAge);
            return Ok(result);
        }

    }
}

