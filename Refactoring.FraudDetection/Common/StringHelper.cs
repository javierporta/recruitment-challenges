using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Common
{
    public static class StringHelper
    {
        public static string ReplaceMultiple(string stringToBeReplaced, Dictionary<string, string> replaceDictionary)
        {
            foreach (var replacePair in replaceDictionary)
            {
                stringToBeReplaced = stringToBeReplaced.Replace(replacePair.Key, replacePair.Value);
            }
            return stringToBeReplaced;
        }
    }
}
