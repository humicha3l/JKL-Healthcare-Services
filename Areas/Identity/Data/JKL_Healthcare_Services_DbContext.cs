using JKL_Healthcare_Services.Areas.Identity.Data;
using JKL_Healthcare_Services.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace JKL_Healthcare_Services.Data;

public class JKL_Healthcare_Services_DbContext : IdentityDbContext<JKL_Healthcare_ServicesUser>
{
    public JKL_Healthcare_Services_DbContext(DbContextOptions<JKL_Healthcare_Services_DbContext> options)
        : base(options)
    {
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Caregiver> Caregivers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<CaregiverAssignment> CaregiverAssignments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        
    }
}
