using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocMvcNet8App.Data.Migrations
{
    /// <inheritdoc />
    public partial class customTheBlogModelToGetTheUserPrimaryInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogModelId",
                table: "UserPrimaryInfo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserPrimaryInfo_BlogModelId",
                table: "UserPrimaryInfo",
                column: "BlogModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPrimaryInfo_BlogModel_BlogModelId",
                table: "UserPrimaryInfo",
                column: "BlogModelId",
                principalTable: "BlogModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPrimaryInfo_BlogModel_BlogModelId",
                table: "UserPrimaryInfo");

            migrationBuilder.DropIndex(
                name: "IX_UserPrimaryInfo_BlogModelId",
                table: "UserPrimaryInfo");

            migrationBuilder.DropColumn(
                name: "BlogModelId",
                table: "UserPrimaryInfo");
        }
    }
}
