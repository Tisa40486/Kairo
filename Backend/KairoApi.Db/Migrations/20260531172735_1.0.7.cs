using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KairoApi.Db.Migrations
{
    /// <inheritdoc />
    public partial class _107 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KairoApi_Task_LKP_KairoApi_Status_LKP_StatusDaoId",
                table: "KairoApi_Task");

            migrationBuilder.DropTable(
                name: "LKP_KairoApi_Status");

            migrationBuilder.DropIndex(
                name: "IX_KairoApi_Task_LKP_StatusDaoId",
                table: "KairoApi_Task");

            migrationBuilder.DropColumn(
                name: "LKP_StatusDaoId",
                table: "KairoApi_Task");

            migrationBuilder.RenameColumn(
                name: "StatusDaoId",
                table: "KairoApi_Task",
                newName: "TaskStatus");

            migrationBuilder.AlterColumn<bool>(
                name: "Done",
                table: "KairoApi_Task",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskStatus",
                table: "KairoApi_Task",
                newName: "StatusDaoId");

            migrationBuilder.AlterColumn<bool>(
                name: "Done",
                table: "KairoApi_Task",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LKP_StatusDaoId",
                table: "KairoApi_Task",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LKP_KairoApi_Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LKP_KairoApi_Status", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "LKP_KairoApi_Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "To do" },
                    { 2, "Doing" },
                    { 3, " In Review" },
                    { 4, "Done" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_KairoApi_Task_LKP_StatusDaoId",
                table: "KairoApi_Task",
                column: "LKP_StatusDaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_KairoApi_Task_LKP_KairoApi_Status_LKP_StatusDaoId",
                table: "KairoApi_Task",
                column: "LKP_StatusDaoId",
                principalTable: "LKP_KairoApi_Status",
                principalColumn: "Id");
        }
    }
}
