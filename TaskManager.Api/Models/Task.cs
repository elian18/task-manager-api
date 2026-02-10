using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManager.Api.Repositories.Interfaces;

namespace TaskManager.Api.Models
{
    [Table("tasks")]
    public class TaskItem : IEntity, ICreatedAt
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("title")]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }

        [Column("status")]
        [MaxLength(50)]
        public Types.TaskStatus Status { get; set; }

        [Column("user_id")]
        public Guid UserId { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;
    }
}
