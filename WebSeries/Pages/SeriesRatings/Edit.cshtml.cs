using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSeries.BusinessLayer;
using WebSeries.Data;

namespace WebSeries.Pages.SeriesRatings
{
    public class EditModel : PageModel
    {
        private readonly WebSeries.Data.WebSeriesDBContext _context;

        public EditModel(WebSeries.Data.WebSeriesDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SeriesRating SeriesRating { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SeriesRating = await _context.SeriesRatings
                .Include(s => s.Series).FirstOrDefaultAsync(m => m.Id == id);

            if (SeriesRating == null)
            {
                return NotFound();
            }
           ViewData["SeriesId"] = new SelectList(_context.Seriess, "Id", "SeriesName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SeriesRating).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeriesRatingExists(SeriesRating.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SeriesRatingExists(int id)
        {
            return _context.SeriesRatings.Any(e => e.Id == id);
        }
    }
}
