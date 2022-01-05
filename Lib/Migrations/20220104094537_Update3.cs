using Microsoft.EntityFrameworkCore.Migrations;

namespace Lib.Migrations
{
    public partial class Update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoLuongEmBe",
                table: "ChuyenBay",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoLuongNguoiLon",
                table: "ChuyenBay",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoLuongTreEm",
                table: "ChuyenBay",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoLuongEmBe",
                table: "ChuyenBay");

            migrationBuilder.DropColumn(
                name: "SoLuongNguoiLon",
                table: "ChuyenBay");

            migrationBuilder.DropColumn(
                name: "SoLuongTreEm",
                table: "ChuyenBay");
        }
    }
}
