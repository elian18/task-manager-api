using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Api.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("email")]
        [MaxLength(150)]
        public string Email { get; set; } = null!;

        [Column("password_hash")]
        public string PasswordHash { get; set; } = null!;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public List<TaskItem> Tasks { get; set; } = new();
    }
}
