using CurrencyConvert.Context;
using CurrencyConvert.Model;
using CurrencyConvert.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CurrencyConvert.Repository.Classes
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CurrencyConvertorContext context;
        public CurrencyRepository(CurrencyConvertorContext context)
        {
            this.context = context;
        }

        public IEnumerable<Currency> GetAll()
        {
            return context.Currencies.ToList();
        }
        public void Add(Currency entity)
        {
            context.Currencies.Add(entity);
        }

        public void Delete(Currency entity)
        {
            context.Currencies.Remove(entity);
            context.SaveChanges();
        }

        public Currency FindById(int id)
        {
            return context.Currencies.First(e => e.Id == id);
        }

        public void Update(Currency entity)
        {
            context.Currencies.Update(entity);
            context.SaveChanges();
        }

        public Currency FindByCode(string code)
        {
            return context.Currencies.First(c => c.Code == code);
        }

        public IEnumerable<CurrencyRate> GetAllRates()
        {
            return context.CurrencyRates.ToList();
        }

        public IEnumerable<Currency> IncludeRatesToCurrencies()
        {
            var result = context.Currencies.Include(c => c.Rate).ToList();
            return result;
        }

        public decimal GetCurrencyForBaseAndTargetCodes(string baseCode, string targetCode)
        {
            var result = context.Currencies.Include(c => c.Rate).ToList().FirstOrDefault(c => c.Code == baseCode).Rate.FirstOrDefault(r => r.TargetCode == targetCode).RateValue;

            return result;
        }
    }
}

