using JKL_Healthcare_Services.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;

namespace JKL_Healthcare_Services.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(500)]
        public string MedicalRecords { get; set; }

        // Navigation property to CaregiverAssignments
        public ICollection<CaregiverAssignment> CaregiverAssignments { get; set; }
    }
}
