using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenzelDev.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        [StringLength(255)]
        public string TaskName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? AssignedTo { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, In Progress, Completed

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; } = DateTime.UtcNow.AddDays(7);

        // Navigation Property
        [ForeignKey("EventId")]
        public Event? Event { get; set; }
    }
}
