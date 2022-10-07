using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TpBiblioteca.Migrations
{
    public partial class migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_1_Autores_AutorId",
                table: "Libros_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_1_Generos_GenerosId",
                table: "Libros_1");

            migrationBuilder.AlterColumn<int>(
                name: "GenerosId",
                table: "Libros_1",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Libros_1",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_1_Autores_AutorId",
                table: "Libros_1",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_1_Generos_GenerosId",
                table: "Libros_1",
                column: "GenerosId",
                principalTable: "Generos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libros_1_Autores_AutorId",
                table: "Libros_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Libros_1_Generos_GenerosId",
                table: "Libros_1");

            migrationBuilder.AlterColumn<int>(
                name: "GenerosId",
                table: "Libros_1",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AutorId",
                table: "Libros_1",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_1_Autores_AutorId",
                table: "Libros_1",
                column: "AutorId",
                principalTable: "Autores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libros_1_Generos_GenerosId",
                table: "Libros_1",
                column: "GenerosId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
