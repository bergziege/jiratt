using System;

namespace Jiratt.Services.Services {
    public interface ITimeSpanService {
        string GetJiraFormattedTimeSpanValue(TimeSpan timeSpan);
    }
}