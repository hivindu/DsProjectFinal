using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminUser.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminUser",
                columns: table => new
                {
                    UId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_name = table.Column<string>(nullable: true),
                    L_name = table.Column<string>(nullable: true),
                    Contact = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUser", x => x.UId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUser");
        }
    }
}
