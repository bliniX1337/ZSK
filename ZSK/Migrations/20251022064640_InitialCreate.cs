using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZSK.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "animalRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EuroValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animalRates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "conversions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalRateId = table.Column<int>(type: "int", nullable: false),
                    Direction = table.Column<int>(type: "int", nullable: false),
                    EuroAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitEuroAtCreation = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conversions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_conversions_animalRates_AnimalRateId",
                        column: x => x.AnimalRateId,
                        principalTable: "animalRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_animalRates_Name",
                table: "animalRates",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_conversions_AnimalRateId",
                table: "conversions",
                column: "AnimalRateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conversions");

            migrationBuilder.DropTable(
                name: "animalRates");
        }
    }
}
