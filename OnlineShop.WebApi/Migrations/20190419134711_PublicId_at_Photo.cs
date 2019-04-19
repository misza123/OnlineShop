using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.WebApi.Migrations
{
    public partial class PublicId_at_Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //TODO Fix and uncomment
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Orders_Users_UserId",
            //     table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "Photos",
                nullable: true);

            // migrationBuilder.AlterColumn<int>(
            //     name: "UserId",
            //     table: "Orders",
            //     nullable: false,
            //     oldClrType: typeof(int),
            //     oldNullable: true);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Orders_Users_UserId",
            //     table: "Orders",
            //     column: "UserId",
            //     principalTable: "Users",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Orders_Users_UserId",
            //     table: "Orders");

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "Photos");

            // migrationBuilder.AlterColumn<int>(
            //     name: "UserId",
            //     table: "Orders",
            //     nullable: true,
            //     oldClrType: typeof(int));

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Orders_Users_UserId",
            //     table: "Orders",
            //     column: "UserId",
            //     principalTable: "Users",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Restrict);
        }
    }
}
