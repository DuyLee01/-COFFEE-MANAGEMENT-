using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLCoffee.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QLDoUong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDoUong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiMon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhGia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLDoUong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QLHoaDon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachHang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayGio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhSachDoUong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TongTien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DanhGia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLHoaDon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QLNhanVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNhanVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GioiTinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Luong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QLNhanVien", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QLDoUong");

            migrationBuilder.DropTable(
                name: "QLHoaDon");

            migrationBuilder.DropTable(
                name: "QLNhanVien");
        }
    }
}
