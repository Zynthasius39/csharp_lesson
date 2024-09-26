using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments
{
    internal class PrimeNumber
    {
        public static void Run()
        {
            START:
            Console.WriteLine("Enter number range [from, to]: ");
            UInt64 numFrom, numTo;
            try
            {
                numFrom = Convert.ToUInt64(Console.ReadLine());
                numTo = Convert.ToUInt64(Console.ReadLine());
            } catch
            {
                Console.WriteLine("Enter valid number range! [0 - 18,446,744,073,709,551,615]");
                goto START;
            }
            if (numFrom > numTo)
            {
                UInt64 Temp = numFrom;
                numFrom = numTo;
                numTo = Temp;
            }
            for (; numFrom <= numTo; numFrom++)
                if (IsPrime(numFrom)) Console.Write(numFrom.ToString() + " ");
        }

        public static Boolean IsPrime(UInt64 num)
        {
            if (num == 0 || num == 1) return false;
            for (UInt64 i = 2; i <= num / 2; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }
    }
}
