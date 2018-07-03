using System;
using System.Collections.Generic;
using System.Text;

namespace PopularSeriesApp.Models
{
    public class PopularSeriesResult
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<PopularSeries> results { get; set; }
        public string NamePage { get; set; }

    }
}
