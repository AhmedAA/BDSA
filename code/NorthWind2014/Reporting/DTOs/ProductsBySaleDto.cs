using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Reporting.DTOs
{
    class ProductsBySaleDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public IList<UnitsSoldByMonthDto> UnitsSoldByMonth { get; set; }
    }
}
