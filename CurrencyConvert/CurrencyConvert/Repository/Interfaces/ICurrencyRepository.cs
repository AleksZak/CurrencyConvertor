using CurrencyConvert.Model;

namespace CurrencyConvert.Repository.Interfaces
{
    public interface ICurrencyRepository
    {
        IEnumerable<Currency> GetAll();
        IEnumerable<CurrencyRate> GetAllRates();
        Currency FindById(int id);
        void Add(Currency entity);
        void Delete(Currency entity);
        void Update(Currency entity);
        Currency FindByCode(string code);
        IEnumerable<Currency> IncludeRatesToCurrencies();
        decimal GetCurrencyForBaseAndTargetCodes(string baseCode,string targetCode);
        
       
    }
}
