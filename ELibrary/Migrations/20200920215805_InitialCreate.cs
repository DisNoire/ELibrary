using Microsoft.EntityFrameworkCore.Migrations;

namespace ELibrary.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PublisherSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookAuthor",
                        column: x => x.AuthorId,
                        principalTable: "AuthorSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorPublisher",
                columns: table => new
                {
                    Author_Id = table.Column<int>(nullable: false),
                    Publisher_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPublisher", x => new { x.Author_Id, x.Publisher_Id });
                    table.ForeignKey(
                        name: "FK_AuthorPublisher_Author",
                        column: x => x.Author_Id,
                        principalTable: "AuthorSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthorPublisher_Publisher",
                        column: x => x.Publisher_Id,
                        principalTable: "PublisherSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FK_AuthorPublisher_Publisher",
                table: "AuthorPublisher",
                column: "Publisher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FK_BookAuthor",
                table: "BookSet",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPublisher");

            migrationBuilder.DropTable(
                name: "BookSet");

            migrationBuilder.DropTable(
                name: "PublisherSet");

            migrationBuilder.DropTable(
                name: "AuthorSet");
        }
    }
}
