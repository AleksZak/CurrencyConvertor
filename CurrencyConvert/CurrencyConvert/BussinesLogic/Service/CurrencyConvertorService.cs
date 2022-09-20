using CurrencyConvert.Model;
using CurrencyConvert.Repository.Interfaces;
using CurrencyConvert.BussinesLogic.Interfaces;
using AutoMapper;


namespace CurrencyConvert.BussinesLogic.Service
{
   
    public class CurrencyConvertorService : ICurrencyConverterService
    {
        public ICurrencyRepository currencyRepository;
        public IMapper mapper;

        public CurrencyConvertorService(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            this.currencyRepository = currencyRepository;
            this.mapper = mapper;
        }
      
        public void Add(Currency entity)
        {
            currencyRepository.Add(entity);
        }

        public decimal CurrencyConvertion(string baseCode, string targetCode, decimal value)
        {
           var targetCurrency= currencyRepository.GetCurrencyForBaseAndTargetCodes(baseCode, targetCode);
            return targetCurrency * value;
        }

        public void Delete(Currency entity)
        {
            currencyRepository.Delete(entity);
        }

        public Currency FindById(int id)
        {
          return  currencyRepository.FindById(id);
        }

        public IEnumerable<Currency> GetAllCurrencies()
        {
            return currencyRepository.GetAll();
        }

        public IEnumerable<Currency> GetAllCurrenciesRates()
        {
            return currencyRepository.IncludeRatesToCurrencies();
        }

        public IEnumerable<CurrencyRate> GetAllRates()
        {
            return currencyRepository.GetAllRates();
        }

        public void Update(Currency entity)
        {
            currencyRepository.Update(entity);
        }
    }
}

