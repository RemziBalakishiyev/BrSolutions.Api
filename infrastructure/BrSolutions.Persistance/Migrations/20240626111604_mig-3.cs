using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrSolutions.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UploadFileId",
                schema: "app",
                table: "UserDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UploadFileId",
                schema: "app",
                table: "UserDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "IX_UserDetails_UploadFileId",
                schema: "app",
                table: "UserDetails",
                column: "UploadFileId",
                unique: true,
                filter: "[UploadFileId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDetails_UploadFileId",
                schema: "app",
                table: "UserDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UploadFileId",
                schema: "app",
                table: "UserDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "Genders",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 904, DateTimeKind.Local).AddTicks(831));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "Genders",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 904, DateTimeKind.Local).AddTicks(911));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 903, DateTimeKind.Local).AddTicks(2537));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 903, DateTimeKind.Local).AddTicks(2645));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 903, DateTimeKind.Local).AddTicks(2648));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 903, DateTimeKind.Local).AddTicks(2650));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 904, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 904, DateTimeKind.Local).AddTicks(1140));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 904, DateTimeKind.Local).AddTicks(1142));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 904, DateTimeKind.Local).AddTicks(8435));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 904, DateTimeKind.Local).AddTicks(8442));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 25, 0, 2, 41, 904, DateTimeKind.Local).AddTicks(8444));

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UploadFileId",
                schema: "app",
                table: "UserDetails",
                column: "UploadFileId",
                unique: true);
        }
    }
}
