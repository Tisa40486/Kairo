using KairoApi.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace KairoApi.Model.LKP
{
    [Table("LKP_KairoApi_Categories")]
    public class Categories : IModelDao
    {
        public int id { get; set; }
        public required string Name { get; set; }
    }
}
