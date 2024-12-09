using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PM.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentsToIP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Department1Id",
                table: "InterfacePoints",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Department2Id",
                table: "InterfacePoints",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InterfacePoints_Department1Id",
                table: "InterfacePoints",
                column: "Department1Id");

            migrationBuilder.CreateIndex(
                name: "IX_InterfacePoints_Department2Id",
                table: "InterfacePoints",
                column: "Department2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterfacePoints_ScopePackageDepartments_Department1Id",
                table: "InterfacePoints",
                column: "Department1Id",
                principalTable: "ScopePackageDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterfacePoints_ScopePackageDepartments_Department2Id",
                table: "InterfacePoints",
                column: "Department2Id",
                principalTable: "ScopePackageDepartments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterfacePoints_ScopePackageDepartments_Department1Id",
                table: "InterfacePoints");

            migrationBuilder.DropForeignKey(
                name: "FK_InterfacePoints_ScopePackageDepartments_Department2Id",
                table: "InterfacePoints");

            migrationBuilder.DropIndex(
                name: "IX_InterfacePoints_Department1Id",
                table: "InterfacePoints");

            migrationBuilder.DropIndex(
                name: "IX_InterfacePoints_Department2Id",
                table: "InterfacePoints");

            migrationBuilder.DropColumn(
                name: "Department1Id",
                table: "InterfacePoints");

            migrationBuilder.DropColumn(
                name: "Department2Id",
                table: "InterfacePoints");
        }
    }
}
