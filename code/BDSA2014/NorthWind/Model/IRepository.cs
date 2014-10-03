namespace NorthWind.Model
{
    interface IRepository
    {
        Product[] Products { get; }
        Order[] Orders { get; }
        Category[] Categories { get; }
        void CreateOrder();
    }
}
