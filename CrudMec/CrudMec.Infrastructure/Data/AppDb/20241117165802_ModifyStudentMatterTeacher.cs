using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudMec.Infrastructure.Data.AppDb
{
    public partial class ModifyStudentMatterTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "credits",
                table: "Students");

            migrationBuilder.AddColumn<string>(
                name: "profile",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MatterStudent",
                columns: table => new
                {
                    MattersMateriaId = table.Column<int>(type: "int", nullable: false),
                    StudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatterStudent", x => new { x.MattersMateriaId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_MatterStudent_Matters_MattersMateriaId",
                        column: x => x.MattersMateriaId,
                        principalTable: "Matters",
                        principalColumn: "MateriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatterStudent_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatterStudent_StudentsId",
                table: "MatterStudent",
                column: "StudentsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatterStudent");

            migrationBuilder.DropColumn(
                name: "profile",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "credits",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
