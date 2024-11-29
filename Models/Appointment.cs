using JKL_Healthcare_Services.Areas.Identity.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace JKL_Healthcare_Services.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int CaregiverId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime AppointmentDate { get; set; }

        [MaxLength(500)]
        public string Notes { get; set; }

        // Navigation properties
        public Patient Patient { get; set; }
        public Caregiver Caregiver { get; set; }

    }
}
