using Microsoft.EntityFrameworkCore.Migrations;

namespace zoologicoBlazor.Server.Migrations
{
    public partial class alt_cuidador_animal2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animais_Especies_IdEspecie",
                table: "Animais");

            migrationBuilder.DropIndex(
                name: "IX_Animais_IdEspecie",
                table: "Animais");

            migrationBuilder.AddColumn<int>(
                name: "EspecieIdEspecie",
                table: "Animais",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animais_EspecieIdEspecie",
                table: "Animais",
                column: "EspecieIdEspecie");

            migrationBuilder.AddForeignKey(
                name: "FK_Animais_Especies_EspecieIdEspecie",
                table: "Animais",
                column: "EspecieIdEspecie",
                principalTable: "Especies",
                principalColumn: "IdEspecie",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animais_Especies_EspecieIdEspecie",
                table: "Animais");

            migrationBuilder.DropIndex(
                name: "IX_Animais_EspecieIdEspecie",
                table: "Animais");

            migrationBuilder.DropColumn(
                name: "EspecieIdEspecie",
                table: "Animais");

            migrationBuilder.CreateIndex(
                name: "IX_Animais_IdEspecie",
                table: "Animais",
                column: "IdEspecie");

            migrationBuilder.AddForeignKey(
                name: "FK_Animais_Especies_IdEspecie",
                table: "Animais",
                column: "IdEspecie",
                principalTable: "Especies",
                principalColumn: "IdEspecie",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
