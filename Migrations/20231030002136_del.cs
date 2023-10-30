using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wasly.net.Migrations
{
    /// <inheritdoc />
    public partial class del : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
    name: "IsEmployeeRequest",
    table: "AspNetUsers"
);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
