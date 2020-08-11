// <copyright file="FraudRadar.cs" company="Payvision">
// Copyright (c) Payvision. All rights reserved.
// </copyright>

namespace Refactoring.FraudDetection
{
    using Refactoring.FraudDetection.Common;
    using Refactoring.FraudDetection.Models;
    using Refactoring.FraudDetection.Services;
    using System;
    using System.Collections.Generic;

    public class FraudRadar: IFraudRadar
    {
        public IEnumerable<FraudResult> Check(string fileName)
        {
            var lines = FilesHandler.GetLinesFromFile(fileName);

            var orderService = new OrdersService();
            var orders = orderService.GetOrdersFromLines(lines);

            orderService.NormalizeOrders(orders);

            var fraudResults = orderService.CheckFraud(orders);
            return fraudResults;
        }

       

    }
}