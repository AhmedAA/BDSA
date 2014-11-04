using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
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
                                                           }).Take(count).OrderByDescending(x => x.TotalPrice);

                return new Report<IList<OrdersByTotalPriceDto>, ReportError>() {Data = dtos.ToList(), Error = null};
            }
        }

        public Report<IList<ProductsBySaleDto>, ReportError> TopProductsBySale(int count)
        {
            using (var context = new northwindEntities())
            {
                context.Configuration.ProxyCreationEnabled = false;
                IEnumerable<ProductsBySaleDto> dtos = (from p in context.Products
                                                           join (from o in context.Orders
                                                               join ))
            }
        } 
    }
}
