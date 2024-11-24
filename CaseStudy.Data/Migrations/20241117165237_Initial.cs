using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseStudy.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Author = table.Column<string>(type: "TEXT", nullable: true),
                    PublishYear = table.Column<int>(type: "INTEGER", nullable: false),
                    Genre = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookCollection",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CollectionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BookId1 = table.Column<Guid>(type: "TEXT", nullable: true),
                    CollectionId1 = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCollection", x => new { x.BookId, x.CollectionId });
                    table.ForeignKey(
                        name: "FK_BookCollection_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCollection_Books_BookId1",
                        column: x => x.BookId1,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookCollection_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCollection_Collections_CollectionId1",
                        column: x => x.CollectionId1,
                        principalTable: "Collections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCollection_BookId1",
                table: "BookCollection",
                column: "BookId1");

            migrationBuilder.CreateIndex(
                name: "IX_BookCollection_CollectionId",
                table: "BookCollection",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCollection_CollectionId1",
                table: "BookCollection",
                column: "CollectionId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCollection");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Collections");
        }
    }
}
