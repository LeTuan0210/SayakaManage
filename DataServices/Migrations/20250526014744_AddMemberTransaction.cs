using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataServices.Migrations
{
    /// <inheritdoc />
    public partial class AddMemberTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RestaurantId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MemberTransaction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    memberId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    memberInfouser_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    cashierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    restaurantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    transactionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transactionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    transactionValue = table.Column<int>(type: "int", nullable: false),
                    transactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    orderId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberTransaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberTransaction_MemberInfos_memberInfouser_Id",
                        column: x => x.memberInfouser_Id,
                        principalTable: "MemberInfos",
                        principalColumn: "user_Id");
                    table.ForeignKey(
                        name: "FK_MemberTransaction_RestaurantInfos_restaurantId",
                        column: x => x.restaurantId,
                        principalTable: "RestaurantInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTransaction_memberInfouser_Id",
                table: "MemberTransaction",
                column: "memberInfouser_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MemberTransaction_restaurantId",
                table: "MemberTransaction",
                column: "restaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_RestaurantInfos_RestaurantId",
                table: "AspNetUsers",
                column: "RestaurantId",
                principalTable: "RestaurantInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_RestaurantInfos_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MemberTransaction");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_RestaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "AspNetUsers");
        }
    }
}
