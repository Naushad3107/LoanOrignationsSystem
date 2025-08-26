using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class permissiontable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_SubModule_SubModuleId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_SubModule_Module_ModuleId",
                table: "SubModule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubModule",
                table: "SubModule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module",
                table: "Module");

            migrationBuilder.RenameTable(
                name: "SubModule",
                newName: "subModules");

            migrationBuilder.RenameTable(
                name: "Module",
                newName: "modules");

            migrationBuilder.RenameIndex(
                name: "IX_SubModule_ModuleId",
                table: "subModules",
                newName: "IX_subModules_ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subModules",
                table: "subModules",
                column: "SubModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_modules",
                table: "modules",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_subModules_SubModuleId",
                table: "RolePermissions",
                column: "SubModuleId",
                principalTable: "subModules",
                principalColumn: "SubModuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subModules_modules_ModuleId",
                table: "subModules",
                column: "ModuleId",
                principalTable: "modules",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_subModules_SubModuleId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_subModules_modules_ModuleId",
                table: "subModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subModules",
                table: "subModules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_modules",
                table: "modules");

            migrationBuilder.RenameTable(
                name: "subModules",
                newName: "SubModule");

            migrationBuilder.RenameTable(
                name: "modules",
                newName: "Module");

            migrationBuilder.RenameIndex(
                name: "IX_subModules_ModuleId",
                table: "SubModule",
                newName: "IX_SubModule_ModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubModule",
                table: "SubModule",
                column: "SubModuleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module",
                table: "Module",
                column: "ModuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_SubModule_SubModuleId",
                table: "RolePermissions",
                column: "SubModuleId",
                principalTable: "SubModule",
                principalColumn: "SubModuleId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubModule_Module_ModuleId",
                table: "SubModule",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "ModuleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
