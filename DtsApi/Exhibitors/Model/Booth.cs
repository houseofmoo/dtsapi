using System;
using System.Collections.Generic;

namespace DtsApi.Exhibitors.Model
{
    public class BoothByYear
    {
        public DateTime Year { get; set; }
        public List<Booth> Booths { get; set; }
    }

    public class Booth
    {
        public BoothType BoothType { get; set; }
        public string BoothNumber { get; set; }
    }

    public enum BoothType
    {
        Booth_10x10 = 0,
        Corner_10x10 = 1,
        Booth_8x10 = 2,
        Corner_8x10 = 3,
        Custom = 4,
    }

    public class BoothRates
    {
        // indexed by BoothType
        public List<decimal> Rates { get; set; }
    }
}
