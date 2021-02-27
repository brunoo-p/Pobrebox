using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using PobreBox.Models;
using PobreBox.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PobreBox.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserCollection database = new UserCollection();

        [HttpGet("{email}")]
        public async Task<IActionResult> FindUser(string email)
        {
            var user = await database.FindUser(email);
            Console.WriteLine(user);
            if (user != null )
            {
                return Ok(user);
            }
            return BadRequest("Usuario não encontrado");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(ObjectId id)
        {
            await database.DeleteUser(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromForm] User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            await database.InsertUser(user);
            return Created("User Created", true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser([FromForm] User user, string id)
        {
            if(user == null)
            {
                return BadRequest();
            }
            user.Id = new ObjectId(id);
            await database.UpdateUser(user);
            return Created("User Updated", true);
        }

    }
}
