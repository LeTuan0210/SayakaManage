using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataServices.Migrations
{
    /// <inheritdoc />
    public partial class AddZaloPromotion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZaloPromotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isDefault = table.Column<bool>(type: "bit", nullable: false),
                    isEnable = table.Column<bool>(type: "bit", nullable: false),
                    createDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaloPromotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZaloPromotionButtons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    promotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaloPromotionButtons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZaloPromotionButtons_ZaloPromotions_promotionId",
                        column: x => x.promotionId,
                        principalTable: "ZaloPromotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZaloPromotionElements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    promotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaloPromotionElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZaloPromotionElements_ZaloPromotions_promotionId",
                        column: x => x.promotionId,
                        principalTable: "ZaloPromotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrders_restaurantId",
                table: "CustomerOrders",
                column: "restaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_ZaloPromotionButtons_promotionId",
                table: "ZaloPromotionButtons",
                column: "promotionId");

            migrationBuilder.CreateIndex(
                name: "IX_ZaloPromotionElements_promotionId",
                table: "ZaloPromotionElements",
                column: "promotionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "ZaloPromotionButtons");

            migrationBuilder.DropTable(
                name: "ZaloPromotionElements");

            migrationBuilder.DropTable(
                name: "ZaloPromotions");

            migrationBuilder.DropIndex(
                name: "IX_CustomerOrders_restaurantId",
                table: "CustomerOrders");
        }
    }
}
