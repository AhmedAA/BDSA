using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Reporting.DTOs
{
    class UnitsSoldByMonthDto
    {
        public int UnitsSoldYear { get; set; }
        public int UnitsSold { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
