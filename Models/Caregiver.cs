using JKL_Healthcare_Services.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace JKL_Healthcare_Services.Models
{
    public class Caregiver
    {
        [Key]
        public int CaregiverId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string ContactInfo { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        // Navigation property for caregiver assignments
        public ICollection<CaregiverAssignment> CaregiverAssignments { get; set; }
    }
}
