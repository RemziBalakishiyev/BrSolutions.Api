using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrSolutions.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_SystemServices_SystemServiceId",
                schema: "app",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_SystemServiceId",
                schema: "app",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "SystemServiceId",
                schema: "app",
                table: "Roles");

            migrationBuilder.CreateTable(
                name: "RoleSystemService",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    SystemServiceId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleSystemService", x => new { x.RoleId, x.SystemServiceId });
                    table.ForeignKey(
                        name: "FK_RoleSystemService_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "app",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleSystemService_SystemServices_SystemServiceId",
                        column: x => x.SystemServiceId,
                        principalSchema: "app",
                        principalTable: "SystemServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "Genders",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(270));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "Genders",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(353));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 857, DateTimeKind.Local).AddTicks(3642));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 857, DateTimeKind.Local).AddTicks(3785));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 857, DateTimeKind.Local).AddTicks(3787));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 857, DateTimeKind.Local).AddTicks(3789));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(555));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(557));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(559));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(5781));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(5790));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "CreateDate",
                value: new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(5792));

            migrationBuilder.CreateIndex(
                name: "IX_RoleSystemService_SystemServiceId",
                table: "RoleSystemService",
                column: "SystemServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleSystemService");

            migrationBuilder.AddColumn<int>(
                name: "SystemServiceId",
                schema: "app",
                table: "Roles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "Genders",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 618, DateTimeKind.Local).AddTicks(7698));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "Genders",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 618, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 618, DateTimeKind.Local).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 618, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 618, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 618, DateTimeKind.Local).AddTicks(1554));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 618, DateTimeKind.Local).AddTicks(7947));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 618, DateTimeKind.Local).AddTicks(7950));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 618, DateTimeKind.Local).AddTicks(7952));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 619, DateTimeKind.Local).AddTicks(7322));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 619, DateTimeKind.Local).AddTicks(7333));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 26, 15, 16, 3, 619, DateTimeKind.Local).AddTicks(7335));

            migrationBuilder.CreateIndex(
                name: "IX_Roles_SystemServiceId",
                schema: "app",
                table: "Roles",
                column: "SystemServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_SystemServices_SystemServiceId",
                schema: "app",
                table: "Roles",
                column: "SystemServiceId",
                principalSchema: "app",
                principalTable: "SystemServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
