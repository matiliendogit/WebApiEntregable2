using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiEntregable2.Dtos;
using WebApiEntregable2.Interfaces;
using WebApiEntregable2.Data.Entities;

namespace WebApiEntregable2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskRepository taskRepository) : ControllerBase
    {

        private readonly ITaskRepository _taskRepository = taskRepository;

        [HttpGet]

        public IActionResult GetAll()
        {
            var tasks = _taskRepository.GetAll();
            return Ok(tasks);
        }


        [HttpGet("{id:int}")]
        public IActionResult GetById(int id) {
            var task = _taskRepository.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Create(SaveTaskDto req)
        {
            var task = new ETask
            {
                Title = req.Title,
                Description = req.Description,
                IsCompleted = req.IsCompleted
            };

            var taskCreated = _taskRepository.Create(task);

            return CreatedAtAction(
                nameof(GetById), 
                new { id = taskCreated.Id }, 
                taskCreated
            );
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, SaveTaskDto req)
        {
            var task = _taskRepository.GetById(id);
            if (task == null)
            {
                return NotFound();
            }

            task.Title = req.Title;
            task.Description = req.Description;
            task.IsCompleted = req.IsCompleted;

            var taskUpdated = _taskRepository.Update(task);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var task = _taskRepository.GetById(id);
            if (task == null)
                return NotFound();
            var taskDeletedCorrectly = _taskRepository.Delete(task);

            if (!taskDeletedCorrectly)
                return NotFound();

            return NoContent();
        }


    }
}
