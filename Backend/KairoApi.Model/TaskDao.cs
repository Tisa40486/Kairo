using KairoApi.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;
using KairoApi.Model.Enum;

namespace KairoApi.Model
{
    [Table("KairoApi_Task")]
    public class TaskDao : IModelDao
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; } 
        public bool? Done { get; set; }
        public EnumTaskStatus? TaskStatus { get; set; } 
    }
}