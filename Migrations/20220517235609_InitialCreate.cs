using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcDentista.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaAsistencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Domicilio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profesion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
