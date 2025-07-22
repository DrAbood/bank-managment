using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Managment_Api_1._2.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bankaccount",
                columns: table => new
                {
                    BankNumber = table.Column<string>(type: "TEXT", nullable: false),
                    HolderName = table.Column<string>(type: "TEXT", nullable: false),
                    AssociatedPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankaccount", x => x.BankNumber);
                });

            migrationBuilder.CreateTable(
                name: "deposits",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deposits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "withdraws",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_withdraws", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "bankaccount",
                columns: new[] { "BankNumber", "AssociatedPhoneNumber", "Balance", "CreationDate", "DateOfBirth", "HolderName", "IsActive" },
                values: new object[] { "2507220000", "50221482", 150.4569m, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(3, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abdulrahman", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bankaccount");

            migrationBuilder.DropTable(
                name: "deposits");

            migrationBuilder.DropTable(
                name: "withdraws");
        }
    }
}
