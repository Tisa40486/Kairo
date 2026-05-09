using KairoApi.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace KairoApi.Model.LKP
{
    [Table("LKP_KairoApi_Status")]

    public class LKP_StatusDao : IModelDao
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}