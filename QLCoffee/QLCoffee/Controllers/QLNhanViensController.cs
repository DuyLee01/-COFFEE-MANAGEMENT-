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
    public class QLNhanViensController : Controller
    {
        private readonly QLCoffeeContext _context;

        public QLNhanViensController(QLCoffeeContext context)
        {
            _context = context;
        }

        // GET: QLNhanViens
        // GET: Movies
        public async Task<IActionResult> Index(string NhanVienGenre, string searchString)
        {
            if (_context.QLNhanVien == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.QLNhanVien
                                            orderby m.GioiTinh
                                            select m.GioiTinh;
            var movies = from m in _context.QLNhanVien
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.TenNhanVien!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(NhanVienGenre))
            {
                movies = movies.Where(x => x.GioiTinh == NhanVienGenre);
            }

            var movieGenreVM = new NhanVienViewModel
            {
                GioiTinh = new SelectList(await genreQuery.Distinct().ToListAsync()),
                NhanViens = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: QLNhanViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLNhanVien = await _context.QLNhanVien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLNhanVien == null)
            {
                return NotFound();
            }

            return View(qLNhanVien);
        }

        // GET: QLNhanViens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QLNhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenNhanVien,NgaySinh,GioiTinh,ChucVu,Luong,SoDienThoai")] QLNhanVien qLNhanVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qLNhanVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qLNhanVien);
        }

        // GET: QLNhanViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLNhanVien = await _context.QLNhanVien.FindAsync(id);
            if (qLNhanVien == null)
            {
                return NotFound();
            }
            return View(qLNhanVien);
        }

        // POST: QLNhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenNhanVien,NgaySinh,GioiTinh,ChucVu,Luong,SoDienThoai")] QLNhanVien qLNhanVien)
        {
            if (id != qLNhanVien.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qLNhanVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QLNhanVienExists(qLNhanVien.Id))
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
            return View(qLNhanVien);
        }

        // GET: QLNhanViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLNhanVien = await _context.QLNhanVien
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLNhanVien == null)
            {
                return NotFound();
            }

            return View(qLNhanVien);
        }

        // POST: QLNhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qLNhanVien = await _context.QLNhanVien.FindAsync(id);
            if (qLNhanVien != null)
            {
                _context.QLNhanVien.Remove(qLNhanVien);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QLNhanVienExists(int id)
        {
            return _context.QLNhanVien.Any(e => e.Id == id);
        }
    }
}
