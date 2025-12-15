using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizOds.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Ods_OdsId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Ods");

            migrationBuilder.DropColumn(
                name: "RespostaBrasil",
                table: "Ods");

            migrationBuilder.RenameColumn(
                name: "OdsId",
                table: "Questions",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_OdsId",
                table: "Questions",
                newName: "IX_Questions_QuizId");

            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OdsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quizzes_Ods_OdsId",
                        column: x => x.OdsId,
                        principalTable: "Ods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_OdsId",
                table: "Quizzes",
                column: "OdsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions",
                column: "QuizId",
                principalTable: "Quizzes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Quizzes_QuizId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Quizzes");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Questions",
                newName: "OdsId");

            migrationBuilder.RenameIndex(
                name: "IX_Questions_QuizId",
                table: "Questions",
                newName: "IX_Questions_OdsId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Questions",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Questions",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Ods",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RespostaBrasil",
                table: "Ods",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Ods_OdsId",
                table: "Questions",
                column: "OdsId",
                principalTable: "Ods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
