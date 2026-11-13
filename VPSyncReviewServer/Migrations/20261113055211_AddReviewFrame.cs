using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VPSyncReviewServer.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewFrame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Frame",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
        

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
            name: "Frame",
            table: "Reviews");
        }
    }
}
