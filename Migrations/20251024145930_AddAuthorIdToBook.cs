using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Turcas_Roxana_lab2.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorIdToBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Adaugă coloana AuthorId
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Book",
                nullable: true); // pune false dacă e obligatoriu

            // 2. Creează index pentru FK
            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            // 3. Creează foreign key
            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author_AuthorId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Book");
        
    }
    }
}
