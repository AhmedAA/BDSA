using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NorthWind.Model;
using NorthWind.Reporting.DTOs;
using NorthWind.Reporting.Errors;

namespace NorthWind.Reporting
{
    class Reporter : IReporter
    {
        public Report<IList<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        {

            using (var context = new northwindEntities())
            {
                // TODO This report doesn't return the correct answer... It should return the top (highest) orders by total price.
                context.Configuration.ProxyCreationEnabled = false;
                IEnumerable<OrdersByTotalPriceDto> dtos = (from order in context.Orders
                                                          join orderDetail in context.Order_Details on order.OrderID equals orderDetail.OrderID
                                                          select new OrdersByTotalPriceDto()
                                                          {
                                                              OrderId = order.OrderID,
                                                              OrderDate = order.OrderDate ?? DateTime.Today,
                                                              CustomerContactName = order.ShipName,
                                                              //TotalPriceWithDiscount = orderDetail.UnitPrice - Convert.ToDecimal(orderDetail.Discount),
                                                              TotalPrice = orderDetail.UnitPrice
                                                          }
                                                          ).Take(count);

                return new Report<IList<OrdersByTotalPriceDto>, ReportError>() {Data = dtos.ToList(), Error = null};
            }
        }
    }
}
