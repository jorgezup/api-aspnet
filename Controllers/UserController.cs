using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using UserApi.Repositories;

namespace UserApi.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult UserList()
        {
            return Ok(_repository.ListUsers());
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            user.CreatedAt = DateTime.Now;
            user.UpdatedAt = DateTime.Now;
            _repository.AddUser(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid Id, [FromBody] User user)
        {
            var userUpdate = _repository.GetById(Id);
            if (userUpdate==null) {
                return NotFound();
            }
            userUpdate.Name = user.Name;
            userUpdate.Surname = user.Surname;
            userUpdate.BirthDate = user.BirthDate;
            userUpdate.UpdatedAt = DateTime.Now;

            _repository.UpdateUser(userUpdate);

            return Ok(userUpdate);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid Id)
        {
            var user = _repository.GetById(Id);
            
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveUser(Guid Id)
        {
            var user = _repository.GetById(Id);
            
            if (user == null) return NotFound();

            _repository.RemoveUser(user);

            return Ok();
        }
    }

}