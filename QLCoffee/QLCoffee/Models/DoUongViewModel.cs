using Microsoft.AspNetCore.Mvc.Rendering;

namespace QLCoffee.Models
{
    public class DoUongViewModel
    {
        public List<QLDoUong>? DoUongs { get; set; }
        public SelectList? Loai { get; set; }
        public string? DoUongGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
