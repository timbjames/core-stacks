using System;
using Utils.Extensions;

namespace SimpleConsole.DateTimeExamples
{
    internal static class DateTimeRunner
    {
        public static void Run()
        {
            Console.WriteLine("DateTimeRunner Running.");

            var today = DateTime.Today;
            var startOfDay = today.StartOfDay();

            Console.WriteLine(startOfDay.TimeOfDay.TotalMilliseconds);

            var ukDate = DateTime.Now;
            
            Console.WriteLine(ukDate.ToBritishDateTimeV1());
            Console.WriteLine(ukDate.ToBritishDateTimeV2());   
        }
    }
}
