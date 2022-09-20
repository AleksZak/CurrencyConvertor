using CurrencyConvert.Model;

namespace CurrencyConvert.BussinesLogic.Interfaces
{
    public interface ICurrencyConverterService
    {
        public IEnumerable<Currency> GetAllCurrencies();
        public IEnumerable<CurrencyRate> GetAllRates();
        public IEnumerable<Currency> GetAllCurrenciesRates();
        public decimal CurrencyConvertion(string baseCode, string targetCode, decimal value);
        public Currency FindById(int id);
        public void Add(Currency entity);
        public void Delete(Currency entity);
        public void Update(Currency entity);
    }
}
