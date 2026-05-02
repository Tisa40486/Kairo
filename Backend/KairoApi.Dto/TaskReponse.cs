namespace KairoApi.Dto
{
    public class TaskReponse
    {
        public int id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
    }
}
