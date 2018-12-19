using System;
using Jiratt.Services.Services;
using Jiratt.Services.Services.Impl;
using NUnit.Framework;

namespace Jiratt.Services.Test.Services {
    [TestFixture]
    public class TimeSpanServiceTest {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        [TestCase(0,0,0,0, ExpectedResult = "0d 0h 0m")]
        [TestCase(1,2,3,0, ExpectedResult = "1d 2h 3m")]
        public string TestGetFormatedJiraTime(int days, int hours, int minutes, int seconds) {

            // Given: 
            ITimeSpanService timeSpanService = new TimeSpanService();

            // When: 
            return timeSpanService.GetJiraFormattedTimeSpanValue(new TimeSpan(days, hours, minutes, seconds));

            // Then: 
        }
    }
}