using KairoApi.Data.Model;
using KairoApi.Model.LKP;
using System.ComponentModel.DataAnnotations.Schema;

namespace KairoApi.Model
{
    [Table("KairoApi_Task")]
    public class TaskDao : IModelDao
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; } 
        public bool Done { get; set; } = false;
        public int? StatusDaoId { get; set; }
        public LKP_StatusDao? LKP_StatusDao { get; set; }
    }
}