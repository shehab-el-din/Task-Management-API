
namespace Task_Management_API.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _Mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _Mapper = mapper;
        }
        public async Task AddTaskAsync(CreateTaskDTO createTaskDTO)
        {
            var task = _Mapper.Map<TaskItem>(createTaskDTO);
            await _taskRepository.AddTaskAsync(task);
            await _taskRepository.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteTaskAsync(id);
            await _taskRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskDTO>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            return _Mapper.Map<IEnumerable<TaskDTO>>(tasks);
        }

        public async Task<TaskDTO> GetTaskByIdAsync(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            return _Mapper.Map<TaskDTO>(task);
        }

        public async Task UpdateTaskAsync(int id, UpdateTaskDTO updateTaskDTO)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task != null)
            {
                _Mapper.Map(updateTaskDTO, task);
                _taskRepository.UpdateTaskAsync(task);
                await _taskRepository.SaveChangesAsync();
            }
        }
        public async Task<bool> UpdateTaskDetailsAsync(int id, UpdateTaskDetailsDTO updateTaskDetailsDTO)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                return false;
            }

            _Mapper.Map(updateTaskDetailsDTO, task);
            await _taskRepository.UpdateTaskAsync(task);
            return true;
        }
        public async Task<bool> TaskCompletionAsync(int id, TaskCompletionDTO taskCompletionDTO)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                return false;
            }
            //check if task is already completed or switch to admin view
            task.IsCompleted = taskCompletionDTO.IsCompleted;
            await _taskRepository.UpdateTaskAsync(task);
            return true;
        }
    }
}