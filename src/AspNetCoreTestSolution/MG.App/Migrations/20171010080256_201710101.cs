using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MG.App.Migrations
{
    public partial class _201710101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "SysRole",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "SysRole",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 16, 2, 56, 900, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "SysOrganize",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 16, 2, 56, 900, DateTimeKind.Local),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2017, 10, 10, 16, 2, 56, 897, DateTimeKind.Local),
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "SysRole",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "SysRole",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 10, 16, 2, 56, 900, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "SysOrganize",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 10, 16, 2, 56, 900, DateTimeKind.Local));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Account",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2017, 10, 10, 16, 2, 56, 897, DateTimeKind.Local));
        }
    }
}
