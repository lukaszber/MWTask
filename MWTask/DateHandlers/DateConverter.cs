using System;
using MWTask.Interafes;

namespace MWTask.DateHandlers
{
    public class DateConverter : IDateConverter
    {
        public string GetDateRange(string first, string second)
        {
            var firstDate = DateTime.ParseExact(first, "dd.MM.yyyy", null);

            var secondDate = DateTime.ParseExact(second, "dd.MM.yyyy", null);

            if (firstDate.Date > secondDate.Date)
                (firstDate, secondDate) = (secondDate, firstDate);

            if (firstDate.Year != secondDate.Year)
                return $"{firstDate:dd.MM.yyyy}-{secondDate:dd.MM.yyyy}";


            if (firstDate.Month != secondDate.Month)
            {
                return $"{firstDate:dd.MM}-{secondDate:dd.MM.yyyy}";
            }

            return $"{firstDate:dd}-{secondDate:dd.MM.yyyy}";
        }
    }
}
