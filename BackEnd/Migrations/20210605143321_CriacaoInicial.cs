using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class CriacaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    professorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.id);
                    table.ForeignKey(
                        name: "FK_Disciplina_Professor_professorId",
                        column: x => x.professorId,
                        principalTable: "Professor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoDisciplina",
                columns: table => new
                {
                    alunoId = table.Column<int>(type: "int", nullable: false),
                    disciplinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDisciplina", x => new { x.alunoId, x.disciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Aluno_alunoId",
                        column: x => x.alunoId,
                        principalTable: "Aluno",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDisciplina_Disciplina_disciplinaId",
                        column: x => x.disciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "id", "nome", "sobrenome", "telefone" },
                values: new object[,]
                {
                    { 1, "Marta", "Kent", "33225555" },
                    { 2, "Paula", "Isabela", "3354288" },
                    { 3, "Laura", "Antonia", "55668899" },
                    { 4, "Luiza", "Maria", "6565659" },
                    { 5, "Lucas", "Machado", "565685415" },
                    { 6, "Pedro", "Alvares", "456454545" },
                    { 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Professor",
                columns: new[] { "id", "nome" },
                values: new object[,]
                {
                    { 1, "Lauro" },
                    { 2, "Roberto" },
                    { 3, "Ronaldo" },
                    { 4, "Rodrigo" },
                    { 5, "Alexandre" }
                });

            migrationBuilder.InsertData(
                table: "Disciplina",
                columns: new[] { "id", "nome", "professorId" },
                values: new object[,]
                {
                    { 1, "Matemática", 1 },
                    { 2, "Física", 2 },
                    { 3, "Português", 3 },
                    { 4, "Inglês", 4 },
                    { 5, "Programação", 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunoDisciplina",
                columns: new[] { "alunoId", "disciplinaId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 4, 5 },
                    { 2, 5 },
                    { 1, 5 },
                    { 7, 4 },
                    { 6, 4 },
                    { 5, 4 },
                    { 4, 4 },
                    { 1, 4 },
                    { 7, 3 },
                    { 5, 5 },
                    { 6, 3 },
                    { 7, 2 },
                    { 6, 2 },
                    { 3, 2 },
                    { 2, 2 },
                    { 1, 2 },
                    { 7, 1 },
                    { 6, 1 },
                    { 4, 1 },
                    { 3, 1 },
                    { 3, 3 },
                    { 7, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDisciplina_disciplinaId",
                table: "AlunoDisciplina",
                column: "disciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplina_professorId",
                table: "Disciplina",
                column: "professorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoDisciplina");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
