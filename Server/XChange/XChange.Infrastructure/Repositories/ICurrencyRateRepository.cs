using XChange.Domain;

namespace XChange.Infrastructure
{
    public interface ICurrencyRateRepository
    {
        //ConvertResponse Convert(ConvertRequest request);
        CurrencyRate GetBySymbol(string from, string to);
    }
}
