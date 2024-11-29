using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JKL_Healthcare_Services.Migrations
{
    /// <inheritdoc />
    public partial class SeedSampleCaregiverData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Caregivers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Caregivers",
                columns: new[] { "CaregiverId", "ContactInfo", "IsAvailable", "Name", "UserId" },
                values: new object[] { 1, "caregiver1@healthcare.com", true, "James Fuhad", "2cc5092d-3732-4f2f-9707-b815fa5bd6b3" });

            migrationBuilder.CreateIndex(
                name: "IX_Caregivers_UserId",
                table: "Caregivers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Caregivers_AspNetUsers_UserId",
                table: "Caregivers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caregivers_AspNetUsers_UserId",
                table: "Caregivers");

            migrationBuilder.DropIndex(
                name: "IX_Caregivers_UserId",
                table: "Caregivers");

            migrationBuilder.DeleteData(
                table: "Caregivers",
                keyColumn: "CaregiverId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Caregivers");
        }
    }
}
