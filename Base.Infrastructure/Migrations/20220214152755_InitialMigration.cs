using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssignedTo = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DoneAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AssignedTo", "CreatedAt", "Deleted", "Description", "DoneAt", "Status" },
                values: new object[] { 1, "", new DateTime(2022, 2, 14, 15, 27, 55, 367, DateTimeKind.Local).AddTicks(709), false, "Task 1", null, 0 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AssignedTo", "CreatedAt", "Deleted", "Description", "DoneAt", "Status" },
                values: new object[] { 2, "", new DateTime(2022, 2, 14, 15, 27, 55, 367, DateTimeKind.Local).AddTicks(744), false, "Task 2", null, 0 });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "Id", "AssignedTo", "CreatedAt", "Deleted", "Description", "DoneAt", "Status" },
                values: new object[] { 3, "", new DateTime(2022, 2, 14, 15, 27, 55, 367, DateTimeKind.Local).AddTicks(746), false, "Task 3", null, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
