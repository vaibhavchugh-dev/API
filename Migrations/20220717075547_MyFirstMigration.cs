using Microsoft.EntityFrameworkCore.Migrations;

namespace rwaAPI.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    ownerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ownername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    towerid = table.Column<int>(type: "int", nullable: false),
                    flatno = table.Column<int>(type: "int", nullable: false),
                    adderess = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noofmembers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    officeaddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    noofvechicles = table.Column<int>(type: "int", nullable: false),
                    isparkingspace = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => x.ownerid);
                });

            migrationBuilder.CreateTable(
                name: "towers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    towerno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<int>(type: "int", nullable: false),
                    noflats = table.Column<int>(type: "int", nullable: false),
                    nofloors = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_towers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "owners");

            migrationBuilder.DropTable(
                name: "towers");
        }
    }
}
