using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyBudgetAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    TransactionType = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Account = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Account", "Amount", "Category", "Title", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { 1, "MainAccount", 100.0, "Rent", null, new DateTime(2026, 1, 12, 19, 10, 1, 692, DateTimeKind.Utc).AddTicks(4090), "Debit" },
                    { 2, "MainAccount", 20.0, "Gas", null, new DateTime(2026, 1, 12, 19, 10, 1, 692, DateTimeKind.Utc).AddTicks(5070), "Debit" },
                    { 3, "MainAccount", 1000.0, "Salary", null, new DateTime(2026, 1, 12, 19, 10, 1, 692, DateTimeKind.Utc).AddTicks(5070), "Credit" },
                    { 4, "MainAccount", 60.0, "Groceries", null, new DateTime(2026, 1, 12, 19, 10, 1, 692, DateTimeKind.Utc).AddTicks(5070), "Debit" },
                    { 5, "MainAccount", 30.0, "Food", null, new DateTime(2026, 1, 12, 19, 10, 1, 692, DateTimeKind.Utc).AddTicks(5070), "Debit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
