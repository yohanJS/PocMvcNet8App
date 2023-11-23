using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocMvcNet8App.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingAuthorPropertyToCommentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "blogPostModel");

            migrationBuilder.DropColumn(
                name: "TitleComment",
                table: "blogPostModel");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "CommentModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "CommentModel");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "blogPostModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleComment",
                table: "blogPostModel",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
