using System.Collections.Generic;
using System.IO;
using DtsApi.Exhibitors.Model;
using Newtonsoft.Json;

namespace DtsApi.Exhibitors.Services
{
    // TODO: this might not be needed, maybe front end should deal with calculating booth rates
    // but we will need to store the booth rates
    public class BoothRateService
    {
        private static string _dbString = "./Database/TestDb/BoothRate.json";
        private Dictionary<BoothType, uint> Rates { get; set; }

        public BoothRateService()
        {
            using (var reader = new StreamReader(_dbString))
            {
                string json = reader.ReadToEnd();
                this.Rates =  JsonConvert.DeserializeObject<Dictionary<BoothType, uint>>(json);
            }
        }

        /// <summary>
        /// Returns the rate for a booth type
        /// </summary>
        /// <param name="boothType"></param>
        /// <returns></returns>
        public uint GetBoothRate(BoothType boothType)
        {
            if (this.Rates.ContainsKey(boothType))
            {
                return this.Rates[boothType];
            }

            return 0;
        }

        public void SetBoothRate(BoothType boothType, uint rate)
        {
            if (this.Rates.ContainsKey(boothType))
            {
                this.Rates[boothType] = rate;
            }
        }
    }
}
