using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedVault.BE.Data.Migrations
{
    /// <inheritdoc />
    public partial class fourthmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalDocumentes_DocumentCategories_document_category_id",
                table: "MedicalDocumentes");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalDocumentes_PatientHistories_patient_history_id",
                table: "MedicalDocumentes");

            migrationBuilder.DropForeignKey(
                name: "FK_OtpVerificationes_user_user_id",
                table: "OtpVerificationes");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientHistories_doctor_profile_doctor_id",
                table: "PatientHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientHistories_patient_profile_patient_id",
                table: "PatientHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Reminderes_patient_profile_patient_id",
                table: "Reminderes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reminderes",
                table: "Reminderes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientHistories",
                table: "PatientHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OtpVerificationes",
                table: "OtpVerificationes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicalDocumentes",
                table: "MedicalDocumentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentCategories",
                table: "DocumentCategories");

            migrationBuilder.RenameTable(
                name: "Reminderes",
                newName: "reminder");

            migrationBuilder.RenameTable(
                name: "PatientHistories",
                newName: "patient_history");

            migrationBuilder.RenameTable(
                name: "OtpVerificationes",
                newName: "otp_verification");

            migrationBuilder.RenameTable(
                name: "MedicalDocumentes",
                newName: "medical_document");

            migrationBuilder.RenameTable(
                name: "DocumentCategories",
                newName: "document_category");

            migrationBuilder.RenameIndex(
                name: "IX_Reminderes_patient_id",
                table: "reminder",
                newName: "IX_reminder_patient_id");

            migrationBuilder.RenameIndex(
                name: "IX_PatientHistories_patient_id",
                table: "patient_history",
                newName: "IX_patient_history_patient_id");

            migrationBuilder.RenameIndex(
                name: "IX_PatientHistories_doctor_id",
                table: "patient_history",
                newName: "IX_patient_history_doctor_id");

            migrationBuilder.RenameIndex(
                name: "IX_OtpVerificationes_user_id",
                table: "otp_verification",
                newName: "IX_otp_verification_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalDocumentes_patient_history_id",
                table: "medical_document",
                newName: "IX_medical_document_patient_history_id");

            migrationBuilder.RenameIndex(
                name: "IX_MedicalDocumentes_document_category_id",
                table: "medical_document",
                newName: "IX_medical_document_document_category_id");

            migrationBuilder.RenameColumn(
                name: "hospital_name",
                table: "document_category",
                newName: "document_category_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reminder",
                table: "reminder",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_patient_history",
                table: "patient_history",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_otp_verification",
                table: "otp_verification",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_medical_document",
                table: "medical_document",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_document_category",
                table: "document_category",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_medical_document_document_category_document_category_id",
                table: "medical_document",
                column: "document_category_id",
                principalTable: "document_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_medical_document_patient_history_patient_history_id",
                table: "medical_document",
                column: "patient_history_id",
                principalTable: "patient_history",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_otp_verification_user_user_id",
                table: "otp_verification",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_patient_history_doctor_profile_doctor_id",
                table: "patient_history",
                column: "doctor_id",
                principalTable: "doctor_profile",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_patient_history_patient_profile_patient_id",
                table: "patient_history",
                column: "patient_id",
                principalTable: "patient_profile",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reminder_patient_profile_patient_id",
                table: "reminder",
                column: "patient_id",
                principalTable: "patient_profile",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medical_document_document_category_document_category_id",
                table: "medical_document");

            migrationBuilder.DropForeignKey(
                name: "FK_medical_document_patient_history_patient_history_id",
                table: "medical_document");

            migrationBuilder.DropForeignKey(
                name: "FK_otp_verification_user_user_id",
                table: "otp_verification");

            migrationBuilder.DropForeignKey(
                name: "FK_patient_history_doctor_profile_doctor_id",
                table: "patient_history");

            migrationBuilder.DropForeignKey(
                name: "FK_patient_history_patient_profile_patient_id",
                table: "patient_history");

            migrationBuilder.DropForeignKey(
                name: "FK_reminder_patient_profile_patient_id",
                table: "reminder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reminder",
                table: "reminder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patient_history",
                table: "patient_history");

            migrationBuilder.DropPrimaryKey(
                name: "PK_otp_verification",
                table: "otp_verification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_medical_document",
                table: "medical_document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_document_category",
                table: "document_category");

            migrationBuilder.RenameTable(
                name: "reminder",
                newName: "Reminderes");

            migrationBuilder.RenameTable(
                name: "patient_history",
                newName: "PatientHistories");

            migrationBuilder.RenameTable(
                name: "otp_verification",
                newName: "OtpVerificationes");

            migrationBuilder.RenameTable(
                name: "medical_document",
                newName: "MedicalDocumentes");

            migrationBuilder.RenameTable(
                name: "document_category",
                newName: "DocumentCategories");

            migrationBuilder.RenameIndex(
                name: "IX_reminder_patient_id",
                table: "Reminderes",
                newName: "IX_Reminderes_patient_id");

            migrationBuilder.RenameIndex(
                name: "IX_patient_history_patient_id",
                table: "PatientHistories",
                newName: "IX_PatientHistories_patient_id");

            migrationBuilder.RenameIndex(
                name: "IX_patient_history_doctor_id",
                table: "PatientHistories",
                newName: "IX_PatientHistories_doctor_id");

            migrationBuilder.RenameIndex(
                name: "IX_otp_verification_user_id",
                table: "OtpVerificationes",
                newName: "IX_OtpVerificationes_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_medical_document_patient_history_id",
                table: "MedicalDocumentes",
                newName: "IX_MedicalDocumentes_patient_history_id");

            migrationBuilder.RenameIndex(
                name: "IX_medical_document_document_category_id",
                table: "MedicalDocumentes",
                newName: "IX_MedicalDocumentes_document_category_id");

            migrationBuilder.RenameColumn(
                name: "document_category_name",
                table: "DocumentCategories",
                newName: "hospital_name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reminderes",
                table: "Reminderes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientHistories",
                table: "PatientHistories",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OtpVerificationes",
                table: "OtpVerificationes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicalDocumentes",
                table: "MedicalDocumentes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentCategories",
                table: "DocumentCategories",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalDocumentes_DocumentCategories_document_category_id",
                table: "MedicalDocumentes",
                column: "document_category_id",
                principalTable: "DocumentCategories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalDocumentes_PatientHistories_patient_history_id",
                table: "MedicalDocumentes",
                column: "patient_history_id",
                principalTable: "PatientHistories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OtpVerificationes_user_user_id",
                table: "OtpVerificationes",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientHistories_doctor_profile_doctor_id",
                table: "PatientHistories",
                column: "doctor_id",
                principalTable: "doctor_profile",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientHistories_patient_profile_patient_id",
                table: "PatientHistories",
                column: "patient_id",
                principalTable: "patient_profile",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reminderes_patient_profile_patient_id",
                table: "Reminderes",
                column: "patient_id",
                principalTable: "patient_profile",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
