using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSeries.BusinessLayer;

namespace WebSeries.Data
{
    public class WebSeriesDBContext : DbContext
    {
        public WebSeriesDBContext(DbContextOptions<WebSeriesDBContext> options)
            : base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Series> Seriess { get; set; }

        public DbSet<SeriesRating> SeriesRatings { get; set; }

        public DbSet<Binge> Binges { get; set; }
    }
}
