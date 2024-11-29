using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JKL_Healthcare_Services.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Caregivers",
                keyColumn: "CaregiverId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9856ec2-bbf1-4f94-b968-b25174db6032");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c9856ec2-bbf1-4f94-b968-b25174db6032", 0, "e3b3eead-55d0-4fba-95f9-b7627ea08699", "patient1@healthcare.com", true, "John", "Doe", false, null, "PATIENT1@HEALTHCARE.COM", "PATIENT1@HEALTHCARE.COM", "AQAAAAIAAYagAAAAEDF8i9jK272gGmb4LhKrpOwsJfOFjSUu7ENKGMVUC1dUJtmL6yaITtYEWrzt3J4WRw==", null, false, "a9dc5e45-dbcf-4bba-9020-9b233089e1b8", false, "patient1@healthcare.com" });

            migrationBuilder.InsertData(
                table: "Caregivers",
                columns: new[] { "CaregiverId", "ContactInfo", "IsAvailable", "Name", "UserId" },
                values: new object[] { 1, "caregiver1@healthcare.com", true, "James Fuhad", "2cc5092d-3732-4f2f-9707-b815fa5bd6b3" });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Address", "DateOfBirth", "MedicalRecords", "Name", "UserId" },
                values: new object[] { 1, "123 Main St", new DateTime(1990, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "No known allergies", "John Doe", "c9856ec2-bbf1-4f94-b968-b25174db6032" });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "AppointmentDate", "CaregiverId", "Notes", "PatientId" },
                values: new object[] { 1, new DateTime(2024, 12, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, "Follow-up appointment.", 1 });
        }
    }
}
