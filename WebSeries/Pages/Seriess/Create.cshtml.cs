using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebSeries.BusinessLayer;
using WebSeries.Data;

namespace WebSeries.Pages.Seriess
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
        ViewData["PlatformId"] = new SelectList(_context.Platforms, "Id", "PlatformName");
            return Page();
        }

        [BindProperty]
        public Series Series { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seriess.Add(Series);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
