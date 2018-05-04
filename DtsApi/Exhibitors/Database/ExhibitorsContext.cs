using System.Collections.Generic;
using System.IO;
using DtsApi.Exhibitors.Model;
using Newtonsoft.Json;

namespace DtsApi.Exhibitors.Database
{
    public class ExhibitorsContext
    {
        public List<Exhibitor> Exhibitors { get; set; }
        private static object _locker = new object();

        public void SeedDatabase(string path)
        {
            lock (_locker)
            {
                using (var reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();
                    this.Exhibitors = JsonConvert.DeserializeObject<List<Exhibitor>>(json);
                }
            }
        }

        public void SaveSeedChanges(string path)
        {
            lock (_locker)
            {
                string json = JsonConvert.SerializeObject(this.Exhibitors);
                using (var writer = new StreamWriter(path))
                {
                    writer.Write(json);
                }
            }
        }
    }
}
