using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.Migrations
{
    public partial class MigracionTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atencion",
                columns: table => new
                {
                    IdAtencion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePaciente = table.Column<string>(nullable: true),
                    NombreMedicamento = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(unicode: false, maxLength: 50, nullable: false),
                    Hora = table.Column<DateTime>(unicode: false, maxLength: 50, nullable: false),
                    Categoria = table.Column<int>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atencion", x => x.IdAtencion);
                });

            migrationBuilder.CreateTable(
                name: "Especialidad",
                columns: table => new
                {
                    IdEspecialidad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidad", x => x.IdEspecialidad);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    IdMedicamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Codigo = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Observacion = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.IdMedicamento);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    IdMedico = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.IdMedico);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Cedula = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                });

            migrationBuilder.CreateTable(
                name: "AtencionMedico",
                columns: table => new
                {
                    IdAtencion = table.Column<int>(nullable: false),
                    IdMedico = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtencionMedico", x => new { x.IdAtencion, x.IdMedico });
                    table.ForeignKey(
                        name: "FK_AtencionMedico_Atencion_IdAtencion",
                        column: x => x.IdAtencion,
                        principalTable: "Atencion",
                        principalColumn: "IdAtencion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtencionMedico_Medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidad",
                columns: table => new
                {
                    IdEspecialidad = table.Column<int>(nullable: false),
                    IdMedico = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidad", x => new { x.IdEspecialidad, x.IdMedico });
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidad_Especialidad_IdEspecialidad",
                        column: x => x.IdEspecialidad,
                        principalTable: "Especialidad",
                        principalColumn: "IdEspecialidad",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidad_Medico_IdMedico",
                        column: x => x.IdMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtencionMedico_IdMedico",
                table: "AtencionMedico",
                column: "IdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidad_IdMedico",
                table: "MedicoEspecialidad",
                column: "IdMedico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtencionMedico");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "MedicoEspecialidad");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Atencion");

            migrationBuilder.DropTable(
                name: "Especialidad");

            migrationBuilder.DropTable(
                name: "Medico");
        }
    }
}
