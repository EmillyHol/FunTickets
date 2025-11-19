using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunTickets.Migrations
{
    /// <inheritdoc />
    public partial class OtherPurchase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Purchase_ActiviteId",
                table: "Purchase");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ActiviteId",
                table: "Purchase",
                column: "ActiviteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Purchase_ActiviteId",
                table: "Purchase");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ActiviteId",
                table: "Purchase",
                column: "ActiviteId",
                unique: true);
        }
    }
}
