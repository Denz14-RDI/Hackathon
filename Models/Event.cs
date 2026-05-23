using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DenzelDev.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; } = DateTime.UtcNow;

        [StringLength(150)]
        public string? Location { get; set; }

        [Required]
        [StringLength(100)]
        public string OrganizerName { get; set; } = string.Empty;

        // Navigation Properties
        public List<Budget> Budgets { get; set; } = new List<Budget>();
        public List<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
    }
}
