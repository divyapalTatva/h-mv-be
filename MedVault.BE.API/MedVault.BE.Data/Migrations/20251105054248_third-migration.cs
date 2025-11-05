using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedVault.BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class thirdmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "OtpVerificationes");

            migrationBuilder.DropColumn(
                name: "created_by",
                table: "OtpVerificationes");

            migrationBuilder.DropColumn(
                name: "is_deleted",
                table: "OtpVerificationes");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "OtpVerificationes");

            migrationBuilder.DropColumn(
                name: "updated_by",
                table: "OtpVerificationes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "OtpVerificationes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "(getutcdate())");

            migrationBuilder.AddColumn<int>(
                name: "created_by",
                table: "OtpVerificationes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_deleted",
                table: "OtpVerificationes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "OtpVerificationes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "updated_by",
                table: "OtpVerificationes",
                type: "int",
                nullable: true);
        }
    }
}
