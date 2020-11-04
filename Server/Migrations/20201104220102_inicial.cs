﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace zoologicoBlazor.Server.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuidadores",
                columns: table => new
                {
                    IdCuidador = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    Funcao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuidadores", x => x.IdCuidador);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    IdEspecie = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.IdEspecie);
                });

            migrationBuilder.CreateTable(
                name: "CuidadorDetails",
                columns: table => new
                {
                    IdCuidadorDetails = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    IdCuidador = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuidadorDetails", x => x.IdCuidadorDetails);
                    table.ForeignKey(
                        name: "FK_CuidadorDetails_Cuidadores_IdCuidador",
                        column: x => x.IdCuidador,
                        principalTable: "Cuidadores",
                        principalColumn: "IdCuidador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    IdAnimal = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Idade = table.Column<int>(nullable: false),
                    IdEspecie = table.Column<string>(nullable: false),
                    EspecieIdEspecie = table.Column<int>(nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.IdAnimal);
                    table.ForeignKey(
                        name: "FK_Animais_Especies_EspecieIdEspecie",
                        column: x => x.EspecieIdEspecie,
                        principalTable: "Especies",
                        principalColumn: "IdEspecie",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CuidadorAnimais",
                columns: table => new
                {
                    IdCuidador = table.Column<int>(nullable: false),
                    IdAnimal = table.Column<int>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuidadorAnimais", x => new { x.IdCuidador, x.IdAnimal });
                    table.ForeignKey(
                        name: "FK_CuidadorAnimais_Animais_IdAnimal",
                        column: x => x.IdAnimal,
                        principalTable: "Animais",
                        principalColumn: "IdAnimal",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CuidadorAnimais_Cuidadores_IdCuidador",
                        column: x => x.IdCuidador,
                        principalTable: "Cuidadores",
                        principalColumn: "IdCuidador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animais_EspecieIdEspecie",
                table: "Animais",
                column: "EspecieIdEspecie");

            migrationBuilder.CreateIndex(
                name: "IX_CuidadorAnimais_IdAnimal",
                table: "CuidadorAnimais",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_CuidadorDetails_IdCuidador",
                table: "CuidadorDetails",
                column: "IdCuidador",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuidadorAnimais");

            migrationBuilder.DropTable(
                name: "CuidadorDetails");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Cuidadores");

            migrationBuilder.DropTable(
                name: "Especies");
        }
    }
}
