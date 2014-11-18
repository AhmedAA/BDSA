using System.Collections.Generic;

namespace NorthWind.Reporting.DTOs
{
    public class ProductsBySaleDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public IList<UnitsSoldByMonthDto> UnitsSoldByMonth { get; set; }
    }
}
