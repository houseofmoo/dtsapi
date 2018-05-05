using System.Collections.Generic;
using DtsApi.Exhibitors.Database;
using DtsApi.Exhibitors.Model;
using Microsoft.AspNetCore.Mvc;

namespace DtsApi.Exhibitors.Controllers
{
    [Produces("application/json")]
    [Route("api/Exhibitors")]
    public class ExhibitorsController : Controller
    {
        private readonly IExhibitorsRepository _repository;

        public ExhibitorsController(IExhibitorsRepository repository)
        {
            this._repository = repository;
        }

        // GET: api/Exhibitors
        [HttpGet]
        public IEnumerable<Exhibitor> Get()
        {
            return this._repository.GetExhibitors();
        }

        // POST: api/Exhibitors
        [HttpPost]
        public void Post([FromBody]Exhibitor exhibitor)
        {
            if (exhibitor == null)
            {
                return;
            }

            if (exhibitor.Id == 0)
            {
                this._repository.AddExhibitor(exhibitor);
            }
            else
            {
                this._repository.UpdateExhibitor(exhibitor);
            }
        }

        // PUT: api/Exhibitors
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/Exhibitors/delete/5
        [HttpDelete("/delete/{id}")]
        public void Delete(int id)
        {
            this._repository.DeleteExhibitor(id);
        }
    }
}
