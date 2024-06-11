using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class RecreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotionPictures",
                columns: table => new
                {
                    ItemKey = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Director_Id = table.Column<int>(type: "int", nullable: false),
                    Director_FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director_LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainGenreId = table.Column<int>(type: "int", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    BoxOfficeRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetworkFirstAiredOn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotionPictures", x => x.ItemKey);
                    table.ForeignKey(
                        name: "FK_MotionPictures_Genres_MainGenreId",
                        column: x => x.MainGenreId,
                        principalTable: "Genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GenreMovie",
                columns: table => new
                {
                    SecondaryGenresId = table.Column<int>(type: "int", nullable: false),
                    SecondaryMoviesItemKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovie", x => new { x.SecondaryGenresId, x.SecondaryMoviesItemKey });
                    table.ForeignKey(
                        name: "FK_GenreMovie_Genres_SecondaryGenresId",
                        column: x => x.SecondaryGenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovie_MotionPictures_SecondaryMoviesItemKey",
                        column: x => x.SecondaryMoviesItemKey,
                        principalTable: "MotionPictures",
                        principalColumn: "ItemKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_SecondaryMoviesItemKey",
                table: "GenreMovie",
                column: "SecondaryMoviesItemKey");

            migrationBuilder.CreateIndex(
                name: "IX_MotionPictures_MainGenreId",
                table: "MotionPictures",
                column: "MainGenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "MotionPictures");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
