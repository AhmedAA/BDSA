using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Reporting.DTOs;
using NorthWind.Reporting.Errors;

namespace NorthWind.Reporting
{
    interface IReporter
    {
        Report<IList<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count);
        Report<IList<ProductsBySaleDto>, ReportError> TopProductsBySale(int count);
    }
}
