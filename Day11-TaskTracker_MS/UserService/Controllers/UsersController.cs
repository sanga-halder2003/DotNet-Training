using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> users = new()
        { new User(1,"Sanga","sangahalder@gmail.com"),
            new User(2,"Debdyuti","debpaul@gmail.com")
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(users);
        }

        [HttpPost]

        public IActionResult Create(User user)
        {
            users.Add(user);
            return Ok(users);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, User updatedUser)
        {
            var user = users.FirstOrDefault(t => t.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            users.Remove(user);
            users.Add(updatedUser);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            users.Remove(user);
            return NoContent();
        }



    }
}
