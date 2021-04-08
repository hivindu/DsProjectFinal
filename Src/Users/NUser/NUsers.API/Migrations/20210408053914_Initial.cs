using Microsoft.EntityFrameworkCore.Migrations;

namespace NUsers.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserData",
                columns: table => new
                {
                    UId = table.Column<int>(nullable: false),
                    F_name = table.Column<string>(nullable: true),
                    L_name = table.Column<string>(nullable: true),
                    Contact = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Batch = table.Column<string>(nullable: true),
                    Degree = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserData", x => x.UId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserData");
        }
    }
}
