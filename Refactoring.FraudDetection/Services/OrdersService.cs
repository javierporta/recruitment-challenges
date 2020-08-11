using Refactoring.FraudDetection.Common;
using Refactoring.FraudDetection.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Services
{
    public class OrdersService : IOrdersService
    {
        public void NormalizeOrders(List<Order> orders)
        {
            foreach (var order in orders)
            {
                NormalizeEmail(order);
                NormalizeStreet(order);
                NormalizeState(order);
            }
        }

        private static void NormalizeState(Order order)
        {
            var stateReplacer = new Dictionary<string, string>
                {
                    {"il","illinois" },
                    {"ca","california" },
                    {"ny","new york" },
                };
            order.State = StringHelper.ReplaceMultiple(order.State, stateReplacer);
        }

        private static void NormalizeStreet(Order order)
        {
            var streetReplacer = new Dictionary<string, string>
                {
                    {"st.","street" },
                    {"rd.","road" }
                };
            order.Street = StringHelper.ReplaceMultiple(order.Street, streetReplacer);
        }

        private static void NormalizeEmail(Order order)
        {
            order.Email = EmailHelper.RemoveStringsFromEmail(order.Email, new[] { "." });
            order.Email = EmailHelper.RemoveSubstringAfterDelimiterFromEmail(order.Email, "+");
        }

        public List<Order> GetOrdersFromLines(string[] lines, char delimiter = ',')
        {

            var orders = new List<Order>();
            foreach (var line in lines)
            {
                var items = line.Split(new char[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

                var order = new Order
                {
                    OrderId = IntHelper.GetIntOrDefault(items[0]),
                    DealId = IntHelper.GetIntOrDefault(items[1]),
                    Email = items[2],
                    Street = items[3],
                    City = items[4],
                    State = items[5],
                    ZipCode = items[6],
                    CreditCard = items[7]
                };

                orders.Add(order);
            }
            return orders;
        }

        public List<FraudResult> CheckFraud(List<Order> orders)
        {
            var fraudResults = new List<FraudResult>();
            for (int index = 0; index < orders.Count; index++)
            {
                var currentOrder = orders[index];
                for (int comparingIndex = index + 1; comparingIndex < orders.Count; comparingIndex++)
                {
                    var orderToCompare = orders[comparingIndex];
                    if (IsFraudulent(currentOrder, orderToCompare))
                    {
                        fraudResults.Add(new FraudResult { IsFraudulent = true, OrderId = orderToCompare.OrderId });
                    }
                }
            }
            return fraudResults;
        }

        private bool IsFraudulent(Order order, Order orderToCompare)
        {
            return HasEmailFraud(order, orderToCompare) || HasAddressFraud(order, orderToCompare);

        }

        private bool HasEmailFraud(Order order, Order orderToCompare)
        {
            return
                order.DealId == orderToCompare.DealId
                        && order.Email == orderToCompare.Email
                        && order.CreditCard != orderToCompare.CreditCard;
        }

        private bool HasAddressFraud(Order order, Order orderToCompare)
        {
            return
                order.DealId == orderToCompare.DealId
                        && order.State == orderToCompare.State
                        && order.ZipCode == orderToCompare.ZipCode
                        && order.Street == orderToCompare.Street
                        && order.City == orderToCompare.City
                        && order.CreditCard != orderToCompare.CreditCard;
        }

    }
}
