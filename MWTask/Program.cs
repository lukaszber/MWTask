using System;
using MWTask.DateHandlers;
using MWTask.Interafes;

namespace MWTask
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException("Invalid number or arguments. Expected two.");
            }

            IDateConverter dateConverter = new DateConverter();
            try
            {
                Console.WriteLine(dateConverter.GetDateRange(args[0], args[1]));
            }
            catch (FormatException)
            {
                Console.WriteLine("Date time format not supported");
                //throw
            }

            Console.ReadLine();
        }
    }
}
