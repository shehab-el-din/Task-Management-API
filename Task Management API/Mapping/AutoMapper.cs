namespace Task_Management_API.Mapping
{
    public class AutoMapper : Profile
    {

        public AutoMapper()
        {
            CreateMap<TaskItem, TaskDTO>().ReverseMap();
            CreateMap<CreateTaskDTO, TaskItem>().ReverseMap();
            CreateMap<UpdateTaskDTO, TaskItem>().ReverseMap();
            CreateMap<TaskCompletionDTO, TaskItem>();
        }

    }
}