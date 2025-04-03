using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITMFotomultas.Migrations
{
    /// <inheritdoc />
    public partial class MakeFotomultaIdNullableInImagen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Fotomultas_FotomultaId",
                table: "Imagenes");

            migrationBuilder.AlterColumn<int>(
                name: "FotomultaId",
                table: "Imagenes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Fotomultas_FotomultaId",
                table: "Imagenes",
                column: "FotomultaId",
                principalTable: "Fotomultas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imagenes_Fotomultas_FotomultaId",
                table: "Imagenes");

            migrationBuilder.AlterColumn<int>(
                name: "FotomultaId",
                table: "Imagenes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Imagenes_Fotomultas_FotomultaId",
                table: "Imagenes",
                column: "FotomultaId",
                principalTable: "Fotomultas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
