using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenzelDev.Models
{
    public class Budget
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EventId { get; set; }

        [Required]
        [StringLength(150)]
        public string ItemName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Type { get; set; } = "Expense"; // Sponsorship or Expense

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 1000000.00)]
        public decimal Amount { get; set; }

        // Navigation Property
        [ForeignKey("EventId")]
        public Event? Event { get; set; }
    }
}
