using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Managment_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_withdraws",
                table: "withdraws");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deposits",
                table: "deposits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bankaccount",
                table: "bankaccount");

            migrationBuilder.DeleteData(
                table: "bankaccount",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "withdraws");

            migrationBuilder.DropColumn(
                name: "id",
                table: "deposits");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "bankaccount");

            migrationBuilder.AddPrimaryKey(
                name: "PK_withdraws",
                table: "withdraws",
                column: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deposits",
                table: "deposits",
                column: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bankaccount",
                table: "bankaccount",
                column: "Number");

            migrationBuilder.InsertData(
                table: "bankaccount",
                columns: new[] { "Number", "AssociatedPhoneNumber", "Balance", "CreationDate", "DateOfBirth", "HolderName", "IsActive" },
                values: new object[] { "2507150000", "50221482", 150.4569m, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(3, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abdulrahman", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_withdraws",
                table: "withdraws");

            migrationBuilder.DropPrimaryKey(
                name: "PK_deposits",
                table: "deposits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bankaccount",
                table: "bankaccount");

            migrationBuilder.DeleteData(
                table: "bankaccount",
                keyColumn: "Number",
                keyValue: "2507150000");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "withdraws",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "deposits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "bankaccount",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_withdraws",
                table: "withdraws",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deposits",
                table: "deposits",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bankaccount",
                table: "bankaccount",
                column: "Id");

            migrationBuilder.InsertData(
                table: "bankaccount",
                columns: new[] { "Id", "AssociatedPhoneNumber", "Balance", "CreationDate", "DateOfBirth", "HolderName", "IsActive", "Number" },
                values: new object[] { 1, "50221482", 150.4569m, new DateTime(2025, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(3, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abdulrahman", true, "2507150000" });
        }
    }
}
