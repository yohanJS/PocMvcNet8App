using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocMvcNet8App.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingBlogModelAndBlogPostModelToDbo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "blogModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "blogPostModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogPostModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogPostModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_blogPostModel_blogModel_BlogModelId",
                        column: x => x.BlogModelId,
                        principalTable: "blogModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogModel_UserId",
                table: "blogModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_blogPostModel_BlogModelId",
                table: "blogPostModel",
                column: "BlogModelId");

            migrationBuilder.CreateIndex(
                name: "IX_blogPostModel_UserId",
                table: "blogPostModel",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blogPostModel");

            migrationBuilder.DropTable(
                name: "blogModel");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
