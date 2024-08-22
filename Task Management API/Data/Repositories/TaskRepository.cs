namespace Task_Management_API.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDpContext _context;
        public TaskRepository(ApplicationDpContext context)
        {
            _context = context;
        }
        public async Task AddTaskAsync(TaskItem task)
        {
            await _context.Tasks.AddAsync(task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
            }
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateTaskAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}