using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSeries.BusinessLayer
{
    public class Binge
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int SeriesId { get; set; }

        public Series Series { get; set; }
    }
}
