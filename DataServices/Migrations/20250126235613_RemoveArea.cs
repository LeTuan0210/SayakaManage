using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataServices.Migrations
{
    /// <inheritdoc />
    public partial class RemoveArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantInfos_RestaurantAreas_restaurantAreaId",
                table: "RestaurantInfos");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantInfos_restaurantAreaId",
                table: "RestaurantInfos");

            migrationBuilder.DropColumn(
                name: "restaurantAreaId",
                table: "RestaurantInfos");

            migrationBuilder.AddColumn<string>(
                name: "restaurantArea",
                table: "RestaurantInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "restaurantArea",
                table: "RestaurantInfos");

            migrationBuilder.AddColumn<Guid>(
                name: "restaurantAreaId",
                table: "RestaurantInfos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantInfos_restaurantAreaId",
                table: "RestaurantInfos",
                column: "restaurantAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantInfos_RestaurantAreas_restaurantAreaId",
                table: "RestaurantInfos",
                column: "restaurantAreaId",
                principalTable: "RestaurantAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
