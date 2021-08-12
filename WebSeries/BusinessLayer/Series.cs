using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSeries.BusinessLayer
{
    public class Series
    {
        public int Id { get; set; }

        public string SeriesName { get; set; }

        public string Language { get; set; }

        public int Season { get; set; }

        public int PlatformId { get; set; }

        public Platform Platform { get; set; }
    }
}
