using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Upload_Folder_MVC.Migrations
{
    public partial class Edit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folder_AspNetUsers_UserId",
                table: "Folder");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Folder",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Folder_AspNetUsers_UserId",
                table: "Folder",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folder_AspNetUsers_UserId",
                table: "Folder");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Folder",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Folder_AspNetUsers_UserId",
                table: "Folder",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
