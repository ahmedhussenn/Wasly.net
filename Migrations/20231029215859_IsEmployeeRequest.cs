using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wasly.net.Migrations
{
    /// <inheritdoc />
    public partial class IsEmployeeRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
    name: "IsEmployeeRequest",
    table: "AspNetUsers",
    type: "bit",
    nullable: false,
    defaultValue: false
);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
