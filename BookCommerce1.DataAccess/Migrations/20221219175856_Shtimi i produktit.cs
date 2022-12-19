using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCommerce1.DataAccess.Migrations
{
    public partial class Shtimiiproduktit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produkti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pershkrimi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CmimiBaze = table.Column<double>(type: "float", nullable: false),
                    Cmimi = table.Column<double>(type: "float", nullable: false),
                    Cmimi100 = table.Column<double>(type: "float", nullable: false),
                    Cmimi50 = table.Column<double>(type: "float", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: false),
                    MbulesaId = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produkti_Kategoria_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produkti_Mbulesa_MbulesaId",
                        column: x => x.MbulesaId,
                        principalTable: "Mbulesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkti_KategoriaId",
                table: "Produkti",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produkti_MbulesaId",
                table: "Produkti",
                column: "MbulesaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkti");
        }
    }
}
