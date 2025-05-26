using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataServices.Migrations
{
    /// <inheritdoc />
    public partial class EditTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberTransaction_MemberInfos_memberInfouser_Id",
                table: "MemberTransaction");

            migrationBuilder.DropColumn(
                name: "memberId",
                table: "MemberTransaction");

            migrationBuilder.AlterColumn<string>(
                name: "memberInfouser_Id",
                table: "MemberTransaction",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberTransaction_MemberInfos_memberInfouser_Id",
                table: "MemberTransaction",
                column: "memberInfouser_Id",
                principalTable: "MemberInfos",
                principalColumn: "user_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberTransaction_MemberInfos_memberInfouser_Id",
                table: "MemberTransaction");

            migrationBuilder.AlterColumn<string>(
                name: "memberInfouser_Id",
                table: "MemberTransaction",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "memberId",
                table: "MemberTransaction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberTransaction_MemberInfos_memberInfouser_Id",
                table: "MemberTransaction",
                column: "memberInfouser_Id",
                principalTable: "MemberInfos",
                principalColumn: "user_Id");
        }
    }
}
