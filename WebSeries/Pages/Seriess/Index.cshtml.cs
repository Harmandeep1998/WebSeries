using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebSeries.BusinessLayer;
using WebSeries.Data;

namespace WebSeries.Pages.Seriess
{
    public class IndexModel : PageModel
    {
        private readonly WebSeries.Data.WebSeriesDBContext _context;

        public IndexModel(WebSeries.Data.WebSeriesDBContext context)
        {
            _context = context;
        }

        public IList<Series> Series { get;set; }

        public async Task OnGetAsync()
        {
            Series = await _context.Seriess
                .Include(s => s.Platform).ToListAsync();
        }
    }
}
