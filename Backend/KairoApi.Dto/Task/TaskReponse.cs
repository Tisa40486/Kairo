using KairoApi.Model.Enum;


namespace KairoApi.Dto
{
    public class TaskReponse
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public bool Done { get; set; }
        public EnumTaskStatus Status{ get; set; }
    }
}