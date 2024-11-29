using System.ComponentModel.DataAnnotations;

namespace JKL_Healthcare_Services.Models
{
    public class CaregiverAssignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        public int CaregiverId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [MaxLength(500)]
        public string AssignmentNotes { get; set; }

        // Navigation properties
        public Patient Patient { get; set; }
        public Caregiver Caregiver { get; set; }
    }
}
