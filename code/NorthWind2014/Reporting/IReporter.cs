using System.Collections.Generic;
using NorthWind.Reporting.DTOs;
using NorthWind.Reporting.Errors;

namespace NorthWind.Reporting
{
    interface IReporter
    {
        Report<IList<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count);
        Report<IList<ProductsBySaleDto>, ReportError> TopProductsBySale(int count);
        Report<EmployeeSaleDto, ReportError> EmployeeSale(int id);
    }
}
