using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.TpFinanceiro.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TPFINANCEIRO",
                columns: table => new
                {
                    IDFINANCIAS = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPFINANCEIRO", x => x.IDFINANCIAS);
                });

            migrationBuilder.CreateTable(
                name: "FINACIAS",
                columns: table => new
                {
                    IDFINANCIAS = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DATA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OBS = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IDTPFINANCIAS = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VALOR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    META = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FINACIAS", x => x.IDFINANCIAS);
                    table.ForeignKey(
                        name: "FK_FINACIAS_TPFINANCEIRO_IDTPFINANCIAS",
                        column: x => x.IDTPFINANCIAS,
                        principalTable: "TPFINANCEIRO",
                        principalColumn: "IDFINANCIAS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FINACIAS_IDTPFINANCIAS",
                table: "FINACIAS",
                column: "IDTPFINANCIAS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FINACIAS");

            migrationBuilder.DropTable(
                name: "TPFINANCEIRO");
        }
    }
}
