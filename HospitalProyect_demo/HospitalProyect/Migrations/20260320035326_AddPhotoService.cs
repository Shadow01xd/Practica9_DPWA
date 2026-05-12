using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalProyect.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "staffModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "staffModel");
        }
    }
}
