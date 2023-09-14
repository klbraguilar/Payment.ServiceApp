using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment.Service.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructur : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "costo",
                table: "bill",
                newName: "amount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "amount",
                table: "bill",
                newName: "costo");
        }
    }
}
