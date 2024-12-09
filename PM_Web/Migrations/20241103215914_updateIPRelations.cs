using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PM.Migrations
{
    /// <inheritdoc />
    public partial class updateIPRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScopePackage1",
                table: "InterfacePoints");

            migrationBuilder.DropColumn(
                name: "ScopePackage2",
                table: "InterfacePoints");

            migrationBuilder.DropColumn(
                name: "System1",
                table: "InterfacePoints");

            migrationBuilder.DropColumn(
                name: "System2",
                table: "InterfacePoints");

            migrationBuilder.AddColumn<int>(
                name: "ScopePackage1Id",
                table: "InterfacePoints",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScopePackage2Id",
                table: "InterfacePoints",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "System1Id",
                table: "InterfacePoints",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "System2Id",
                table: "InterfacePoints",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InterfacePoints_ScopePackage1Id",
                table: "InterfacePoints",
                column: "ScopePackage1Id");

            migrationBuilder.CreateIndex(
                name: "IX_InterfacePoints_ScopePackage2Id",
                table: "InterfacePoints",
                column: "ScopePackage2Id");

            migrationBuilder.CreateIndex(
                name: "IX_InterfacePoints_System1Id",
                table: "InterfacePoints",
                column: "System1Id");

            migrationBuilder.CreateIndex(
                name: "IX_InterfacePoints_System2Id",
                table: "InterfacePoints",
                column: "System2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterfacePoints_ScopePackages_ScopePackage1Id",
                table: "InterfacePoints",
                column: "ScopePackage1Id",
                principalTable: "ScopePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterfacePoints_ScopePackages_ScopePackage2Id",
                table: "InterfacePoints",
                column: "ScopePackage2Id",
                principalTable: "ScopePackages",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterfacePoints__System_System1Id",
                table: "InterfacePoints",
                column: "System1Id",
                principalTable: "_System",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterfacePoints__System_System2Id",
                table: "InterfacePoints",
                column: "System2Id",
                principalTable: "_System",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterfacePoints_ScopePackages_ScopePackage1Id",
                table: "InterfacePoints");

            migrationBuilder.DropForeignKey(
                name: "FK_InterfacePoints_ScopePackages_ScopePackage2Id",
                table: "InterfacePoints");

            migrationBuilder.DropForeignKey(
                name: "FK_InterfacePoints__System_System1Id",
                table: "InterfacePoints");

            migrationBuilder.DropForeignKey(
                name: "FK_InterfacePoints__System_System2Id",
                table: "InterfacePoints");

            migrationBuilder.DropIndex(
                name: "IX_InterfacePoints_ScopePackage1Id",
                table: "InterfacePoints");

            migrationBuilder.DropIndex(
                name: "IX_InterfacePoints_ScopePackage2Id",
                table: "InterfacePoints");

            migrationBuilder.DropIndex(
                name: "IX_InterfacePoints_System1Id",
                table: "InterfacePoints");

            migrationBuilder.DropIndex(
                name: "IX_InterfacePoints_System2Id",
                table: "InterfacePoints");

            migrationBuilder.DropColumn(
                name: "ScopePackage1Id",
                table: "InterfacePoints");

            migrationBuilder.DropColumn(
                name: "ScopePackage2Id",
                table: "InterfacePoints");

            migrationBuilder.DropColumn(
                name: "System1Id",
                table: "InterfacePoints");

            migrationBuilder.DropColumn(
                name: "System2Id",
                table: "InterfacePoints");

            migrationBuilder.AddColumn<string>(
                name: "ScopePackage1",
                table: "InterfacePoints",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ScopePackage2",
                table: "InterfacePoints",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "System1",
                table: "InterfacePoints",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "System2",
                table: "InterfacePoints",
                type: "TEXT",
                nullable: true);
        }
    }
}
