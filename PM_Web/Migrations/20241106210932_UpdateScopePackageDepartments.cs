using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PM.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScopePackageDepartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "ScopePackageDepartments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ScopePackageDepartments_ProjectId",
                table: "ScopePackageDepartments",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScopePackageDepartments_Projects_ProjectId",
                table: "ScopePackageDepartments",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScopePackageDepartments_Projects_ProjectId",
                table: "ScopePackageDepartments");

            migrationBuilder.DropIndex(
                name: "IX_ScopePackageDepartments_ProjectId",
                table: "ScopePackageDepartments");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ScopePackageDepartments");
        }
    }
}
