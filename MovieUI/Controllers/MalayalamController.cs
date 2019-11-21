using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieLibrary;

namespace MovieUI.Controllers
{
    [Authorize]
    public class MalayalamController : Controller
    {
        private readonly MovieContext _context = new MovieContext();

        
        // GET: Malayalam
        public async Task<IActionResult> Index()
        {
            return View(Movielibrarian.GetAllMoviesByLanguage(TypeOfLanguages.Malayalam));
        }

        // GET: Malayalam/Details/5
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

        // GET: Malayalam/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Malayalam/Create
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

        // GET: Malayalam/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieDetails = Movielibrarian.GetMovieDetailsByTrackNumber(id.Value);
            if (movieDetails == null)
            {
                return NotFound();
            }
            return View(movieDetails);
        }

        // POST: Malayalam/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrackNumber,Rating,Availability,Views")] MovieDetails movieDetails)
        {
            if (id != movieDetails.TrackNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Movielibrarian.UpdateMovieDetails(movieDetails);
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

        // GET: Malayalam/Delete/5
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

        // POST: Malayalam/Delete/5
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
