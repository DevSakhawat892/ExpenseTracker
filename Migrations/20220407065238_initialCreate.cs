using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseTracker.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ExpenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpenseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseDetails_ExpenseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExpenseCategories",
                columns: new[] { "Id", "Category" },
                values: new object[,]
                {
                    { 1, "House Rent" },
                    { 2, "Water Bill" },
                    { 3, "Electric Bill" },
                    { 4, "Groceries" },
                    { 5, "Uber" },
                    { 6, "Medications" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategories_Category",
                table: "ExpenseCategories",
                column: "Category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseDetails_CategoryId",
                table: "ExpenseDetails",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseDetails");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");
        }
    }
}
