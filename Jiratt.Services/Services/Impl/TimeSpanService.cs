using System;

namespace Jiratt.Services.Services.Impl {
    public class TimeSpanService : ITimeSpanService {
        public string GetJiraFormattedTimeSpanValue(TimeSpan timeSpan) {
            return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
        }
    }
}