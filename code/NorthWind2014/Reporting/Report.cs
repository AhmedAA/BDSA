using System;

namespace NorthWind.Reporting
{
    public class Report<TData, TError>
    {
        public TData Data { get; set; }
        public TError Error { get; set; }
    }
}
