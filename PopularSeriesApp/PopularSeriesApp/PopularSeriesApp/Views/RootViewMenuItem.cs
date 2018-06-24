using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopularSeriesApp.Views
{

    public class RootViewMenuItem
    {
        public RootViewMenuItem()
        {
            TargetType = typeof(RootViewDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}