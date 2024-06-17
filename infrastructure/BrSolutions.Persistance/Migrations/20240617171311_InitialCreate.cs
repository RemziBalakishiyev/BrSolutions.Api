using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BrSolutions.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.EnsureSchema(
                name: "libraries");

            migrationBuilder.CreateTable(
                name: "Genders",
                schema: "libraries",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTypes",
                schema: "libraries",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemServices",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncryptedName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                schema: "libraries",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UserStatusId = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserStatuses_UserStatusId",
                        column: x => x.UserStatusId,
                        principalSchema: "libraries",
                        principalTable: "UserStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LastEditUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modules_Users_LastEditUserId",
                        column: x => x.LastEditUserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modules_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    SystemServiceId = table.Column<int>(type: "int", nullable: false),
                    LastEditUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_SystemServices_SystemServiceId",
                        column: x => x.SystemServiceId,
                        principalSchema: "app",
                        principalTable: "SystemServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roles_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roles_Users_LastEditUserId",
                        column: x => x.LastEditUserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UploadFiles",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelativePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    LastEditUserId = table.Column<int>(type: "int", nullable: true),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UploadFiles_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UploadFiles_Users_LastEditUserId",
                        column: x => x.LastEditUserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LastEditUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "app",
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Categories_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Users_LastEditUserId",
                        column: x => x.LastEditUserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Categories_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleUsers",
                schema: "app",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUsers", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RoleUsers_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "app",
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUsers_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<byte>(type: "tinyint", nullable: false),
                    UploadFileId = table.Column<int>(type: "int", nullable: false),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDetails_Genders_GenderId",
                        column: x => x.GenderId,
                        principalSchema: "libraries",
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDetails_UploadFiles_UploadFileId",
                        column: x => x.UploadFileId,
                        principalSchema: "app",
                        principalTable: "UploadFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDetails_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostPlans",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Definition = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nText", nullable: false),
                    Caption = table.Column<string>(type: "nText", nullable: false),
                    SharedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostStatusId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    LastEditUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedUserId = table.Column<int>(type: "int", nullable: true),
                    LastEditedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostPlans_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "app",
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostPlans_PostStatus_PostStatusId",
                        column: x => x.PostStatusId,
                        principalTable: "PostStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostPlans_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostPlans_Users_LastEditUserId",
                        column: x => x.LastEditUserId,
                        principalSchema: "app",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "libraries",
                table: "Genders",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[,]
                {
                    { (byte)1, new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(9429), "Male" },
                    { (byte)2, new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(9510), "Female" }
                });

            migrationBuilder.InsertData(
                table: "PostStatus",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(1464), "NotStarted" },
                    { 2, new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(1595), "Progress" },
                    { 3, new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(1598), "Stoped" },
                    { 4, new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(1600), "Shared" }
                });

            migrationBuilder.InsertData(
                schema: "libraries",
                table: "PostTypes",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[,]
                {
                    { (byte)1, new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(9751), "Carousel" },
                    { (byte)2, new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(9754), "OnePost" },
                    { (byte)3, new DateTime(2024, 6, 17, 21, 13, 10, 555, DateTimeKind.Local).AddTicks(9756), "Reels" }
                });

            migrationBuilder.InsertData(
                schema: "libraries",
                table: "UserStatuses",
                columns: new[] { "Id", "CreateDate", "Name" },
                values: new object[,]
                {
                    { (byte)1, new DateTime(2024, 6, 17, 21, 13, 10, 556, DateTimeKind.Local).AddTicks(9342), "Register" },
                    { (byte)2, new DateTime(2024, 6, 17, 21, 13, 10, 556, DateTimeKind.Local).AddTicks(9355), "Active" },
                    { (byte)3, new DateTime(2024, 6, 17, 21, 13, 10, 556, DateTimeKind.Local).AddTicks(9358), "Deactive" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CreatedUserId",
                schema: "app",
                table: "Categories",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_LastEditUserId",
                schema: "app",
                table: "Categories",
                column: "LastEditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ModuleId",
                schema: "app",
                table: "Categories",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UserId",
                schema: "app",
                table: "Categories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_CreatedUserId",
                schema: "app",
                table: "Modules",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_LastEditUserId",
                schema: "app",
                table: "Modules",
                column: "LastEditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_UserId",
                schema: "app",
                table: "Modules",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPlans_CategoryId",
                schema: "app",
                table: "PostPlans",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPlans_CreatedUserId",
                schema: "app",
                table: "PostPlans",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPlans_LastEditUserId",
                schema: "app",
                table: "PostPlans",
                column: "LastEditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPlans_PostStatusId",
                schema: "app",
                table: "PostPlans",
                column: "PostStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedUserId",
                schema: "app",
                table: "Roles",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_LastEditUserId",
                schema: "app",
                table: "Roles",
                column: "LastEditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_SystemServiceId",
                schema: "app",
                table: "Roles",
                column: "SystemServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUsers_RoleId",
                schema: "app",
                table: "RoleUsers",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemServices_EncryptedName",
                schema: "app",
                table: "SystemServices",
                column: "EncryptedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UploadFiles_CreatedUserId",
                schema: "app",
                table: "UploadFiles",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UploadFiles_LastEditUserId",
                schema: "app",
                table: "UploadFiles",
                column: "LastEditUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_GenderId",
                schema: "app",
                table: "UserDetails",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UploadFileId",
                schema: "app",
                table: "UserDetails",
                column: "UploadFileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_UserId",
                schema: "app",
                table: "UserDetails",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "app",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserStatusId",
                schema: "app",
                table: "Users",
                column: "UserStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostPlans",
                schema: "app");

            migrationBuilder.DropTable(
                name: "PostTypes",
                schema: "libraries");

            migrationBuilder.DropTable(
                name: "RoleUsers",
                schema: "app");

            migrationBuilder.DropTable(
                name: "UserDetails",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "app");

            migrationBuilder.DropTable(
                name: "PostStatus");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Genders",
                schema: "libraries");

            migrationBuilder.DropTable(
                name: "UploadFiles",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Modules",
                schema: "app");

            migrationBuilder.DropTable(
                name: "SystemServices",
                schema: "app");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "app");

            migrationBuilder.DropTable(
                name: "UserStatuses",
                schema: "libraries");
        }
    }
}
