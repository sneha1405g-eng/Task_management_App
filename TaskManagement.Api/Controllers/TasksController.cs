using Microsoft.AspNetCore.Mvc;
using TaskManagement.Api.Models;
using TaskManagement.Api.Services;

namespace TaskManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllTasks());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var task = await _service.GetTask(id);
            return task == null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateTask(task);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskItem task)
        {
            var updated = await _service.UpdateTask(id, task);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteTask(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}