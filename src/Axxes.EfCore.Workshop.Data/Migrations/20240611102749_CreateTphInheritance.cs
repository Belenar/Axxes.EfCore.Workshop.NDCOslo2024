using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTphInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BoxOfficeRevenue",
                table: "MotionPictures",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MotionPictures",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NetworkFirstAiredOn",
                table: "MotionPictures",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoxOfficeRevenue",
                table: "MotionPictures");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MotionPictures");

            migrationBuilder.DropColumn(
                name: "NetworkFirstAiredOn",
                table: "MotionPictures");
        }
    }
}
