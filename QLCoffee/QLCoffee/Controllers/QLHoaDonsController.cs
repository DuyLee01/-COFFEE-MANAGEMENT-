using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLCoffee.Data;
using QLCoffee.Models;

namespace QLCoffee.Controllers
{
    public class QLHoaDonsController : Controller
    {
        private readonly QLCoffeeContext _context;

        public QLHoaDonsController(QLCoffeeContext context)
        {
            _context = context;
        }

        // GET: QLHoaDons
        public async Task<IActionResult> Index(string HoaDonGenre, string searchString)
        {
            if (_context.QLHoaDon == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.QLHoaDon
                                            orderby m.NgayGio
                                            select m.NgayGio;
            var movies = from m in _context.QLHoaDon
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.TenKhachHang!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(HoaDonGenre))
            {
                movies = movies.Where(x => x.NgayGio == HoaDonGenre);
            }

            var movieGenreVM = new HoaDonViewModel
            {
                NgayGio = new SelectList(await genreQuery.Distinct().ToListAsync()),
                HoaDons = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: QLHoaDons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLHoaDon = await _context.QLHoaDon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLHoaDon == null)
            {
                return NotFound();
            }

            return View(qLHoaDon);
        }

        // GET: QLHoaDons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QLHoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenKhachHang,NgayGio,DanhSachDoUong,TongTien,DanhGia")] QLHoaDon qLHoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qLHoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qLHoaDon);
        }

        // GET: QLHoaDons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLHoaDon = await _context.QLHoaDon.FindAsync(id);
            if (qLHoaDon == null)
            {
                return NotFound();
            }
            return View(qLHoaDon);
        }

        // POST: QLHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenKhachHang,NgayGio,DanhSachDoUong,TongTien,DanhGia")] QLHoaDon qLHoaDon)
        {
            if (id != qLHoaDon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qLHoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QLHoaDonExists(qLHoaDon.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(qLHoaDon);
        }

        // GET: QLHoaDons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLHoaDon = await _context.QLHoaDon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLHoaDon == null)
            {
                return NotFound();
            }

            return View(qLHoaDon);
        }

        // POST: QLHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qLHoaDon = await _context.QLHoaDon.FindAsync(id);
            if (qLHoaDon != null)
            {
                _context.QLHoaDon.Remove(qLHoaDon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QLHoaDonExists(int id)
        {
            return _context.QLHoaDon.Any(e => e.Id == id);
        }
    }
}
