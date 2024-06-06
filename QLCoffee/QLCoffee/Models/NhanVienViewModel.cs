using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace QLCoffee.Models;

public class NhanVienViewModel
{
    public List<QLNhanVien>? NhanViens { get; set; }
    public SelectList? GioiTinh { get; set; }
    public string? NhanVienGenre { get; set; }
    public string? SearchString { get; set; }
}