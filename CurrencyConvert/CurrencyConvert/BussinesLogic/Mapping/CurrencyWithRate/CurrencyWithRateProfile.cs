using AutoMapper;
using CurrencyConvert.Model;
using CurrencyConvert.BussinesLogic.DTO;
using CurrencyConvert.BussinesLogic.Models;

namespace CurrencyConvert.BussinesLogic.Mapping.CurrencyWithRate
{
    public class CurrencyWithRateProfile : Profile
    {
        public CurrencyWithRateProfile()
        {
            CreateMap<Currency, CurrencyWithCurrencyRatesDTO>()
                .ConvertUsing<CurrencyWithRatesConverter>();
               
        }
    }

    internal class CurrencyWithRatesConverter : ITypeConverter<Currency, CurrencyWithCurrencyRatesDTO>
    {
     
        public  CurrencyWithCurrencyRatesDTO Convert(Currency source, CurrencyWithCurrencyRatesDTO destination, ResolutionContext context)
        {
            var rates = source.Rate!.Where(item=>item.CurrencyId==source.Id);

            destination.Id = source.Id;
            destination.Name = source.Name; 
            destination.Code = source.Code; 
            destination.IsActive = source.IsActive;
            destination.Rate = context.Mapper.Map<IEnumerable<CurrencyRateDTO>>(rates); 


            return destination;
        }
    }
}
