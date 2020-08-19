using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Entities;
using LibraryManagement.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/user
        [HttpGet(Name = "GetUsers")]
        public List<User> Get()
        {
            List<User> Users = _userRepository.GetUsers();
            return Users;
        }

        // GET: api/user/{id}
        [HttpGet("{id}", Name = "GetUser")]
        public User Get(int id)
        {
            return _userRepository.Get(id);
        }

        // POST: api/user
        [HttpPost(Name = "AddUser")]
        public void Post([FromBody] User user)
        {
            _userRepository.Add(user);
        }

        [HttpPut("{id}", Name = "EditUser")]
        public int Edit([FromBody] User user)
        {
            return _userRepository.Edit(user);
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}", Name = "DeleteUser")]
        public int Delete(int id)
        {
            return _userRepository.Delete(id);
        }
    }
}