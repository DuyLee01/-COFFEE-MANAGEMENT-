using Microsoft.AspNetCore.Mvc.Rendering;

namespace QLCoffee.Models
{
    public class HoaDonViewModel
    {
        public List<QLHoaDon>? HoaDons { get; set; }
        public SelectList? NgayGio { get; set; }
        public string? HoaDonGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
