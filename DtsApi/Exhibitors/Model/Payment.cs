using System;

namespace DtsApi.Exhibitors.Model
{
    public class Payment
    {
        public DateTime Date { get; set; }
        public decimal Ammount { get; set; }
        public string CheckNumber { get; set; }
    }
}
