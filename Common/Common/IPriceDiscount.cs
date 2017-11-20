namespace Common
{
    public interface IPriceDiscount
    {
        decimal CalcDiscount(decimal rate, decimal price);
    }
}