using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}