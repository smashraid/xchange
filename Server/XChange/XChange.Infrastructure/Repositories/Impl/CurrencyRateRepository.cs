using XChange.Domain;

namespace XChange.Infrastructure
{
    public class CurrencyRateRepository : ICurrencyRateRepository
    {
        private readonly XChangeContext _dbContext;
        public CurrencyRateRepository(XChangeContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public CurrencyRate GetBySymbol(string from, string to)
        {
            return _dbContext.CurrencyRates.Find(1);
        }
    }
}