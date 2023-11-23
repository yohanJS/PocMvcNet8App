using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocMvcNet8App.Data.Migrations
{
    /// <inheritdoc />
    public partial class FifthTimeComment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "CommentModel",
                newName: "TitleComment");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "CommentModel",
                newName: "Comment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitleComment",
                table: "CommentModel",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "CommentModel",
                newName: "Content");
        }
    }
}
