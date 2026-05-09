using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KairoApi.Db.Migrations
{
    /// <inheritdoc />
    public partial class _103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LKP_StatusDaoid",
                table: "KairoApi_Task",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusDaoId",
                table: "KairoApi_Task",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LKP_KairoApi_Status",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LKP_KairoApi_Status", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "LKP_KairoApi_Status",
                columns: new[] { "id", "Name" },
                values: new object[,]
                {
                    { 1, "To do" },
                    { 2, "Doing" },
                    { 3, " In Review" },
                    { 4, "Done" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_KairoApi_Task_LKP_StatusDaoid",
                table: "KairoApi_Task",
                column: "LKP_StatusDaoid");

            migrationBuilder.AddForeignKey(
                name: "FK_KairoApi_Task_LKP_KairoApi_Status_LKP_StatusDaoid",
                table: "KairoApi_Task",
                column: "LKP_StatusDaoid",
                principalTable: "LKP_KairoApi_Status",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KairoApi_Task_LKP_KairoApi_Status_LKP_StatusDaoid",
                table: "KairoApi_Task");

            migrationBuilder.DropTable(
                name: "LKP_KairoApi_Status");

            migrationBuilder.DropIndex(
                name: "IX_KairoApi_Task_LKP_StatusDaoid",
                table: "KairoApi_Task");

            migrationBuilder.DropColumn(
                name: "LKP_StatusDaoid",
                table: "KairoApi_Task");

            migrationBuilder.DropColumn(
                name: "StatusDaoId",
                table: "KairoApi_Task");
        }
    }
}
