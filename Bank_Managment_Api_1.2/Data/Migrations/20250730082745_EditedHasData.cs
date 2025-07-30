using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Managment_Api_1._2.Migrations
{
    /// <inheritdoc />
    public partial class EditedHasData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "pending");

            migrationBuilder.UpdateData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "completed");

            migrationBuilder.UpdateData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "failed");

            migrationBuilder.UpdateData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "cancelled");

            migrationBuilder.UpdateData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: "processing");

            migrationBuilder.UpdateData(
                table: "TransactionsType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "deposit");

            migrationBuilder.UpdateData(
                table: "TransactionsType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "withdraw");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryName",
                value: "vip");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryName",
                value: "premium");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryName",
                value: "regular");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleName",
                value: "customer");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleName",
                value: "teller");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleName",
                value: "admin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Pending");

            migrationBuilder.UpdateData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Completed");

            migrationBuilder.UpdateData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Failed");

            migrationBuilder.UpdateData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "Status",
                value: "Cancelled");

            migrationBuilder.UpdateData(
                table: "TransactionStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "Status",
                value: "Processing");

            migrationBuilder.UpdateData(
                table: "TransactionsType",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Deposit");

            migrationBuilder.UpdateData(
                table: "TransactionsType",
                keyColumn: "Id",
                keyValue: 2,
                column: "Type",
                value: "Withdraw");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryName",
                value: "VIP");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryName",
                value: "Premium");

            migrationBuilder.UpdateData(
                table: "category",
                keyColumn: "Id",
                keyValue: 3,
                column: "CategoryName",
                value: "Regular");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleName",
                value: "Customer");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleName",
                value: "Teller");

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleName",
                value: "Admin");
        }
    }
}
