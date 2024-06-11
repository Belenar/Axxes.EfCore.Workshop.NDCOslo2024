using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axxes.EfCore.Workshop.Data.Migrations
{
    /// <inheritdoc />
    public partial class RecreateDatabaseForTpc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "MovieSequence");

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
                name: "CinemaMovie",
                columns: table => new
                {
                    ItemKey = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [MovieSequence]"),
                    MovieTitle = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainGenreId = table.Column<int>(type: "int", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoxOfficeRevenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaMovie", x => x.ItemKey);
                    table.ForeignKey(
                        name: "FK_CinemaMovie_Genres_MainGenreId",
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
                });

            migrationBuilder.CreateTable(
                name: "MotionPictures",
                columns: table => new
                {
                    ItemKey = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [MovieSequence]"),
                    MovieTitle = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainGenreId = table.Column<int>(type: "int", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "TelevisionMovie",
                columns: table => new
                {
                    ItemKey = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR [MovieSequence]"),
                    MovieTitle = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainGenreId = table.Column<int>(type: "int", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NetworkFirstAiredOn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelevisionMovie", x => x.ItemKey);
                    table.ForeignKey(
                        name: "FK_TelevisionMovie_Genres_MainGenreId",
                        column: x => x.MainGenreId,
                        principalTable: "Genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaMovie_MainGenreId",
                table: "CinemaMovie",
                column: "MainGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovie_SecondaryMoviesItemKey",
                table: "GenreMovie",
                column: "SecondaryMoviesItemKey");

            migrationBuilder.CreateIndex(
                name: "IX_MotionPictures_MainGenreId",
                table: "MotionPictures",
                column: "MainGenreId");

            migrationBuilder.CreateIndex(
                name: "IX_TelevisionMovie_MainGenreId",
                table: "TelevisionMovie",
                column: "MainGenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaMovie");

            migrationBuilder.DropTable(
                name: "GenreMovie");

            migrationBuilder.DropTable(
                name: "MotionPictures");

            migrationBuilder.DropTable(
                name: "TelevisionMovie");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropSequence(
                name: "MovieSequence");
        }
    }
}
