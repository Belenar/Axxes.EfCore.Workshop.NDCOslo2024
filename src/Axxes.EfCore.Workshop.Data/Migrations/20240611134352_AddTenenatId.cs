using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTenenatId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "MotionPictures",
                type: "varchar(32)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MotionPictures_TenantId",
                table: "MotionPictures",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MotionPictures_TenantId",
                table: "MotionPictures");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MotionPictures");
        }
    }
}
