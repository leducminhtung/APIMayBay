using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lib.Migrations
{
    public partial class Update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Khach",
                columns: table => new
                {
                    MaKhach = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CCCD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Khach", x => x.MaKhach);
                });

            migrationBuilder.CreateTable(
                name: "LoTuyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CangDiId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaCangDi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id2 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CangDenId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaCangDen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoTuyen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoTuyen_CangBay_CangDenId",
                        column: x => x.CangDenId,
                        principalTable: "CangBay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoTuyen_CangBay_CangDiId",
                        column: x => x.CangDiId,
                        principalTable: "CangBay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    MaTK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.MaTK);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SL_NguoiLon = table.Column<int>(type: "int", nullable: false),
                    SL_TreEm = table.Column<int>(type: "int", nullable: false),
                    SL_EmBe = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaKhach = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KhachMaKhach = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDon_Khach_KhachMaKhach",
                        column: x => x.KhachMaKhach,
                        principalTable: "Khach",
                        principalColumn: "MaKhach",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VeMayBay",
                columns: table => new
                {
                    STT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChuyenBayId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaHD = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HoaDonMaHD = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TongTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoaiVe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VeMayBay", x => x.STT);
                    table.ForeignKey(
                        name: "FK_VeMayBay_ChuyenBay_ChuyenBayId",
                        column: x => x.ChuyenBayId,
                        principalTable: "ChuyenBay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VeMayBay_HoaDon_HoaDonMaHD",
                        column: x => x.HoaDonMaHD,
                        principalTable: "HoaDon",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_KhachMaKhach",
                table: "HoaDon",
                column: "KhachMaKhach");

            migrationBuilder.CreateIndex(
                name: "IX_LoTuyen_CangDenId",
                table: "LoTuyen",
                column: "CangDenId");

            migrationBuilder.CreateIndex(
                name: "IX_LoTuyen_CangDiId",
                table: "LoTuyen",
                column: "CangDiId");

            migrationBuilder.CreateIndex(
                name: "IX_VeMayBay_ChuyenBayId",
                table: "VeMayBay",
                column: "ChuyenBayId");

            migrationBuilder.CreateIndex(
                name: "IX_VeMayBay_HoaDonMaHD",
                table: "VeMayBay",
                column: "HoaDonMaHD");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoTuyen");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "VeMayBay");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "Khach");
        }
    }
}
