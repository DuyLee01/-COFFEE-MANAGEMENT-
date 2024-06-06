using System.ComponentModel.DataAnnotations;

namespace QLCoffee.Models
{
    public class QLNhanVien
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Tên Nhân Viên")]
        public string? TenNhanVien { get; set; }

        [Display(Name = "Ngày Sinh")]
        public string? NgaySinh { get; set; }

        [Display(Name = "Giới Tính")]
        public string? GioiTinh { get; set; }

        [Display(Name = "Chức Vụ")]
        public string? ChucVu { get; set; }

        [Display(Name = "Lương")]
        public string? Luong { get; set; }

        [Display(Name = "Số Điện Thoại")]
        public string? SoDienThoai { get; set; }
    }
}
