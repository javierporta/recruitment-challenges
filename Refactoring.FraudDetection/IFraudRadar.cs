using Refactoring.FraudDetection.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection
{
    interface IFraudRadar
    {
        IEnumerable<FraudResult> Check(string fileName);
    }
}
