using Microsoft.EntityFrameworkCore.Migrations;

namespace AFO_Transport.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    IdTransport = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombrePassagerMax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arrivee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeTransport = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.IdTransport);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    Identifiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionSm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdTransportNavigationIdTransport = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.Identifiant);
                    table.ForeignKey(
                        name: "FK_Personnes_Transports_IdTransportNavigationIdTransport",
                        column: x => x.IdTransportNavigationIdTransport,
                        principalTable: "Transports",
                        principalColumn: "IdTransport",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personnes_IdTransportNavigationIdTransport",
                table: "Personnes",
                column: "IdTransportNavigationIdTransport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personnes");

            migrationBuilder.DropTable(
                name: "Transports");
        }
    }
}
