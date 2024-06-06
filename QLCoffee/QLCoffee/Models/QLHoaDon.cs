using System.ComponentModel.DataAnnotations;

namespace QLCoffee.Models
{
    public class QLHoaDon
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Tên Khách Hàng")]
        public string? TenKhachHang { get; set; }

        [Display(Name = "Ngày Giờ")]
        public string? NgayGio { get; set; }

        [Display(Name = "Danh Sách Đồ Uống")]
        public string? DanhSachDoUong { get; set; }

        [Display(Name = "Tổng Tiền")]
        public string? TongTien { get; set; }

        [Display(Name = "Đánh Giá")]
        public string? DanhGia { get; set; }
    }
}
