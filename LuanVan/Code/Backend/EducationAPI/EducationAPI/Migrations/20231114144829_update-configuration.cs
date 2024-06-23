using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EducationAPI.Migrations
{
    public partial class updateconfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Practices_Sections_SectionId",
                table: "Practices");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Practices",
                newName: "LessonId");

            migrationBuilder.RenameIndex(
                name: "IX_Practices_SectionId",
                table: "Practices",
                newName: "IX_Practices_LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Practices_Lessons_LessonId",
                table: "Practices",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Practices_Lessons_LessonId",
                table: "Practices");

            migrationBuilder.RenameColumn(
                name: "LessonId",
                table: "Practices",
                newName: "SectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Practices_LessonId",
                table: "Practices",
                newName: "IX_Practices_SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Practices_Sections_SectionId",
                table: "Practices",
                column: "SectionId",
                principalTable: "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
