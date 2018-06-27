using XChange.Domain;

namespace XChange.Infrastructure {
    public class ConvertService : IConvertService
    {
        readonly ICurrencyRateRepository _currencyRateRepository;
        public ConvertService(ICurrencyRateRepository currencyRateRepository)
        {
            this._currencyRateRepository = currencyRateRepository;
        }
        public ConvertResponse GetBySymbol(ConvertRequest request)
        {
            var currencyRate = _currencyRateRepository.GetBySymbol(request.From, request.To);
            return new ConvertResponse{
                Success = true,
                Rate = currencyRate.Rate                
            };
        }
    }
}