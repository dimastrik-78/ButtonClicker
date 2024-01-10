namespace Utilities
{
    public static class TimeConversion
    {
        private const int SECONDS_IN_MINUTES = 60;
        private const int MINUTES_IN_HOURS = 60;
        private const int HOURS_IN_DAYS = 24;

        public static void Time(int time, out string firstTime, out string secondTime)
        {
            if (time >= SECONDS_IN_MINUTES)
            {
                var minutes = time / SECONDS_IN_MINUTES;

                if (minutes >= MINUTES_IN_HOURS)
                {
                    var hours = minutes / MINUTES_IN_HOURS;

                    if (hours >= HOURS_IN_DAYS)
                    {
                        var days = hours / HOURS_IN_DAYS;

                        firstTime = $"{days} Day";
                        secondTime = $"{hours % HOURS_IN_DAYS} Hours";
                    }
                    else
                    {
                        firstTime = $"{hours} Hours";
                        secondTime = $"{minutes % SECONDS_IN_MINUTES} Minutes";
                    }
                }
                else
                {
                    firstTime = $"{minutes} Minutes";
                    secondTime = $"{time % SECONDS_IN_MINUTES} Seconds";
                }
            }
            else
            {
                firstTime = "0 Minutes";
                secondTime = $"{time} Seconds";
            }
        }
    }
}