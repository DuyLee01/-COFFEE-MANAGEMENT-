using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QLCoffee.Data;
using QLCoffee.Models;
using System;
using System.Linq;

namespace QLCoffee.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new QLCoffeeContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<QLCoffeeContext>>()))
        {
            // Look for any movies.
            if (context.QLNhanVien.Any())
            {
                return;   // DB has been seeded
            }
            context.QLNhanVien.AddRange(
                new QLNhanVien
                {
                    TenNhanVien = "Nguyễn Văn A",
                    NgaySinh = "01/01/2001",
                    GioiTinh = "Nam",
                    ChucVu = "Nhân Viên Phục Vụ",
                    Luong = "3M",
                    SoDienThoai = "0123456789"
                },
                new QLNhanVien
                {
                    TenNhanVien = "Nguyễn Thị B",
                    NgaySinh = "02/01/2001",
                    GioiTinh = "Nữ",
                    ChucVu = "Thu Ngân",
                    Luong = "6M",
                    SoDienThoai = "0123456789"
                },
                new QLNhanVien
                {
                    TenNhanVien = "Nguyen Văn C",
                    NgaySinh = "03/01/2001",
                    GioiTinh = "Nam",
                    ChucVu = "Quản Lý",
                    Luong = "8M",
                    SoDienThoai = "0123456789"
                },
                new QLNhanVien
                {
                    TenNhanVien = "Nguyễn Thị D",
                    NgaySinh = "04/01/2001",
                    GioiTinh = "Nữ",
                    ChucVu = "Nhân Viên Pha Chế",
                    Luong = "7M",
                    SoDienThoai = "0123456789"
                }
            );
            context.SaveChanges();
        }

        using (var context = new QLCoffeeContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<QLCoffeeContext>>()))
        {
            // Look for any movies.
            if (context.QLDoUong.Any())
            {
                return;   // DB has been seeded
            }
            context.QLDoUong.AddRange(
                new QLDoUong
                {
                    TenDoUong = "Ép Ổi",
                    MoTa = "Ổi Ép",
                    LoaiMon = "Nước",
                    Gia = "20.000vnd",
                    DanhGia = "Ngon"

                },
                new QLDoUong
                {
                    TenDoUong = "Trà Đào",
                    MoTa = "Gồm trà và đào ngâm giấm",
                    LoaiMon = "Nước",
                    Gia = "22.000vnd",
                    DanhGia = "Ngon"
                },
                new QLDoUong
                {
                    TenDoUong = "Cà Phê Sữa Đá",
                    MoTa = "Gồm sữa và cà phê được pha phin",
                    LoaiMon = "Nước",
                    Gia = "17.000vnd",
                    DanhGia = "Ngon"
                },
                new QLDoUong
                {
                    TenDoUong = "Hạt Dưa",
                    MoTa = "Hạt dưa đóng gói",
                    LoaiMon = "Khô",
                    Gia = "10.000vnd",
                    DanhGia = "Ngon"
                }
            );
            context.SaveChanges();
        }

        using (var context = new QLCoffeeContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<QLCoffeeContext>>()))
        {
            // Look for any movies.
            if (context.QLHoaDon.Any())
            {
                return;   // DB has been seeded
            }
            context.QLHoaDon.AddRange(
                new QLHoaDon
                {
                    TenKhachHang = "Nguyễn Văn A",
                    NgayGio = "1/1/2024",
                    DanhSachDoUong = "Cà Phê Sữa Đá",
                    TongTien = "17.000vnd",
                    DanhGia = "Ngon"

                },
                new QLHoaDon
                {
                    TenKhachHang = "Nguyễn Thị B",
                    NgayGio = "21/3/2024",
                    DanhSachDoUong = "Ép Ổi, Hạt Dưa",
                    TongTien = "30.000vnd",
                    DanhGia = "Bình Thường"
                },
                new QLHoaDon
                {
                    TenKhachHang = "Nguyễn Chí D",
                    NgayGio = "1/4/2024",
                    DanhSachDoUong = "Trà Đào, Cà Phê Sữa Đá, Hạt Dưa",
                    TongTien = "49.000vnd",
                    DanhGia = "Ngon"
                },
                new QLHoaDon
                {
                    TenKhachHang = "Bùi Thị E",
                    NgayGio = "22/04/2024",
                    DanhSachDoUong = "Trà Đào, Hạt Dưa",
                    TongTien = "32.000vnd",
                    DanhGia = "Bình Thường"
                }
            );
            context.SaveChanges();
        }
    }
}
