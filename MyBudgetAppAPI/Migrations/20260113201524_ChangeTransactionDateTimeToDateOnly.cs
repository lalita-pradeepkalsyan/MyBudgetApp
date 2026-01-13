using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudgetAppAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTransactionDateTimeToDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "TransactionDate",
                table: "Transactions",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "TransactionDate",
                value: new DateOnly(2026, 1, 13));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "TransactionDate",
                value: new DateOnly(2026, 1, 13));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "TransactionDate",
                value: new DateOnly(2026, 1, 13));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 4,
                column: "TransactionDate",
                value: new DateOnly(2026, 1, 13));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 5,
                column: "TransactionDate",
                value: new DateOnly(2026, 1, 13));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "TransactionDate",
                table: "Transactions",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

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
    }
}
