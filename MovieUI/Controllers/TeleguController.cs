using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieLibrary;

namespace MovieUI.Controllers
{
    public class TeleguController : Controller
    {
        private readonly MovieContext _context = new MovieContext();

   

        // GET: Telegu
        public async Task<IActionResult> Index()
        {
            return View(Movielibrarian.GetAllMoviesByLanguage(TypeOfLanguages.Telegu));
        }

        // GET: Telegu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieDetails = await _context.MoviesDetails
                .FirstOrDefaultAsync(m => m.TrackNumber == id);
            if (movieDetails == null)
            {
                return NotFound();
            }

            return View(movieDetails);
        }

        // GET: Telegu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Telegu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieName,ReleasedYear,Language,Rating,Availability")] MovieDetails movieDetails)
        {
            if (ModelState.IsValid)
            {
                Movielibrarian.CreateMovieDetails(movieDetails.MovieName, movieDetails.Language, movieDetails.ReleasedYear, movieDetails.Availability, movieDetails.Rating);
                return RedirectToAction(nameof(Index));
            }
            return View(movieDetails);
        }

        // GET: Telegu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieDetails = await _context.MoviesDetails.FindAsync(id);
            if (movieDetails == null)
            {
                return NotFound();
            }
            return View(movieDetails);
        }

        // POST: Telegu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieName,ReleasedYear,CreatedDate,TrackNumber,Language,Rating,Availability,Views")] MovieDetails movieDetails)
        {
            if (id != movieDetails.TrackNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieDetailsExists(movieDetails.TrackNumber))
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
            return View(movieDetails);
        }

        // GET: Telegu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieDetails = await _context.MoviesDetails
                .FirstOrDefaultAsync(m => m.TrackNumber == id);
            if (movieDetails == null)
            {
                return NotFound();
            }

            return View(movieDetails);
        }

        // POST: Telegu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieDetails = await _context.MoviesDetails.FindAsync(id);
            _context.MoviesDetails.Remove(movieDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieDetailsExists(int id)
        {
            return _context.MoviesDetails.Any(e => e.TrackNumber == id);
        }
    }
}
