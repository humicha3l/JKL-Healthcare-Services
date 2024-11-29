using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JKL_Healthcare_Services.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsersAndPatients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c9856ec2-bbf1-4f94-b968-b25174db6032", 0, "e3b3eead-55d0-4fba-95f9-b7627ea08699", "patient1@healthcare.com", true, "John", "Doe", false, null, "PATIENT1@HEALTHCARE.COM", "PATIENT1@HEALTHCARE.COM", "AQAAAAIAAYagAAAAEDF8i9jK272gGmb4LhKrpOwsJfOFjSUu7ENKGMVUC1dUJtmL6yaITtYEWrzt3J4WRw==", null, false, "a9dc5e45-dbcf-4bba-9020-9b233089e1b8", false, "patient1@healthcare.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9856ec2-bbf1-4f94-b968-b25174db6032");
        }
    }
}
