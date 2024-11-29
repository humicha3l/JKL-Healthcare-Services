using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JKL_Healthcare_Services.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "AppointmentDate", "CaregiverId", "Notes", "PatientId" },
                values: new object[] { 1, new DateTime(2024, 12, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, "Follow-up appointment.", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1);
        }
    }
}
