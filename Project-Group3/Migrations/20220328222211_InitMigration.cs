using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_Group3.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNasc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ocupacao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionEnunciado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionCorreta = table.Column<bool>(type: "bit", nullable: false),
                    AvaliacaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    AvaliacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvaliacaoNota = table.Column<float>(type: "real", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    DisciplinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.AvaliacaoId);
                    table.ForeignKey(
                        name: "FK_Avaliacao_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurmaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    DisciplinaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.TurmaId);
                    table.ForeignKey(
                        name: "FK_Turma_User_StudentId",
                        column: x => x.StudentId,
                        principalTable: "User",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    DisciplinaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisciplinaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    TurmaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.DisciplinaId);
                    table.ForeignKey(
                        name: "FK_Discipline_Turma_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turma",
                        principalColumn: "TurmaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discipline_User_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "User",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_DisciplinaId",
                table: "Avaliacao",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacao_StudentId",
                table: "Avaliacao",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_TurmaId",
                table: "Discipline",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_UsuarioId",
                table: "Discipline",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_AvaliacaoId",
                table: "Question",
                column: "AvaliacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_DisciplinaId",
                table: "Turma",
                column: "DisciplinaId",
                unique: true,
                filter: "[DisciplinaId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_StudentId",
                table: "Turma",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Avaliacao_AvaliacaoId",
                table: "Question",
                column: "AvaliacaoId",
                principalTable: "Avaliacao",
                principalColumn: "AvaliacaoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacao_Discipline_DisciplinaId",
                table: "Avaliacao",
                column: "DisciplinaId",
                principalTable: "Discipline",
                principalColumn: "DisciplinaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turma_Discipline_DisciplinaId",
                table: "Turma",
                column: "DisciplinaId",
                principalTable: "Discipline",
                principalColumn: "DisciplinaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turma_Discipline_DisciplinaId",
                table: "Turma");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
