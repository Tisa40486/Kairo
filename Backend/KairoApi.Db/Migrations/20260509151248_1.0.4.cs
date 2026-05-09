using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KairoApi.Db.Migrations
{
    /// <inheritdoc />
    public partial class _104 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KairoApi_Task_LKP_KairoApi_Status_LKP_StatusDaoid",
                table: "KairoApi_Task");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LKP_KairoApi_Status",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "KairoApi_User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LKP_StatusDaoid",
                table: "KairoApi_Task",
                newName: "LKP_StatusDaoId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "KairoApi_Task",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_KairoApi_Task_LKP_StatusDaoid",
                table: "KairoApi_Task",
                newName: "IX_KairoApi_Task_LKP_StatusDaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_KairoApi_Task_LKP_KairoApi_Status_LKP_StatusDaoId",
                table: "KairoApi_Task",
                column: "LKP_StatusDaoId",
                principalTable: "LKP_KairoApi_Status",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KairoApi_Task_LKP_KairoApi_Status_LKP_StatusDaoId",
                table: "KairoApi_Task");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LKP_KairoApi_Status",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "KairoApi_User",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "LKP_StatusDaoId",
                table: "KairoApi_Task",
                newName: "LKP_StatusDaoid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "KairoApi_Task",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_KairoApi_Task_LKP_StatusDaoId",
                table: "KairoApi_Task",
                newName: "IX_KairoApi_Task_LKP_StatusDaoid");

            migrationBuilder.AddForeignKey(
                name: "FK_KairoApi_Task_LKP_KairoApi_Status_LKP_StatusDaoid",
                table: "KairoApi_Task",
                column: "LKP_StatusDaoid",
                principalTable: "LKP_KairoApi_Status",
                principalColumn: "id");
        }
    }
}
