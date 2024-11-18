using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudMec.Infrastructure.Data.AppDb
{
    public partial class ModifyRegistrationLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameUser",
                table: "Registrations",
                newName: "Username");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Registrations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "Registrations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Registrations");

            migrationBuilder.DropColumn(
                name: "fullName",
                table: "Registrations");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Registrations",
                newName: "NameUser");
        }
    }
}
