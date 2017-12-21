using System;

namespace FreelanceSite.Web.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToAppropriateTime(this DateTime date)
        {
            DateTime startTime = date;

            DateTime endTime = DateTime.Now;

            TimeSpan span = endTime.Subtract(startTime);

            string returnTime = "now";

            if(span.Minutes > 5 && span.Minutes < 60 && span.Hours < 1)
            {
                returnTime = $"{span.Minutes} minutes ago";
            }
            else if(span.Hours >= 1 && span.Days < 1)
            {

                returnTime = span.Hours == 1 ? $"{span.Hours} hour ago" : $"{span.Hours} hours ago";
            }
            else if (span.Days >= 1)
            {
                returnTime = span.Days == 1 ? $"{span.Days} day ago" : $"{span.Days} days ago";
            }

            return returnTime;
        }
    }
}
