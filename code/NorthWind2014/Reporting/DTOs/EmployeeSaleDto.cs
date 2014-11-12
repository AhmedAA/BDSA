using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Model;

namespace NorthWind.Reporting.DTOs
{
    class EmployeeSaleDto
    {
        public string EmployeeName { get; set; }
        public int ReportsTo { get; set; }
        public IList<ReportOrderDto> Orders { get; set; }
    }
}
