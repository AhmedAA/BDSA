using System.Collections.Generic;

namespace NorthWind.Reporting.DTOs
{
    class EmployeeSaleDto
    {
        public string EmployeeName { get; set; }
        public int ReportsTo { get; set; }
        public IList<ReportOrderDto> Orders { get; set; }
    }
}
