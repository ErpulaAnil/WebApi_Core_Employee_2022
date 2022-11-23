using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi_Core_Employee_2022.Migrations
{
    public partial class employeetableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesTable1",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesTable1", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "EmployeesTable1",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 1L, "uncle.bob@gmail.com", "Uncle", "Bob", "999-888-7777" });

            migrationBuilder.InsertData(
                table: "EmployeesTable1",
                columns: new[] { "EmployeeId", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[] { 2L, "jan.kirsten@gmail.com", "Jan", "Kirsten", "111-222-3333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeesTable1");
        }
    }
}
