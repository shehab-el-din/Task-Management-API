namespace Task_Management_API.Data
{
    public class ApplicationDpContext : DbContext
    {
        public ApplicationDpContext(DbContextOptions<ApplicationDpContext> options)
            : base(options)
        {

        }
        public DbSet<TaskItem> Tasks { get; set; }
    }
}