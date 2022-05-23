using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using shopmohinh.Data;
using shopmohinh.Models;

namespace shopmohinh.Controllers
{
    public class figs1Controller : Controller
    {
        private readonly shopmohinhContext _context;

        public figs1Controller(shopmohinhContext context)
        {
            _context = context;
        }

        // GET: figs1
        public async Task<IActionResult> Index(string figsGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.fig
                                            orderby b.Genre
                                            select b.Genre;
            var figs = from b in _context.fig
                        select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                figs = figs.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(figsGenre))
            {
                figs = figs.Where(x => x.Genre == figsGenre);
            }
            var figsGenreVM = new figs1GenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                figs = await figs.ToListAsync()
            };
            return View(figsGenreVM);
        }
        public async Task<IActionResult> admin(string figsGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.fig
                                            orderby b.Genre
                                            select b.Genre;
            var figs = from b in _context.fig
                       select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                figs = figs.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(figsGenre))
            {
                figs = figs.Where(x => x.Genre == figsGenre);
            }
            var figsGenreVM = new figs1GenreViewModel
            {
                Genres = new SelectList(await
           genreQuery.Distinct().ToListAsync()),
                figs = await figs.ToListAsync()
            };
            return View(figsGenreVM);
        }


        // GET: figs1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fig = await _context.fig
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fig == null)
            {
                return NotFound();
            }

            return View(fig);
        }

        // GET: figs1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: figs1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] fig fig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fig);
        }

        // GET: figs1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fig = await _context.fig.FindAsync(id);
            if (fig == null)
            {
                return NotFound();
            }
            return View(fig);
        }

        // POST: figs1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] fig fig)
        {
            if (id != fig.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!figExists(fig.Id))
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
            return View(fig);
        }

        // GET: figs1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fig = await _context.fig
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fig == null)
            {
                return NotFound();
            }

            return View(fig);
        }

        // POST: figs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fig = await _context.fig.FindAsync(id);
            _context.fig.Remove(fig);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool figExists(int id)
        {
            return _context.fig.Any(e => e.Id == id);
        }
    }
}
