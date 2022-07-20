namespace Utils.Extensions
{
    using TimeZoneConverter;
    
    public static class DateTimeExtensions
    {
        public static DateTime StartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, DateTimeKind.Unspecified);
        }

        public static DateTime ToBritishDateTimeV1(this DateTime _)
        {
            var info = TimeZoneInfo.GetSystemTimeZones().Any(x => x.Id == "GMT Standard Time") ?
                        TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time") :
                        TimeZoneInfo.FindSystemTimeZoneById("Europe/London");

            return DateTime.UtcNow.AddTicks(info.GetUtcOffset(DateTime.UtcNow).Ticks);
        }

        public static DateTime ToBritishDateTimeV2(this DateTime _)
        {
            if (IsDaylightSavingTime())
            {
                return DateTime.UtcNow.AddHours(1);
            }

            return DateTime.UtcNow;
        }

        private static bool IsDaylightSavingTime()
        {
            var ukTimeZone = TZConvert.GetTimeZoneInfo("GMT Standard Time");
            return ukTimeZone.IsDaylightSavingTime(DateTime.UtcNow);
        }
    }
}
