using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSeries.BusinessLayer
{
    public class SeriesRating
    {
        public int Id { get; set; }

        public string Review { get; set; }

        public int Rating { get; set; }

        public int SeriesId { get; set; }

        public Series Series { get; set; }
    }
}
