using Microsoft.EntityFrameworkCore.Migrations;
using System.IO;

namespace WebSeries.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seriess",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeriesName = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    Season = table.Column<int>(nullable: false),
                    PlatformId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seriess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seriess_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Binges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(nullable: true),
                    SeriesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Binges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Binges_Seriess_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Seriess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeriesRatings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    SeriesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeriesRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeriesRatings_Seriess_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Seriess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Binges_SeriesId",
                table: "Binges",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_SeriesRatings_SeriesId",
                table: "SeriesRatings",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Seriess_PlatformId",
                table: "Seriess",
                column: "PlatformId");

            var sql = Path.Combine(".\\Data", @"all_queries.sql");
            migrationBuilder.Sql(File.ReadAllText(sql));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Binges");

            migrationBuilder.DropTable(
                name: "SeriesRatings");

            migrationBuilder.DropTable(
                name: "Seriess");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
