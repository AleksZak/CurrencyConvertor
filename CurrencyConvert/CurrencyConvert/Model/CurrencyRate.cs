namespace CurrencyConvert.Model
{
    public class CurrencyRate
    {
        public int CurrencyRateId { get; set; }
        public int CurrencyId { get; set; }       
        public DateTime RateDate { get; set; }
        public string TargetCode { get; set; }  
        public decimal RateValue { get; set; }
        public Currency? Currency { get; set; }
    }
}
