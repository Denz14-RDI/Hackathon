using System;
using System.ComponentModel.DataAnnotations;

namespace DenzelDev.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Slug { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        public string ShortDescription { get; set; } = string.Empty;

        [Required]
        public string FullDescriptionMarkdown { get; set; } = string.Empty;

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        [StringLength(500)]
        public string? GithubUrl { get; set; }

        [StringLength(500)]
        public string? LiveUrl { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Tags { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
