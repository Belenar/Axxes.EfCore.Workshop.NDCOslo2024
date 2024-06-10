using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class MappingWithFluentApi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "MotionPictures");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "MotionPictures",
                newName: "MovieTitle");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "MotionPictures",
                newName: "ItemKey");

            migrationBuilder.AlterColumn<string>(
                name: "MovieTitle",
                table: "MotionPictures",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MotionPictures",
                table: "MotionPictures",
                column: "ItemKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MotionPictures",
                table: "MotionPictures");

            migrationBuilder.RenameTable(
                name: "MotionPictures",
                newName: "Pictures");

            migrationBuilder.RenameColumn(
                name: "MovieTitle",
                table: "Pictures",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ItemKey",
                table: "Pictures",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Pictures",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");
        }
    }
}
