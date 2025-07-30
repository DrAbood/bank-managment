using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Managment_Api_1._2.Migrations
{
    /// <inheritdoc />
    public partial class tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bankaccount_categories_CategoryID",
                table: "bankaccount");

            migrationBuilder.DropForeignKey(
                name: "FK_bankaccount_users_UserID",
                table: "bankaccount");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_transactionsstatus_StatusId",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_transactiontypes_TransactionTypeId",
                table: "transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactiontypes",
                table: "transactiontypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transactionsstatus",
                table: "transactionsstatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "transactiontypes",
                newName: "TransactionsType");

            migrationBuilder.RenameTable(
                name: "transactionsstatus",
                newName: "TransactionStatus");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionsType",
                table: "TransactionsType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionStatus",
                table: "TransactionStatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bankaccount_category_CategoryID",
                table: "bankaccount",
                column: "CategoryID",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bankaccount_user_UserID",
                table: "bankaccount",
                column: "UserID",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_TransactionStatus_StatusId",
                table: "transactions",
                column: "StatusId",
                principalTable: "TransactionStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_TransactionsType_TransactionTypeId",
                table: "transactions",
                column: "TransactionTypeId",
                principalTable: "TransactionsType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bankaccount_category_CategoryID",
                table: "bankaccount");

            migrationBuilder.DropForeignKey(
                name: "FK_bankaccount_user_UserID",
                table: "bankaccount");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_TransactionStatus_StatusId",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_TransactionsType_TransactionTypeId",
                table: "transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionsType",
                table: "TransactionsType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionStatus",
                table: "TransactionStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "TransactionsType",
                newName: "transactiontypes");

            migrationBuilder.RenameTable(
                name: "TransactionStatus",
                newName: "transactionsstatus");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactiontypes",
                table: "transactiontypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transactionsstatus",
                table: "transactionsstatus",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_transactionsstatus_StatusId",
                table: "transactions",
                column: "StatusId",
                principalTable: "transactionsstatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_transactiontypes_TransactionTypeId",
                table: "transactions",
                column: "TransactionTypeId",
                principalTable: "transactiontypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
