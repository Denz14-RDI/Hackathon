using System.ComponentModel.DataAnnotations;

namespace DenzelDev.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required]
        [Range(1, 100)]
        public int ProficiencyPercent { get; set; }

        [StringLength(50)]
        public string? IconClass { get; set; }
    }
}
