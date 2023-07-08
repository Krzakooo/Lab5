using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly TaskManager _taskManager;

        public TaskController()
        {
            _taskManager = new TaskManager();
        }

        [HttpGet]
        public IActionResult GetAllTasks()
        {
            var tasks = _taskManager.GetTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskManager.GetTaskById(id);
            if (task != null)
                return Ok(task);

            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateTask(Task task)
        {
            _taskManager.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, Task updatedTask)
        {
            var result = _taskManager.UpdateTask(id, updatedTask);
            if (result)
                return NoContent();

            return NotFound();
        }

        [HttpPatch("{id}/complete")]
        public IActionResult MarkTaskAsCompleted(int id)
        {
            var result = _taskManager.MarkTaskAsCompleted(id);
            if (result)
                return NoContent();

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var result = _taskManager.DeleteTask(id);
            if (result)
                return NoContent();

            return NotFound();
        }
    }
}

