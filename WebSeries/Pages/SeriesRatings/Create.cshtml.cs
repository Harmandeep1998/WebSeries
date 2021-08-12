using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSeries.BusinessLayer;
using WebSeries.Data;

namespace WebSeries.Pages.SeriesRatings
{
    public class CreateModel : PageModel
    {
        private readonly WebSeries.Data.WebSeriesDBContext _context;

        public CreateModel(WebSeries.Data.WebSeriesDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SeriesId"] = new SelectList(_context.Seriess, "Id", "SeriesName");
            return Page();
        }

        [BindProperty]
        public SeriesRating SeriesRating { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SeriesRatings.Add(SeriesRating);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
