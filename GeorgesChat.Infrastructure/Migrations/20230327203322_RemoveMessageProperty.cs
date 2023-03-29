using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeorgesChat.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMessageProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConnectionlId",
                table: "Messages",
                newName: "ConnectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ConnectionId",
                table: "Messages",
                newName: "ConnectionlId");
        }
    }
}
