namespace Task_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ILogger<TasksController> _logger;
        private readonly ITaskService _taskService;

        public TasksController(ILogger<TasksController> logger, ITaskService taskService)
        {
            _taskService = taskService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(CreateTaskDTO createTaskDTO)
        {//need adjustment
            await _taskService.AddTaskAsync(createTaskDTO);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDTO updateTaskDTO)
        {
            await _taskService.UpdateTaskAsync(id, updateTaskDTO);
            return Ok();
        }

        [HttpPut("{id}/details")]
        public async Task<IActionResult> UpdateTaskDetails(int id, UpdateTaskDetailsDTO updateTaskDetailsDTO)
        {
            var result = await _taskService.UpdateTaskDetailsAsync(id, updateTaskDetailsDTO);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> TaskCompletion(int id, TaskCompletionDTO taskCompletionDTO)
        {
            var result = await _taskService.TaskCompletionAsync(id, taskCompletionDTO);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return Ok();
        }
    }
}