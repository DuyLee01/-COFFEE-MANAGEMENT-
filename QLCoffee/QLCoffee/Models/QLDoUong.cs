using System.ComponentModel.DataAnnotations;

namespace QLCoffee.Models
{
    public class QLDoUong
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "Tên Đồ Uống")]
        public string? TenDoUong { get; set; }

        [Display(Name = "Mô Tả")]
        public string? MoTa { get; set; }

        [Display(Name = "Loại Món")]
        public string? LoaiMon { get; set; }

        [Display(Name = "Giá")]
        public string? Gia { get; set; }

        [Display(Name = "Đánh Giá")]
        public string? DanhGia { get; set; }
    }
}
