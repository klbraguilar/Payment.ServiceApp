using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment.Service.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    categoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    clientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.clientId);
                });

            migrationBuilder.CreateTable(
                name: "bill",
                columns: table => new
                {
                    billId = table.Column<Guid>(type: "TEXT", nullable: false),
                    categoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    clientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    period = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    state = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bill", x => x.billId);
                    table.ForeignKey(
                        name: "FK_bill_category_categoryId",
                        column: x => x.categoryId,
                        principalTable: "category",
                        principalColumn: "categoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bill_client_clientId",
                        column: x => x.clientId,
                        principalTable: "client",
                        principalColumn: "clientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bill_categoryId",
                table: "bill",
                column: "categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_bill_clientId",
                table: "bill",
                column: "clientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bill");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "client");
        }
    }
}
