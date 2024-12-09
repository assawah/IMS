using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PM.Migrations
{
    /// <inheritdoc />
    public partial class updatepro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddForeignKey(
                name: "FK_InterfacePoints_ScopePackages_ScopePackage1Id",
                table: "InterfacePoints",
                column: "ScopePackage1Id",
                principalTable: "ScopePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_InterfacePoints_ScopePackages_ScopePackage2Id",
                table: "InterfacePoints",
                column: "ScopePackage2Id",
                principalTable: "ScopePackages",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_InterfacePoints__System_System1Id",
                table: "InterfacePoints",
                column: "System1Id",
                principalTable: "_System",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_InterfacePoints__System_System2Id",
                table: "InterfacePoints",
                column: "System2Id",
                principalTable: "_System",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
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
    }
}
