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
                context.Configuration.ProxyCreationEnabled = false;

                var ordersAndDetails = from o in context.Orders
                                       join od in context.Order_Details on o.OrderID equals od.OrderID into orderOrderDetail
                                       from ood in orderOrderDetail
                                       select new
                                       {
                                           ood.OrderID,
                                           ood.Quantity,
                                           ood.ProductID
                                       };

                IEnumerable<ProductsBySaleDto> dtos = (from p in context.Products
                                                       join ood in ordersAndDetails on p.ProductID equals ood.ProductID
                                                       orderby ood.Quantity
                                                       select new ProductsBySaleDto()
                                                       {
                                                           ProductId = p.ProductID,
                                                           ProductName = p.ProductName,
                                                       }).Take(count);

                foreach (ProductsBySaleDto pbsd in dtos)
                {
                    ProductsBySaleDto prdBSl = pbsd;
                    IEnumerable<UnitsSoldByMonthDto> dtos2 = (from od in context.Order_Details
                                    where od.ProductID == prdBSl.ProductId
                                    group od by od.Order.OrderDate.Value.Month into unitsSoldByMonth
                                    select new UnitsSoldByMonthDto()
                                    {
                                        UnitsSold = unitsSoldByMonth.FirstOrDefault().Quantity,
                                        UnitsSoldYear = (from od2 in context.Order_Details
                                                        where od2.ProductID == unitsSoldByMonth.FirstOrDefault().ProductID
                                                        group od2 by od2.Order.OrderDate.Value.Year into unitsSoldByYear
                                                        select unitsSoldByYear.FirstOrDefault().Quantity).FirstOrDefault(),
                                        Month = unitsSoldByMonth.Key,
                                        Year = unitsSoldByMonth.FirstOrDefault().Order.OrderDate.Value.Year
                                    }).OrderByDescending(x => x.UnitsSoldYear).Take(3);
                    pbsd.UnitsSoldByMonth = dtos2.ToList();
                }
                return new Report<IList<ProductsBySaleDto>, ReportError>() {Data = dtos.ToList(), Error = null};
            }
        }
    }
}
