using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class fkfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModuleId1",
                table: "subModules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subModules_ModuleId1",
                table: "subModules",
                column: "ModuleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_subModules_modules_ModuleId1",
                table: "subModules",
                column: "ModuleId1",
                principalTable: "modules",
                principalColumn: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subModules_modules_ModuleId1",
                table: "subModules");

            migrationBuilder.DropIndex(
                name: "IX_subModules_ModuleId1",
                table: "subModules");

            migrationBuilder.DropColumn(
                name: "ModuleId1",
                table: "subModules");
        }
    }
}
