using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName]) VALUES (NEWID(), 'Admin', 'ADMIN')");
            migrationBuilder.Sql("INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName]) VALUES (NEWID(), 'Teacher', 'TEACHER')");
            migrationBuilder.Sql("INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName]) VALUES (NEWID(), 'Student', 'STUDENT')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles] WHERE [Name] = 'Admin'");
            migrationBuilder.Sql("DELETE FROM [AspNetRoles] WHERE [Name] = 'Teacher'");
            migrationBuilder.Sql("DELETE FROM [AspNetRoles] WHERE [Name] = 'Student'");
        }
    }
}
