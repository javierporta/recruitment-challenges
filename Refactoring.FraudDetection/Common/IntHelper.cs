using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Common
{
    public static class IntHelper
    {
        public static int GetIntOrDefault(string stringToBeParsed)
        {
            int intOutputOrDefault;
            int.TryParse(stringToBeParsed, out intOutputOrDefault);
            return intOutputOrDefault;
        }
    }
}
