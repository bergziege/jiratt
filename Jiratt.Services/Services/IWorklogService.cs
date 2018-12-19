using System;
using System.Threading.Tasks;
using Atlassian.Jira;

namespace Jiratt.Services.Services {
    public interface IWorklogService {
        Task AddTimeToWorklog(Issue issue, TimeSpan timeToAdd);
    }
}