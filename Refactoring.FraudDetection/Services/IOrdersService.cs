using Refactoring.FraudDetection.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Services
{
    interface IOrdersService
    {
        public void NormalizeOrders(List<Order> orders);
        public List<Order> GetOrdersFromLines(string[] lines, char delimiter = ',');
        public List<FraudResult> CheckFraud(List<Order> orders);
    }
}
