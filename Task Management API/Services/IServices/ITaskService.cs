namespace Task_Management_API.Services.IServices
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDTO>> GetAllTasksAsync();

        Task<TaskDTO> GetTaskByIdAsync(int id);
        Task AddTaskAsync(CreateTaskDTO createTaskDTO);
        Task UpdateTaskAsync(int id, UpdateTaskDTO updateTaskDTO);
        Task<bool> TaskCompletionAsync(int id, TaskCompletionDTO taskCompletionDTO);
        Task<bool> UpdateTaskDetailsAsync(int id, UpdateTaskDetailsDTO updateTaskDetailsDTO);
        Task DeleteTaskAsync(int id);
    }
}