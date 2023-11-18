using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocMvcNet8App.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovingDbSetBlogModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogPostModel_blogModel_BlogModelId",
                table: "blogPostModel");

            migrationBuilder.DropTable(
                name: "blogModel");

            migrationBuilder.DropIndex(
                name: "IX_blogPostModel_BlogModelId",
                table: "blogPostModel");

            migrationBuilder.DropColumn(
                name: "BlogModelId",
                table: "blogPostModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogModelId",
                table: "blogPostModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "blogModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogPostModel_BlogModelId",
                table: "blogPostModel",
                column: "BlogModelId");

            migrationBuilder.CreateIndex(
                name: "IX_blogModel_UserId",
                table: "blogModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogPostModel_blogModel_BlogModelId",
                table: "blogPostModel",
                column: "BlogModelId",
                principalTable: "blogModel",
                principalColumn: "Id");
        }
    }
}
