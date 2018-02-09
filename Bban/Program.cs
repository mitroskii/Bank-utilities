using System;

namespace Bban
{
    class Program
    {
        static void Main(string[] args)
        {
            string machineFormat = BankUtil.CorrectNumber("227720-35988");
            Console.WriteLine(BankUtil.isValidAccount(machineFormat));
            Console.ReadKey();
        }
    }
}
//Oman pankkinumeron tarkistus
//FI23 5482 3720 0153 38
//     2121 2121 2121 2
//    1+0+4+1+6+2+6+7+4+0+0+1+1+0+3+6=50-42=8