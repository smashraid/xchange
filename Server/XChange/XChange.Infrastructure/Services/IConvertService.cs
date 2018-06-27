using XChange.Domain;

namespace XChange.Infrastructure {
    public interface IConvertService
    {
        ConvertResponse GetBySymbol(ConvertRequest request);
    }
}