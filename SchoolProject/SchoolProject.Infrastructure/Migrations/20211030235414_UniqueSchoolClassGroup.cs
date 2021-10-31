using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolProject.Infrastructure.Migrations
{
    public partial class UniqueSchoolClassGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_Group",
                table: "SchoolClasses",
                column: "Group",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SchoolClasses_Group",
                table: "SchoolClasses");
        }
    }
}
