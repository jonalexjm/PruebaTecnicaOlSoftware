using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLSoftware.Core.Entities;
using OLSoftware.Core.Repositories;

namespace OlSoftware.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            //var projectResult = await _userRepository.GetAll();

            var resultUsers = await _userRepository.GetAllSP();
            
            return Ok(resultUsers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {           

            var resultUsers = await _userRepository.GetIdUser(id);
            if (resultUsers == null) { return NotFound(); }

            return Ok(resultUsers);
        }

        // POST api/values
        [HttpPost]
        public async Task<object> Post([FromBody] User value)
        {
             await _userRepository.InsertUser(value);

            var response = new
            {
                status = "OK"
            };


            return response;
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _userRepository.DeleteById(id);
        }


        // POST api/values
        [HttpPut("{id}")]
        public async Task<object> Update([FromBody] User value, int id)
        {
            var resultUsers = await _userRepository.GetIdUser(id);

            if(resultUsers != null)
            {
                value.Id = resultUsers.Id;
                await _userRepository.UpdateUser(value);
            }


            var response = new
            {
                status = "OK"
            };


            return response;
        }

        



    }
}
