using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudMec.Infrastructure.Data.AppDb
{
    public partial class ModifyRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Matters_MatterId",
                table: "Registrations");

            migrationBuilder.DropForeignKey(
                name: "FK_Registrations_Students_StudentId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_MatterId",
                table: "Registrations");

            migrationBuilder.DropIndex(
                name: "IX_Registrations_StudentId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "MatterId",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Registrations");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameUser",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "NameUser",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Registrations");

            migrationBuilder.AddColumn<int>(
                name: "MatterId",
                table: "Registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_MatterId",
                table: "Registrations",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_StudentId",
                table: "Registrations",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Matters_MatterId",
                table: "Registrations",
                column: "MatterId",
                principalTable: "Matters",
                principalColumn: "MateriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Registrations_Students_StudentId",
                table: "Registrations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
