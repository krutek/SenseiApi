using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SenseiApi.Migrations
{
    /// <inheritdoc />
    public partial class AddFlashcardType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlashcardType",
                table: "Flashcards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlashcardType",
                table: "Flashcards");
        }
    }
}
