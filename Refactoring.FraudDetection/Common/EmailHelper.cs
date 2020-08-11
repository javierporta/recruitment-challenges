using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.FraudDetection.Common
{
    public class EmailHelper
    {
        const char AT_CHAR = '@';
        public static string RemoveStringsFromEmail(string email, string[] stringsToRemove)
        {
            var splittedEmail = email.Split(new char[] { AT_CHAR }, StringSplitOptions.RemoveEmptyEntries);
            var mailbox = splittedEmail[0];
            var domain = splittedEmail[1];

            foreach (var stringToRemove in stringsToRemove)
            {
                mailbox = mailbox.Replace(stringToRemove, string.Empty);
            }

            var result = string.Join(AT_CHAR, new string[] { mailbox, domain });
            return result;
        }

        public static string RemoveSubstringAfterDelimiterFromEmail(string email, string delimiter)
        {
            var splittedEmail = email.Split(new char[] { AT_CHAR }, StringSplitOptions.RemoveEmptyEntries);

            var mailbox = splittedEmail[0];
            var domain = splittedEmail[1];

            var atIndex = mailbox.IndexOf(delimiter, StringComparison.Ordinal);

            if (atIndex >= 0)
            {
                //Remove all after first occurence of the delimiter
                mailbox = mailbox.Remove(atIndex);
            }

            var result = string.Join(AT_CHAR, new string[] { mailbox, domain });
            return result;
        }
    }
}
