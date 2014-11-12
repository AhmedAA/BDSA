using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Reporting.DTOs
{
    class UnitsSoldByMonthDto
    {
        public int UnitsSold { get; set; }
        public int Count { get; set; }
        public int Avg
        {
            get { return UnitsSold/Count; }
        }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
