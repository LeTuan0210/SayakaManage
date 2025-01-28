using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataServices.Migrations
{
    /// <inheritdoc />
    public partial class AddGoogleMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "restaurantEmbedMap",
                table: "RestaurantInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "restaurantLatitude",
                table: "RestaurantInfos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "restaurantLongitude",
                table: "RestaurantInfos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "restaurantEmbedMap",
                table: "RestaurantInfos");

            migrationBuilder.DropColumn(
                name: "restaurantLatitude",
                table: "RestaurantInfos");

            migrationBuilder.DropColumn(
                name: "restaurantLongitude",
                table: "RestaurantInfos");
        }
    }
}
