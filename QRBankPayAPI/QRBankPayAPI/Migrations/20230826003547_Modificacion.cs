using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRBankPayAPI.Migrations
{
    /// <inheritdoc />
    public partial class Modificacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CuentaOrigen",
                table: "Transaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CuentaOrigen",
                table: "Transaction");
        }
    }
}
