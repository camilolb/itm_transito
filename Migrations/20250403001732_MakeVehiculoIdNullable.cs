using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITMFotomultas.Migrations
{
    /// <inheritdoc />
    public partial class MakeVehiculoIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotomultas_Vehiculos_VehiculoId",
                table: "Fotomultas");

            migrationBuilder.AlterColumn<int>(
                name: "VehiculoId",
                table: "Fotomultas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Fotomultas_Vehiculos_VehiculoId",
                table: "Fotomultas",
                column: "VehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fotomultas_Vehiculos_VehiculoId",
                table: "Fotomultas");

            migrationBuilder.AlterColumn<int>(
                name: "VehiculoId",
                table: "Fotomultas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fotomultas_Vehiculos_VehiculoId",
                table: "Fotomultas",
                column: "VehiculoId",
                principalTable: "Vehiculos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
