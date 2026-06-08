using KairoApi.Model.Enum;

namespace KairoApi.Dto
{
    public class TaskInput
    {
        public int? Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public EnumTaskStatus? TaskStatus { get; set; } 
    }
}