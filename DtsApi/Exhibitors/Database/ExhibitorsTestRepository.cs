using System;
using System.Collections.Generic;
using System.Linq;
using DtsApi.Exhibitors.Model;
using Microsoft.Extensions.Logging;

namespace DtsApi.Exhibitors.Database
{
    /// <summary>
    /// Testing repository using a json file as a database
    /// </summary>
    public class ExhibitorsTestRepository : IExhibitorsRepository
    {

        private readonly ILogger<ExhibitorsTestRepository> _logger;
        private readonly ExhibitorsContext _context;
        private const string _dbString = "./Database/TestDb/Exhibitors_test.json";

        public ExhibitorsTestRepository(ILogger<ExhibitorsTestRepository> logger,
                                        ExhibitorsContext context)
        {
            this._logger = logger;
            this._context = context;

            // for testing
            this._context.SeedDatabase(_dbString);
        }

        /// <summary>
        /// Get a list of all exhibitors from database
        /// </summary>
        /// <returns></returns>
        public List<Exhibitor> GetExhibitors()
        {
            return this._context.Exhibitors;
        }

        /// <summary>
        /// Adds a single exhibitor to the database
        /// </summary>
        /// <param name="exhibitor"></param>
        /// <returns></returns>
        public void AddExhibitor(Exhibitor exhibitor)
        {
            var IDs = this._context.Exhibitors.Select(e => e.Id);
            int? max = IDs?.Max();
            if (max != null)
            {
                exhibitor.Id = (int)max + 1;
            }
            else
            {
                exhibitor.Id = 1;
            }

            // add to db and save
            this._context.Exhibitors.Add(exhibitor);
            this._context.SaveSeedChanges(_dbString);
        }

        /// <summary>
        /// Updates an exhisting exhibitor
        /// </summary>
        /// <param name="exhibitor"></param>
        /// <returns></returns>
        public bool UpdateExhibitor(Exhibitor newExhibitor)
        {
            try
            {
                var oldExhibitor = this._context.Exhibitors.Where(e => e.Id == newExhibitor.Id).FirstOrDefault();
                if (oldExhibitor != null)
                {
                    int index = this._context.Exhibitors.IndexOf(oldExhibitor);
                    this._context.Exhibitors[index] = newExhibitor;
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                this._logger.LogError("Unable to update exhibitor", e);
                return false;
            }
            finally
            {
                this._context.SaveSeedChanges(_dbString);
            }
        }

        /// <summary>
        /// Deletes an exhibitor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteExhibitor(int id)
        {
            var exhibitor = this._context.Exhibitors.Where(e => e.Id == id).FirstOrDefault();
            if (exhibitor != null)
            {
                this._context.Exhibitors.Remove(exhibitor);
                this._context.SaveSeedChanges(_dbString);
                return true;
            }

            return false;
        }
    }
}
