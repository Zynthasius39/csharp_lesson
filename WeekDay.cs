using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class WeekDay
    {
        public static void Run()
        {
            Console.Write("Enter a week day [1-7]: ");
            START:
            String input = Console.ReadLine();

            Int16 inputNum;
            String[] weekdays = {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };
            try
            {
                inputNum = Convert.ToInt16(input);
            }
            catch
            {
                Console.Write("Enter a valid week day [1-7]: ");
                goto START;
            }

            if (inputNum > 7 || inputNum < 1)
            {
                Console.Write("Enter a day between [1-7]: ");
                goto START;
            }
            Console.WriteLine(weekdays[inputNum - 1]);
        }
    }
}
