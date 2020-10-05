using Microsoft.EntityFrameworkCore.Migrations;

namespace PubBase.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pubs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pubs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pubs",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 1, "Liberec", "Svah" });

            migrationBuilder.InsertData(
                table: "Pubs",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 2, "Jablonec nad Nisou", "Techtle" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pubs");
        }
    }
}
