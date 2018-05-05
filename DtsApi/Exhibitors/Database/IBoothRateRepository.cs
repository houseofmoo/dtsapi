using DtsApi.Exhibitors.Model;

namespace DtsApi.Exhibitors.Database
{
    public interface IBoothRateRepository
    {
        BoothRates GetBoothRates();
        void UpdateBoothRates(BoothRates boothRates);
    }
}