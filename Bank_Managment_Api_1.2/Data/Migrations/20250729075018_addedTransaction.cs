using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank_Managment_Api_1._2.Migrations
{
    /// <inheritdoc />
    public partial class addedTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transactionsstatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactionsstatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transactiontypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactiontypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    BankAccoutnId = table.Column<int>(type: "INTEGER", nullable: false),
                    bankAccountBankNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Beneficiary = table.Column<string>(type: "TEXT", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_transactions_bankaccount_bankAccountBankNumber",
                        column: x => x.bankAccountBankNumber,
                        principalTable: "bankaccount",
                        principalColumn: "BankNumber");
                    table.ForeignKey(
                        name: "FK_transactions_transactionsstatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "transactionsstatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transactions_transactiontypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "transactiontypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "transactionsstatus",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Completed" },
                    { 3, "Failed" },
                    { 4, "Cancelled" },
                    { 5, "Processing" }
                });

            migrationBuilder.InsertData(
                table: "transactiontypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Deposit" },
                    { 2, "Withdraw" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_bankAccountBankNumber",
                table: "transactions",
                column: "bankAccountBankNumber");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_StatusId",
                table: "transactions",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_TransactionTypeId",
                table: "transactions",
                column: "TransactionTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "transactionsstatus");

            migrationBuilder.DropTable(
                name: "transactiontypes");
        }
    }
}
