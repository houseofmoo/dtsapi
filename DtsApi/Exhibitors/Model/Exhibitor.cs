using System;
using System.Collections.Generic;

namespace DtsApi.Exhibitors.Model
{
    public class Exhibitor
    {
        /*
         * We're gonna need a way to move all current year booth information
         * into the previous year when user instructs action
         * 
         * We also need a way for users to set the both costs
         * what we'll do is we store the booth costs here in the database
         * then we create a service in front end
         * that service gets the costs from the backend,
         * then the service can be injected into anything that needs it
         * to calculate and display booth costs and remaining balance
         */

        public int Id { get; set; }

        public string ControlNumber { get; set; }
        public DateTime EntryDate { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }

        public Company Company { get; set; }
        public Products Product { get; set; }
        public CategoryType Category { get; set; }

        public List<DateTime> YearsAttended { get; set; }

        public bool Hlta { get; set; }
        public bool Hra { get; set; }
        public RequiredForms RequiredForms { get; set; }

        public List<BoothByYear> Booths;
        public List<PaymentByYear> Payments { get; set; }
        public string BoothNotes;

        public bool IsAttending { get; set; }
        public string SpecialRequests { get; set; }
        public string Notes { get; set; }
        public string WorkOrders { get; set; }

        public Exhibitor()
        {
            this.Company = new Company();
            this.Product = new Products();
            this.YearsAttended = new List<DateTime>();
            this.RequiredForms = new RequiredForms();
            this.Booths = new List<BoothByYear>();
            this.Payments = new List<PaymentByYear>();
        }
    }
}
