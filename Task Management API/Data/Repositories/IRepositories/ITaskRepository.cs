namespace Task_Management_API.Data.Repositories.IRepositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();

        Task<TaskItem> GetTaskByIdAsync(int id);

        Task AddTaskAsync(TaskItem task);

        Task UpdateTaskAsync(TaskItem task);

        Task DeleteTaskAsync(int id);

        Task<bool> SaveChangesAsync();
    }
}