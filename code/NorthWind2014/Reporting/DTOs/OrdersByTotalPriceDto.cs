using System;

namespace NorthWind.Reporting.DTOs
{
    public class OrdersByTotalPriceDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerContactName { get; set; }
        public decimal TotalPriceWithDiscount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
