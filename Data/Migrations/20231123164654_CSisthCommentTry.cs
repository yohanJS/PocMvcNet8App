using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocMvcNet8App.Data.Migrations
{
    /// <inheritdoc />
    public partial class CSisthCommentTry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogModelId",
                table: "CommentModel",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_BlogModelId",
                table: "CommentModel",
                column: "BlogModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_BlogModel_BlogModelId",
                table: "CommentModel",
                column: "BlogModelId",
                principalTable: "BlogModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_BlogModel_BlogModelId",
                table: "CommentModel");

            migrationBuilder.DropIndex(
                name: "IX_CommentModel_BlogModelId",
                table: "CommentModel");

            migrationBuilder.DropColumn(
                name: "BlogModelId",
                table: "CommentModel");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "blogPostModel");

            migrationBuilder.DropColumn(
                name: "TitleComment",
                table: "blogPostModel");
        }
    }
}
