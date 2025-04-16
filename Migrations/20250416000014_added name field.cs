using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrentJasonWebsite.Migrations
{
    /// <inheritdoc />
    public partial class addednamefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChurchName",
                table: "Churches",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChurchName",
                table: "Churches");
        }
    }
}
