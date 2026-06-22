using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskService.Models;
namespace TaskService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static List<TaskItem> Tasks = new()
        {
            new TaskItem(1, "Learn .NET", false),
            new TaskItem(2, "Build Microservices", false)
        };

        [HttpGet]

        public IActionResult GetAll()
        {
            return Ok(Tasks);
        }

        [HttpPost]

        public IActionResult Create(TaskItem task)
        {
            
            Tasks.Add(task);
            return Ok(Tasks);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskItem updatedTask)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            Tasks.Remove(task);
            Tasks.Add(updatedTask);

            return Ok(updatedTask);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var task = Tasks.FirstOrDefault(x => x.Id == id);

            if (task == null)
                return NotFound();

            Tasks.Remove(task);
            return NoContent();
        }
    }
}
