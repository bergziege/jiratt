using System;
using System.Threading.Tasks;
using Atlassian.Jira;

namespace Jiratt.Services.Services.Impl {
    public class WorklogService : IWorklogService {
        private readonly ITimeSpanService _timeSpanService;

        public WorklogService(ITimeSpanService timeSpanService) {
            _timeSpanService = timeSpanService;
        }

        public async Task AddTimeToWorklog(Issue issue, TimeSpan timeToAdd) {
            await issue.AddWorklogAsync(_timeSpanService.GetJiraFormattedTimeSpanValue(timeToAdd));
            await issue.SaveChangesAsync();
        }
    }
}