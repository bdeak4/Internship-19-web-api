using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Data.Migrations
{
    public partial class FixCategoriesTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdCategory_CategoryId",
                table: "Ads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdCategory",
                table: "AdCategory");

            migrationBuilder.RenameTable(
                name: "AdCategory",
                newName: "AdCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdCategories",
                table: "AdCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AdCategories_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "AdCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AdCategories_CategoryId",
                table: "Ads");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdCategories",
                table: "AdCategories");

            migrationBuilder.RenameTable(
                name: "AdCategories",
                newName: "AdCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdCategory",
                table: "AdCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AdCategory_CategoryId",
                table: "Ads",
                column: "CategoryId",
                principalTable: "AdCategory",
                principalColumn: "Id");
        }
    }
}
