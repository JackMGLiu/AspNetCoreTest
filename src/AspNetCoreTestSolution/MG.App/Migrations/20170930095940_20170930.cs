using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MG.App.Migrations
{
    public partial class _20170930 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SysOrganize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EnCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsEnableed = table.Column<bool>(type: "bit", nullable: false),
                    Layer = table.Column<int>(type: "int", nullable: true),
                    ManagerId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SortCode = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    TelePhone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Type = table.Column<short>(type: "smallint", nullable: true),
                    WeChat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysOrganize", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AllowEdit = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EnCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsEnableed = table.Column<bool>(type: "bit", nullable: false),
                    ModifyTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifyUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SortCode = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Type = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    District = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmailChecked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    HeadImgUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsEnableed = table.Column<bool>(type: "bit", nullable: false),
                    LastLoginIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastWeixinSignInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    OrganizeId = table.Column<int>(type: "int", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneChecked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    PicUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Province = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QQ = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    RealName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Tel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThisLoginIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThisLoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Wallet = table.Column<decimal>(type: "decimal(18, 2)", nullable: false, defaultValue: 0m),
                    WeixinOpenId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_SysOrganize_OrganizeId",
                        column: x => x.OrganizeId,
                        principalTable: "SysOrganize",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Guid = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    SortCode = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_SysRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "SysRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_OrganizeId",
                table: "Account",
                column: "OrganizeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "SysRole");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "SysOrganize");
        }
    }
}
