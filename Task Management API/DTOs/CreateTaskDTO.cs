namespace Task_Management_API.DTOs
{
    public class CreateTaskDTO
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; } = DateTime.Now;

    }
}