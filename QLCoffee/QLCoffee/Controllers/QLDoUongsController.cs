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
    public class QLDoUongsController : Controller
    {
        private readonly QLCoffeeContext _context;

        public QLDoUongsController(QLCoffeeContext context)
        {
            _context = context;
        }

        // GET: QLDoUongs
        public async Task<IActionResult> Index(string DoUongGenre, string searchString)
        {
            if (_context.QLDoUong == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.QLDoUong
                                            orderby m.LoaiMon
                                            select m.LoaiMon;
            var movies = from m in _context.QLDoUong    
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.TenDoUong!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(DoUongGenre))
            {
                movies = movies.Where(x => x.LoaiMon == DoUongGenre);
            }

            var movieGenreVM = new DoUongViewModel
            {
                Loai = new SelectList(await genreQuery.Distinct().ToListAsync()),
                DoUongs = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: QLDoUongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLDoUong = await _context.QLDoUong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLDoUong == null)
            {
                return NotFound();
            }

            return View(qLDoUong);
        }

        // GET: QLDoUongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QLDoUongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenDoUong,MoTa,LoaiMon,Gia,DanhGia")] QLDoUong qLDoUong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qLDoUong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(qLDoUong);
        }

        // GET: QLDoUongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLDoUong = await _context.QLDoUong.FindAsync(id);
            if (qLDoUong == null)
            {
                return NotFound();
            }
            return View(qLDoUong);
        }

        // POST: QLDoUongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenDoUong,MoTa,LoaiMon,Gia,DanhGia")] QLDoUong qLDoUong)
        {
            if (id != qLDoUong.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qLDoUong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QLDoUongExists(qLDoUong.Id))
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
            return View(qLDoUong);
        }

        // GET: QLDoUongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qLDoUong = await _context.QLDoUong
                .FirstOrDefaultAsync(m => m.Id == id);
            if (qLDoUong == null)
            {
                return NotFound();
            }

            return View(qLDoUong);
        }

        // POST: QLDoUongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qLDoUong = await _context.QLDoUong.FindAsync(id);
            if (qLDoUong != null)
            {
                _context.QLDoUong.Remove(qLDoUong);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QLDoUongExists(int id)
        {
            return _context.QLDoUong.Any(e => e.Id == id);
        }
    }
}
