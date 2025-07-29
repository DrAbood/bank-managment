using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bank_Managment_Api_1._2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    HashedPassword = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "bankaccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankNumber = table.Column<string>(type: "TEXT", nullable: false),
                    HolderName = table.Column<string>(type: "TEXT", nullable: false),
                    AssociatedPhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Balance = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CategoryID = table.Column<int>(type: "INTEGER", nullable: false),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bankaccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bankaccount_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bankaccount_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    BankAccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Beneficiary = table.Column<string>(type: "TEXT", nullable: false),
                    TransactionAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_bankaccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "bankaccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "VIP" },
                    { 2, "Premium" },
                    { 3, "Regular" }
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
                name: "IX_bankaccount_CategoryID",
                table: "bankaccount",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_bankaccount_UserID",
                table: "bankaccount",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_BankAccountId",
                table: "transactions",
                column: "BankAccountId");

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
                name: "deposits");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "withdraws");

            migrationBuilder.DropTable(
                name: "bankaccount");

            migrationBuilder.DropTable(
                name: "transactionsstatus");

            migrationBuilder.DropTable(
                name: "transactiontypes");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
