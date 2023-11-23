using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocMvcNet8App.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThirdTryAddingComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "CommentModel",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "TitleContent",
                table: "blogPostModel",
                newName: "CommentContent");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CommentModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "CommentModel");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "CommentModel",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "CommentContent",
                table: "blogPostModel",
                newName: "TitleContent");
        }
    }
}
