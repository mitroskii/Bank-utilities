using System;
using System.Collections.Generic;
using System.Text;

namespace Bban
{
    class BankUtil
    {
        public static string CorrectNumber(string accountNumber)
        {
            accountNumber = accountNumber.Replace("-", "").Replace(" ", "");
            return accountNumber;
        }
    }
}
