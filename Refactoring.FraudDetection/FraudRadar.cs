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

            //Note: It should be used with dependency injection, once service is registered in main program, 
            //      which is quite easy to do with asp.net core app, for instance
            var orderService = new OrdersService();
            var orders = orderService.GetOrdersFromLines(lines);

            orderService.NormalizeOrders(orders);

            var fraudResults = orderService.CheckFraud(orders);
            return fraudResults;
        }

       

    }
}