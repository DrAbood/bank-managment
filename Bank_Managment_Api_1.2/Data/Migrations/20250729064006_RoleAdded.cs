using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank_Managment_Api_1._2.Migrations
{
    /// <inheritdoc />
    public partial class RoleAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "bankaccount",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "bankaccount",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "VIP" },
                    { 2, "Premium" },
                    { 3, "Regular" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_bankaccount_CategoryID",
                table: "bankaccount",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_bankaccount_UserID",
                table: "bankaccount",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_bankaccount_categories_CategoryID",
                table: "bankaccount",
                column: "CategoryID",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bankaccount_users_UserID",
                table: "bankaccount",
                column: "UserID",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bankaccount_categories_CategoryID",
                table: "bankaccount");

            migrationBuilder.DropForeignKey(
                name: "FK_bankaccount_users_UserID",
                table: "bankaccount");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropIndex(
                name: "IX_bankaccount_CategoryID",
                table: "bankaccount");

            migrationBuilder.DropIndex(
                name: "IX_bankaccount_UserID",
                table: "bankaccount");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "bankaccount");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "bankaccount");
        }
    }
}
