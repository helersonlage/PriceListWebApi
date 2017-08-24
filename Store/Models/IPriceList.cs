namespace Store.Models
{
    public interface IPriceList
    {
        decimal DiscountRate { get; set; }
        int ID { get; set; }
        string Name { get; set; }
        decimal price { get; set; }
        decimal PriceFull { get; set; }
    }
}