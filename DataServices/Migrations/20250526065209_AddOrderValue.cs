using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataServices.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberTransaction_MemberInfos_memberInfouser_Id",
                table: "MemberTransaction");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberTransaction_RestaurantInfos_restaurantId",
                table: "MemberTransaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberTransaction",
                table: "MemberTransaction");

            migrationBuilder.RenameTable(
                name: "MemberTransaction",
                newName: "MemberTransactions");

            migrationBuilder.RenameIndex(
                name: "IX_MemberTransaction_restaurantId",
                table: "MemberTransactions",
                newName: "IX_MemberTransactions_restaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberTransaction_memberInfouser_Id",
                table: "MemberTransactions",
                newName: "IX_MemberTransactions_memberInfouser_Id");

            migrationBuilder.AddColumn<int>(
                name: "orderValue",
                table: "MemberTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberTransactions",
                table: "MemberTransactions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberTransactions_MemberInfos_memberInfouser_Id",
                table: "MemberTransactions",
                column: "memberInfouser_Id",
                principalTable: "MemberInfos",
                principalColumn: "user_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberTransactions_RestaurantInfos_restaurantId",
                table: "MemberTransactions",
                column: "restaurantId",
                principalTable: "RestaurantInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberTransactions_MemberInfos_memberInfouser_Id",
                table: "MemberTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MemberTransactions_RestaurantInfos_restaurantId",
                table: "MemberTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberTransactions",
                table: "MemberTransactions");

            migrationBuilder.DropColumn(
                name: "orderValue",
                table: "MemberTransactions");

            migrationBuilder.RenameTable(
                name: "MemberTransactions",
                newName: "MemberTransaction");

            migrationBuilder.RenameIndex(
                name: "IX_MemberTransactions_restaurantId",
                table: "MemberTransaction",
                newName: "IX_MemberTransaction_restaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_MemberTransactions_memberInfouser_Id",
                table: "MemberTransaction",
                newName: "IX_MemberTransaction_memberInfouser_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberTransaction",
                table: "MemberTransaction",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberTransaction_MemberInfos_memberInfouser_Id",
                table: "MemberTransaction",
                column: "memberInfouser_Id",
                principalTable: "MemberInfos",
                principalColumn: "user_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MemberTransaction_RestaurantInfos_restaurantId",
                table: "MemberTransaction",
                column: "restaurantId",
                principalTable: "RestaurantInfos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
