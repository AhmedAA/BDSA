using System;
using System.Collections.Generic;
using System.Linq;
using NorthWind.Model;
using NorthWind.Reporting.DTOs;
using NorthWind.Reporting.Errors;

namespace NorthWind.Reporting
{
    class Reporter : IReporter
    {

        private IRepository _repository;

        public Reporter(IRepository repository)
        {
            _repository = repository;
        }

        public Report<IList<OrdersByTotalPriceDto>, ReportError> TopOrdersByTotalPrice(int count)
        {
                IEnumerable<OrdersByTotalPriceDto> dtos = (from order in _repository.Orders
                                                           join orderDetail in _repository.OrderDetails on order.OrderID equals orderDetail.OrderID
                                                           group orderDetail by orderDetail.OrderID into fullOrder
                                                           select new OrdersByTotalPriceDto()
                                                           {
                                                               OrderId = fullOrder.FirstOrDefault().OrderID,
                                                               OrderDate = fullOrder.FirstOrDefault().Order.OrderDate ?? DateTime.Today,
                                                               CustomerContactName = fullOrder.FirstOrDefault().Order.ShipName,
                                                               TotalPriceWithDiscount = fullOrder.Sum(t => t.Quantity) * fullOrder.Sum(u => u.UnitPrice) - fullOrder.Sum(t => t.Discount),
                                                               TotalPrice = fullOrder.Sum(t => t.Quantity) * fullOrder.Sum(u => u.UnitPrice)
                                                           }).OrderByDescending(x => x.TotalPrice).Take(count);

                if (!dtos.Any())
                {
                    return new Report<IList<OrdersByTotalPriceDto>, ReportError>() {Data = null, Error = new ReportError() {Message = "No orders found"}};
                }

                return new Report<IList<OrdersByTotalPriceDto>, ReportError>() { Data = dtos.ToList(), Error = null };
        }

        public Report<IList<ProductsBySaleDto>, ReportError> TopProductsBySale(int count)
        {
            
                IList<ProductsBySaleDto> dtos = (from od in _repository.OrderDetails
                    group od by od.ProductID
                    into orderDetailsProducts
                    select new ProductsBySaleDto()
                    {
                        ProductId = orderDetailsProducts.FirstOrDefault().ProductID,
                        ProductName = orderDetailsProducts.FirstOrDefault().Product.ProductName,
                        UnitsSoldByMonth = (
                            from t in orderDetailsProducts
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

                if (dtos.Count == 0)
                {
                    return new Report<IList<ProductsBySaleDto>, ReportError>() {Data = null, Error = new ReportError() {Message = "No products found"}};
                } 

                IList<ProductsBySaleDto> dtosSorted = (from pd in dtos
                    orderby pd.UnitsSoldByMonth.Sum(x => x.UnitsSold) descending
                    select pd).Take(count).ToList();

                return new Report<IList<ProductsBySaleDto>, ReportError>() { Data = dtosSorted, Error = null };
        }

        public Report<EmployeeSaleDto, ReportError> EmployeeSale(int id)
        {
            
                 EmployeeSaleDto dto = (from od in _repository.OrderDetails
                    where od.Order.EmployeeID == id
                    select new EmployeeSaleDto()
                    {
                        EmployeeName = od.Order.Employee.FirstName + " " + od.Order.Employee.LastName,
                        ReportsTo = od.Order.Employee.ReportsTo ?? default(int),
                        Orders = (from o in _repository.Orders
                            where o.EmployeeID == id
                            select new ReportOrderDto()
                            {
                                OrderId = o.OrderID,
                                OrderDate = o.OrderDate ?? default(DateTime),
                                TotalPrice = (from od2 in _repository.OrderDetails
                                    where od2.OrderID == o.OrderID
                                    select new
                                    {
                                        TotalPrice = od2.Quantity*od2.UnitPrice - od2.Discount
                                    }).Sum(x => x.TotalPrice),
                                Products = (from od3 in _repository.OrderDetails
                                    where od3.OrderID == o.OrderID
                                    group od3 by od3.ProductID
                                    into products
                                    from p in products
                                    select new ReportProductDto()
                                    {
                                        ProductName = p.Product.ProductName,
                                        Quantity = p.Quantity,
                                        UnitPrice = p.Product.UnitPrice ?? default(decimal)
                                    }).ToList()
                            }).ToList()
                    }).FirstOrDefault();

                // If no employee found, return error.
                if (dto == null)
                {
                    return new Report<EmployeeSaleDto, ReportError>() {Data = null, Error = new ReportError() {Message = "No employee found with id " + id}};
                }

                // If employee found, return it.
                return new Report<EmployeeSaleDto, ReportError>() {Data = dto, Error = null};
        } 
    }
}
