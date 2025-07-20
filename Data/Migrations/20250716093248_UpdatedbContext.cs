using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Managment_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_account",
                table: "account");

            migrationBuilder.RenameTable(
                name: "account",
                newName: "bankaccount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bankaccount",
                table: "bankaccount",
                column: "Id");

            migrationBuilder.InsertData(
                table: "bankaccount",
                columns: new[] { "Id", "AssociatedPhoneNumber", "Balance", "CreationDate", "DateOfBirth", "HolderName", "IsActive", "Number" },
                values: new object[] { 1, "50221482", 150.4569m, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(3, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abdulrahman", true, "2507150000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_bankaccount",
                table: "bankaccount");

            migrationBuilder.DeleteData(
                table: "bankaccount",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "bankaccount",
                newName: "account");

            migrationBuilder.AddPrimaryKey(
                name: "PK_account",
                table: "account",
                column: "Id");
        }
    }
}
