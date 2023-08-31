using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QRBankPayAPI.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionTabla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SourceBankAccount",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceAccount = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceBankAccount", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SourceBankAccount");
        }
    }
}
