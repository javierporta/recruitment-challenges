using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int DealId { get; set; }

        private string _Email;
        public string Email { get => _Email; set => _Email = value.ToLower(); }

        private string _Street;
        public string Street { get => _Street; set => _Street = value.ToLower(); }

        private string _City;
        public string City { get => _City; set => _City = value.ToLower(); }

        private string _State;
        public string State { get => _City; set => _City = value.ToLower(); }


        public string ZipCode { get; set; }

        public string CreditCard { get; set; }
    }
}
