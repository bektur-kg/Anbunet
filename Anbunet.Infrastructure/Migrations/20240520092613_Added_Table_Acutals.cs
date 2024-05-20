using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anbunet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_Table_Acutals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ActualId",
                table: "Stories",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Actuals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actuals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stories_ActualId",
                table: "Stories",
                column: "ActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Actuals_UserId",
                table: "Actuals",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Actuals_ActualId",
                table: "Stories",
                column: "ActualId",
                principalTable: "Actuals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Actuals_ActualId",
                table: "Stories");

            migrationBuilder.DropTable(
                name: "Actuals");

            migrationBuilder.DropIndex(
                name: "IX_Stories_ActualId",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "ActualId",
                table: "Stories");
        }
    }
}
