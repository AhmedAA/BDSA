using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core;
using System.Data.Odbc;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
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
                context.Configuration.ProxyCreationEnabled = false;
                IEnumerable<OrdersByTotalPriceDto> dtos = (from order in context.Orders
                                                           join orderDetail in context.Order_Details on order.OrderID equals orderDetail.OrderID
                                                           group orderDetail by orderDetail.OrderID into fullOrder
                                                           select new OrdersByTotalPriceDto()
                                                           {
                                                               OrderId = fullOrder.FirstOrDefault().OrderID,
                                                               OrderDate = fullOrder.FirstOrDefault().Order.OrderDate ?? DateTime.Today,
                                                               CustomerContactName = fullOrder.FirstOrDefault().Order.ShipName,
                                                               TotalPriceWithDiscount = fullOrder.Sum(t => t.Quantity) * fullOrder.Sum(u => u.UnitPrice) - fullOrder.Sum(t => t.Discount),
                                                               TotalPrice = fullOrder.Sum(t => t.Quantity) * fullOrder.Sum(u => u.UnitPrice)
                                                           }).OrderByDescending(x => x.TotalPrice).Take(count);

                return new Report<IList<OrdersByTotalPriceDto>, ReportError>() { Data = dtos.ToList(), Error = null };
            }
        }

        public Report<IList<ProductsBySaleDto>, ReportError> TopProductsBySale(int count)
        {
            // TODO The UnitsSoldByMonth is returned as null...
            using (var context = new northwindEntities())
            {
                IList<ProductsBySaleDto> dtos = (from od in context.Order_Details
                    group od by od.ProductID
                    into OrderDetailsProducts
                    select new ProductsBySaleDto()
                    {
                        ProductId = OrderDetailsProducts.FirstOrDefault().ProductID,
                        ProductName = OrderDetailsProducts.FirstOrDefault().Product.ProductName,
                        UnitsSoldByMonth = (
                            from t in OrderDetailsProducts
                            let orderDate = t.Order.OrderDate
                            where orderDate != null
                            group t by new
                            {
                                orderDate.Value.Month,
                                orderDate.Value.Year
                            } into timing
                            select new UnitsSoldByMonthDto()
                            {
                                UnitsSold = timing.Sum(x => x.Quantity),
                                Count = timing.Count(),
                                Month = timing.Key.Month,
                                Year = timing.Key.Year
                            }).ToList()
                    }).ToList();

                IList<ProductsBySaleDto> dtosSorted = (from pd in dtos
                    orderby pd.UnitsSoldByMonth.Sum(x => x.UnitsSold) descending
                    select pd).Take(count).ToList();
                return new Report<IList<ProductsBySaleDto>, ReportError>() { Data = dtosSorted, Error = null };
            }
        }
    }
}
