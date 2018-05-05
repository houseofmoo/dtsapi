using DtsApi.Exhibitors.Database;
using DtsApi.Exhibitors.Model;
using Microsoft.AspNetCore.Mvc;

namespace DtsApi.Exhibitors.Controllers
{
    [Produces("application/json")]
    [Route("api/BoothRate")]
    public class BoothRateController : Controller
    {
        private readonly IBoothRateRepository _repository;

        public BoothRateController(IBoothRateRepository repository)
        {
            this._repository = repository;
        }

        // GET: api/BoothRate
        [HttpGet]
        public BoothRates Get()
        {
            return this._repository.GetBoothRates();
        }
        
        // POST: api/BoothRate
        [HttpPost]
        public void Post([FromBody]BoothRates boothRates)
        {
            if (boothRates == null)
            {
                return;
            }

            this._repository.UpdateBoothRates(boothRates);
        }
    }
}
