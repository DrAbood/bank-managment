using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank_Managment_Api_1._2.Migrations
{
    /// <inheritdoc />
    public partial class addedUserTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "bankaccount",
                keyColumn: "BankNumber",
                keyValue: "2507220000");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MobileNumber = table.Column<string>(type: "TEXT", nullable: true),
                    HashedPassword = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { 1, "Customer" },
                    { 2, "Teller" },
                    { 3, "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.InsertData(
                table: "bankaccount",
                columns: new[] { "BankNumber", "AssociatedPhoneNumber", "Balance", "CreationDate", "DateOfBirth", "HolderName", "IsActive" },
                values: new object[] { "2507220000", "50221482", 150.4569m, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(3, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abdulrahman", true });
        }
    }
}
