using System;
using System.ComponentModel.DataAnnotations;

namespace DenzelDev.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Slug { get; set; } = string.Empty;

        [Required]
        public string ContentMarkdown { get; set; } = string.Empty;

        [StringLength(500)]
        public string? BannerImageUrl { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Range(1, 120)]
        public int ReadTimeMinutes { get; set; }

        [Required]
        public bool IsPublished { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
