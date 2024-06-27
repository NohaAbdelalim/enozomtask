using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace enozom.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReturnStatus",
                table: "StudentBorrowBook");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BookCopy");

            migrationBuilder.AddColumn<int>(
                name: "ReturnStatusId",
                table: "StudentBorrowBook",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "BookCopy",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookCopyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCopyStatus", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "BookCopy",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "BookCopy",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "BookCopy",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: 1);

            migrationBuilder.InsertData(
                table: "BookCopyStatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Good" },
                    { 2, "Damaged" },
                    { 3, "Lost" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentBorrowBook_ReturnStatusId",
                table: "StudentBorrowBook",
                column: "ReturnStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCopy_StatusId",
                table: "BookCopy",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCopy_BookCopyStatus_StatusId",
                table: "BookCopy",
                column: "StatusId",
                principalTable: "BookCopyStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentBorrowBook_BookCopyStatus_ReturnStatusId",
                table: "StudentBorrowBook",
                column: "ReturnStatusId",
                principalTable: "BookCopyStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCopy_BookCopyStatus_StatusId",
                table: "BookCopy");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentBorrowBook_BookCopyStatus_ReturnStatusId",
                table: "StudentBorrowBook");

            migrationBuilder.DropTable(
                name: "BookCopyStatus");

            migrationBuilder.DropIndex(
                name: "IX_StudentBorrowBook_ReturnStatusId",
                table: "StudentBorrowBook");

            migrationBuilder.DropIndex(
                name: "IX_BookCopy_StatusId",
                table: "BookCopy");

            migrationBuilder.DropColumn(
                name: "ReturnStatusId",
                table: "StudentBorrowBook");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "BookCopy");

            migrationBuilder.AddColumn<string>(
                name: "ReturnStatus",
                table: "StudentBorrowBook",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "BookCopy",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "BookCopy",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Good");

            migrationBuilder.UpdateData(
                table: "BookCopy",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Good");

            migrationBuilder.UpdateData(
                table: "BookCopy",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Good");
        }
    }
}
