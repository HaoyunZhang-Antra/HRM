using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingCandidateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobStatusLookUp_JobStatusLookUpId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Submission_Candidates_CandidateId",
                table: "Submission");

            migrationBuilder.DropForeignKey(
                name: "FK_Submission_Jobs_JobId",
                table: "Submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Submission",
                table: "Submission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobStatusLookUp",
                table: "JobStatusLookUp");

            migrationBuilder.RenameTable(
                name: "Submission",
                newName: "Submissions");

            migrationBuilder.RenameTable(
                name: "JobStatusLookUp",
                newName: "JobStatusLookUps");

            migrationBuilder.RenameIndex(
                name: "IX_Submission_JobId",
                table: "Submissions",
                newName: "IX_Submissions_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Submission_CandidateId",
                table: "Submissions",
                newName: "IX_Submissions_CandidateId");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Candidates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Candidates",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Submissions",
                table: "Submissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobStatusLookUps",
                table: "JobStatusLookUps",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_Email",
                table: "Candidates",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobStatusLookUps_JobStatusLookUpId",
                table: "Jobs",
                column: "JobStatusLookUpId",
                principalTable: "JobStatusLookUps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Candidates_CandidateId",
                table: "Submissions",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submissions_Jobs_JobId",
                table: "Submissions",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobStatusLookUps_JobStatusLookUpId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Candidates_CandidateId",
                table: "Submissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Submissions_Jobs_JobId",
                table: "Submissions");

            migrationBuilder.DropIndex(
                name: "IX_Candidates_Email",
                table: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Submissions",
                table: "Submissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobStatusLookUps",
                table: "JobStatusLookUps");

            migrationBuilder.RenameTable(
                name: "Submissions",
                newName: "Submission");

            migrationBuilder.RenameTable(
                name: "JobStatusLookUps",
                newName: "JobStatusLookUp");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_JobId",
                table: "Submission",
                newName: "IX_Submission_JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Submissions_CandidateId",
                table: "Submission",
                newName: "IX_Submission_CandidateId");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Candidates",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Candidates",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Submission",
                table: "Submission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobStatusLookUp",
                table: "JobStatusLookUp",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobStatusLookUp_JobStatusLookUpId",
                table: "Jobs",
                column: "JobStatusLookUpId",
                principalTable: "JobStatusLookUp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_Candidates_CandidateId",
                table: "Submission",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_Jobs_JobId",
                table: "Submission",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
