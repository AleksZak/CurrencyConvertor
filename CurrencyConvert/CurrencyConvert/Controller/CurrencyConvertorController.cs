using CurrencyConvert.Model;
using CurrencyConvert.Repository.Classes;
using CurrencyConvert.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CurrencyConvert.Context;
using CurrencyConvert.BussinesLogic.Interfaces;

namespace CurrencyConvert.Controller
{
    [Route("api")]
    [ApiController]
    public class CurrencyConvertorController : ControllerBase
    {

        private ICurrencyConverterService currencyConvertorService { get; set; }

        public CurrencyConvertorController(ICurrencyConverterService currencyConvertorService)
        {
            this.currencyConvertorService = currencyConvertorService;
        }


        [HttpGet("rates")]
        public IEnumerable<CurrencyRate> GetAllRates()
        {

            return currencyConvertorService.GetAllRates();
        }
        [HttpGet("names")]
        public IEnumerable<Currency> GetAll()
        {

            return currencyConvertorService.GetAllCurrencies();
        }
        [HttpGet("getAll")]
        public IEnumerable<Currency> GetAllRatesAndCurrencies()
        {
            return currencyConvertorService.GetAllCurrenciesRates();
        }
        [Route("{baseCode:maxlength(3)}&{targetCode:maxlength(3)}=>{value:decimal}")]
        public decimal Convert(string baseCode, string targetCode, decimal value)
        {

            return currencyConvertorService.CurrencyConvertion(baseCode.ToUpper(), targetCode.ToUpper(), value);
        }
        [Route("{id}")]
        public ActionResult<Currency> GetById(int id)
        {
            return currencyConvertorService.FindById(id);
        }



        [HttpPost]
        public void Post([FromQuery] Currency value)
        {
            currencyConvertorService.Update(value);

        }

        [HttpPut]
        public void Put(int id, [FromBody] Currency value)
        {
            if (id == value.Id)
            {
                currencyConvertorService.Add(value);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var entity = currencyConvertorService.FindById(id);
            currencyConvertorService.Delete(entity);
        }
    }
}
