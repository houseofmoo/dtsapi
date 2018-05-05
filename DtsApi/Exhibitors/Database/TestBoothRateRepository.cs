using DtsApi.Exhibitors.Model;
using Microsoft.Extensions.Logging;

namespace DtsApi.Exhibitors.Database
{
    public class TestBoothRateRepository : IBoothRateRepository
    {
        private readonly ILogger<TestBoothRateRepository> _logger;
        private readonly BoothRateContext _context;
        private const string _dbString = "./Database/TestDb/BoothRate_test.json";

        public TestBoothRateRepository(ILogger<TestBoothRateRepository> logger,
                                       BoothRateContext context)
        {
            this._logger = logger;
            this._context = context;

            // for testing
            this._context.SeedDatabase(_dbString);
        }

        public BoothRates GetBoothRates()
        {
            return this._context.BoothRates;
        }

        public void UpdateBoothRates(BoothRates boothRates)
        {
            this._context.BoothRates = boothRates;
            this._context.SaveSeedChanges(_dbString);
        }
    }
}
