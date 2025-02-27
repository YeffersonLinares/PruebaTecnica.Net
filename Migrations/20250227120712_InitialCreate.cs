using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace my_dotnet_postgres_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    DocumentoIdentidad = table.Column<string>(type: "text", nullable: false),
                    Nombres = table.Column<string>(type: "text", nullable: false),
                    Apellidos = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.DocumentoIdentidad);
                });

            migrationBuilder.CreateTable(
                name: "CorreosElectronicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Correo = table.Column<string>(type: "text", nullable: false),
                    PersonaDocumentoIdentidad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorreosElectronicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorreosElectronicos_Personas_PersonaDocumentoIdentidad",
                        column: x => x.PersonaDocumentoIdentidad,
                        principalTable: "Personas",
                        principalColumn: "DocumentoIdentidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DireccionesFisicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Direccion = table.Column<string>(type: "text", nullable: false),
                    PersonaDocumentoIdentidad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionesFisicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DireccionesFisicas_Personas_PersonaDocumentoIdentidad",
                        column: x => x.PersonaDocumentoIdentidad,
                        principalTable: "Personas",
                        principalColumn: "DocumentoIdentidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumerosTelefonicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    PersonaDocumentoIdentidad = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumerosTelefonicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumerosTelefonicos_Personas_PersonaDocumentoIdentidad",
                        column: x => x.PersonaDocumentoIdentidad,
                        principalTable: "Personas",
                        principalColumn: "DocumentoIdentidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorreosElectronicos_PersonaDocumentoIdentidad",
                table: "CorreosElectronicos",
                column: "PersonaDocumentoIdentidad");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionesFisicas_PersonaDocumentoIdentidad",
                table: "DireccionesFisicas",
                column: "PersonaDocumentoIdentidad");

            migrationBuilder.CreateIndex(
                name: "IX_NumerosTelefonicos_PersonaDocumentoIdentidad",
                table: "NumerosTelefonicos",
                column: "PersonaDocumentoIdentidad");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorreosElectronicos");

            migrationBuilder.DropTable(
                name: "DireccionesFisicas");

            migrationBuilder.DropTable(
                name: "NumerosTelefonicos");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
