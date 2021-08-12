using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebSeries.BusinessLayer;
using WebSeries.Data;

namespace WebSeries.Pages.SeriesRatings
{
    public class DeleteModel : PageModel
    {
        private readonly WebSeries.Data.WebSeriesDBContext _context;

        public DeleteModel(WebSeries.Data.WebSeriesDBContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SeriesRating = await _context.SeriesRatings.FindAsync(id);

            if (SeriesRating != null)
            {
                _context.SeriesRatings.Remove(SeriesRating);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
