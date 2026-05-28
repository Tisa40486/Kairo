using KairoApi.Data.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace KairoApi.Model
{
    [Table("KairoApi_User")]
    public class UserDao : IModelDao
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? UserName { get; set; }
        public string Password { get; set; }
        public required bool IsVerified { get; set; }
        public required DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Email { get; set; }
        
        
    }
}