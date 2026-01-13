using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudgetAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTransactionDateToOffset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTimeOffset(new DateTime(2026, 1, 13, 19, 56, 50, 967, DateTimeKind.Unspecified).AddTicks(9090), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "TransactionDate",
                value: new DateTimeOffset(new DateTime(2026, 1, 13, 19, 56, 50, 968, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "TransactionDate",
                value: new DateTimeOffset(new DateTime(2026, 1, 13, 19, 56, 50, 968, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                column: "TransactionDate",
                value: new DateTimeOffset(new DateTime(2026, 1, 13, 19, 56, 50, 968, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                column: "TransactionDate",
                value: new DateTimeOffset(new DateTime(2026, 1, 13, 19, 56, 50, 968, DateTimeKind.Unspecified).AddTicks(150), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateTime(2026, 1, 12, 19, 10, 1, 692, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "TransactionDate",
                value: new DateTime(2026, 1, 12, 19, 10, 1, 692, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "TransactionDate",
                value: new DateTime(2026, 1, 12, 19, 10, 1, 692, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                column: "TransactionDate",
                value: new DateTime(2026, 1, 12, 19, 10, 1, 692, DateTimeKind.Utc).AddTicks(5070));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                column: "TransactionDate",
                value: new DateTime(2026, 1, 12, 19, 10, 1, 692, DateTimeKind.Utc).AddTicks(5070));
        }
    }
}
