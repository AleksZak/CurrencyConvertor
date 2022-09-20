using Microsoft.EntityFrameworkCore;
using CurrencyConvert.Model;

namespace CurrencyConvert.Context
{
    public class CurrencyConvertorContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
    
        public CurrencyConvertorContext(DbContextOptions<CurrencyConvertorContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>(currency =>
            {
                currency.HasKey(c => c.Id);
                currency.Property(c => c.Name).IsRequired();
                currency.Property(c => c.Code).IsRequired();
                currency.Property(c => c.IsActive).IsRequired();
                currency.HasMany(c => c.Rate).WithOne(r => r.Currency).OnDelete(DeleteBehavior.Cascade);


            }
            );
            modelBuilder.Entity<CurrencyRate>(rate =>
            {
                rate.HasKey(key => key.CurrencyRateId);
                rate.Property(date => date.RateDate).IsRequired();
                rate.Property(key => key.CurrencyRateId).IsRequired();
                rate.Property(value => value.RateValue).IsRequired();

            });
        }
    }
    }

