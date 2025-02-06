using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataServices.Migrations
{
    /// <inheritdoc />
    public partial class AddZaloToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "canEditPhone",
                table: "MemberInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "MemberInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "memberPhone",
                table: "MemberInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ZaloTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tokenValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    expireTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaloTokens", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZaloTokens");

            migrationBuilder.DropColumn(
                name: "canEditPhone",
                table: "MemberInfos");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "MemberInfos");

            migrationBuilder.DropColumn(
                name: "memberPhone",
                table: "MemberInfos");
        }
    }
}
