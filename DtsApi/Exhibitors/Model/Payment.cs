using System;
using System.Collections.Generic;

namespace DtsApi.Exhibitors.Model
{
    public class PaymentByYear
    {
        public DateTime Year { get; set; }
        public List<Payment> Payments { get; set; }
    }

    public class Payment
    {
        public DateTime Date { get; set; }
        public decimal Ammount { get; set; }
        public string CheckNumber { get; set; }
    }
}
