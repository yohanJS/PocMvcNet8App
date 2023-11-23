using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocMvcNet8App.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingComment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_AspNetUsers_UserId",
                table: "CommentModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_blogPostModel_BlogPostId",
                table: "CommentModel");

            migrationBuilder.DropIndex(
                name: "IX_CommentModel_BlogPostId",
                table: "CommentModel");

            migrationBuilder.DropIndex(
                name: "IX_CommentModel_UserId",
                table: "CommentModel");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "CommentModel");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "CommentModel");

            migrationBuilder.RenameColumn(
                name: "Body",
                table: "CommentModel",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "blogPostModel",
                newName: "TitleContent");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CommentModel",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "CommentModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleComment",
                table: "blogPostModel",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_ApplicationUserId",
                table: "CommentModel",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_AspNetUsers_ApplicationUserId",
                table: "CommentModel",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentModel_AspNetUsers_ApplicationUserId",
                table: "CommentModel");

            migrationBuilder.DropIndex(
                name: "IX_CommentModel_ApplicationUserId",
                table: "CommentModel");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "CommentModel");

            migrationBuilder.DropColumn(
                name: "TitleComment",
                table: "blogPostModel");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "CommentModel",
                newName: "Body");

            migrationBuilder.RenameColumn(
                name: "TitleContent",
                table: "blogPostModel",
                newName: "Comment");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CommentModel",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "CommentModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "CommentModel",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_BlogPostId",
                table: "CommentModel",
                column: "BlogPostId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModel_UserId",
                table: "CommentModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_AspNetUsers_UserId",
                table: "CommentModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentModel_blogPostModel_BlogPostId",
                table: "CommentModel",
                column: "BlogPostId",
                principalTable: "blogPostModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
