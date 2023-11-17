using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocMvcNet8App.Data.Migrations
{
    /// <inheritdoc />
    public partial class ThirdAttempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostModel_AspNetUsers_UserId",
                table: "BlogPostModel");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostModel_blogModel_BlogModelId",
                table: "BlogPostModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostModel",
                table: "BlogPostModel");

            migrationBuilder.RenameTable(
                name: "BlogPostModel",
                newName: "blogPostModel");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostModel_UserId",
                table: "blogPostModel",
                newName: "IX_blogPostModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostModel_BlogModelId",
                table: "blogPostModel",
                newName: "IX_blogPostModel_BlogModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_blogPostModel",
                table: "blogPostModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogPostModel_AspNetUsers_UserId",
                table: "blogPostModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_blogPostModel_blogModel_BlogModelId",
                table: "blogPostModel",
                column: "BlogModelId",
                principalTable: "blogModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogPostModel_AspNetUsers_UserId",
                table: "blogPostModel");

            migrationBuilder.DropForeignKey(
                name: "FK_blogPostModel_blogModel_BlogModelId",
                table: "blogPostModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_blogPostModel",
                table: "blogPostModel");

            migrationBuilder.RenameTable(
                name: "blogPostModel",
                newName: "BlogPostModel");

            migrationBuilder.RenameIndex(
                name: "IX_blogPostModel_UserId",
                table: "BlogPostModel",
                newName: "IX_BlogPostModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_blogPostModel_BlogModelId",
                table: "BlogPostModel",
                newName: "IX_BlogPostModel_BlogModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostModel",
                table: "BlogPostModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostModel_AspNetUsers_UserId",
                table: "BlogPostModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostModel_blogModel_BlogModelId",
                table: "BlogPostModel",
                column: "BlogModelId",
                principalTable: "blogModel",
                principalColumn: "Id");
        }
    }
}
