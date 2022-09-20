using CurrencyConvert.BussinesLogic.Models;

namespace CurrencyConvert.BussinesLogic.DTO
{
    public class CurrencyWithCurrencyRatesDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<CurrencyRateDTO> Rate { get; set; }
    }
}
