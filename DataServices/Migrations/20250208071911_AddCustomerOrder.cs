using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataServices.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberFavouriteRestaurants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberInfos",
                table: "MemberInfos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MemberInfos");

            migrationBuilder.AlterColumn<string>(
                name: "user_Id",
                table: "MemberInfos",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberInfos",
                table: "MemberInfos",
                column: "user_Id");

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    restaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    memberId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    countCustomer = table.Column<int>(type: "int", nullable: false),
                    customerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orderNote = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.id);
                    table.ForeignKey(
                        name: "FK_CustomerOrders_MemberInfos_memberId",
                        column: x => x.memberId,
                        principalTable: "MemberInfos",
                        principalColumn: "user_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_memberId",
                table: "CustomerOrders",
                column: "memberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberInfos",
                table: "MemberInfos");

            migrationBuilder.AlterColumn<string>(
                name: "user_Id",
                table: "MemberInfos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "MemberInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberInfos",
                table: "MemberInfos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MemberFavouriteRestaurants",
                columns: table => new
                {
                    restaurantInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    memberInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberFavouriteRestaurants", x => new { x.restaurantInfoId, x.memberInfoId });
                    table.ForeignKey(
                        name: "FK_MemberFavouriteRestaurants_MemberInfos_memberInfoId",
                        column: x => x.memberInfoId,
                        principalTable: "MemberInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MemberFavouriteRestaurants_RestaurantInfos_restaurantInfoId",
                        column: x => x.restaurantInfoId,
                        principalTable: "RestaurantInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberFavouriteRestaurants_memberInfoId",
                table: "MemberFavouriteRestaurants",
                column: "memberInfoId");
        }
    }
}
