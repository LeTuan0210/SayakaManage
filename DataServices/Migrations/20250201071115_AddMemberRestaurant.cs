using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataServices.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberRestaurant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    user_Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_Id_By_App = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    memberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    memberBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    memberGender = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberFavouriteRestaurants",
                columns: table => new
                {
                    memberInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    restaurantInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberFavouriteRestaurants");

            migrationBuilder.DropTable(
                name: "MemberInfos");
        }
    }
}
