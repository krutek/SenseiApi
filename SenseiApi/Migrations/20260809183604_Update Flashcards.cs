using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SenseiApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFlashcards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashcardTranslation");

            migrationBuilder.CreateTable(
                name: "FlashcardTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    FlashcardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashcardTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlashcardTranslations_Flashcards_FlashcardId",
                        column: x => x.FlashcardId,
                        principalTable: "Flashcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardTranslations_FlashcardId",
                table: "FlashcardTranslations",
                column: "FlashcardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashcardTranslations");

            migrationBuilder.CreateTable(
                name: "FlashcardTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlashcardId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Language = table.Column<int>(type: "int", nullable: false),
                    Translation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashcardTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlashcardTranslation_Flashcards_FlashcardId",
                        column: x => x.FlashcardId,
                        principalTable: "Flashcards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardTranslation_FlashcardId",
                table: "FlashcardTranslation",
                column: "FlashcardId");
        }
    }
}
