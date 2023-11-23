using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocMvcNet8App.Data.Migrations
{
    /// <inheritdoc />
    public partial class FourthTimeCOmment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "CommentModel",
                type: "nvarchar(450)",
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
    }
}
