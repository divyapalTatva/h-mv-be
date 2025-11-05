using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MedVault.BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class secondmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocumentCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    is_active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    hospital_name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getutcdate())"),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentCategories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OtpVerificationes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    OtpCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    expiry = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getutcdate())"),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtpVerificationes", x => x.id);
                    table.ForeignKey(
                        name: "FK_OtpVerificationes_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientHistories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getutcdate())"),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientHistories", x => x.id);
                    table.ForeignKey(
                        name: "FK_PatientHistories_doctor_profile_doctor_id",
                        column: x => x.doctor_id,
                        principalTable: "doctor_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientHistories_patient_profile_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reminderes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    type_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    reminder_datetime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getutcdate())"),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminderes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reminderes_patient_profile_patient_id",
                        column: x => x.patient_id,
                        principalTable: "patient_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalDocumentes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    patient_history_id = table.Column<int>(type: "int", nullable: false),
                    document_category_id = table.Column<int>(type: "int", nullable: false),
                    date_of_document = table.Column<DateTime>(type: "datetime2", nullable: false),
                    file_path = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getutcdate())"),
                    created_by = table.Column<int>(type: "int", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true),
                    updated_by = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalDocumentes", x => x.id);
                    table.ForeignKey(
                        name: "FK_MedicalDocumentes_DocumentCategories_document_category_id",
                        column: x => x.document_category_id,
                        principalTable: "DocumentCategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalDocumentes_PatientHistories_patient_history_id",
                        column: x => x.patient_history_id,
                        principalTable: "PatientHistories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DocumentCategories",
                columns: new[] { "id", "created_by", "is_active", "hospital_name", "updated_at", "updated_by" },
                values: new object[,]
                {
                    { 1, null, true, "Consultation Report", null, null },
                    { 2, null, true, "Pathology", null, null },
                    { 3, null, true, "Radiology", null, null },
                    { 4, null, true, "Discharge Summary", null, null },
                    { 5, null, true, "Treatment Report", null, null },
                    { 6, null, true, "Prescription", null, null },
                    { 7, null, true, "Prescription", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDocumentes_document_category_id",
                table: "MedicalDocumentes",
                column: "document_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalDocumentes_patient_history_id",
                table: "MedicalDocumentes",
                column: "patient_history_id");

            migrationBuilder.CreateIndex(
                name: "IX_OtpVerificationes_user_id",
                table: "OtpVerificationes",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistories_doctor_id",
                table: "PatientHistories",
                column: "doctor_id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientHistories_patient_id",
                table: "PatientHistories",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reminderes_patient_id",
                table: "Reminderes",
                column: "patient_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalDocumentes");

            migrationBuilder.DropTable(
                name: "OtpVerificationes");

            migrationBuilder.DropTable(
                name: "Reminderes");

            migrationBuilder.DropTable(
                name: "DocumentCategories");

            migrationBuilder.DropTable(
                name: "PatientHistories");
        }
    }
}
