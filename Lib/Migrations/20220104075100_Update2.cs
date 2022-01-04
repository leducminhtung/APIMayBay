using Microsoft.EntityFrameworkCore.Migrations;

namespace Lib.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GIA",
                table: "ChuyenBay",
                newName: "TONGTIEN");

            migrationBuilder.AddColumn<decimal>(
                name: "GIADICHVUEMBE",
                table: "ChuyenBay",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GIADICHVUNGUOILON",
                table: "ChuyenBay",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GIADICHVUTREEM",
                table: "ChuyenBay",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GIAEMBE",
                table: "ChuyenBay",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GIANGUOILON",
                table: "ChuyenBay",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "GIATREEM",
                table: "ChuyenBay",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "THUEPHISANBAYEMBE",
                table: "ChuyenBay",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "THUEPHISANBAYNGUOILON",
                table: "ChuyenBay",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "THUEPHISANBAYTREEM",
                table: "ChuyenBay",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GIADICHVUEMBE",
                table: "ChuyenBay");

            migrationBuilder.DropColumn(
                name: "GIADICHVUNGUOILON",
                table: "ChuyenBay");

            migrationBuilder.DropColumn(
                name: "GIADICHVUTREEM",
                table: "ChuyenBay");

            migrationBuilder.DropColumn(
                name: "GIAEMBE",
                table: "ChuyenBay");

            migrationBuilder.DropColumn(
                name: "GIANGUOILON",
                table: "ChuyenBay");

            migrationBuilder.DropColumn(
                name: "GIATREEM",
                table: "ChuyenBay");

            migrationBuilder.DropColumn(
                name: "THUEPHISANBAYEMBE",
                table: "ChuyenBay");

            migrationBuilder.DropColumn(
                name: "THUEPHISANBAYNGUOILON",
                table: "ChuyenBay");

            migrationBuilder.DropColumn(
                name: "THUEPHISANBAYTREEM",
                table: "ChuyenBay");

            migrationBuilder.RenameColumn(
                name: "TONGTIEN",
                table: "ChuyenBay",
                newName: "GIA");

            
        }
    }
}
