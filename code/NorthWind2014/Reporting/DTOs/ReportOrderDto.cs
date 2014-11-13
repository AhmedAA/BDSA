using System;
using System.Collections.Generic;

namespace NorthWind.Reporting.DTOs
{
    class ReportOrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public IList<ReportProductDto> Products { get; set; }
    }
}
