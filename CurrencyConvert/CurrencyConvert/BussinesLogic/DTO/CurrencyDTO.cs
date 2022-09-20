namespace CurrencyConvert.BussinesLogic.Models
{
    public class CurrencyDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<CurrencyRateDTO> Rate { get; set; }
    }
}
