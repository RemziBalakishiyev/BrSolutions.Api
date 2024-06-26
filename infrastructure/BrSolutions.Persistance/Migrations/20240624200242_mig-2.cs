using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BrSolutions.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HttpMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EndpointName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExceptionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExceptionLogs_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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
                name: "IX_ExceptionLogs_UserId",
                table: "ExceptionLogs",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExceptionLogs");

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "Genders",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(9429));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "Genders",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(1464));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(1595));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(1598));

            migrationBuilder.UpdateData(
                table: "PostStatus",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(1600));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(9751));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(9754));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "PostTypes",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(9756));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)1,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 556, DateTimeKind.Local).AddTicks(9342));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)2,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 556, DateTimeKind.Local).AddTicks(9355));

            migrationBuilder.UpdateData(
                schema: "libraries",
                table: "UserStatuses",
                keyColumn: "Id",
                keyValue: (byte)3,
                column: "CreateDate",
                value: new DateTime(2024, 6, 17, 21, 13, 10, 556, DateTimeKind.Local).AddTicks(9358));
        }
    }
}
