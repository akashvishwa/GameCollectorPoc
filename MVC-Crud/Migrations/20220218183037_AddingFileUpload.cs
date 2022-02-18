using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_Crud.Migrations
{
    public partial class AddingFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_GamerProfile",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamingDevice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEsportPlayer = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamingPlatformId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_GamerProfile", x => x.ProfileId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfGame = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfLevel = table.Column<int>(type: "int", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Popularity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Ranking",
                columns: table => new
                {
                    RankId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Ranking", x => x.RankId);
                    table.ForeignKey(
                        name: "FK_tbl_Ranking_tbl_GamerProfile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "tbl_GamerProfile",
                        principalColumn: "ProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_Ranking_tbl_Games_Id",
                        column: x => x.Id,
                        principalTable: "tbl_Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Ranking_Id",
                table: "tbl_Ranking",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Ranking_ProfileId",
                table: "tbl_Ranking",
                column: "ProfileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Ranking");

            migrationBuilder.DropTable(
                name: "tbl_GamerProfile");

            migrationBuilder.DropTable(
                name: "tbl_Games");
        }
    }
}
