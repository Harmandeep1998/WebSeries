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

namespace WebSeries.Pages.Seriess
{
    public class EditModel : PageModel
    {
        private readonly WebSeries.Data.WebSeriesDBContext _context;

        public EditModel(WebSeries.Data.WebSeriesDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Series Series { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Series = await _context.Seriess
                .Include(s => s.Platform).FirstOrDefaultAsync(m => m.Id == id);

            if (Series == null)
            {
                return NotFound();
            }
           ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "PlatformName");
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

            _context.Attach(Series).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeriesExists(Series.Id))
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

        private bool SeriesExists(int id)
        {
            return _context.Seriess.Any(e => e.Id == id);
        }
    }
}
