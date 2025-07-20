using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Managment_API.Data.Migrations
{
    /// <inheritdoc />
    public partial class New_Update : Migration
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_withdraws",
                table: "withdraws",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deposits",
                table: "deposits",
                column: "id");
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

            migrationBuilder.DropColumn(
                name: "Id",
                table: "withdraws");

            migrationBuilder.DropColumn(
                name: "id",
                table: "deposits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_withdraws",
                table: "withdraws",
                column: "Number");

            migrationBuilder.AddPrimaryKey(
                name: "PK_deposits",
                table: "deposits",
                column: "Number");
        }
    }
}
