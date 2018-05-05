using System.IO;
using DtsApi.Exhibitors.Model;
using Newtonsoft.Json;

namespace DtsApi.Exhibitors.Database
{
    public class BoothRateContext
    {
        public BoothRates BoothRates { get; set; } = new BoothRates();

        private static object _locker = new object();

        public void SeedDatabase(string path)
        {
            lock (_locker)
            {
                using (var reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();
                    this.BoothRates = JsonConvert.DeserializeObject<BoothRates>(json);
                }
            }
        }

        public void SaveSeedChanges(string path)
        {
            lock (_locker)
            {
                string json = JsonConvert.SerializeObject(this.BoothRates);
                using (var writer = new StreamWriter(path))
                {
                    writer.Write(json);
                }
            }
        }
    }
}
