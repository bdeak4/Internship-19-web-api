using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Data.Migrations
{
    public partial class FixFKIdColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdCategory_CategoryId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdOwners_OwnerId",
                table: "Ads");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Ads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Ads",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AdCategory_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "AdCategory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AdOwners_OwnerId",
                table: "Ads",
                column: "OwnerId",
                principalTable: "AdOwners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdCategory_CategoryId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdOwners_OwnerId",
                table: "Ads");

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Ads",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AdCategory_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "AdCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AdOwners_OwnerId",
                table: "Ads",
                column: "OwnerId",
                principalTable: "AdOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
