using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Upload_Folder_MVC.Migrations
{
    public partial class Edit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Folder");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Folder",
                newName: "FileName");

            migrationBuilder.AddColumn<byte[]>(
                name: "Content",
                table: "Folder",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Folder");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Folder",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Folder",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
