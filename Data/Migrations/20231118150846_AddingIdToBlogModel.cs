using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocMvcNet8App.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingIdToBlogModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogModelId",
                table: "blogPostModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BlogModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogPostModel_BlogModelId",
                table: "blogPostModel",
                column: "BlogModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogPostModel_BlogModel_BlogModelId",
                table: "blogPostModel",
                column: "BlogModelId",
                principalTable: "BlogModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogPostModel_BlogModel_BlogModelId",
                table: "blogPostModel");

            migrationBuilder.DropTable(
                name: "BlogModel");

            migrationBuilder.DropIndex(
                name: "IX_blogPostModel_BlogModelId",
                table: "blogPostModel");

            migrationBuilder.DropColumn(
                name: "BlogModelId",
                table: "blogPostModel");
        }
    }
}
