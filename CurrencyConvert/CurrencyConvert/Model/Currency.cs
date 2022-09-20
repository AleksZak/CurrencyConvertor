namespace CurrencyConvert.Model
{
    public class Currency
    {
        public int Id { get; set; }
        public  string? Name { get; set; }
        public string? Code { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<CurrencyRate>  Rate { get; set; }
    }
}
