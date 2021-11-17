using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class HRMDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "Id", "Email", "LastName", "Name" },
                values: new object[] { 1, "ekatsianos@gmail.com", "Katsianos", "Evripidis" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "Id", "Email", "LastName", "Name" },
                values: new object[] { 2, "gpapadopoulos.com", "papadopoulos", "Giannis" });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "Id", "Email", "LastName", "Name" },
                values: new object[] { 3, "ipapas@gmail.com", "Papas", "Ilias" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
