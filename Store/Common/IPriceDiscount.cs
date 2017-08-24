namespace Store.Common
{
    public interface IPriceDiscount
    {
        decimal calcDiscount(decimal rate, decimal price);
    }
}