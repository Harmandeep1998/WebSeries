using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebSeries.BusinessLayer;
using WebSeries.Data;

namespace WebSeries.Pages.Binges
{
    public class DeleteModel : PageModel
    {
        private readonly WebSeries.Data.WebSeriesDBContext _context;

        public DeleteModel(WebSeries.Data.WebSeriesDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Binge Binge { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Binge = await _context.Binges
                .Include(b => b.Series).FirstOrDefaultAsync(m => m.Id == id);

            if (Binge == null)
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

            Binge = await _context.Binges.FindAsync(id);

            if (Binge != null)
            {
                _context.Binges.Remove(Binge);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
