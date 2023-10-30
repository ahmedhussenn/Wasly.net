using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wasly.net.Migrations
{
    /// <inheritdoc />
    public partial class was : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmployeeRequest",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmployeeRequest",
                table: "AspNetUsers");
        }
    }
}
